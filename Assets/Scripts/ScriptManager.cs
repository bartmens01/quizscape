using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public static ScriptManager main;
    public PlayerController _PlayerController;
    public UiManager _UiManager;
    public GarageQuestionDivider _GarageQuestionDivider;
    private int question = 0;
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
        _PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _UiManager = GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void popUpQuestion()
    {

        if (question < _GarageQuestionDivider.QuestionList.Count)
        {
         _GarageQuestionDivider.PopUpQuestions(question);
            
        }
        else
        {
            InvetoryManager.main.SetHoldItem();
        }
      
    }

    public void pickUpItem(GameObject item)
    {
        
        
    }

    public void AddInt()
    {
        question++;
    }

    public void ActivatePlayer(bool a)
    {
        if (a == false)
        {


            ScriptManager.main._PlayerController.canMove = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            ScriptManager.main._PlayerController.canMove = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
