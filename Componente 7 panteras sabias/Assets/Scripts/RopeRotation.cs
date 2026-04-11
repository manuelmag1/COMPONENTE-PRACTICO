using UnityEngine;
using TMPro; // Esencial para interactuar con la UI de TextMeshPro

public class RopeRotation : MonoBehaviour
{
    [Header("Configuración de la Cuerda")]
    public float velocidadGiro = 150f;

    [Header("Interfaz de Usuario")]
    public TextMeshProUGUI textoContador; // Aquí arrastraremos nuestro texto desde el inspector

    private float gradosAcumulados = 0f;
    private int vueltasCompletadas = 0;

    void Update()
    {
        // 1. Calculamos cuánto va a girar exactamente en este frame
        float giroEnEsteFrame = velocidadGiro * Time.deltaTime;

        // 2. Aplicamos la rotación (tu código original)
        transform.Rotate(Vector3.right, giroEnEsteFrame, Space.Self);

        // 3. Sumamos el giro a nuestro acumulador. 
        // Usamos Mathf.Abs por si decides poner una velocidad negativa para que gire al revés.
        gradosAcumulados += Mathf.Abs(giroEnEsteFrame);

        // 4. Si los grados acumulados llegan a 360, significa que dio una vuelta entera
        if (gradosAcumulados >= 360f)
        {
            // Restamos 360 al acumulador para empezar a contar la siguiente vuelta, 
            // conservando cualquier pequeño exceso para ser exactos.
            gradosAcumulados -= 360f; 
            
            // Sumamos 1 al contador de vueltas
            vueltasCompletadas++;

            // Actualizamos el texto en la pantalla (solo si asignaste el texto en el inspector)
            if (textoContador != null)
            {
                textoContador.text = vueltasCompletadas.ToString();
            }
        }
    }
}