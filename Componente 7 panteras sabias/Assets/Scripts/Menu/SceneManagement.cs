using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Estructura de la Interfaz")]
    public GameObject menuInicial;     
    public GameObject pantallaReglas;  
    public GameObject pantallaSeleccion; // ¡NUEVA! Aquí arrastraremos la selección de personajes

    void Start()
    {
        // Al iniciar, solo mostramos el menú principal
        if (menuInicial != null) menuInicial.SetActive(true);
        if (pantallaReglas != null) pantallaReglas.SetActive(false);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(false); 
    }

    // 1. Del Menú Inicial a las Reglas
    public void MostrarReglas()
    {
        if (menuInicial != null) menuInicial.SetActive(false);
        if (pantallaReglas != null) pantallaReglas.SetActive(true);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(false);
    }

    // 2. De las Reglas a la Selección de Personajes (PARA TU BOTÓN SIGUIENTE)
    public void IrASeleccionPersonajes()
    {
        if (pantallaReglas != null) pantallaReglas.SetActive(false);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(true);
    }

    // 3. Botón para regresar al principio desde cualquier lado
    public void VolverAlMenuInicial()
    {
        if (pantallaReglas != null) pantallaReglas.SetActive(false);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(false);
        if (menuInicial != null) menuInicial.SetActive(true);
    }

    // (Opcional) Por si decides poner un botón que salte directamente al nivel
    public void EmpezarNivel()
    {
        SceneManager.LoadScene("Nivel1"); 
    }
}