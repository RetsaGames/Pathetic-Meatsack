using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb2d;

    void Update()
    {
        animator.SetBool("moving", (playerMovement.getXInput() != 0));

        if (rb2d.velocity.y > 0)
            animator.SetBool("goingUp", true);
        else
            animator.SetBool("goingUp", false);
        
        animator.SetBool("onFloor", playerMovement.inFloor());
        
    }
}
