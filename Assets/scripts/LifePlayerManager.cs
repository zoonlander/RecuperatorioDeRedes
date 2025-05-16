using UnityEngine;
using TMPro;

public class LifePlayerManager : MonoBehaviour
{
    [Header("Configuración de Vida")]
    public int maxVida = 100;
    private int vidaActual;

    [Header("UI de Vida")]
    public TextMeshProUGUI textoVida; // Referencia al texto que muestra la vida

    void Start()
    {
        vidaActual = maxVida;
        ActualizarTextoVida();
        Debug.Log("Vida inicial del jugador: " + vidaActual);
    }

    void Update()
    {
        // Función de prueba: daño con P, curación con G
        if (Input.GetKeyDown(KeyCode.P))
        {
            RestarVida(10);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            SumarVida(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Vida actual del jugador: " + vidaActual);
        }
    }

    public void RestarVida(int cantidad)
    {
        GlobalAudioManager.instance.PlaySFX("Damage");
        vidaActual -= cantidad;
        vidaActual = Mathf.Max(vidaActual, 0);
        Debug.Log("Vida restada: -" + cantidad + " | Vida actual: " + vidaActual);
        ActualizarTextoVida();
    }

    public void SumarVida(int cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Min(vidaActual, maxVida);
        Debug.Log("Vida aumentada: +" + cantidad + " | Vida actual: " + vidaActual);
        ActualizarTextoVida();
    }

    public int ObtenerVida()
    {
        return vidaActual;
    }

    private void ActualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vidaActual.ToString();
        }
    }

    public void MostrarTextoVida(bool mostrar)
    {
        if (textoVida != null)
            textoVida.gameObject.SetActive(mostrar);
    }
}


