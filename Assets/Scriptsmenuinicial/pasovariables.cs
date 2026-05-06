using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PasoVariables : MonoBehaviour
{
    [Header("Configuración de Escenas")]
    public string nombreEscenaDestino; // Nombre de la escena a la que vamos
    public TextMeshProUGUI textoDisplayIndice; // Para mostrar el índice en la UI

    void Start()
    {
        // Al empezar la escena, leemos qué nivel se seleccionó (por defecto 0)
        int nivelSeleccionado = PlayerPrefs.GetInt("IndiceNivel", 0);
        
        if (textoDisplayIndice != null)
        {
            textoDisplayIndice.text = "Nivel Cargado: " + nivelSeleccionado;
        }
        
        Debug.Log("Iniciando escena. El nivel actual guardado es: " + nivelSeleccionado);

        /*if (nivelSeleccionado == 0) {
            // Configurar evaporador para agua (ejemplo)
            Debug.Log("Configurando máquina para Agua");
        } else if (nivelSeleccionado == 1) {
            // Configurar evaporador para alcohol (ejemplo)
            Debug.Log("Configurando máquina para Alcohol");
        }*/
    }

    /// <summary>
    /// Esta función será llamada por los botones del Canvas.
    /// </summary>
    /// <param name="indiceNivel">El número que identifica al nivel/escena</param>
    public void SeleccionarNivelYCargar(int indiceNivel)
    {
        // 1. Guardamos el índice en PlayerPrefs para que "sobreviva" al cambio de escena
        PlayerPrefs.SetInt("IndiceNivel", indiceNivel);
        PlayerPrefs.Save(); // Forzamos el guardado en disco

        Debug.Log("Botón pulsado. Guardando índice: " + indiceNivel);

        // 2. Cargamos la escena de juego/máquina
        SceneManager.LoadScene(nombreEscenaDestino);
    }
}