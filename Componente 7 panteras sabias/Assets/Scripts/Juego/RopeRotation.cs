using UnityEngine;
using TMPro;

public class RopeRotation : MonoBehaviour
{
    [Header("Configuración de la Cuerda")]
    public float velocidadNormal = 150f;
    public float velocidadRapida = 300f; // Ajusta esta velocidad en el inspector
    private float velocidadActual;

    [Header("Interfaz de Usuario")]
    public TextMeshProUGUI textoContador;

    [Header("Objetos Podoboo")]
    [Tooltip("Arrastra aquí todos los podoboos amarillos")]
    public GameObject[] podoboosAmarillos; 
    
    [Tooltip("Arrastra aquí todos los podoboos azules")]
    public GameObject[] podoboosAzules;

    private float gradosAcumulados = 0f;
    private int vueltasCompletadas = 0;
    private bool yaCambioColor = false;

    void Start()
    {
        // Iniciamos con la velocidad normal
        velocidadActual = velocidadNormal;
        
        // Nos aseguramos de que al darle Play, los azules estén encendidos y los amarillos apagados
        CambiarEstadoPodoboos(podoboosAzules, true);
        CambiarEstadoPodoboos(podoboosAmarillos, false);
    }

    void Update()
    {

        // ¡NUEVA LÍNEA! Si el juego no está activo, detenemos la función aquí mismo.
        if (GameManager.Instancia != null && !GameManager.Instancia.juegoActivo) return;
        
        // 1. Calculamos el giro usando la velocidadActual (que cambiará más adelante)
        float giroEnEsteFrame = velocidadActual * Time.deltaTime;
        transform.Rotate(Vector3.right, giroEnEsteFrame, Space.Self);
        gradosAcumulados += Mathf.Abs(giroEnEsteFrame);

        // 2. Comprobamos si dio una vuelta
        if (gradosAcumulados >= 360f)
        {
            gradosAcumulados -= 360f; 
            vueltasCompletadas++;

            if (textoContador != null)
            {
                textoContador.text = vueltasCompletadas.ToString();
            }

            // 3. Lógica de aumento gradual de velocidad cada 5-7 vueltas (+5 puntos)
            if (vueltasCompletadas > 0 && vueltasCompletadas % 6 == 0)
            {
                velocidadActual += 5f;
            }

            // 4. Lógica de cambio de color al llegar a 10 vueltas (azul a amarillo)
            if (vueltasCompletadas == 10 && !yaCambioColor)
            {
                CambiarEstadoPodoboos(podoboosAzules, false);   // Apagamos azules
                CambiarEstadoPodoboos(podoboosAmarillos, true); // Encendemos amarillos
                yaCambioColor = true; // Evitamos que este código se repita en la vuelta 11, 12, etc.
            }
        }
    }

    // Función auxiliar para encender o apagar grupos enteros de objetos
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