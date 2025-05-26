using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerManager playerManager;
    private Vector2 moveInput;

    private Rigidbody rb;
    private float moveSpeed = 5f;

    private float rotateSpeed = 15f;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();
    }

    public void HandleAllLocomotion()
    {
        //jump
        //doge
        RotateWithCamera();
    }

    private void OnAnimatorMove()
    {
        rb.velocity = playerManager.playerAnimator.animator.deltaPosition / Time.fixedDeltaTime;
    }

    public void RotateWithCamera()
    {
        Quaternion targetRotation = playerManager.playerNetwork.CameraRotation;
        targetRotation.x = targetRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);
    }
}
