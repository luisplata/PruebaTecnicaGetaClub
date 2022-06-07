using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputFacade : MonoBehaviour
{
    public Action OnSwitchCamera;
    public void SwitchCameraInput(InputAction.CallbackContext input)
    {
        //Debug.Log("SwitchCameraInput");
        OnSwitchCamera?.Invoke();
    }
    
    public Action<Vector2> OnMovement;
    public void MovementInput(InputAction.CallbackContext input)
    {
        //Debug.Log(input.ReadValue<Vector2>());
        OnMovement?.Invoke(input.ReadValue<Vector2>());
    }


    public Action OnFire;
    public void FireInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnFire?.Invoke();
        }
    }

}
