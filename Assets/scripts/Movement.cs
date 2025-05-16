using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f;

    private Rigidbody rb;
    private Animator animator;

    private bool isCrouching = false;
    private bool isProne = false;
    private bool isSprinting = false;

    private GameObject colliderParado;
    private GameObject colliderSentado;
    private GameObject colliderAcostado;

    private AudioSource sprintAudio;
    private AudioSource crawlAudio;

    private bool sprintSoundPlaying = false;
    private bool crawlSoundPlaying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        animator = GetComponent<Animator>();

        foreach (Transform child in transform)
        {
            if (child.CompareTag("parado")) colliderParado = child.gameObject;
            else if (child.CompareTag("sentado")) colliderSentado = child.gameObject;
            else if (child.CompareTag("acostado")) colliderAcostado = child.gameObject;
        }

        ActivarCollider("parado");

        // Crea y configura los AudioSource para sprint y crawl
        sprintAudio = gameObject.AddComponent<AudioSource>();
        sprintAudio.clip = GetClip("sprint");
        sprintAudio.loop = true;

        crawlAudio = gameObject.AddComponent<AudioSource>();
        crawlAudio.clip = GetClip("crawl");
        crawlAudio.loop = true;
    }

    void Update()
    {
        HandleAnimationParameters();
        HandleCrouchToggle();
        HandleProneToggle();
        HandleSprint();
        HandleFootstepSounds(); // NUEVO
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float currentSpeed = moveSpeed;

        if (isProne)
            currentSpeed *= 0.5f;
        else if (isCrouching)
            currentSpeed *= 0.75f;
        else if (isSprinting)
            currentSpeed *= sprintMultiplier;

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        Vector3 targetPosition = rb.position + move * currentSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);
    }

    void HandleAnimationParameters()
    {
        float xSpeed = 0f;
        float ySpeed = 0f;

        if (Input.GetKey(KeyCode.W)) ySpeed = 1f;
        else if (Input.GetKey(KeyCode.S)) ySpeed = -1f;

        if (Input.GetKey(KeyCode.D)) xSpeed = 1f;
        else if (Input.GetKey(KeyCode.A)) xSpeed = -1f;

        animator.SetFloat("Xspeed", xSpeed);
        animator.SetFloat("Yspeed", ySpeed);
    }

    void HandleCrouchToggle()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                isProne = false;
                animator.SetBool("CuerpoAlSuelo", false);
                ActivarCollider("sentado");
            }
            else
            {
                ActivarCollider("parado");
            }

            animator.SetBool("Agachado", isCrouching);
        }
    }

    void HandleProneToggle()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isProne = !isProne;

            if (isProne)
            {
                isCrouching = false;
                animator.SetBool("Agachado", false);
                ActivarCollider("acostado");
            }
            else
            {
                ActivarCollider("parado");
            }

            animator.SetBool("CuerpoAlSuelo", isProne);
        }
    }

    void HandleSprint()
    {
        isSprinting = !isCrouching && !isProne && Input.GetKey(KeyCode.LeftShift);
    }

    void HandleFootstepSounds()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Sprint
        if (isSprinting && isMoving)
        {
            if (!sprintSoundPlaying)
            {
                sprintAudio.Play();
                sprintSoundPlaying = true;
            }
        }
        else
        {
            if (sprintSoundPlaying)
            {
                sprintAudio.Stop();
                sprintSoundPlaying = false;
            }
        }

        // Crawl
        if (isProne && isMoving)
        {
            if (!crawlSoundPlaying)
            {
                crawlAudio.Play();
                crawlSoundPlaying = true;
            }
        }
        else
        {
            if (crawlSoundPlaying)
            {
                crawlAudio.Stop();
                crawlSoundPlaying = false;
            }
        }
    }

    void ActivarCollider(string estado)
    {
        if (colliderParado != null) colliderParado.SetActive(estado == "parado");
        if (colliderSentado != null) colliderSentado.SetActive(estado == "sentado");
        if (colliderAcostado != null) colliderAcostado.SetActive(estado == "acostado");
    }

    private AudioClip GetClip(string name)
    {
        SoundClass s = System.Array.Find(GlobalAudioManager.instance.SfxSounds, x => x.nameClip == name);
        return s?.clip;
    }
}




