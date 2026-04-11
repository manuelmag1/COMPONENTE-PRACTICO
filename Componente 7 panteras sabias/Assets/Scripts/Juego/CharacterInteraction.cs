using UnityEngine;
using System.Collections;

public class InteraccionPersonaje : MonoBehaviour
{
    private Animator anim;
    public bool yaFueGolpeado = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        // (Opcional) Si pusiste aquí el código para apagar a los que no juegan desde el menú, déjalo aquí:
        // if (gameObject.name == "Mario" && !SeleccionPersonajes.juegaMario) gameObject.SetActive(false);
        // if (gameObject.name == "Wario" && !SeleccionPersonajes.juegaWario) gameObject.SetActive(false);
        // if (gameObject.name == "Peach" && !SeleccionPersonajes.juegaPeach) gameObject.SetActive(false);
        // if (gameObject.name == "Kong" && !SeleccionPersonajes.juegaKong) gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Podoboo") && !yaFueGolpeado)
        {
            // Usamos gameObject.name para saber exactamente quién se quemó
            Debug.Log("¡" + gameObject.name + " fue quemado por el Podoboo!");
            
            yaFueGolpeado = true;

            // --- ¡ESTA ES LA LÍNEA NUEVA VITAL! ---
            // Le avisamos al cerebro del juego que este personaje acaba de perder
            if (GameManager.Instancia != null) 
            {
                GameManager.Instancia.RegistrarMuerte();
            }
            // --------------------------------------

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

        // Desactivamos al personaje
        gameObject.SetActive(false);
    }
}