using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator anim;
    private bool isGrounded = false;
    public bool isSprinting = false;

    public void SetMoveValues(Vector2 movevalues)
    {

        if (isSprinting)
        {
            movevalues.y *= 2f;
        }
        anim.SetFloat("Vertical", movevalues.y);
        anim.SetFloat("Horizontal", movevalues.x);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Main_Jump_Lift_01");
            //anim.CrossFade("Main_Jump_01", 2f);
        }
    }

    public void UpdateGrounding(bool _isGrounded)
    {
        isGrounded = _isGrounded;
        anim.SetBool("isGrounded", isGrounded);
    }
}
