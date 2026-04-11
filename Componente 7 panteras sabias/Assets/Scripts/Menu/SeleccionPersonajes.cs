using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // VITAL to change scenes!

public class SeleccionPersonajes : MonoBehaviour
{
    [Header("Interface Images")]
    public RawImage fotoMario;
    public RawImage fotoWario;
    public RawImage fotoPeach;
    public RawImage fotoKong;

    [Header("Status Colors")]
    public Color colorDisponible = Color.white;
    public Color colorConfirmado = Color.gray; 

    public static bool juegaMario = false;
    public static bool juegaWario = false;
    public static bool juegaPeach = false;
    public static bool juegaKong = false;

    void Start()
    {
        juegaMario = false; juegaWario = false; juegaPeach = false; juegaKong = false;
        ActualizarVisuales();
    }

    void Update()
    {
        // --- CHARACTER SELECTION ---
        if (Keyboard.current != null && Keyboard.current.aKey.wasPressedThisFrame)
        {
            juegaMario = !juegaMario; 
            fotoMario.color = juegaMario ? colorConfirmado : colorDisponible;
        }

        if (Keyboard.current != null && Keyboard.current.vKey.wasPressedThisFrame)
        {
            juegaWario = !juegaWario;
            fotoWario.color = juegaWario ? colorConfirmado : colorDisponible;
        }

        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            juegaPeach = !juegaPeach;
            fotoPeach.color = juegaPeach ? colorConfirmado : colorDisponible;
        }

        if (Keyboard.current != null && Keyboard.current.lKey.wasPressedThisFrame)
        {
            juegaKong = !juegaKong;
            fotoKong.color = juegaKong ? colorConfirmado : colorDisponible;
        }

        // --- START THE GAME (SPACEBAR) ---
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Optional: Prevent the game from starting if no one has been selected
            if (!juegaMario && !juegaWario && !juegaPeach && !juegaKong)
            {
                Debug.Log("Select at least one character first!");
                return; // Cut the function here to not load the scene
            }

            SceneManager.LoadScene("Juego"); 
        }
    }

    void ActualizarVisuales()
    {
        fotoMario.color = colorDisponible;
        fotoWario.color = colorDisponible;
        fotoPeach.color = colorDisponible;
        fotoKong.color = colorDisponible;
    }
}