using UnityEngine;
using System.Collections;

public class InteraccionPersonaje : MonoBehaviour
{
    private Animator anim;
    
    // Public so the GameManager can read if the player is burning
    public bool yaFueGolpeado = false;

    [Header("Character Specific Audio")]
    public AudioClip sonidoMuerte;   // Audio when this specific character dies
    public AudioClip sonidoVictoria; // Audio when this specific character wins
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider otro)
    {
        // We only care if the object is a Podoboo and the player hasn't been hit yet
        if (otro.CompareTag("Podoboo") && !yaFueGolpeado)
        {
            Debug.Log(gameObject.name + " was burned by the Podoboo!");
            yaFueGolpeado = true;

            // --- PLAY CHARACTER SPECIFIC DEATH SOUND ---
            // We send THIS character's death sound to the universal AudioManager
            if (AudioManager.Instancia != null && sonidoMuerte != null) 
            {
                AudioManager.Instancia.ReproducirEfectoEspecifico(sonidoMuerte);
            }

            // Notify the GameManager that this character just lost
            if (GameManager.Instancia != null) 
            {
                GameManager.Instancia.RegistrarMuerte();
            }

            StartCoroutine(SecuenciaDeEliminacion());
        }
    }

    IEnumerator SecuenciaDeEliminacion()
    {
        // Play the defeat animation
        if (anim != null)
        {
            anim.SetTrigger("CaminarFuera"); 
        }

        // Wait for the animation to finish (1.5 seconds)
        yield return new WaitForSeconds(1.5f);

        // Deactivate the character from the scene
        gameObject.SetActive(false);
    }
}