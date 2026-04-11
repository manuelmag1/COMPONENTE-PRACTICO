using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // ¡VITAL para cambiar de escena!

public class SeleccionPersonajes : MonoBehaviour
{
    [Header("Imágenes de la Interfaz")]
    public RawImage fotoMario;
    public RawImage fotoWario;
    public RawImage fotoPeach;
    public RawImage fotoKong;

    [Header("Colores de Estado")]
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
        // --- SELECCIÓN DE PERSONAJES ---
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

        // --- INICIAR EL JUEGO (BARRA ESPACIADORA) ---
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Opcional: Evitar que el juego empiece si nadie se ha seleccionado
            if (!juegaMario && !juegaWario && !juegaPeach && !juegaKong)
            {
                Debug.Log("¡Selecciona al menos un personaje primero!");
                return; // Corta la función aquí para no cargar la escena
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