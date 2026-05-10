using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instancia;

    // We use two separate sources: one for music, one for effects
    private AudioSource sfxSource;
    private AudioSource musicSource;

    [Header("Shared Sounds")]
    public AudioClip sonidoSalto;
    public AudioClip sonidoBoton;

    void Awake()
    {
        // Singleton pattern with persistence
        if (Instancia == null)
        {
            Instancia = this;
            
            // We create and configure the AudioSources via code
            sfxSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();
            
            musicSource.loop = true; // Music should always loop
            
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- MUSIC CONTROL ---
    public void ChangeMusic(AudioClip newMusic)
    {
        // If the music is already playing, we don't restart it
        if (musicSource.clip == newMusic) return;

        musicSource.Stop();
        musicSource.clip = newMusic;
        musicSource.Play();
    }

    // --- SFX CONTROL ---
    public void ReproducirSalto()
    {
        if (sonidoSalto != null) sfxSource.PlayOneShot(sonidoSalto);
    }

    public void ReproducirClick()
    {
        if (sonidoBoton != null) sfxSource.PlayOneShot(sonidoBoton);
    }

    public void ReproducirEfectoEspecifico(AudioClip clip)
    {
        if (clip != null) sfxSource.PlayOneShot(clip);
    }
}