using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PasoVariables : MonoBehaviour
{
    [Header("Configuración de Escenas")]
    public string nombreEscenaDestino;
    public TextMeshProUGUI textoDisplayIndice;

    [Header("Paneles del Menú")]
    public GameObject panelPrincipal;
    public GameObject panelCreditos;

    void Start()
    {
        // Esto solo se ejecuta si estamos en la escena jugable
        int nivelSeleccionado = PlayerPrefs.GetInt("IndiceNivel", 0);
        
        if (textoDisplayIndice != null)
        {
            textoDisplayIndice.text = "Nivel Cargado: " + nivelSeleccionado;
        }
    }

    public void SeleccionarNivelYCargar(int indiceNivel)
    {
        PlayerPrefs.SetInt("IndiceNivel", indiceNivel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(nombreEscenaDestino);
    }

    public void MostrarCreditos()
    {
        if (panelPrincipal != null)
        {
            panelPrincipal.SetActive(false);
        }

        if (panelCreditos != null)
        {
            panelCreditos.SetActive(true);
        }
    }

    public void VolverAlMenu()
    {
        Debug.Log("Intentando volver al menú..."); // Esto te dirá en la consola si el botón se pulsa
        if(panelPrincipal != null) panelPrincipal.SetActive(true);
        if(panelCreditos != null) panelCreditos.SetActive(false);
    }
}