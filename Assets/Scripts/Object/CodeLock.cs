using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CodeLock : MonoBehaviour
{
    private bool lockRepaired;

    [SerializeField]
    private GameObject BrokePartical;

    private int questDone;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
      BrokePartical.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepairLock()
    {
        if (InvetoryManager.main.Objects.Contains("ToolBox"))
        {
            if (lockRepaired)
            {
                
                ScriptManager.main._UiManager.ActivateCodeLockPanel();
                
            }

            if (questDone == 2)
            {


                lockRepaired = true;
                BrokePartical.SetActive(false);
                ScriptManager.main.ActivatePlayer(false);
            }
            else
            {
                
                ScriptManager.main.popUpQuestion();
                questDone++;
                if (questDone == 2)
                {
                    
                    RepairLock();
                }
            }
        }
        else
        {
            print("Needs to be repaired");
           
        }

    }


}
