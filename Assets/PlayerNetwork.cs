using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UIElements.Experimental;
public class PlayerNetwork : NetworkBehaviour
{
    private PlayerManager playerManager;
    private NetworkVariable<Vector2> moveInput =
        new NetworkVariable<Vector2>(
            Vector2.zero,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Owner);

    private NetworkVariable<Quaternion> cameraRotation =
        new NetworkVariable<Quaternion>(
            Quaternion.identity,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Owner);

    private NetworkVariable<Vector3> netPosition =
    new NetworkVariable<Vector3>(
        Vector3.zero,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner);

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    public Vector2 MoveInput
    {
        get { return moveInput.Value; }
        set { moveInput.Value = value; }
    }

    public Quaternion CameraRotation
    {
        get { return cameraRotation.Value; }
        set {cameraRotation.Value = value; }
    }

    public Vector3 NetPosition
    {
        get { return netPosition.Value; }
        set { netPosition.Value = value; }
    }

    
    public void AsyncInput(Vector2 _moveInput, Quaternion _cameraRotation)
    {
        MoveInput = _moveInput;
        CameraRotation = _cameraRotation;
    }


}
