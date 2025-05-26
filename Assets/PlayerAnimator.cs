using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerManager playerManager;
    public Animator animator;

    private int xMoveHash;
    private int yMoveHash;
    private float animatorSmoothTime = 0.2f;
    private Vector2 moveInput;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        xMoveHash = Animator.StringToHash("horizontal");
        yMoveHash = Animator.StringToHash("vertical");
    }

    public void HandleAllAnimator()
    {
        moveInput = playerManager.playerNetwork.MoveInput;
        PlayLocomotionAnimation();
    }

    private void PlayLocomotionAnimation()
    {
        animator.SetFloat(xMoveHash, moveInput.x,animatorSmoothTime, Time.deltaTime);
        animator.SetFloat(yMoveHash, moveInput.y, animatorSmoothTime, Time.deltaTime);
    }

}
