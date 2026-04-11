using UnityEngine;
using UnityEngine.InputSystem;

public class Mario : MonoBehaviour
{
    [Header("Configuraci�n de Salto")]
    public float fuerzaSalto = 5f; // Ajusta este valor para saltar m�s alto o m�s bajo

    [Header("Configuraci�n de Suelo")]
    [Tooltip("Distancia desde el centro del personaje hasta los pies para detectar el suelo")]
    public float distanciaSuelo = 0.02f; 
    [Tooltip("Desplazamiento vertical desde la posici�n del personaje para iniciar el rayo, �til si el collider no est� en 0")]
    public float offsetRayo = 0.5f;
    [Tooltip("La capa (Layer) que representa el suelo")]
    public LayerMask capaSuelo;

    private Rigidbody rb;
    private Animator anim;

    [SerializeField, Tooltip("Muestra en el Inspector si el script detecta el suelo")]
    private bool estaEnElSuelo;

    void Start()
    {
        // Obtenemos los componentes adjuntos al objeto
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Determinamos el origen del rayo, elev�ndolo ligeramente si el centro est� desalineado
        Vector3 origenRayo = transform.position + Vector3.up * offsetRayo;

        // Detectamos si el personaje est� tocando el suelo mediante un rayo hacia abajo
        estaEnElSuelo = Physics.Raycast(origenRayo, Vector3.down, distanciaSuelo + offsetRayo, capaSuelo);

        // Actualizamos la variable del Animator para saber si est� en el suelo o cayendo/saltando
        if (anim != null)
        {
            anim.SetBool("enSuelo", estaEnElSuelo);
        }

        // Comprobamos si se presiona la tecla A
        if (Keyboard.current != null && Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("Tecla A presionada por Mario. Detecta suelo: " + estaEnElSuelo);

            // Solo saltamos si estamos en el suelo y NO estamos ya movi�ndonos hacia arriba
            if (estaEnElSuelo && rb != null && rb.linearVelocity.y <= 0.1f)
            {
                Saltar();
            }
        }
    }

    void Saltar()
    {
        // Solo saltamos si tenemos el componente Rigidbody
        if (rb != null)
        {
            // Aplicamos un impulso hacia arriba
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

            // Si quieres que inicie una animaci�n forzada al instante al presionar saltar
            if (anim != null) 
            {
                anim.SetTrigger("salto");
            }
        }
        else
        {
            Debug.LogWarning("�Falta a�adir un Rigidbody al objeto de Mario!");
        }
    }
}
