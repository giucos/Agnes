using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip mainThemeSound, itemSound, gameOver, win;
    static AudioSource audioSrc;

    void Start()
    {
        mainThemeSound = Resources.Load<AudioClip>("mainTheme");
        itemSound = Resources.Load<AudioClip>("item");
        gameOver = Resources.Load<AudioClip>("gameOver");
        win = Resources.Load<AudioClip>("win");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "mainTheme":
                audioSrc.PlayOneShot(mainThemeSound);
                break;
            case "item":
                audioSrc.PlayOneShot(itemSound);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOver);
                break;
            case "win":
                audioSrc.PlayOneShot(win);
                break;
        }
    }

    public static void MuteMainTheme()
    {
        audioSrc.Stop();
    }
}
