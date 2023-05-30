using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    private Transform startPos;

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {


            print("Out of Bounds");
        if (collision.gameObject.tag == "outOfBounds")
        {

            if (startPos != null)
            {
                transform.position = startPos.position;


            }
        }
    }
}
