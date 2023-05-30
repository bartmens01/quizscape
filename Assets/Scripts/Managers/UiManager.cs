using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject CodeLockPanel;

    private bool IsActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsActive)
        {
            IsActive = false;
            ScriptManager.main.ActivatePlayer(true);
            CodeLockPanel.SetActive(false);
        }
    }

    public void ActivateCodeLockPanel()
    {
        IsActive = true;
        CodeLockPanel.SetActive(true);
    }
}
