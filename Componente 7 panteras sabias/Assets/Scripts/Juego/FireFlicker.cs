using UnityEngine;

public class FireFlicker : MonoBehaviour
{
    private Light fireLight;

    [Header("Flicker Settings")]
    public float minIntensity = 1.5f; // Minimum light intensity
    public float maxIntensity = 3.0f; // Maximum light intensity
    public float flickerSpeed = 0.1f; // How fast the light flickers

    void Start()
    {
        // We get the Light component attached to this object
        fireLight = GetComponent<Light>();
    }

    void Update()
    {
        if (fireLight != null)
        {
            // We smoothly transition between random intensities to simulate real fire
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            fireLight.intensity = Mathf.Lerp(fireLight.intensity, randomIntensity, flickerSpeed);
        }
    }
}
