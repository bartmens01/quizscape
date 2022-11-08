using System.Collections.Generic;
using System;

// Receiving data from CMS to Unity
[Serializable]
public class ReceivedJson
{
    public bool success;
    public Validation validation;
    public Data data = new Data();
}

[Serializable]
public class Validation
{
    // Empty
}

[Serializable]
public class Data
{
    public Rooms room = new Rooms();
}

[Serializable]
public class Rooms
{
    public string name;
    public string description;
    public string type;
    public List<Question> questions = new List<Question>();
}

[Serializable]
public class Question
{
    public int id;
    public string question;
    public List<Answer> answers = new List<Answer>();
}

[Serializable]
public class Answer
{
    public int id;
    public string answer;
    public bool is_correct;
}

// Send to CMS
[Serializable]
public class SendJson
{
    public string name;
    public int invalid_attempts;
    public int timeSpent;
}

// Static classes
public static class RoomCode
{
    public static string RoomId;
}

public static class Timestamp
{
    public static float Timer = 0.0f;
}

public static class InvalidAttempts
{
    public static int Invalid_Attempts = 0;
}

public static class QuestionPoppedClass
{
    public static bool Question_Popped;
}
