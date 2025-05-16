using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead && Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("Dead", true);
            isDead = true;
            DestroyArmas();
        }
    }

    void DestroyArmas()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag("arma"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}


