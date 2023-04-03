using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ObjectsIntoolbox;
    private bool Drill;

    private bool hammer;
    private bool IsInRange;
    private bool screwDriver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsInRange)
        {
            if (InvetoryManager.main.Objects.Contains("Drill") && !Drill)
            {
                Drill = true;
                ObjectsIntoolbox[0].SetActive(true);
                InvetoryManager.main.removeHoldingItem();
            }
            if (InvetoryManager.main.Objects.Contains("Screwdriver") && !screwDriver)
            {
                screwDriver = true;
                ObjectsIntoolbox[1].SetActive(true);
                InvetoryManager.main.removeHoldingItem();
            }
            if (InvetoryManager.main.Objects.Contains("Hammer") & !hammer)
            {
                hammer = true;
                ObjectsIntoolbox[2].SetActive(true);
                InvetoryManager.main.removeHoldingItem();
            }
            if (Drill && hammer && screwDriver )
            {
                collect();
            }
        }
    }

    void collect()
    {
        InvetoryManager.main.ToolBoxCollected = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        IsInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsInRange = false;
    }
}
