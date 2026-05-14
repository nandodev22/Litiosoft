using UnityEngine;

public class ControladorPaneles : MonoBehaviour
{
    [Header("Paneles del Menú")]
    public GameObject panelPrincipal;
    public GameObject panelCreditos;

    // Función para ir a Créditos
    public void MostrarCreditos()
    {
        panelPrincipal.SetActive(false);
        panelCreditos.SetActive(true);
    }

    // Función para volver al menú
    public void MostrarPrincipal()
    {
        panelPrincipal.SetActive(true);
        panelCreditos.SetActive(false);
    }
}
