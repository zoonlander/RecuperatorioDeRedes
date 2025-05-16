using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [Tooltip("Referencia al LifePlayerManager del jugador")]
    public LifePlayerManager lifeManager;

    [Tooltip("Daño que este collider causa al recibir un impacto")]
    public int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (lifeManager != null)
            {
                lifeManager.RestarVida(damage);
            }
        }
    }
}

