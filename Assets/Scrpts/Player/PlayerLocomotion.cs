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

    private float dampingTime = 0.2f;

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
        float rotateYAxis = cameraTransform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rotateYAxis, 0), dampingTime);
    }
}
