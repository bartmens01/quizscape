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

    private int amountofNumbers;
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

        if (amountofNumbers != 4)
        {

        Code = Code + a.ToString();
        Text.text = Code;
        amountofNumbers++;
        }
    }

    public void Enter()
    {
        if (Code == KeyCodeManager.main.keyCode)
        {

            SceneMan.main.endScreen();
        }
        else
        {
            Code = "ERROR";
            Text.text = Code;
           amountofNumbers = 0;
        }
    }
}
