using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerLocomotion playerLocomotion;
    public PlayerInput playerInput;
    public PlayerAnimator playerAnimator;

    public Vector2 moveInput;

    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        playerInput.HandleAllInput();
    }

    private void FixedUpdate()
    {   playerAnimator.HandleAllAnimator(playerInput.GetMoveInput());
        playerLocomotion.HandleAllLocomotion();        
    }
}
