using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerController
{

    public void InputRun(InputAction.CallbackContext context)
    {
        if (!(context.ReadValue<Vector3>() == Vector3.zero))
        {
            animator.SetBool("Running", true);
            SetAnimation(AnimParameters.Run);
            SetDirection(context.ReadValue<Vector3>());
            IsRunning = true;
        }
        if (context.ReadValue<Vector3>() == Vector3.zero)
        {
            animator.SetBool("Running", false);
            IdleAnim();
            SetDirection(Vector3.zero);
            IsRunning = false;
        }
    }
    public void InputJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetAnimation(AnimParameters.Jump);
            StartCoroutine(JumpTimer());
        }
    }
    IEnumerator JumpTimer()
    {
        IsJumping = true;
        animator.SetBool("Jumping", true);
        CapsuleCollider.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Jump();
        yield return new WaitForSeconds(0.9f);
        IsJumping = false;
        CapsuleCollider.enabled = true;
        animator.SetBool("Jumping", false);

    }
    public void InputLook(InputAction.CallbackContext context)
    {
        if (!IsAttacking)
        {
            if (!ShiftClicked)
            {
                transform.Rotate(new Vector3(0, context.ReadValue<Vector2>().normalized.x * TurnSpeed, 0));
            }
            else
            {
                LookRotate.transform.Rotate(new Vector3(0, context.ReadValue<Vector2>().normalized.x * TurnSpeed, 0));
            }
        }
    }
    public void InputShift(InputAction.CallbackContext context)
    {
        ShiftClicked = context.performed ? true : false;
        if (context.canceled)
        {
            LookRotate.transform.rotation = transform.rotation;
        }
    }
    public void InputZoom(InputAction.CallbackContext context)
    {
        if (!ShiftClicked)
        {
            if (context.ReadValue<Vector2>().y > 0 && GameManager.FollowPoint.transform.localPosition.z <= -1)
            {
                GameManager.ZoomCamera(0.01f);
            }
            else if (context.ReadValue<Vector2>().y < 0 && GameManager.FollowPoint.transform.localPosition.z >= -3)
            {
                GameManager.ZoomCamera(-0.01f);
            }
        }
    }
    public void InputAttack(InputAction.CallbackContext context)
    {
        if (context.started && !IsRunning && !IsAttacking)
        {
            SetAnimation(AnimParameters.BowShot);
            UseSkills(PlayerSkills.Attack);
        }
    }
    public void InputQ(InputAction.CallbackContext context)
    {
        if (context.started && !IsRunning && !IsAttacking)
        {
            SetAnimation(AnimParameters.Buff);
            UseSkills(PlayerSkills.Buff);
        }
    }
    public void InputE(InputAction.CallbackContext context)
    {
        if (context.started && !IsRunning && !IsAttacking)
        {
            SetAnimation(AnimParameters.SpellCast);
            UseSkills(PlayerSkills.SpellCast);
        }
    }
    public void InputZ(InputAction.CallbackContext context)
    {

    }
    public void InputV(InputAction.CallbackContext context)
    {

    }
}
