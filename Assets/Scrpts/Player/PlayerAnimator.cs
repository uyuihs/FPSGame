using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerAnimator : NetworkBehaviour
{
    public PlayerManager playerManager;
    public Animator animator;

    private int xMoveHash;
    private int yMoveHash;
    private float animatorSmoothTime = 0.2f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        xMoveHash = Animator.StringToHash("horizontal");
        yMoveHash = Animator.StringToHash("vertical");
    }

    public void HandleAllAnimator()
    {
        PlayLocomotionAnimationOnserverRpc();
    }

    [ServerRpc]
    private void PlayLocomotionAnimationOnserverRpc()
    {
        PlayLocomotionAnimationOnClientRpc();   
            
    }

    [ClientRpc]
    private void PlayLocomotionAnimationOnClientRpc()
    {
        Vector2 moveInput = playerManager.playerNetwork.MoveInput;
        animator.SetFloat(xMoveHash, moveInput.x, animatorSmoothTime, Time.deltaTime);
        animator.SetFloat(yMoveHash, moveInput.y, animatorSmoothTime, Time.deltaTime);
    }
}
