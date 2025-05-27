using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class GameUIManager : NetworkBehaviour
{

    [SerializeField] private Button hostBtn;
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button clientBtn;

    private void Awake()
    {
        hostBtn = GameObject.Find("Host").GetComponent<Button>();
        serverBtn = GameObject.Find("Server").GetComponent<Button>();
        clientBtn = GameObject.Find("Client").GetComponent<Button>();
    }

    private void Start()
    {
        hostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            DestoryAllBtn();
        });
        serverBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            DestoryAllBtn();
        });
        clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            DestoryAllBtn();
        });
        
    }

    private void DestoryAllBtn()
    {

        Destroy(hostBtn.gameObject);
        Destroy(serverBtn.gameObject);
        Destroy(clientBtn.gameObject);

    }

}
