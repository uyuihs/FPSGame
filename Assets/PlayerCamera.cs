using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Unity.Netcode;
public class PlayerCamera : NetworkBehaviour
{
    private CinemachineFreeLook cinCamera;
    private PlayerManager playerManager;
    private void Awake()
    {
        cinCamera = FindAnyObjectByType<CinemachineFreeLook>();
        playerManager = GetComponent<PlayerManager>();
    }


    public void SetCineCamera()
    {
        cinCamera.LookAt = GetComponentInChildren<LookAt>().transform;
        cinCamera.Follow = transform;
    }
}
