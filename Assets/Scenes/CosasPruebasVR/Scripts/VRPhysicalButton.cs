using UnityEngine;
using UnityEngine.Events;

public class VRPhysicalButton : MonoBehaviour
{
    public Vector3 pushDirection = new Vector3(0, -0.05f, 0);
    public float smoothSpeed = 10f;
    
    public bool isToggled = false;
    public UnityEvent OnActivated;
    public UnityEvent OnDeactivated;

    private Vector3 _initialLocalPos;
    private Vector3 _targetLocalPos;
    private bool _canPress = true; 

    void Start()
    {
        _initialLocalPos = transform.localPosition;
        _targetLocalPos = isToggled ? _initialLocalPos + pushDirection : _initialLocalPos;
    }

    // Se activa cuando el mando del simulador entra en el botón
    private void OnTriggerEnter(Collider other)
    {
        if (_canPress)
        {
            isToggled = !isToggled;
            _targetLocalPos = isToggled ? _initialLocalPos + pushDirection : _initialLocalPos;

            if (isToggled) OnActivated.Invoke();
            else OnDeactivated.Invoke();

            Debug.Log("META SIMULATOR: Botón presionado por " + other.name);
            
            _canPress = false; // Bloqueo para evitar que vibre el botón
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canPress = true; // Permite pulsar de nuevo al sacar el mando
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetLocalPos, Time.deltaTime * smoothSpeed);
    }
}