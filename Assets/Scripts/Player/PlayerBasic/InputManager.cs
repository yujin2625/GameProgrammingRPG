using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Tools Tools;
    public PlayerController PlayerController;
    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        PlayerController.MoveTo(Tools.GetAimByMousePosition());
    }

    public void OnUseSkillA(InputAction.CallbackContext context)
    {
        Debug.Log("A");
    }
    public void OnUseSkillS(InputAction.CallbackContext context)
    {
        Debug.Log("S");
    }
    public void OnUseSkillD(InputAction.CallbackContext context)
    {
        Debug.Log("D");
    }
    public void OnUseSkillF(InputAction.CallbackContext context)
    {
        Debug.Log("F");
    }

}
