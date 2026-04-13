using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // The Singleton Pattern
    public static AudioManager Instancia;

    private AudioSource audioSource;

    [Header("Efectos de Sonido")]
    public AudioClip sonidoSalto;
    public AudioClip sonidoQuemadura;
    public AudioClip sonidoVictoria;
    public AudioClip sonidoBoton;

    void Awake()
    {
        // We ensure that only one AudioManager exists
        if (Instancia == null)
        {
            Instancia = this;
            audioSource = GetComponent<AudioSource>(); // We get the component automatically
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- GAME FUNCTIONS (Called from code) ---
    public void ReproducirSalto()
    {
        if (sonidoSalto != null) audioSource.PlayOneShot(sonidoSalto);
    }

    public void ReproducirQuemadura()
    {
        if (sonidoQuemadura != null) audioSource.PlayOneShot(sonidoQuemadura);
    }

    public void ReproducirVictoria()
    {
        if (sonidoVictoria != null) audioSource.PlayOneShot(sonidoVictoria);
    }

    // --- BUTTON FUNCTION (Called from the Inspector) ---
    public void ReproducirClick()
    {
        if (sonidoBoton != null) audioSource.PlayOneShot(sonidoBoton);
    }
}
