using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerLocomotion : NetworkBehaviour
{
    public PlayerManager playerManager;
    private Vector2 moveInput;

    private Rigidbody rb;
    private Transform cameraTransform;
    private float moveSpeed = 5f;

    private float rotateSpeed = 15f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        cameraTransform = playerManager.playerCamera.GetCameraTransform();
    }
    
    public void HandleAllLocomotion()
    {
        //jump
        //doge
        RotateWithCamera();
    }

    private void OnAnimatorMove()
    {
        if (IsOwner)
        {
            rb.velocity = playerManager.playerAnimator.animator.deltaPosition / Time.fixedDeltaTime;
        }
    }

    public void RotateWithCamera()
    {
        Quaternion targetRotation = cameraTransform.rotation;
        Debug.Log(targetRotation);
        targetRotation.x = targetRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);
    }
}
