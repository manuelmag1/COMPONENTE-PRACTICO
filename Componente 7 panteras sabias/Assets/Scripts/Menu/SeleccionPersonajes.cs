using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // VITAL to change scenes!

/// <summary>
/// This class manages character selection in the menu screen.
/// Players can select multiple characters using keyboard inputs (A, V, M, L keys)
/// and start the game by pressing the spacebar.
/// </summary>
public class SeleccionPersonajes : MonoBehaviour
{
    // References to the UI RawImage components that display character portraits
    [Header("Interface Images")]
    public RawImage fotoMario;
    public RawImage fotoWario;
    public RawImage fotoPeach;
    public RawImage fotoKong;

    // Colors used to indicate character selection status
    // colorDisponible: Character is NOT selected (shown in white)
    // colorConfirmado: Character is SELECTED (shown in gray)
    [Header("Status Colors")]
    public Color colorDisponible = Color.white;
    public Color colorConfirmado = Color.gray; 

    // Static boolean flags to track which characters have been selected
    // These persist across scenes so the game manager knows which characters are active
    public static bool juegaMario = false;
    public static bool juegaWario = false;
    public static bool juegaPeach = false;
    public static bool juegaKong = false;

    // Initialization method: resets all character selections and updates the UI
    void Start()
    {
        // Clear all previous selections to ensure a clean state
        juegaMario = false; juegaWario = false; juegaPeach = false; juegaKong = false;
        // Update visual states to reflect the initial selection state
        ActualizarVisuales();
    }

    void Update()
    {
        // --- CHARACTER SELECTION INPUT HANDLING ---
        // Check for key presses and toggle character selection on/off
        // Each key corresponds to a character:
        // A = Mario, V = Wario, M = Peach, L = Kong
        
        // Toggle Mario selection with 'A' key
        if (Keyboard.current != null && Keyboard.current.aKey.wasPressedThisFrame)
        {
            juegaMario = !juegaMario; // Toggle selection state
            // Change image color to show selection status
            fotoMario.color = juegaMario ? colorConfirmado : colorDisponible;
        }

        // Toggle Wario selection with 'V' key
        if (Keyboard.current != null && Keyboard.current.vKey.wasPressedThisFrame)
        {
            juegaWario = !juegaWario;
            fotoWario.color = juegaWario ? colorConfirmado : colorDisponible;
        }

        // Toggle Peach selection with 'M' key
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            juegaPeach = !juegaPeach;
            fotoPeach.color = juegaPeach ? colorConfirmado : colorDisponible;
        }

        // Toggle Kong selection with 'L' key
        if (Keyboard.current != null && Keyboard.current.lKey.wasPressedThisFrame)
        {
            juegaKong = !juegaKong;
            fotoKong.color = juegaKong ? colorConfirmado : colorDisponible;
        }

        // --- START THE GAME (SPACEBAR) ---
        // Spacebar triggers scene loading to start the game
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Validation: Prevent the game from starting if no character has been selected
            if (!juegaMario && !juegaWario && !juegaPeach && !juegaKong)
            {
                Debug.Log("Select at least one character first!");
                return; // Exit early if validation fails
            }

            // Load the game scene to start the gameplay
            SceneManager.LoadScene("Juego"); 
        }
    }

    // Updates all character portrait colors to reflect their current selection state
    // Called during initialization to set all characters to the "available" state
    void ActualizarVisuales()
    {
        // Reset all character images to the "available" color
        fotoMario.color = colorDisponible;
        fotoWario.color = colorDisponible;
        fotoPeach.color = colorDisponible;
        fotoKong.color = colorDisponible;
    }
}