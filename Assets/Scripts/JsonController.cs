using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class JsonController : MonoBehaviour
{
    // Json to receive from CMS
    private string _Url;
    public ReceivedJson _ReceivedData;

    // Json to send to CMS
    private SendJson _DataSent;
    private string _SendUrl;
    private string _SendToCMS = "";

    // Event
    public UnityEvent DoneProcessingJson;

    // Start is called before the first frame update
    void Start()
    {
        // Url of the Json to be read
        _Url = $"http://localhost:8000/api/rooms/{RoomCode.RoomId}";
        // Url of the Json to be send
        _SendUrl = $"http://localhost:8000/api/rooms/{RoomCode.RoomId}/results";

        // Read the Json
        ReadJson();
    }

    // Update is called once per frame
    void Update()
    {
        // Json class
        _DataSent = new SendJson();
        _DataSent.name = _ReceivedData.data.room.name;
        _DataSent.invalid_attempts = InvalidAttempts.Invalid_Attempts;
        _DataSent.timeSpent = (int)Timestamp.Timer;
    }

    /// <summary>
    /// Starts a new thread to read and store the corresponding Json data
    /// </summary>
    public void ReadJson()
    {
        StartCoroutine(GetData());
    }

    // Json Controller
    /// <summary>
    /// Web Request to request for the specific website where the Json is being stored.
    /// Check if the website exists or not, if yes, read the Json file, if not, return error.
    /// </summary>
    /// <returns></returns>
    IEnumerator GetData()
    {
        UnityWebRequest _www = UnityWebRequest.Get(_Url);
        yield return _www.SendWebRequest();
        if (_www.error == null)
        {
            ProcessJsonData(_www.downloadHandler.text);
            // Call the event
            DoneProcessingJson.Invoke();
            Debug.Log("Data from CMS Processed");
            // Debug.Log(_www.downloadHandler.text);
        }
        else
        {
            Debug.Log("Error while getting room data from CMS");
        }
    }

    /// <summary>
    /// Takes the Url of the website as a parameter, deserialize the read Json into the corresponding classes in JsonClasses Script.
    /// </summary>
    /// <param name="url"></param>
    private void ProcessJsonData(string url)
    {
        _ReceivedData = JsonUtility.FromJson<ReceivedJson>(url);
    }

    /// <summary>
    /// Send serialized data to CMS
    /// </summary>
    /// <returns></returns>
    IEnumerator SendData()
    {
        UnityWebRequest WebSite = new UnityWebRequest(_SendUrl);

        using (WebSite = UnityWebRequest.Post(_SendUrl, _SendToCMS))
        {
            yield return WebSite.SendWebRequest();

            if (WebSite.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(WebSite.error);
            }
            else
            {
                Debug.Log("Success!");
                Debug.Log(_SendToCMS);
            }
        }
    }

    // Serilazing to Json
    public void SerializeJson()
    {
        _SendToCMS = JsonUtility.ToJson(_DataSent);
    }

    // Send data to CMS
    public void SendJson()
    {
        StartCoroutine(SendData());
    }
}
