using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSwitch : MonoBehaviour
{
    public Sprite MainRoom;
    public Sprite SideRoom;
    public SpriteRenderer spriteRenderer;

    public List<GameObject> MainRoomButtons;
    public List<GameObject> SideRoomButtons;

    // For Question Tab
    public GameObject QuestionTab;
    public Text QuestionText;
    private bool _OpenQuestion;
    public GarageQuestionDivider _Questions;
    public Animator QuestionTabAnimation;

    // For Help Tab
    public GameObject HelpTab;
    private bool _OpenHelp;
    public Animator HelpTabAnimation;

    void Start()
    {
        // Set the question tab to false
        QuestionTab.SetActive(false);
        _OpenQuestion = false;

        // Set the help tab to false
        HelpTab.SetActive(false);
        _OpenHelp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToSideRoom()
    {
        ToggleButtons(false, true);
        spriteRenderer.sprite = SideRoom;
    }
    public void ToMainRoom()
    {
        ToggleButtons(true, false);
        spriteRenderer.sprite = MainRoom;
    }
    
    private void ToggleButtons(bool main, bool side)
    {
        foreach (GameObject Btn in MainRoomButtons)
        {
            Btn.SetActive(main);
        }

        foreach (GameObject Btn in SideRoomButtons)
        {
            Btn.SetActive(side);
        }
    }

    // For Question Tab

    /// <summary>
    /// Function to open the question tab
    /// Lists all of the found question
    /// </summary>
    public void OpenQuestionTab()
    {
        Debug.Log($"Questions window opened");
        if (!_OpenQuestion)
        {
            // Run Pop Animation
            QuestionTab.SetActive(true);
            _OpenQuestion = true;
            QuestionTabAnimation.SetTrigger("Pop");

            // List all previously opened questions
            if (_Questions.FoundQuestions.Count != 0)
            {
                for(int i = 0; i < _Questions.FoundQuestions.Count; i++)
                {
                    QuestionText.text = $"Question {i + 1}: {_Questions.FoundQuestions[i]}\n\n{QuestionText.text}";
                }
            }
        }
        else
        {
            // Run Close Animation
            QuestionTabAnimation.SetTrigger("Close");
            _OpenQuestion = false;
            QuestionText.text = string.Empty;
        }
    }

    // For Tutorials

    public void OpenHelpTab()
    {
        if (!_OpenHelp)
        {
            HelpTab.SetActive(true);
            _OpenHelp = true;

            // Run Pop Animation
            HelpTabAnimation.SetTrigger("Pop");
        }
        else
        {
            // Run Close Animation
            HelpTabAnimation.SetTrigger("Close");

            //HelpTab.SetActive(false);
            _OpenHelp = false;
        }
    }
}
