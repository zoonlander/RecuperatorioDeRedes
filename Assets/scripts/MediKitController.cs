using UnityEngine;

public class MediKitController : MonoBehaviour
{
    public float tiempoRespawn = 10f;

    private MeshRenderer[] renderers;
    private HealPlayerContact[] healScripts;
    private Collider[] colliders;
    private float tiempoActual;
    private bool activo = true;

    void Start()
    {
        // Recolectar todos los componentes necesarios
        renderers = GetComponentsInChildren<MeshRenderer>(true);
        healScripts = GetComponentsInChildren<HealPlayerContact>(true);
        colliders = GetComponentsInChildren<Collider>(true);
    }

    public void Desaparecer()
    {
        foreach (var renderer in renderers)
            renderer.enabled = false;

        foreach (var script in healScripts)
            script.enabled = false;

        foreach (var col in colliders)
            col.enabled = false;

        activo = false;
        tiempoActual = tiempoRespawn;
        Debug.Log("Medikit desaparecido");
    }

    void Update()
    {
        if (!activo)
        {
            tiempoActual -= Time.deltaTime;

            if (tiempoActual <= 0f)
            {
                Reaparecer();
            }
        }
    }

    void Reaparecer()
    {
        foreach (var renderer in renderers)
            renderer.enabled = true;

        foreach (var script in healScripts)
            script.enabled = true;

        foreach (var col in colliders)
            col.enabled = true;

        activo = true;
        Debug.Log("Medikit reaparecido");
    }
}


