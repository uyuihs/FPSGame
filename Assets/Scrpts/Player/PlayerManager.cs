using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerManager : NetworkBehaviour
{
    public PlayerLocomotion playerLocomotion;
    public PlayerInput playerInput;
    public PlayerAnimator playerAnimator;
    public PlayerNetwork playerNetwork;
    public PlayerCamera playerCamera;
    public PlayerSetup playerSetup;


    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerNetwork = GetComponent<PlayerNetwork>();
        playerCamera = GetComponent<PlayerCamera>();
        playerSetup = GetComponent<PlayerSetup>();

        playerLocomotion.playerManager = this;
        playerInput.playerManager = this;
        playerAnimator.playerManager = this;
        playerNetwork.playerManager = this;
        playerCamera.playerManager = this;
        playerSetup.playerManager = this;

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DontDestroyOnLoad(this);
    }



    private void FixedUpdate()
    {


        //同步位置
        if (IsOwner)
        {
            playerAnimator.HandleAllAnimator();
            playerLocomotion.HandleAllLocomotion();
            playerNetwork.NetPosition = transform.position;
            playerNetwork.Rotation = transform.rotation;
        }
        else
        {
            //非拥有者，更新位置和旋转
            transform.position = playerNetwork.NetPosition;
            transform.rotation = playerNetwork.Rotation;
        }

    }
    private void Update()
    {
        if (IsOwner)
        {
            //处理输入
            playerInput.HandleAllInput();

            //同步网络变量
            playerNetwork.AsyncMoveInput(playerInput.MoveInput);

        }

    }
    

   


}
