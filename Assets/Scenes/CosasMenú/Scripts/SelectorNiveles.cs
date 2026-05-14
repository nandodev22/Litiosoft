using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorNiveles : MonoBehaviour
{
    [Tooltip("Escribe el nombre exacto de la escena a la que quieres ir")]
    public string nombreEscenaJugable = "Escenario_Jugable";

    public void IrAlNivel(int idNivel)
    {
        // 1. Guardamos el valor en la 'nube' local del juego
        PlayerPrefs.SetInt("NivelSeleccionado", idNivel);
        PlayerPrefs.Save(); // Forzamos el guardado

        Debug.Log("Cambiando a escena: " + nombreEscenaJugable + " con el nivel ID: " + idNivel);

        // 2. Cargamos la escena de juego
        SceneManager.LoadScene(nombreEscenaJugable);
    }
} 
