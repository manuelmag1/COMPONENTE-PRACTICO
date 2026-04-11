using UnityEngine;
using System.Collections;

public class InteraccionPersonaje : MonoBehaviour
{
    private Animator anim;
    private bool yaFueGolpeado = false;

    void Start()
    {
        // Como el script ahora está en Mario, buscamos el Animator aquí mismo
        anim = GetComponent<Animator>();
    }

    // Esta función detectará automáticamente si algo toca la cápsula de Mario
    void OnTriggerEnter(Collider otro)
    {
        // Solo nos importa si lo que nos tocó tiene la etiqueta "Podoboo"
        if (otro.CompareTag("Podoboo") && !yaFueGolpeado)
        {
            Debug.Log("¡Mario fue quemado por el Podoboo!");
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

        // Esperamos a que termine la animación
        yield return new WaitForSeconds(1.5f);

        // Desactivamos a Mario
        gameObject.SetActive(false);
    }
}