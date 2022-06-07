using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private InputFacade inputFacade;
    private bool isCameraSwitched;

    private void Start()
    {
        inputFacade.OnSwitchCamera += SwitchCamera;
    }

    private void SwitchCamera()
    {
        isCameraSwitched = !isCameraSwitched;
        cameraAnimator.SetBool("2D", isCameraSwitched);
    }
}
