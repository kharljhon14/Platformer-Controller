using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<float> OnMovementPressed { get; set; }
    [field: SerializeField] public UnityEvent OnJumpPressed { get; set; }
    [field: SerializeField] public UnityEvent OnJumpReleased { get; set; }

    private void Update()
    {
        GetHorizontalMovementInputs();
        GetJumpInputs();
    }

    private void GetJumpInputs()
    {
        if (Input.GetButtonDown("Jump"))
            OnJumpPressed?.Invoke();

        if (Input.GetButtonUp("Jump"))
            OnJumpReleased?.Invoke();
    }

    private void GetHorizontalMovementInputs()
    {
        OnMovementPressed?.Invoke(Input.GetAxisRaw("Horizontal"));
    }
}
