using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    public static AudioSource bgMusic;
    public static MusicScript current;
    public static bool playBgMusic = true;
    public static bool playSounds = true;

    void Awake()
    {
        current = this;
        bgMusic = GetComponent<AudioSource>();
        PlayMusic();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayOrStop()
    {
        playBgMusic = !playBgMusic;
        if (playBgMusic)
        {
            bgMusic.Play();
        }
        else
        {
            bgMusic.Stop();
        }
    }

    public void EnableSounds()
    {
        playSounds = !playSounds;
    }

    public void PlayMusic()
    {
        if (playBgMusic && !bgMusic.isPlaying)
        {
            bgMusic.Play();
        }
    }

}
