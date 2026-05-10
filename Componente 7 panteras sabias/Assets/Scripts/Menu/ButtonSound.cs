using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    void Start()
    {
        // We get the Button component and add a listener via code
        // This ensures it always finds the current AudioManager instance
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(PlaySound);
        }
    }

    void PlaySound()
    {
        // We call the static instance directly
        if (AudioManager.Instancia != null)
        {
            AudioManager.Instancia.ReproducirClick();
        }
    }
}