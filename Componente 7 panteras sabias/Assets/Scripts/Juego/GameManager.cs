using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement; // NEW! Necessary to change scenes

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia; 

    [Header("Interface")]
    public TextMeshProUGUI textoCuentaRegresiva;
    public TextMeshProUGUI textoVictoria; 
    public GameObject panelBotonesFinales; // NEW! We drag the buttons here

    [Header("Players")]
    public GameObject[] todosLosJugadores; 
    private int jugadoresVivos = 0;

    [Header("Game State")]
    public bool juegoActivo = false;

    void Awake()
    {
        if (Instancia == null) { Instancia = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        StartCoroutine(RutinaInicioJuego());
        StartCoroutine(ContarJugadoresAlInicio());
    }

    // On startup, we count active players

    IEnumerator ContarJugadoresAlInicio()
    {
        yield return new WaitForEndOfFrame();
        
        foreach(GameObject jugador in todosLosJugadores)
        {
            if (jugador != null && jugador.activeSelf)
            {
                jugadoresVivos++;
            }
        }
    }

    IEnumerator RutinaInicioJuego()
    {
        juegoActivo = false; 
        textoCuentaRegresiva.gameObject.SetActive(true);

        textoCuentaRegresiva.text = "3";
        yield return new WaitForSeconds(1f);
        textoCuentaRegresiva.text = "2";
        yield return new WaitForSeconds(1f);
        textoCuentaRegresiva.text = "1";
        yield return new WaitForSeconds(1f);

        textoCuentaRegresiva.text = "GO!";
        juegoActivo = true; 

        yield return new WaitForSeconds(1f);
        textoCuentaRegresiva.gameObject.SetActive(false); 
    }

    public void RegistrarMuerte()
    {
        jugadoresVivos--;

        if (jugadoresVivos == 1)
        {
            DeclararGanador();
        }
        else if (jugadoresVivos <= 0) 
        {
            juegoActivo = false;
            textoVictoria.text = "TIE!";
            textoVictoria.gameObject.SetActive(true);
            
            // If there's a tie, we also show the buttons
            if (panelBotonesFinales != null) panelBotonesFinales.SetActive(true);
        }
    }

    void DeclararGanador()
    {
        juegoActivo = false; 

        GameObject[] podoboos = GameObject.FindGameObjectsWithTag("Podoboo");
        foreach(GameObject fuego in podoboos)
        {
            fuego.SetActive(false);
        }

        GameObject ganador = null;
        foreach(GameObject jugador in todosLosJugadores)
        {
            if (jugador != null && jugador.activeSelf)
            {
                InteraccionPersonaje script = jugador.GetComponent<InteraccionPersonaje>();
                if (script != null && script.yaFueGolpeado == false)
                {
                    ganador = jugador; 
                }
            }
        }

        if (ganador != null)
        {
            textoVictoria.text = ganador.name.ToUpper() + " WINS!";
            textoVictoria.gameObject.SetActive(true);
            
            // NEW! We show the rematch and quit buttons
            if (panelBotonesFinales != null) panelBotonesFinales.SetActive(true);

            Animator anim = ganador.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Victoria");
            }
        }
    }

    // --- NEW FUNCTIONS FOR THE BUTTONS! ---

    public void IrARevancha()
    {
        // Change "MainMenu" to the exact name of your menu scene.
        // The static variables will remember who was playing.
        SceneManager.LoadScene(0); 
    }

    public void SalirDelJuego()
    {
        Debug.Log("Closing the game...");
        Application.Quit(); // This will close the game when you export to .exe
    }
}