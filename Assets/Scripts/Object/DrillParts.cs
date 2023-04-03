using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillParts : MonoBehaviour
{
    [SerializeField] private
         int type;

    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void addToInventory()
    {
        InvetoryManager.main.addToInventory(type);
        turnOffCollider();
    }

   private void turnOffCollider()
   {
       
       col.enabled = false;
   }
}
