using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimParameters
{
    Hit, Jump, Buff, SpellCast, Dead, Run, Stunned, Last
}
public partial class PlayerController
{
    public void SetAnimation(AnimParameters parameters)
    {
        switch (parameters)
        {
            case AnimParameters.Hit:
            case AnimParameters.Jump:
            case AnimParameters.Buff:
            case AnimParameters.SpellCast:
            case AnimParameters.Stunned:
                break;
            case AnimParameters.Run:
            case AnimParameters.Dead:
                SetIdleFalse();
                break;
        }
        animator.SetTrigger(parameters.ToString());   
    }
    public void IdleAnim()
    {
        animator.SetBool("IsIdle", true);
    }
    public void SetIdleFalse()
    {
        animator.SetBool("IsIdle", false);
    }
}

