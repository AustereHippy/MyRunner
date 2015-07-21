using UnityEngine;
using System.Collections;

public class LetsPlayScript : MonoBehaviour {



    void PlayGame()
    {
        Application.LoadLevel(1);
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ChoosePlayer0()
    {
        PlayerPrefs.SetInt("player", 0);
        
        PlayGame();
    }

    public void ChoosePlayer1()
    {
        PlayerPrefs.SetInt("player", 1);
        PlayGame();
    }

}
