using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Unity.Netcode;
public class PlayerCamera : NetworkBehaviour
{
    private CinemachineFreeLook cinCamera;
    public PlayerManager playerManager;
    private Camera cam;
    private void Awake()
    {
        cinCamera = FindAnyObjectByType<CinemachineFreeLook>();
        cam = Camera.main;
    }


    public void SetCineCamera()
    {
        cinCamera.LookAt = GetComponentInChildren<LookAt>().transform;
        cinCamera.Follow = transform;
    }
    
    public Transform GetCameraTransform()
    {
        return cam.transform;
    }

}
