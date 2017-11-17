using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

    private string currentQuestion;
    private string currentAnswer3;
    private string currentAnswer2;
    private string currentAnswer1;
    private string currentRightAnswer;
    private string currentType;

    public Text questionText;
    public Text answer3Text;
    public Text answer2Text;
    public Text answer1Text;

    private Sprite currentAnswer1Image;
    private Sprite currentAnswer2Image;
    private Sprite currentAnswer3Image;
    private Sprite currentRightAnswerImage;

    public UnityEngine.UI.Image Answer1Image;
    public UnityEngine.UI.Image Answer2Image;
    public UnityEngine.UI.Image Answer3Image;

    private Sprite currentSprite;
    public UnityEngine.UI.Image monsterRandom;

    public Question[] vragenGroep4 = new Question[9];
    public Question[] vragenGroep5 = new Question[9];
    public Question[] vragenGroep6 = new Question[9];

    public Sprite[] Images = new Sprite[6];
    public Sprite[] Monsters = new Sprite[4];

    public Animator anim;
    private int questionIndex = 0;
    int schoolGroup;
    int randomMonster;

    // first question to see in which schoolgroup the user is.
    Question Groepvraag = new Question("other", "In welke groep zit jij?", "groep 4", "groep 5", "groep 6", "");

    // function that starts when app is opened
    void Start()
    {
        // make the questions for all the groups
        vragenGroep4[1] = new Question("img", "Anne koopt een appel van 3 euro en heeft 5 euro. Hoeveel geld heeft ze nog over? ", Images[0], Images[1], Images[2], Images[1]);
        vragenGroep4[0] = new Question("Hoeveel is 100 + 30?", "13", "130", "70", "130");
        vragenGroep4[2] = new Question("Hoeveel is 33 - 7?", "24", "25", "26", "26");
        vragenGroep4[3] = new Question("Lisa heeft 200 bananen, ze geeft 2 weg. Hoeveel bananen heeft ze nog over?", "188 bananen", "198 bananen", "180 bananen", "198 bananen");
        vragenGroep4[4] = new Question("Hoeveel is 8 x 3?", "24", "11", "5", "24");
        vragenGroep4[6] = new Question("Hoeveel is 32 : 4?", "6", "7", "8", "8");
        vragenGroep4[5] = new Question("img","Max krijgt 5 euro van zijn moeder. Hij verdeelt het geld over 5 vrienden. Hoeveel geld krijgen elk van zijn vrienden?", Images[2], Images[1], Images[0], Images[0]);
        vragenGroep4[7] = new Question("Er liggen 33 pakken yogurt in de koelkast. Liesbeth legt er nog 7 pakken bij. Hoeveel pakken liggen er nu in de koelkast?", "24 pakken", "42 pakken", "40 pakken", "40 pakken");
        vragenGroep4[8] = new Question("Hoeveel 14 - 5?", "9", "19", "29", "9");
        vragenGroep4[9] = new Question("Job wil 9  papiertjes geven aan 5 vrienden. Hoeveel papiertjes is hij in totaal nodig?", "55 papiertjes", "45 papiertjes", "35 papiertjes", "45 papiertjes");


        vragenGroep5[0] = new Question("Hoeveel is 12 x 20?", "32", "320", "240", "240");
        vragenGroep5[2] = new Question("Hoeveel is 5 : 5?", "1", "2", "3", "1");
        vragenGroep5[1] = new Question("100 mensen geven Leslie \u20AC 4,50. Hoeveel geld heeft Leslie uiteindelijk?", "45", "450", "4500", "450");  //IMG
        vragenGroep5[4] = new Question("Hoeveel is 3,2 : 10?", "0,32", "3,2", "32", "0,32");
        vragenGroep5[3] = new Question("Hoe kun je 1000 cm ook anders zeggen?", "1 dm", "1 m", "1 km", "1 m");
        vragenGroep5[5] = new Question("Hoe kun je 1 km ook anders zeggen?", "1000 cm", "1000 dm", "1000 m", "1000 m");
        vragenGroep5[6] = new Question("Hoeveel is 55,5 : 100?", "0,555", "5,55", "555", "0,555");
        vragenGroep5[8] = new Question("Hoeveel is 23,5 x 10?", "2,35", "235", "2350", "235");
        vragenGroep5[7] = new Question("Je verdeelt 3 appels over 6 mensen. Hoeveel appels krijgt iedereen?", "0,4 appel", "0,5 appel", "0,6 appel", "0,5 appel"); //IMG
        vragenGroep5[9] = new Question("Hoveel is 62 x 3?", "92", "126", "186", "186");


        vragenGroep6[0] = new Question("Er zijn 6 appels en 3 mensen. Hoeveel appels krijgt ieder persoon?", "2", "3", "4", "2");
        vragenGroep6[1] = new Question("Hoeveel is 8 x 8?", "16", "32", "64", "64");
        vragenGroep6[2] = new Question("Emy heeft 43 snoepjes. Op haar verjaardag krijgt ze nog 62 snoepjes erbij. Hoeveel snoepjes heeft ze nu in totaal?", "106 snoepjes", "105 snoepjes", "104 snoepjes", "105 snoepjes");
        vragenGroep6[3] = new Question("Hoeveel is 73 - 37 ?", "36", "46", "56", "36");
        vragenGroep6[5] = new Question("Hoeveel is \u20AC 3,15 + \u20AC 1,22 ?", "\u20AC 4,36", "\u20AC 4,37", "\u20AC 4,38", "\u20AC 4,37"); //IMG
        vragenGroep6[4] = new Question("Aurora loopt 1,2 km. De volgende dag loopt ze 100 m. Hoeveel heeft je na twee dagen gelopen?", "1,21 km", "1,3 km", "2,2 km", "1,3 km");
        vragenGroep6[6] = new Question("Er zijn 111 mensen op een feestje. Er gaan 22 weg. Hoeveel mensen blijven er nog over?", "99 mensen", "89 mensen", "88 mensen", "89 mensen");
        vragenGroep6[7] = new Question("Hoeveel is 97 + 35?", "122", "123", "132", "132");
        vragenGroep6[9] = new Question("Hoeveel is 1,5 x 6?", "6,5", "7", "9", "9");
        vragenGroep6[8] = new Question("Hoeveel is 15 : 5?", "3", "2", "1", "3");

        // initialise the current question and answers
        currentQuestion = Groepvraag.question;
        currentAnswer3 = Groepvraag.answer3;
        currentAnswer2 = Groepvraag.answer2;
        currentAnswer1 = Groepvraag.answer1;
        currentRightAnswer = Groepvraag.rightAnswer;

        questionText.text = currentQuestion;
        answer3Text.text = currentAnswer3;
        answer2Text.text = currentAnswer2;
        answer1Text.text = currentAnswer1;

        Answer1Image.color = new Color(255,255,255,0);
        Answer2Image.color = new Color(255, 255, 255, 0);
        Answer3Image.color = new Color(255, 255, 255, 0);

        
    }

    // function to get next question
    void GetRandomQuestion()
    {
        Question nextQuestion;
        randomMonster = Random.Range(0,3);

        // when all the questions are asked
        if (questionIndex == 10)
        {
            // go to end phase
            anim.SetTrigger("End");
        }
        else
        {
            // when the user is in group 4
            if(schoolGroup == 4)
            {
                // select next question from group 4
                nextQuestion = vragenGroep4[questionIndex];
            }
            // when the user is in group 5
            else if (schoolGroup == 5)
            {
                // select next question from group 5
                nextQuestion = vragenGroep5[questionIndex];
            }
            // when the user is in group 6
            else
            {
                // select next question from group 6
                nextQuestion = vragenGroep6[questionIndex];
            }

            // set the next question and answers
            currentQuestion = nextQuestion.question;
            currentAnswer3 = nextQuestion.answer3;
            currentAnswer2 = nextQuestion.answer2;
            currentAnswer1 = nextQuestion.answer1;
            currentRightAnswer = nextQuestion.rightAnswer;
            currentType = nextQuestion.type;

            // set the text on the screen
            questionText.text = currentQuestion;
            answer3Text.text = currentAnswer3;
            answer2Text.text = currentAnswer2;
            answer1Text.text = currentAnswer1;

            // set the images when there is one
            currentAnswer1Image = nextQuestion.answer1Image;
            currentAnswer2Image = nextQuestion.answer2Image;
            currentAnswer3Image = nextQuestion.answer3Image;
            currentRightAnswerImage = nextQuestion.rightAnswerImage;

            Answer1Image.sprite = currentAnswer1Image;
            Answer2Image.sprite = currentAnswer2Image;
            Answer3Image.sprite = currentAnswer3Image;

            // set the random monster picture to show in the screen
            currentSprite = Monsters[randomMonster];
            monsterRandom.sprite = currentSprite;

            // if there is a question with images
            if (currentType == "img")
            {
                // show images
                Answer1Image.color = new Color(255, 255, 255, 255);
                Answer2Image.color = new Color(255, 255, 255, 255);
                Answer3Image.color = new Color(255, 255, 255, 255);
            }
            else
            {
                // don't show images
                Answer1Image.color = new Color(255, 255, 255, 0);
                Answer2Image.color = new Color(255, 255, 255, 0);
                Answer3Image.color = new Color(255, 255, 255, 0);
            }

        }


    }

    // when user chooses third answer 
    public void UserSelectAnswer3()
    {
        // if there is no right answer (only with the first question about which group)
        if (currentRightAnswer == "")
        {
            anim.SetTrigger("Group");
            // set the group to 6
            schoolGroup = 6;
            // get next question
            GetRandomQuestion();
        }
        else
        {
            // if the question is with images
            if (currentType == "img")
            {
                // look if answer is correct
                if (currentAnswer3Image == currentRightAnswerImage)
                {
                    // show on screen that the answer was correct
                    anim.SetTrigger("Right");
                    // add 1 to the question index to show the question has been answered
                    questionIndex += 1;
                    // get next question
                    GetRandomQuestion();
                }
                else
                {
                    // show on screen that the answer was wrong
                    anim.SetTrigger("Wrong");
                }
            }
            else
            {
                // look if answer is correct
                if (currentAnswer3 == currentRightAnswer)
                {
                    // show on screen that the answer was correct
                    anim.SetTrigger("Right");
                    // add 1 to the question index to show the question has been answered
                    questionIndex += 1;
                    // get next question
                    GetRandomQuestion();
                }
                else
                {
                    // show on screen that the answer was wrong
                    anim.SetTrigger("Wrong");
                }
            }
        }

    }

    public void UserSelectAnswer2()
    {
        // if there is no right answer (only with the first question about which group)
        if (currentRightAnswer == "")
        {
            anim.SetTrigger("Group");
            // set group to 5
            schoolGroup = 5;
            // get next question
            GetRandomQuestion();
        }
        else
        {
            // if the question has images
            if (currentType == "img")
            {
                // look if answer is correct
                if (currentAnswer2Image == currentRightAnswerImage)
                {
                    // show on screen that the answer was correct
                    anim.SetTrigger("Right");
                    // add 1 to the question index to show the question has been answered
                    questionIndex += 1;
                    // get next question
                    GetRandomQuestion();
                }
                else
                {
                    // show on screen that the answer was wrong
                    anim.SetTrigger("Wrong");
                }
            }
            else
            {
                // look if answer is correct
                if (currentAnswer2 == currentRightAnswer)
                {
                    // show on screen that the answer was correct
                    anim.SetTrigger("Right");
                    // add 1 to the question index to show the question has been answered
                    questionIndex += 1;
                    // get next question
                    GetRandomQuestion();
                }
                else
                {
                    // show on screen that the answer was wrong
                    anim.SetTrigger("Wrong");
                }
            }
        }
    }

    public void UserSelectAnswer1()
    {
        // if there is no right answer (only with the first question about which group)
        if (currentRightAnswer == "")
        {
            anim.SetTrigger("Group");
            // set group to 4
            schoolGroup = 4;
            // get next question
            GetRandomQuestion();
        }
        else
        {
            // if question has images
            if (currentType == "img")
            {
                // look if answer is correct
                if (currentAnswer1Image == currentRightAnswerImage)
                {
                    // show on screen that the answer was correct
                    anim.SetTrigger("Right");
                    // add 1 to the question index to show the question has been answered
                    questionIndex += 1;
                    // get next question
                    GetRandomQuestion();
                }
                else
                {
                    // show on screen that the answer was wrong
                    anim.SetTrigger("Wrong");
                }
            }
            else
            {
                // look if answer is correct
                if (currentAnswer1 == currentRightAnswer)
                {
                    // show on screen that the answer was correct
                    anim.SetTrigger("Right");
                    // add 1 to the question index to show the question has been answered
                    questionIndex += 1;
                    // get next question
                    GetRandomQuestion();
                }
                else
                {
                    // show on screen that the answer was wrong
                    anim.SetTrigger("Wrong");
                }
            }
        }
    }

    // user clicks on X on the popup
    public void ClosePopUp()
    {
        // close popup
        anim.SetTrigger("X");
    }

    // user wants to start over
    public void StartOver()
    {
        // start from beginning
        SceneManager.LoadScene("1Question");
    }

    
}
