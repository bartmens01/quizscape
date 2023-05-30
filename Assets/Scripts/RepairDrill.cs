using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RepairDrill : MonoBehaviour
{
    public bool canDestroy; 
    private bool isInRage;
    [SerializeField]
    GameObject[] Objects;
    [SerializeField]
    string[] neededObjects;
    int ObjectsActive;
    [SerializeField] string ObjectName;
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

         
            ActivateObject();
            
        }
    }
    void ActivateObject()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            print(neededObjects[i]);
            if (InvetoryManager.main.Objects.Contains(neededObjects[i]))
            {
                if (!Objects[i].activeSelf)
                { 
                    Objects[i].SetActive(true);
                    InvetoryManager.main.removeHoldingItem();
                }
            
            }
        }
        CheckIfObjectsActive();
    }
   void CheckIfObjectsActive()
    {
        
        for (int i = 0; i < Objects.Length; i++)
        {
            if (Objects[i].activeSelf)
            {

                ObjectsActive++;
            }
        }
        if (ObjectsActive == Objects.Length)
        {
         
            InvetoryManager.main.AddTolistString(ObjectName);
          
            gameObject.layer = LayerMask.NameToLayer("Default");
            if (canDestroy)
            {
                Destroy(gameObject);
            }

        }
        ObjectsActive = 0;
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
