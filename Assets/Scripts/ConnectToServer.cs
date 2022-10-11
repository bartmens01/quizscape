using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Find The server
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Connecting to server
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    // Go To lobby
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
