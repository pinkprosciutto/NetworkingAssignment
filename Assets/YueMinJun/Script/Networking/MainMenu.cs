using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager = null;
    [SerializeField] private GameObject landingPage = null;

    public void HostLobby()
    {
        networkManager.StartHost();
        landingPage.SetActive(false);
    }
}
