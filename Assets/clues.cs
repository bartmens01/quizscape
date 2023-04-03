using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class clues : MonoBehaviour
{
    public  enum Clues {clue1, clue2, clue3, clue4};
[SerializeField]
    private Transform startpPosition;
    public Clues currentClue;
    [SerializeField]
    private TextMeshProUGUI clue;
    bool returnStartPos;
    private float dist;
    private Vector3 startPos;
    private float orgX, orgY, orgZ;
    public string clue1;
    public string clue2;
    public string clue3;
    public string clue4;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        if (startpPosition == null)
        {
            orgX = transform.rotation.x;
            orgY = transform.rotation.y;
            orgZ = transform.rotation.z;
            startPos = transform.position ;
            
        }
        else
        {
            startPos = startpPosition.position;
            orgX = startpPosition.rotation.x;
            orgY = startpPosition.rotation.y;
            orgZ = startpPosition.rotation.z;
        }
        switch (currentClue)
        {
            case Clues.clue1:
                clue1 = clue1 + KeyCodeManager.main.number1;
                clue.text = clue1;
                break;
            case Clues.clue2:
                clue2 = clue2 + KeyCodeManager.main.number2;
                clue.text = clue2;
                break;
            case Clues.clue3:
                clue3 = clue3 + KeyCodeManager.main.number3;
                clue.text = clue3;
                break;
            case Clues.clue4:
                clue4 = clue4;
                clue.text = clue4;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (returnStartPos)
        { 
            dist = Vector3.Distance(transform.position, startPos);
            print("Me is going back yes");
         transform.position = Vector3.Lerp(transform.position, startPos, 0.2f);
         transform.rotation = new Quaternion(orgX, orgY, orgZ, 0);
            if (dist < 0.05f)
            {

                returnStartPos = false;
            }
        }
    }

    public void UpdateStartPos()
    {
        if (returnStartPos == false)
        {


            orgX = transform.rotation.x;
            orgY = transform.rotation.y;
            orgZ = transform.rotation.z;
             startPos = transform.position;
        }
    }

    public void returnToStart()
    {
        GetComponent<Collider>().enabled = true;
        if (startpPosition != null)
        {


            startPos = startpPosition.position;
            orgX = startpPosition.rotation.x;
            orgY = startpPosition.rotation.y;
            orgZ = startpPosition.rotation.z;
        }

        returnStartPos = true;
    }
}
