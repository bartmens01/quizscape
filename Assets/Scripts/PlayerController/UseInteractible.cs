using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInteractible : MonoBehaviour
{
    private Ray ray;
    [SerializeField]
  
    private RaycastHit hit;

   
    private Transform HoldPoistion;
    [SerializeField] private Transform ObjectHoldPos;
    [SerializeField] private Transform ClueHoldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if(HoldPoistion == ClueHoldPos && InvetoryManager.main.holdingItem)
            {
                InvetoryManager.main.holdebleItem.GetComponent<clues>().returnToStart();
                InvetoryManager.main.holdebleItem.GetComponent<Collider>().enabled = true;
                InvetoryManager.main.holdingItem = false;

            }
            else
            {
             ActivateObject();
                
            }
        }

        if (InvetoryManager.main.holdingItem)
        {
            HoldItem(HoldPoistion);
        }

       
    }

    void HoldItem(Transform holdpos)
    {
        
        InvetoryManager.main.holdebleItem.transform.position = Vector3.Lerp(InvetoryManager.main.holdebleItem.transform.position, holdpos.position, 0.2f);
        InvetoryManager.main.holdebleItem.transform.rotation = holdpos.transform.rotation;
        
    }

    

    void ActivateObject()
    {


        ray = new Ray(transform.position, transform.forward);
        RaycastHit rayHit;

        Debug.DrawRay(transform.position, transform.forward * 5, Color.green, 1);
        if (Physics.Raycast(ray, out hit, 5))
        {
            print(hit.transform.gameObject.name);
            if (hit.collider.tag == "Interact")
            {
                hit.transform.GetComponent<OpenObject>().OpenDoor();

            }

            if (InvetoryManager.main.holdingItem == false)
            {


                if (hit.collider.tag == "DrillPart")
                {
                    HoldPoistion = ObjectHoldPos;
                    InvetoryManager.main.holdItem(hit.collider.gameObject);
                  ScriptManager.main.popUpQuestion(); 
               
                   
                }

                if (hit.collider.tag == "Tools")
                {
                    HoldPoistion = ObjectHoldPos;
                    InvetoryManager.main.holdItem(hit.collider.gameObject);
                    hit.collider.GetComponent<DrillParts>().addToInventory();
                    InvetoryManager.main.AddTolist(hit.collider.gameObject);
                    ScriptManager.main.popUpQuestion();
                }
                
                if (hit.collider.tag == "Clue")
                {
                    HoldPoistion = ClueHoldPos;
                    InvetoryManager.main.holdItem(hit.collider.gameObject);
                    if (!InvetoryManager.main.Objects.Contains(hit.collider.gameObject.name))
                    {
                        ScriptManager.main.popUpQuestion();


                    }
                    else
                    {
                        InvetoryManager.main.holdItem(hit.collider.gameObject);
                        InvetoryManager.main.SetHoldItem();
                    }

                    InvetoryManager.main.holdebleItem.GetComponent<Collider>().enabled = false;
                }
                if (hit.collider.tag == "CodeLock")
                {
                    hit.collider.GetComponent<CodeLock>().RepairLock();
                }
            }
        }
    }
}
