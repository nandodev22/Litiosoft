using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorNiveles : MonoBehaviour
{
    [Header("Configuración de Carga")]
    public string nombreEscenaJugable = "Escenario_Jugable";

    // Esta función la llamarás desde los botones
    public void CargarNivel(int numeroDeNivel)
    {
        // 1. Guardamos el número para que la otra escena lo lea
        PlayerPrefs.SetInt("NivelACargar", numeroDeNivel);
        PlayerPrefs.Save();

        Debug.Log("Guardando nivel: " + numeroDeNivel + ". Cargando escena...");

        // 2. Cambiamos de escena
        SceneManager.LoadScene(nombreEscenaJugable);
    }
} 
