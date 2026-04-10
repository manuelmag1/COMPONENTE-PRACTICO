using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SonidosJugador : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip saltoSonido;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // Reproduce el sonido de salto desde otros scripts
    public void PlaySalto()
    {
        if (audioSource == null) return;
        if (saltoSonido != null)
            audioSource.PlayOneShot(saltoSonido);
        else
            audioSource.Play();
    }
}
