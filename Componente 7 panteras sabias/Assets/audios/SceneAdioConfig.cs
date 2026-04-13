using UnityEngine;

public class SceneAudioConfig : MonoBehaviour
{
    public AudioClip backgroundMusic;

    void Start()
    {
        // When the scene starts, we tell the Manager to change the music
        if (AudioManager.Instancia != null && backgroundMusic != null)
        {
            AudioManager.Instancia.ChangeMusic(backgroundMusic);
        }
    }
}