using UnityEngine;
using System.Collections;

public class InteraccionPersonaje : MonoBehaviour
{
    private Animator anim;
    public bool yaFueGolpeado = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        // (Optional) If you put the code here to turn off those who don't play from the menu, leave it here:
        // if (gameObject.name == "Mario" && !SeleccionPersonajes.juegaMario) gameObject.SetActive(false);
        // if (gameObject.name == "Wario" && !SeleccionPersonajes.juegaWario) gameObject.SetActive(false);
        // if (gameObject.name == "Peach" && !SeleccionPersonajes.juegaPeach) gameObject.SetActive(false);
        // if (gameObject.name == "Kong" && !SeleccionPersonajes.juegaKong) gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Podoboo") && !yaFueGolpeado)
        {
            // We use gameObject.name to know exactly who got burned
            Debug.Log("" + gameObject.name + " was burned by the Podoboo!");
            
            yaFueGolpeado = true;

            // --- THIS IS THE NEW VITAL LINE! ---
            // We notify the game brain that this character just lost
            if (GameManager.Instancia != null) 
            {
                GameManager.Instancia.RegistrarMuerte();
            }
            // -------- ----

            StartCoroutine(SecuenciaDeEliminacion());
        }
    }

    IEnumerator SecuenciaDeEliminacion()
    {
        if (anim != null)
        {
            anim.SetTrigger("CaminarFuera"); 
        }

        // We wait for the animation to finish
        yield return new WaitForSeconds(1.5f);

        // We deactivate the character
        gameObject.SetActive(false);
    }
}