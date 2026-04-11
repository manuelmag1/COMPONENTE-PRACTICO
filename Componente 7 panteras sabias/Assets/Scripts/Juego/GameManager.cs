using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement; // ¡NUEVO! Necesario para cambiar de escena

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia; 

    [Header("Interfaz")]
    public TextMeshProUGUI textoCuentaRegresiva;
    public TextMeshProUGUI textoVictoria; 
    public GameObject panelBotonesFinales; // ¡NUEVO! Aquí arrastraremos los botones

    [Header("Jugadores")]
    public GameObject[] todosLosJugadores; 
    private int jugadoresVivos = 0;

    [Header("Estado del Juego")]
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

        textoCuentaRegresiva.text = "YA!";
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
            textoVictoria.text = "EMPATE!";
            textoVictoria.gameObject.SetActive(true);
            
            // Si hay empate, también mostramos los botones
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
            
            // ¡NUEVO! Mostramos los botones de revancha y salir
            if (panelBotonesFinales != null) panelBotonesFinales.SetActive(true);

            Animator anim = ganador.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Victoria");
            }
        }
    }

    // --- ¡NUEVAS FUNCIONES PARA LOS BOTONES! ---

    public void IrARevancha()
    {
        // Cambia "MenuPrincipal" por el nombre exacto de tu escena de menú.
        // Las variables estáticas recordarán quiénes estaban jugando.
        SceneManager.LoadScene(0); 
    }

    public void SalirDelJuego()
    {
        Debug.Log("Cerrando el juego...");
        Application.Quit(); // Esto cerrará el juego cuando lo exportes a .exe
    }
}