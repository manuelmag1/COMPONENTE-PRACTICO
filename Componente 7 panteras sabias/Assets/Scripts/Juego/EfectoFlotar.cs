using System;
using UnityEngine;

public class EfectoFlotar : MonoBehaviour
{
    [Header("Configuración de Flotación")]
    [Tooltip("Qué tanto sube y baja el fuego (Distancia).")]
    public float amplitud = 0.1f;

    [Tooltip("Qué tan rápido hace el recorrido de subir y bajar.")]
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private float desfaseAleatorio;

    void Start()
    {
        // Guardamos la posición original donde colocaste el objeto en la escena
        posicionInicial = transform.position;

        // TRUCO PRO: Le damos un número aleatorio al inicio. 
        // Esto hace que si tienes 5 fuegos, no suban y bajen exactamente al mismo tiempo.
        desfaseAleatorio = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // Calculamos la nueva altura (Y) usando la función matemática Seno
        float nuevaY = posicionInicial.y + Mathf.Sin((Time.time * velocidad) + desfaseAleatorio) * amplitud;

        // Le aplicamos la nueva posición al objeto, dejando X y Z exactamente igual
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
    }
}