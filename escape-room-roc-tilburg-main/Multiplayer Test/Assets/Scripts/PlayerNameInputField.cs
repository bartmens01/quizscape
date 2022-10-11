using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame
{
    /// <summary>
    /// Player name input field. Let the user input his name, will appear above the player in the game.
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        // Private Constants
        // Store the PlayerPref Key to avoid typos
        const string _PlayerNamePrefKey = "PlayerName";

        // MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
        {
            string _DefaultName = string.Empty;
            InputField _InputField = this.GetComponent<InputField>();
            if (_InputField != null)
            {
                if (PlayerPrefs.HasKey(_PlayerNamePrefKey))
                {
                    _DefaultName = PlayerPrefs.GetString(_PlayerNamePrefKey);
                    _InputField.text = _DefaultName;
                }
            }
            PhotonNetwork.NickName = _DefaultName;
        }

        // Public Methods

        /// <summary>
        /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        /// </summary>
        /// <param name="value">The name of the Player</param>
        public void SetPlayerName(string value)
        {
            // #Important
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = value;


            PlayerPrefs.SetString(_PlayerNamePrefKey, value);
        }
    }
}
