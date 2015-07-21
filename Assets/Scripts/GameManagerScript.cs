using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript current;
    public GameObject player0, player1;
    GameObject player;
    public Text gameOverText;
    public Animator anim;
    public GameObject restartButton;
    PlayerController playerController;
    int numOfPlayer;
    bool paused;
    public float gameSpeed;
    
    void Awake()
    {
        current = this;
        numOfPlayer = PlayerPrefs.GetInt("player");


        switch (numOfPlayer)
        {
            case 0:
                player0.SetActive(true);
                player1.SetActive(false);
                

                break;
            case 1:
                player1.SetActive(true);
                player0.SetActive(false);
                

                break;

            default:
                break;
        }

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        paused = false;
        

    }

    void Start()
    {
        MusicScript.current.PlayMusic();
    }


    public void GameOver()
    {
        if (PlayerPrefs.GetString("Name") == "")
        {
            gameOverText.text = "You collect " + ScoreManagerScript.score.ToString() + " coins!";
        }
        else
        {
            gameOverText.text = "Hey, " + PlayerPrefs.GetString("Name") + "! you collect " + ScoreManagerScript.score.ToString() + " coins!";
        }
            anim.SetTrigger("dead");
            playerController.isDead = false;
        
    }


    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ToMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
        }
        else if (paused)
        {
            Time.timeScale = ScoreManagerScript.gameSpeed;
        }

        paused = !paused;
    }

}
