using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;

    private float timer;
    private Rigidbody rb;
    private Vector3 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        timer = 0f;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            Desactivar();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Solo desactiva si la colisión es con "Player" o "Mundo"
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("mundo"))
        {
            Desactivar();
        }
    }

    void Desactivar()
    {
        gameObject.SetActive(false);
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    // Método que se llama luego de SetDirection
    public void Activate()
    {
        rb.velocity = moveDirection * speed;
    }
}




