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

    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerNetwork = GetComponent<PlayerNetwork>();
        playerCamera = GetComponent<PlayerCamera>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DontDestroyOnLoad(this);
    }



    private void FixedUpdate()
    {
        playerAnimator.HandleAllAnimator();
        playerLocomotion.HandleAllLocomotion();
        //同步位置
        if (IsOwner)
        {

        }

    }
    private void Update()
    {
        if (IsOwner)
        {
            //处理输入
            playerInput.HandleAllInput();

            //同步网络变量
            playerNetwork.AsyncInput(
                playerInput.MoveInput,
                playerInput.CameraInput);

        }

    }
    

   


}
