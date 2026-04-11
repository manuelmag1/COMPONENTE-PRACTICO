using UnityEngine;
using System.Collections;

public class InteraccionPersonaje : MonoBehaviour
{
    private Animator anim;
    private bool yaFueGolpeado = false;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter(Collider otro)
    {
        // 1. Ignoramos si los pies chocan con el propio cuerpo del personaje
        if (otro.gameObject == transform.parent.gameObject)
        {
            return; // No hacemos nada, nos salimos de la función
        }

        // 2. Ahora sí, esto nos avisará solo cuando toque ALGO MÁS (como el piso o el fuego)
        Debug.Log("¡Choque! Mis pies tocaron a: " + otro.gameObject.name + " - Etiqueta: " + otro.tag);

        if (otro.CompareTag("Podoboo") && !yaFueGolpeado)
        {
            Debug.Log("¡FUEGO DETECTADO! Ejecutando animación...");
            yaFueGolpeado = true;
            StartCoroutine(SecuenciaDeEliminacion());
        }
    }

    IEnumerator SecuenciaDeEliminacion()
    {
        if (anim != null)
        {
            anim.SetTrigger("CaminarFuera"); 
        }

        yield return new WaitForSeconds(1.5f);

        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}