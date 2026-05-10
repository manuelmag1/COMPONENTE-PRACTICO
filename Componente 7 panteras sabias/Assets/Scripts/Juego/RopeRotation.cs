using UnityEngine;
using TMPro;

/// <summary>
/// Manages the rotation of the spinning rope obstacle and controls Podoboo (enemy) activation.
/// The rope spins with increasing speed, and switches which Podoboos are active based on rotation count.
/// At 10 complete rotations, the yellow (faster) Podoboos activate while blue ones deactivate.
/// </summary>
public class RopeRotation : MonoBehaviour
{
    [Header("Rope Configuration")]
    // Normal rotation speed in degrees per second (base difficulty)
    public float velocidadNormal = 150f;
    // Increased rotation speed triggered after certain rotation counts
    public float velocidadRapida = 300f;
    // The current active rotation speed (changes dynamically during gameplay)
    private float velocidadActual;

    [Header("User Interface")]
    // Text display showing the current number of completed rotations (score/difficulty indicator)
    public TextMeshProUGUI textoContador;

    [Header("Podoboo Objects")]
    [Tooltip("Drag all yellow podoboos here")]
    // Yellow Podoboos (faster, more dangerous) - activated at 10 rotations
    public GameObject[] podoboosAmarillos; 
    
    [Tooltip("Drag all blue podoboos here")]
    // Blue Podoboos (slower, easier) - active at game start, deactivated at 10 rotations
    public GameObject[] podoboosAzules;

    // Accumulates rotation degrees to detect when a full 360° rotation is completed
    private float gradosAcumulados = 0f;
    // Counter for the number of complete 360° rotations the rope has made
    private int vueltasCompletadas = 0;
    // Flag to ensure the Podoboo color swap happens only once at 10 rotations (prevents repetition)
    private bool yaCambioColor = false;

    void Start()
    {
        // Initialize rope speed to normal difficulty level
        velocidadActual = velocidadNormal;
        
        // Set initial Podoboo state: blue ones active, yellow ones inactive
        // This ensures the game starts with easier enemies before difficulty increases
        ActivateSpecificPodoboos(podoboosAzules, true);
        ActivateSpecificPodoboos(podoboosAmarillos, false);
    }

    void Update()
    {
        // GAME STATE CHECK: Stop rope rotation if the game is paused or over
        if (GameManager.Instancia != null && !GameManager.Instancia.juegoActivo) return;
        
        // --- STEP 1: CALCULATE AND APPLY ROPE ROTATION ---
        // Calculate rotation angle for this frame (degrees = speed × time)
        float rotationThisFrame = velocidadActual * Time.deltaTime;
        // Apply rotation around the local X axis (horizontal spin)
        transform.Rotate(Vector3.right, rotationThisFrame, Space.Self);
        // Accumulate total rotation to detect when a full 360° rotation is completed
        gradosAcumulados += Mathf.Abs(rotationThisFrame);

        // --- STEP 2: DETECT COMPLETED ROTATIONS (360°) ---
        if (gradosAcumulados >= 360f)
        {
            // Reset accumulated degrees counter for next rotation
            gradosAcumulados -= 360f; 
            // Increment the rotation counter
            vueltasCompletadas++;

            // Update the visual counter on the UI
            if (textoContador != null)
            {
                textoContador.text = vueltasCompletadas.ToString();
            }

            // --- STEP 3: PROGRESSIVE DIFFICULTY INCREASE ---
            // Increase rope speed every 6 rotations (creates escalating challenge)
            if (vueltasCompletadas > 0 && vueltasCompletadas % 6 == 0)
            {
                velocidadActual += 5f;
            }

            // --- STEP 4: ENEMY DIFFICULTY SWAP AT 10 ROTATIONS ---
            // Switch from blue (slower) Podoboos to yellow (faster) ones
            // This increases game difficulty significantly at the midpoint
            if (vueltasCompletadas == 10 && !yaCambioColor)
            {
                // Deactivate blue Podoboos
                ActivateSpecificPodoboos(podoboosAzules, false);
                // Activate yellow (faster) Podoboos
                ActivateSpecificPodoboos(podoboosAmarillos, true);
                // Set flag to prevent this swap from occurring again
                yaCambioColor = true;
            }
        }
    }

    /// <summary>
    /// Enables or disables a group of Podoboo (enemy) gameobjects.
    /// Used to switch between blue and yellow enemy sets based on game progression.
    /// </summary>
    /// <param name="group">Array of Podoboo gameobjects to modify</param>
    /// <param name="activeState">True to activate objects, false to deactivate them</param>
    private void ActivateSpecificPodoboos(GameObject[] group, bool activeState)
    {
        // Iterate through each Podoboo in the group
        foreach (GameObject poseboo in group)
        {
            // Safety check: only modify objects that exist
            if (poseboo != null)
            {
                // Set the active state (visible and functional or hidden and disabled)
                poseboo.SetActive(activeState);
            }
        }
    }
}