using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockTime : MonoBehaviour
{
    [SerializeField] private GameObject HourTime;

    private int a;
    // Start is called before the first frame update
    void Start()
    {

       a = KeyCodeManager.main.d * 30;
        print(a);
       HourTime.transform.rotation = Quaternion.Euler(0, 90, KeyCodeManager.main.d * 30); 
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
