using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCodeManager : MonoBehaviour
{
    public static KeyCodeManager main;
    public int a;
    public int b;
    public int c;
    public int d;
    public string number1;
    public string number2;
    public string number3;
    public string number4;
    public string keyCode = "0000";
    private void Awake()
    {
        
        //singleton pattern
        if (main == null)
        {
            main = this;
      
        }
        else Destroy(gameObject);
        genkeyCode();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void genkeyCode()
    {
         a = Random.Range(0, 9);
         b = Random.Range(0, 9);
         c = Random.Range(0, 9); 
         d = Random.Range(0, 9);
        number1 = a.ToString();
        number2 = b.ToString();
        number3 = c.ToString();
        number4 = d.ToString();
        keyCode = (number1  + number2 + number3 + number4);
        print(keyCode);
    }
}
