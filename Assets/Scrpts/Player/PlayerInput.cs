using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerInput : NetworkBehaviour
{
    private InputController inputController;
    private Transform cinCameraTransform;
    [Header("Player Input")]
    private float epszero = (float)1e-20;//表示0
    private Vector2 moveInput = Vector2.zero;

    private Vector3 playerPosition;

    private bool sprintInput;
    private bool jumpInput;

    private void Awake()
    {
        cinCameraTransform = Camera.main.transform;        
    }

    private void OnEnable()
    {
        if (inputController == null)
        {
            inputController = new InputController();
        }
        
        inputController.PlayerMove.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputController.PlayerMove.Sprint.performed += ctx => sprintInput = true;
        inputController.PlayerMove.Sprint.canceled += ctx => sprintInput = false;
        inputController.Enable();

    }

    public void HandleAllInput()
    {
        HandleMoveInput();

    }

    private void HandleMoveInput()
    {
        if (moveInput.x > epszero) { moveInput.x = 1; }
        else if (moveInput.x < -epszero) { moveInput.x = -1; }
        else { moveInput.x = 0; }
        if (moveInput.y > epszero) { moveInput.y = 1; }
        else if (moveInput.y < -epszero) { moveInput.y = -1; }
        else { moveInput.y = 0; }
        if (sprintInput && moveInput.y > epszero) { moveInput.y = 2; moveInput.x = 0; }
        Debug.Log(moveInput);
    }

    public Quaternion CameraInput
    {
        get { return cinCameraTransform.rotation; }
    }

    public Vector2 MoveInput
    {
        get { return moveInput; }
    }

}
