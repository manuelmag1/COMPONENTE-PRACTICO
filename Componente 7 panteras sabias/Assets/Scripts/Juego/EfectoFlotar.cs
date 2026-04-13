using System;
using UnityEngine;

public class EfectoFlotar : MonoBehaviour
{
    [Header("Floating Configuration")]
    [Tooltip("How much the fire goes up and down (Distance).")]
    public float amplitud = 0.1f;

    [Tooltip("How fast it moves up and down.")]
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private float desfaseAleatorio;

    void Start()
    {
        // We store the original position where you placed the object in the scene
        posicionInicial = transform.position;

        // PRO TIP: We give it a random number at the start. 
        // This makes it so if you have 5 fires, they don't go up and down at exactly the same time.
        desfaseAleatorio = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // We calculate the new height (Y) using the mathematical function Sine
        float nuevaY = posicionInicial.y + Mathf.Sin((Time.time * velocidad) + desfaseAleatorio) * amplitud;

        // We apply the new position to the object, leaving X and Z exactly the same
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
    }
}