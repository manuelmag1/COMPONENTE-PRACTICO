using UnityEngine;
using UnityEngine.InputSystem;

public class Peach : MonoBehaviour
{
    [Header("Jump Configuration")]
    public float fuerzaSalto = 5f; // Adjust this value to jump higher or lower

    [Header("Ground Configuration")]
    [Tooltip("Distance from the character's center to the feet to detect the ground")]
    public float distanciaSuelo = 0.02f; 
    [Tooltip("Vertical offset from the character's position to start the ray, useful if the collider is not at 0")]
    public float offsetRayo = 0.5f;
    [Tooltip("The layer that represents the ground")]
    public LayerMask capaSuelo;

    private Rigidbody rb;
    private Animator anim;

    [SerializeField, Tooltip("Shows in the Inspector if the script detects the ground")]
    private bool estaEnElSuelo;

    void Start()
    {
        // We get the components attached to the object
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // We determine the ray origin, raising it slightly if the center is misaligned
        Vector3 origenRayo = transform.position + Vector3.up * offsetRayo;

        // We detect if the character is touching the ground via a downward ray
        estaEnElSuelo = Physics.Raycast(origenRayo, Vector3.down, distanciaSuelo + offsetRayo, capaSuelo);

        // We update the Animator variable to know if it's on the ground or falling/jumping
        if (anim != null)
        {
            anim.SetBool("enSuelo", estaEnElSuelo);
        }

        // We check if the M key is pressed
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            Debug.Log("M key pressed by Peach. Detects ground: " + estaEnElSuelo);

            // We only jump if we're on the ground and NOT already moving upward
            if (estaEnElSuelo && rb != null && rb.linearVelocity.y <= 0.1f)
            {
                Saltar();
            }
        }
    }

    void Saltar()
    {
        // We only jump if we have the Rigidbody component
        if (rb != null)
        {
            // We apply an upward impulse
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

                        // --- PLAY JUMP SOUND ---
            if (AudioManager.Instancia != null) 
            {
                AudioManager.Instancia.ReproducirSalto();
            }
            
            // If you want a forced animation to start instantly when pressing jump
            if (anim != null) 
            {
                anim.SetTrigger("salto");
            }
        }
        else
        {
            Debug.LogWarning("Missing adding a Rigidbody to Peach's object!");
        }
    }
}