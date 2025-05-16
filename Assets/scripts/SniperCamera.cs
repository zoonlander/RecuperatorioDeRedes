using UnityEngine;

public class SniperCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Transform cameraChild;

    public GameObject miraNumeroUno;
    public GameObject miraNumeroDos;

    public LifePlayerManager lifePlayerManager; // Referencia al script de vida

    private float normalFOV = 60f;
    private float zoomFOV = 20f;

    private Vector3 normalPosition = new Vector3(-0.0130000114f, 1.72300005f, 0.0170001984f);
    private Vector3 crouchCameraPos = new Vector3(-0.01300001f, 1.093f, 0.0170002f);
    private Vector3 proneCameraPos = new Vector3(0.03f, 0.334f, 0.676f);

    private Vector3 normalChildLocalPos = new Vector3(0.1290806f, -0.1243291f, 0.2636065f);
    private Vector3 zoomChildLocalPos = new Vector3(0.004f, -0.043f, 0.261f);

    private bool isCrouching = false;
    private bool isProne = false;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        HandleZoom();
        HandleInputToggleStates();
        HandleCameraPosition();
    }

    void HandleZoom()
    {
        bool zooming = Input.GetMouseButton(1);

        if (zooming)
        {
            mainCamera.fieldOfView = zoomFOV;
            if (cameraChild != null) cameraChild.localPosition = zoomChildLocalPos;
            if (miraNumeroUno != null) miraNumeroUno.SetActive(false);
            if (miraNumeroDos != null) miraNumeroDos.SetActive(true);
        }
        else
        {
            mainCamera.fieldOfView = normalFOV;
            if (cameraChild != null) cameraChild.localPosition = normalChildLocalPos;
            if (miraNumeroUno != null) miraNumeroUno.SetActive(true);
            if (miraNumeroDos != null) miraNumeroDos.SetActive(false);
        }

        // Ocultar o mostrar el texto de vida
        if (lifePlayerManager != null)
            lifePlayerManager.MostrarTextoVida(!zooming);
    }

    void HandleInputToggleStates()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            if (isCrouching)
                isProne = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            isProne = !isProne;
            if (isProne)
                isCrouching = false;
        }
    }

    void HandleCameraPosition()
    {
        if (isProne)
        {
            transform.localPosition = proneCameraPos;
        }
        else if (isCrouching)
        {
            transform.localPosition = crouchCameraPos;
        }
        else
        {
            transform.localPosition = normalPosition;
        }
    }
}









