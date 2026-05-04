using UnityEngine;
using System.Collections.Generic;

public class Menuinicialscript : MonoBehaviour
{
    [Header("Configuración de Spawn")]
    [SerializeField] private PrimitiveType[] primitiveTypes = { PrimitiveType.Cube, PrimitiveType.Sphere, PrimitiveType.Cylinder };
    [SerializeField] private Vector3 spawnPosition = new Vector3(1, 1, 2);
    [SerializeField] private Vector3 spawnRotation = new Vector3(45, 45, 0);
    [SerializeField] private Vector3 spawnScale = new Vector3(0.5f, 0.5f, 0.5f);

    private int currentIndex = -1;
    private bool hasBeenGenerated = false;
    private List<GameObject> objs = new List<GameObject>();

    // Referencia al contenedor para poder limpiarlo si fuera necesario
    private GameObject container;

    public void GenerateObjects()
    {
        // Evitamos generar los objetos más de una vez
        if (hasBeenGenerated) return;

        container = new GameObject("ObjectsContainer");
        
        for (int i = 0; i < primitiveTypes.Length; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(primitiveTypes[i]);
            obj.transform.parent = container.transform;
            obj.transform.position = spawnPosition;
            obj.transform.rotation = Quaternion.Euler(spawnRotation);
            obj.transform.localScale = spawnScale;
            
            // Los guardamos desactivados
            obj.SetActive(false);
            objs.Add(obj);
        }

        currentIndex = 0;
        if (objs.Count > 0)
        {
            objs[currentIndex].SetActive(true);
        }
        
        hasBeenGenerated = true;
    }

    // Cambiamos 'Single' por 'float' que es el estándar de Unity para Sliders
    public void RotateObj(float sliderValue)
    {
        if (!hasBeenGenerated || currentIndex < 0) return;

        // Mantenemos X y Z originales, solo rotamos Y según el Slider (0 a 1)
        float newYRotation = sliderValue * 360f;
        objs[currentIndex].transform.eulerAngles = new Vector3(spawnRotation.x, newYRotation, spawnRotation.z);
    }

    // Cambiamos 'Int32' por 'int' para que sea compatible con el evento de Dropdown
    public void ChangeObj(int index)
    {
        if (!hasBeenGenerated || index < 0 || index >= objs.Count) return;

        // Desactivamos el actual
        objs[currentIndex].SetActive(false);
        
        // Cambiamos al nuevo
        currentIndex = index;
        objs[currentIndex].SetActive(true);
    }

    public void ToggleObj(bool state)
    {
        if (!hasBeenGenerated || currentIndex < 0) return;
        
        objs[currentIndex].SetActive(state);
    }
}
