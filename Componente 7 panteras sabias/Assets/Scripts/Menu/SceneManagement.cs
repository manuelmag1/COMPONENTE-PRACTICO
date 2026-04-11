using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("UI Structure")]
    public GameObject menuInicial;     
    public GameObject pantallaReglas;  
    public GameObject pantallaSeleccion; // NEW! We drag the character selection here

    void Start()
    {
        // On startup, we only show the main menu
        if (menuInicial != null) menuInicial.SetActive(true);
        if (pantallaReglas != null) pantallaReglas.SetActive(false);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(false); 
    }

    // 1. From Main Menu to Rules
    public void MostrarReglas()
    {
        if (menuInicial != null) menuInicial.SetActive(false);
        if (pantallaReglas != null) pantallaReglas.SetActive(true);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(false);
    }

    // 2. From Rules to Character Selection (FOR YOUR NEXT BUTTON)
    public void IrASeleccionPersonajes()
    {
        if (pantallaReglas != null) pantallaReglas.SetActive(false);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(true);
    }

    // 3. Button to return to the beginning from anywhere
    public void VolverAlMenuInicial()
    {
        if (pantallaReglas != null) pantallaReglas.SetActive(false);
        if (pantallaSeleccion != null) pantallaSeleccion.SetActive(false);
        if (menuInicial != null) menuInicial.SetActive(true);
    }

    // (Optional) In case you decide to put a button that jumps directly to the level
    public void EmpezarNivel()
    {
        SceneManager.LoadScene("Nivel1"); 
    }
}