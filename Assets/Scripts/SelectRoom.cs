using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectRoom : MonoBehaviour
{
    // Get the data from Json
    public JsonController GetJson;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function To select room from Json
    public void RoomType()
    {
        if (GetJson._ReceivedData.data.room.type == "garage")
        {
            Debug.Log("Room Type: Garage");
            SceneManager.LoadScene("Garage");
        }
        else if (GetJson._ReceivedData.data.room.type == "laboratory")
        {
            Debug.Log("Room Type: Laboratory");
            SceneManager.LoadScene("Laboratory");
        }
        
    }
}
