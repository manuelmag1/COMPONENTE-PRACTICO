using UnityEngine;

public class RopeRotation : MonoBehaviour
{
    [Header("Configuración de la Cuerda")]
    public float velocidadGiro = 150f;

    void Update()
    {
        // Vector3.right hace que gire sobre el eje X. 
        // Cambia Space.World a Space.Self para que use la orientación del propio pivote.
        transform.Rotate(Vector3.right, velocidadGiro * Time.deltaTime, Space.Self);
    }
}