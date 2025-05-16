using UnityEngine;

public class MediKitAnimation : MonoBehaviour
{
    [Header("Rotaci�n")]
    public float minRotationSpeed = 30f;
    public float maxRotationSpeed = 90f;
    public float rotationOscillationSpeed = 1f;
    public Vector3 rotationAxis = Vector3.up;

    [Header("Flotaci�n vertical")]
    public float floatHeight = 0.25f;            // Cu�nto sube y baja en Y
    public float floatSpeed = 1f;                // Velocidad de la oscilaci�n
    private Vector3 initialPosition;

    private float rotationTimer;
    private float floatTimer;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Rotaci�n oscilante suave
        rotationTimer += Time.deltaTime;
        float rotCurve = (Mathf.Sin(rotationTimer * rotationOscillationSpeed * Mathf.PI * 2f) + 1f) / 2f;
        float currentRotationSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, rotCurve);
        transform.Rotate(rotationAxis * currentRotationSpeed * Time.deltaTime);

        // Movimiento vertical interpolado
        floatTimer += Time.deltaTime;
        float yOffset = Mathf.Sin(floatTimer * floatSpeed * Mathf.PI * 2f) * floatHeight;
        Vector3 newPosition = new Vector3(initialPosition.x, initialPosition.y + yOffset, initialPosition.z);
        transform.position = newPosition;
    }
}


