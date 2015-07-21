using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    Animator anim;
    public Text musicText, soundText, enterYourNameText, nameText;
    
    
    public GameObject players;

    void Awake()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 1;
        Music();
        Sounds();
    }

    void Start()
    {
        if (PlayerPrefs.GetString("Name") == "")
        {
            enterYourNameText.text = "enter your name";
        }
        else
        {
            enterYourNameText.text = PlayerPrefs.GetString("Name");
            
        }
    }

    public void ChangeName()
    {
        PlayerPrefs.SetString("Name", nameText.text);
    }


    public void Settings()
    {
        anim.SetBool("Settings", true);
        
    }

    public void Music()
    {
        if (MusicScript.playBgMusic)
        {
            musicText.text = "Music\n on";
        }
        else
        {
            musicText.text = "Music\n off";
        }
    }

    public void Sounds()
    {
        if (MusicScript.playSounds)
        {
            soundText.text = "Sounds\n" + "on";
        }
        else
        {
            soundText.text = "Sounds\n off";
        }
    }

    public void Back()
    {
        anim.SetBool("Settings", false);
        anim.SetBool("Play", false);
        players.SetActive(false);
    }

    public void Play()
    {
        anim.SetBool("Play", true);
        players.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }



}
