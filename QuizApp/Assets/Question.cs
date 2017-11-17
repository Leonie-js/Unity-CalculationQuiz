using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Question
{
    public string question;
    public Sprite questionImage;

    public string type;

    public string answer1;
    public string answer2;
    public string answer3;
    public Sprite answer1Image;
    public Sprite answer2Image;
    public Sprite answer3Image;

    public string rightAnswer;
    public Sprite rightAnswerImage;

    // question class for the first question 
    public Question(string type, string question, string answer1, string answer2, string answer3, string rightAnswer)
    {
        this.type = type;
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.rightAnswer = rightAnswer;
    }

    // question class for questions with images
    public Question(string type, string question, Sprite answer1Image, Sprite answer2Image, Sprite answer3Image, Sprite rightAnswerImage)
    {
        this.type = type;
        this.question = question;
        this.answer1Image = answer1Image;
        this.answer2Image = answer2Image;
        this.answer3Image = answer3Image;
        this.rightAnswerImage = rightAnswerImage;
    }

    // quesion class for normal questions
    public Question(string question, string answer1, string answer2, string answer3, string rightAnswer)
    {
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.rightAnswer = rightAnswer;
    }
}
