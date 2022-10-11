using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CustomProperties : MonoBehaviour
{
    /*
     * This class is used to store all necessary data to be shared within the photon server
     * Sharing is done using the photon custom properties
     */

    // Set custom property
    /*private ExitGames.Client.Photon.Hashtable _MyCustomProperty = new ExitGames.Client.Photon.Hashtable();

    public void SetProperties()
    {
        int SelectedIndex = RandomIndex.Index;
        _MyCustomProperty["Index"] = SelectedIndex;
        PhotonNetwork.LocalPlayer.CustomProperties = _MyCustomProperty;
    }

    public void ShareProperties(Player player)
    {
        RandomIndex.SharedIndex = (int)player.CustomProperties["Index"];
    }*/
}
