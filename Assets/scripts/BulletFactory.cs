using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public BulletPool pool;

    public GameObject SpawnBullet(Vector3 position, Quaternion rotation, Vector3 direction)
    {
        GameObject bullet = pool.GetBullet();

        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
            bulletScript.Activate(); // Se llama después de asignar la dirección
        }

        return bullet;
    }
}



