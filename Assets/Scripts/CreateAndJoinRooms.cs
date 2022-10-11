using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    // Variables for the inputs
    public InputField CreateInput;
    public InputField JoinInput;

    // Call the custom properties
    public CustomProperties Properties;

    // Create a room
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateInput.text);
        //Properties.SetProperties();
    }

    // Join a room
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
        //Properties.ShareProperties();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Garage");
    }
}
