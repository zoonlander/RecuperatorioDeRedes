using UnityEngine;

public class HealPlayerContact : MonoBehaviour
{
    public int cantidadCuracion = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifePlayerManager lifeManager = other.GetComponent<LifePlayerManager>();

            if (lifeManager != null && lifeManager.ObtenerVida() < lifeManager.maxVida)
            {
                lifeManager.SumarVida(cantidadCuracion);

                // Buscar y llamar al MediKitController en el padre
                MediKitController controller = GetComponentInParent<MediKitController>();
                if (controller != null)
                {
                    controller.Desaparecer();
                }
            }
        }
    }
}


