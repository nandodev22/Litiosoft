using System;
using UnityEngine;

public class MaquinaEjemplo : MonoBehaviour
{
    public GameObject valvula1;
    public Material mat1, mat2;
    private MeshRenderer mr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mr= GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (valvula1.transform.rotation.x >= 60)
        {
            mr.material=mat1;
            Debug.Log("Mat1");
        } else
        {
            mr.material=mat2;
            Debug.Log("Mat2");
        }
    }
}
