using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {

    public Text scoreText;
    public static int score;
    public static float gameSpeed;

    void Awake()
    {

        gameSpeed = 1.2f;
        score = 0;
        ChangeTime();
    }


    void Update()
    {
        scoreText.text = "Coins: "+ score.ToString();

        switch (score)
        {
            case 30:
                gameSpeed = 1.4f;
                ChangeTime();
                break;

            case 70:
                gameSpeed = 1.6f;
                ChangeTime();
                break;

            case 120:
                gameSpeed = 1.8f;
                ChangeTime();
                break;

            case 230:
                gameSpeed = 2f;
                ChangeTime();
                break;

            case 270:
                gameSpeed = 2.2f;
                ChangeTime();
                break;

            case 320:
                gameSpeed = 2.4f;
                ChangeTime();
                break;

            default: break;
        }
            
    }


    void ChangeTime()
    {
        Time.timeScale = gameSpeed;
    }


}
