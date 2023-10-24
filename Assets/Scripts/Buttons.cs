using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ServerButton;
    [SerializeField] private Button ClientButton;

    private void Awake()
    {
        HostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });

        ServerButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });

        ClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
}
