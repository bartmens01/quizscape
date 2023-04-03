using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class KeyPad : MonoBehaviour
{
    public GameObject KeyPadObject;

    private string Code;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNumberToText(int a)
    {
        if (Code == "ERROR")
        {
            Code = "";

        }

       
        Code = Code + a.ToString();
        Text.text = Code;
    }

    public void Enter()
    {
        if (Code == KeyCodeManager.main.keyCode)
        {
            
            KeyPadObject.SetActive(false);
            ScriptManager.main.ActivatePlayer(true);
        }
        else
        {
            Code = "ERROR";
            Text.text = Code;
        }
    }
}
