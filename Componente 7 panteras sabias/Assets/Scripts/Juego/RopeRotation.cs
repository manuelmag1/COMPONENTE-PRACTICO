using UnityEngine;
using TMPro;

public class RopeRotation : MonoBehaviour
{
    [Header("Rope Configuration")]
    public float velocidadNormal = 150f;
    public float velocidadRapida = 300f; // Adjust this speed in the inspector
    private float velocidadActual;

    [Header("User Interface")]
    public TextMeshProUGUI textoContador;

    [Header("Podoboo Objects")]
    [Tooltip("Drag all yellow podoboos here")]
    public GameObject[] podoboosAmarillos; 
    
    [Tooltip("Drag all blue podoboos here")]
    public GameObject[] podoboosAzules;

    private float gradosAcumulados = 0f;
    private int vueltasCompletadas = 0;
    private bool yaCambioColor = false;

    void Start()
    {
        // We start with normal speed
        velocidadActual = velocidadNormal;
        
        // We make sure that when you press Play, the blue ones are on and the yellow ones are off
        CambiarEstadoPodoboos(podoboosAzules, true);
        CambiarEstadoPodoboos(podoboosAmarillos, false);
    }

    void Update()
    {

        // NEW LINE! If the game is not active, we stop the function right here.
        if (GameManager.Instancia != null && !GameManager.Instancia.juegoActivo) return;
        
        // 1. We calculate the rotation using the current speed (which will change later)
        float giroEnEsteFrame = velocidadActual * Time.deltaTime;
        transform.Rotate(Vector3.right, giroEnEsteFrame, Space.Self);
        gradosAcumulados += Mathf.Abs(giroEnEsteFrame);

        // 2. We check if it completed one rotation
        if (gradosAcumulados >= 360f)
        {
            gradosAcumulados -= 360f; 
            vueltasCompletadas++;

            if (textoContador != null)
            {
                textoContador.text = vueltasCompletadas.ToString();
            }

            // 3. Gradual speed increase logic every 5-7 rotations (+5 points)
            if (vueltasCompletadas > 0 && vueltasCompletadas % 6 == 0)
            {
                velocidadActual += 5f;
            }

            // 4. Color change logic when reaching 10 rotations (blue to yellow)
            if (vueltasCompletadas == 10 && !yaCambioColor)
            {
                CambiarEstadoPodoboos(podoboosAzules, false);   // Turn off blues
                CambiarEstadoPodoboos(podoboosAmarillos, true); // Turn on yellows
                yaCambioColor = true; // We prevent this code from repeating on rotation 11, 12, etc.
            }
        }
    }

    // Helper function to turn on or off entire groups of objects
    private void CambiarEstadoPodoboos(GameObject[] grupo, bool estado)
    {
        foreach (GameObject podoboo in grupo)
        {
            if (podoboo != null)
            {
                podoboo.SetActive(estado);
            }
        }
    }
}