using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerSetup : NetworkBehaviour
{
    private PlayerManager playerManager;
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            playerManager.playerCamera.SetCineCamera();
            float position = Random.Range(1, 5);
            transform.position = new Vector3(position, 0, position);
            playerManager.playerNetwork.NetPosition = transform.position;
        }
        else
        {
            playerManager.playerInput.enabled = false;
            transform.position = playerManager.playerNetwork.NetPosition;
        }
    }
}
