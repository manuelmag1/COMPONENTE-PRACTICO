using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Esto es un "Singleton". Permite que cualquier otro script encuentre al GameManager fácilmente.
    public static GameManager Instancia; 

    [Header("Interfaz")]
    public TextMeshProUGUI textoCuentaRegresiva;

    [Header("Estado del Juego")]
    public bool juegoActivo = false;

    void Awake()
    {
        // Configuramos el Singleton
        if (Instancia == null) { Instancia = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        // Apenas carga la escena, empezamos la cuenta regresiva
        StartCoroutine(RutinaInicioJuego());
    }

    IEnumerator RutinaInicioJuego()
    {
        // 1. Bloqueamos el juego por si acaso
        juegoActivo = false; 
        textoCuentaRegresiva.gameObject.SetActive(true);

        // 2. Secuencia de números
        textoCuentaRegresiva.text = "3";
        yield return new WaitForSeconds(1f); // Esperamos 1 segundo

        textoCuentaRegresiva.text = "2";
        yield return new WaitForSeconds(1f);

        textoCuentaRegresiva.text = "1";
        yield return new WaitForSeconds(1f);

        // 3. ¡Empieza la acción!
        textoCuentaRegresiva.text = "YA!";
        juegoActivo = true; // Al poner esto en true, liberamos la cuerda y los controles

        // 4. Esperamos un segundo más y borramos el texto
        yield return new WaitForSeconds(1f);
        textoCuentaRegresiva.gameObject.SetActive(false); 
    }
}