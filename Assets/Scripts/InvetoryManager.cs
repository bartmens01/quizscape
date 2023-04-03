using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryManager : MonoBehaviour
{
   public bool DrillPart1;
   public bool DrillPart2;
   public bool DrillPart3;
   public bool screwDriver, Hammer; 
   public bool DrillCollected;
   public bool ToolBoxCollected;
public  List<string> Objects = new List<string>();
   public bool holdingItem;

   public GameObject holdebleItem;
    // Start is called before the first frame update
    public static InvetoryManager main;
    private void Awake()
    {
        
        //singleton pattern
        if (main == null)
        {
            main = this;
      
        }
        else Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void removeHoldingItem()
    {
        holdingItem = false;
        Destroy(holdebleItem);
    }

    public void holdItem(GameObject item)
    {
        print("ME DOING THIS A");
       
        holdebleItem = item;
    }

    public void SetHoldItem()
    {
        if (holdebleItem != null)
        {
            holdingItem = true;
        }

    }

    public void AddTolist(GameObject current)
    {
        Objects.Add(current.name);

    }

    public void addToInventory(int a)
    {
        switch (a)
        {
            case  1:
                DrillPart1 = true;
                break;
            case  2:
                DrillPart2 = true;
                break;
            case 3:
                    DrillPart3 = true;
                    break;
            
            case 4: 
                DrillCollected = true;
                break;
            case 5: 
                Hammer = true;
                break;
            case 6: 
               screwDriver = true;
                break;
        }
        
    }
}
