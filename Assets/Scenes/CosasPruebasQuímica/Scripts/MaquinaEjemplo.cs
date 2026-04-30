using UnityEngine;

public class MaquinaEjemplo : MonoBehaviour
{
    public GameObject valvula1; 
    public Material mat1, mat2;
    private MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (valvula1 == null || mr == null) return;

        // Leemos la rotación en Z (Forward) que es el eje que usa Meta por defecto
        float anguloZ = valvula1.transform.localEulerAngles.z;

        // Normalizamos el ángulo para que Unity no se confunda (de 0..360 a -180..180)
        if (anguloZ > 180f) anguloZ -= 360f;

        // Si giramos la válvula 30 grados o más
        if (Mathf.Abs(anguloZ) >= 30f)
        {
            if (mr.sharedMaterial != mat1) mr.sharedMaterial = mat1;
        } 
        else
        {
            if (mr.sharedMaterial != mat2) mr.sharedMaterial = mat2;
        }
    }
}