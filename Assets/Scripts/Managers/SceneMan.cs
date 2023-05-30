using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
   public static SceneMan main;
    private void Awake()
    {

        //singleton pattern
        if (main == null)
        {
            main = this;

        }
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void endScreen()
    {

        SceneManager.LoadScene("EndScreen");
    }
    public void sceneSwitch(int a)
    {
        SceneManager.LoadScene(a);

    }

}
