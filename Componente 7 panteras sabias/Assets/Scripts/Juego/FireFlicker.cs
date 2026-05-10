using UnityEngine;

/// <summary>
/// Simulates a flickering fire effect by randomly modulating the intensity of a light source.
/// This creates a realistic fire/spirit flame animation without complex particle systems.
/// </summary>
public class FireFlicker : MonoBehaviour
{
    // Reference to the Light component that will flicker
    private Light fireLight;

    [Header("Flicker Settings")]
    // Minimum light intensity value for the flicker effect
    public float minIntensity = 1.5f;
    // Maximum light intensity value for the flicker effect
    public float maxIntensity = 3.0f;
    // Speed at which the light transitions between intensity values (lerp speed)
    public float flickerSpeed = 0.1f;

    void Start()
    {
        // Retrieve the Light component attached to this gameobject
        // This component will be modulated to create the flickering effect
        fireLight = GetComponent<Light>();
    }

    void Update()
    {
        // Only execute if the Light component exists
        if (fireLight != null)
        {
            // Generate a random intensity value within the min-max range
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            
            // Smoothly interpolate from current intensity to the random target intensity
            // This creates a smooth flickering motion instead of abrupt changes
            // Mathf.Lerp blends between two values based on the flickerSpeed parameter
            fireLight.intensity = Mathf.Lerp(fireLight.intensity, randomIntensity, flickerSpeed);
        }
    }
}
