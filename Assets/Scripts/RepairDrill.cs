using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RepairDrill : MonoBehaviour
{
    private bool isInRage;
    private bool repaired; 
    [SerializeField]
    private GameObject part1;
    [SerializeField]
    private GameObject part2;
    [SerializeField]
    private GameObject part3;
    // Start is called before the first frame update
    void Start()
    {
       gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRage && Input.GetKeyDown(KeyCode.E))
        {
           
            if (InvetoryManager.main.Objects.Contains("DrillPart1"))
            {
                if (!part1.activeSelf)
                {
                InvetoryManager.main.removeHoldingItem();
                    
                }
                part1.SetActive(true);
            }
            if (InvetoryManager.main.Objects.Contains("DrillPart2"))
            {
                if (!part2.activeSelf)
                {
                InvetoryManager.main.removeHoldingItem();
                }
                part2.SetActive(true);

            }
            if (InvetoryManager.main.Objects.Contains("DrillPart3"))
            {
                if (!part3.activeSelf)
                {
                    InvetoryManager.main.removeHoldingItem();
                }
                part3.SetActive(true);
               
            }

            if (InvetoryManager.main.Objects.Contains("DrillPart1") && InvetoryManager.main.Objects.Contains("DrillPart2") && InvetoryManager.main.Objects.Contains("DrillPart3") )
            {

                InvetoryManager.main.DrillCollected = true;
                gameObject.layer = LayerMask.NameToLayer("Default");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRage = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInRage = false;
    }
}
