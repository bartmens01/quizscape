using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GarageQuestionDivider : MonoBehaviour
{
    public class Answer
    {
        public string[] answer;
        public int correctIndex;

        // The correct answer has to be randomized but will always be given as the first one when ititiating.
        // The answer string contains 4 different answers divided by a ","
        public Answer(string ans)
        {
            // dit werkt
            string[] words = ans.Split(',');

            // Randomize the different answers
            correctIndex = OrderRandomizer(words);
        }
        private int OrderRandomizer(string[] words)
        {
            string correctAnswer = words[0];
            int newIndex = 0;
            // Randomize array.
            for (int t = 0; t < words.Length; t++)
            {
                string temp = words[t];
                int r = Random.Range(t, words.Length);
                words[t] = words[r];
                words[r] = temp;
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == correctAnswer)
                {
                    newIndex = i;
                }
            }

            // Save the randomized array.
            answer = words;
            return newIndex;
        }
    }

    // Variables for the pop-up.
    public GameObject PopUpBox;
    public Animator PopUpAnimation;
    public TMP_Text PopUpText;
    public GameObject AnswerCard;
    public TMP_Text[] AnswerTexts;
    private bool AlreadyPopped = false;
    private bool FullQuestionPopped = false;

    public Inventory Inventory;

    // Variables for the QuestionsRemaining text
    public TMP_Text QuestionsRemaining;
    public List<Answer> CurrentAnswers = new List<Answer>();

    // Variables for the questions and answers.
    private List<string> Questions = new List<string>();
    private List<Question> QuestionList = new List<Question>();
    private List<Answer> Answers = new List<Answer>();
    //private List<string> CorrectAnswers = new List<string>();

    // Get the data from Json
    public JsonController GetJson;

    // Questions that have been popped before
    public List<string> FoundQuestions = new List<string>();
    private List<Answer> AnswersToFind = new List<Answer>();
    private bool QuestionPopped = false;
    private int QuestionPoppedIndex;

    private int TimesAnsweredWrong = 0;

    void Start()
    {
        Debug.Log("starting room: " + RoomCode.RoomId);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Update()
    {
        // Time Elapsed
        if (AnswersToFind.Count != 0)
        {
            // Start Timer
            Timestamp.Timer += Time.deltaTime;
        }
        else
        {
            // Stop Timer

            //Invalid Attampts
            InvalidAttempts.Invalid_Attempts = TimesAnsweredWrong;
        }

        if (Input.GetKey("escape"))
        {
            // Close application when the escape button is pressed.
            Application.Quit();

            // When closing with escape it might disable clicking on buttons entirely.
            //if (PopUpBox.activeSelf)
            //{
            //    Animator animation = PopUpBox.GetComponent<Animator>();
            //    animation.SetTrigger("Close");
            //    AlreadyPopped = false;
            //    QuestionPopped = false;
            //}
        }
    }

    // Method to add Questions and Answers for events - WERKT
    public void FillAndRandomize()
    {
        // Fill Questions and answers
        int questionCount = GetJson._ReceivedData.data.room.questions.Count;
        for (int i = 0; i < questionCount; i++ )
        {
            Questions.Add(GetJson._ReceivedData.data.room.questions[i].question);
            QuestionList.Add(GetJson._ReceivedData.data.room.questions[i]);

            int answerCount = GetJson._ReceivedData.data.room.questions[i].answers.Count;
            for ( int ia = 0; ia < answerCount; ia++)
            {
                Answers.Add(new Answer(GetJson._ReceivedData.data.room.questions[i].answers[ia].answer));
            }
        }

        // Randomize - WERKT
        //Randomize list
        int questionAmount = Questions.Count;
        for (int i = 0; i < questionAmount; i++)
        {
            string tempQ = Questions[i];
            Question tempQuestion = QuestionList[i];
            Answer tempA = Answers[i];
            int randomIndex = Random.Range(i, questionAmount);

            // Store the random index for the next player

            Questions[i] = Questions[randomIndex];
            QuestionList[i] = QuestionList[randomIndex];

            Questions[randomIndex] = tempQ;
            QuestionList[randomIndex] = tempQuestion;
            Answers[i] = Answers[randomIndex];
            Answers[randomIndex] = tempA;
        }

        // Copy All answers to the to be found list; - WERKT
        foreach (Answer a in Answers)
        {
            AnswersToFind.Add(a);
        }
        Debug.Log($"questionsRemaining: {AnswersToFind.Count / 4}, AnswersToFind: {AnswersToFind.Count}");
        QuestionsRemaining.text = (AnswersToFind.Count / 4).ToString();
    }

    // Pop up with the question. - dit gebeurt als je op een van de objecten klikt
    public void PopUpQuestions(int val)
    {
        if (!AlreadyPopped)
        {
            QuestionPopped = true;
            QuestionPoppedClass.Question_Popped = true;
            if (!FoundQuestions.Contains(Questions.ElementAt(val)))
            {
                FoundQuestions.Add(Questions[val]);
            }

            QuestionPoppedIndex = val;

            PopUpBox.SetActive(true);
            PopUpText.text = Questions.ElementAt(val);

            // Load in the answers for the question.
            // TODO randomize answers
            for (int i = 0; i < 4; i++)
            {
                AnswerTexts[i].text = QuestionList[val].answers[i].answer;
                Answer newCurrentAnswer = new Answer(QuestionList[val].answers[i].answer);
                CurrentAnswers.Add(newCurrentAnswer);
            }

            FullQuestionPopped = true;
            PopUpAnimation.SetTrigger("Pop");

            Debug.Log("popped Quesiton: " + Questions.ElementAt(val));
            // Debug.Log("Questions: "+ Questions);
        }
        else
        {
            // There is a pop up open.
            AlreadyPopped = true;
            FullQuestionPopped = false;
        }
    }

    // Pop up with the answers.
    public void PopUpAnswers(int val)
    {
        // Clicked while question pop is open. 
        if (QuestionPopped)
        {
            // Check if the answers fit the question.
            if (QuestionPoppedIndex == Inventory.AnswerCardIndex)
            {
                // Pop the full question with the answer.
                QuestionAndAnswerPop(val);
                FullQuestionPopped = true;
            }
        }
        // Else normal pop up.
        else
        {
            FullQuestionPopped = false;

            PopUpBox.SetActive(true);

            for (int i = 0; i < AnswerTexts.Length; i++)
            {
                AnswerTexts[i].text = Answers.ElementAt(val).answer[i];
                CurrentAnswers.Add(Answers.ElementAt(i));
            }
            Debug.Log($"currentanswers.count: {CurrentAnswers.Count}");
            PopUpText.text = "";
            PopUpAnimation.SetTrigger("Pop");

            // Add answer to the sidelist.
            if (AnswersToFind.Contains(Answers.ElementAt(val)))
            {
                AnswerCard.SetActive(true);
                Inventory.AnswerCardIndex = val;
            }
        }

        // There is a pop up open.
        AlreadyPopped = true;
    }
    public void QuestionClosed()
    {
        QuestionPopped = false;
        QuestionPoppedClass.Question_Popped = false;
        AlreadyPopped = false;
        FullQuestionPopped = false;
        CurrentAnswers.Clear();
    }

    // When the correct Answer is linked to a correct Question.
    private void QuestionAndAnswerPop(int val)
    {
        // Close popup first.
        PopUpBox.SetActive(false);

        // Open again with the correct info.
        PopUpBox.SetActive(true);

        // Creating the question text for the popup.
        string toPop = Questions.ElementAt(val);

        //Creating the answer text for the popup.
        Debug.Log($"Current answers before: {CurrentAnswers.Count}");
        for (int i = 0; i < AnswerTexts.Length; i++)
        {
            AnswerTexts[i].text = Answers.ElementAt(val).answer[i];
            CurrentAnswers.Add(Answers.ElementAt(i));
        }
        Debug.Log($"Current answers for ths popup: {CurrentAnswers.Count}");

        // Popping.
        PopUpText.text = toPop;
        PopUpAnimation.SetTrigger("Pop");
    }

    // Checking if the answer is correct.
    public void CheckingAnswer(int ans)
    {
        // Only check when a full answer is popped up. - WERKT
        if (FullQuestionPopped)
        {
            string[] answer = Answers[ans].answer;
            Answer curAnswer = Answers.ElementAt(ans);

            // If the answer is correct
            if (curAnswer.correctIndex == ans)
            {
                // Remove the current questions answers from the to be found list. - WERKT
                for (int i = 0; i < 3; i++) {
                    Answer removeAnswer = Answers[i];
                    if (CurrentAnswers.Count > 0)
                    {
                        AnswersToFind.Remove(CurrentAnswers[i]);
                    }
                    else
                    {
                        throw new System.Exception("no current answers left to delete");
                    }
                }
                CurrentAnswers.Clear();
                Debug.Log($"questionsRemaining: {AnswersToFind.Count / 4}, AnswersToFind: {AnswersToFind.Count}");
                QuestionsRemaining.text = (AnswersToFind.Count / 4).ToString();

                // All questions have been answered.
                if (AnswersToFind.Count == 0)
                {
                    // CLear all fields and end.
                    PopUpText.text = $"You've escaped! \n Wrong answers: {TimesAnsweredWrong}";
                    AnswerTexts[0].text = "";
                    AnswerTexts[1].text = "";
                    AnswerTexts[2].text = "";
                    AnswerTexts[3].text = "";

                    // Timer
                    Debug.Log($"Time elapsed: {Timestamp.Timer}");

                    // Serialize and send json data
                    GetJson.SerializeJson();
                    GetJson.SendJson();
                }

                // There are more questions left.
                else
                {
                    // Give the player a new Answer card and pop up.
                    // QuestionClosed();

                    int ran = Random.Range(0, AnswersToFind.Count - 1);

                    // Change the card in the inventory.
                    Answer newAnswer = AnswersToFind.ElementAt(ran);

                    int indx = 0;
                    foreach (Answer a in Answers)
                    {
                        if (a.answer[0] == newAnswer.answer[0])
                        {
                            Inventory.AnswerCardIndex = indx;
                        }
                        indx++;
                    }

                    PopUpText.text = "Correct!";
                    AnswerTexts[0].text = "This";
                    AnswerTexts[1].text = "question";
                    AnswerTexts[2].text = "has been";
                    AnswerTexts[3].text = "answered correctly";
                }
            }

            // Answer was wrong.
            else
            {
                TimesAnsweredWrong++;
            }
        }
    }
}