using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int AnswerCardIndex;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    // When the button is clicked show the found answer.
    public void DisplayAnswer()
    {
        GarageQuestionDivider div = GameObject.FindGameObjectWithTag("GarageManager").GetComponent<GarageQuestionDivider>();
        div.PopUpAnswers(AnswerCardIndex);
    }
}
