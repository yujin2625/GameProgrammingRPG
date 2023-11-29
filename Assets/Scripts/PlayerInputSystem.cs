using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerController
{
    public void InputRun(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector3>());

        if (!(context.ReadValue<Vector3>() == Vector3.zero))
        {
            if (animator.GetBool("IsIdle"))
            {
                SetAnimation(AnimParameters.Run);
            }
            MoveTo(context.ReadValue<Vector3>());
        }
        else
        {
            IdleAnim();
        }
    }
    public void InputJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetAnimation(AnimParameters.Jump);
        }
    }
    public void InputLook(InputAction.CallbackContext context)
    {

    }
}
