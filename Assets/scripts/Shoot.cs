using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Disparo")]
    public Transform shootPoint;
    public float reloadTime = 1.5f; // Tiempo de recarga
    public int magazineSize = 1;    // Balas por recarga
    private int currentAmmo;
    private bool isReloading = false;

    [Header("Sistema de balas")]
    public BulletFactory bulletFactory;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = magazineSize;
    }

    void Update()
    {
        if (isReloading) return;

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void Fire()
    {
        currentAmmo--;

        animator.SetTrigger("Shoot");

        GlobalAudioManager.instance.PlaySFX("shoot");

        if (bulletFactory != null && shootPoint != null)
        {
            bulletFactory.SpawnBullet(shootPoint.position, shootPoint.rotation, shootPoint.forward);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        GlobalAudioManager.instance.PlaySFX("reload");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineSize;
        isReloading = false;
    }

    void OnDrawGizmos()
    {
        if (shootPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(shootPoint.position, shootPoint.position + shootPoint.forward * 2f);
        }
    }
}


