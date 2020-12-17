using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl: MonoBehaviour 
{
    private const string JOKER_TITLE = "JOKER";
    private const string JOKER_TAGLINE = "Glück gehabt!";
    private const string GAME_OVER_TITLE = "ERWISCHT";
    private const string GAME_OVER_TAGLINE = "Probiers nochmals"; 
    private const string WIN_TITLE = "GEWONNEN!";
    private const string WIN_TAGLINE = "";

    GameObject TitleText;
    GameObject TagLineText;
    void Start(){
        FindTitleAndTagline();
        DeactivateTitleAndTagline();
    }

    private void FindTitleAndTagline(){
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("JokerText");

        if (Objects.Length = 2){
            if (Objects[0].name = "Title") {
                TitleText = Objects[0];
                TagLineText = Objects[1];
            } else {
                TitleText = Objects[1];
                TagLineText = Objects[0];
            }
        } else
        {
            Debug.Log("Kein Title/Tagline Objekt gefunden");
        }
    }

    public void Win(){
        TitleText.text = WIN_TITLE;
        TagLineText.text = WIN_TAGLINE;
        setActiveTitleAndTagLine(true);
    }

    public void GameOver(){
        TitleText.text = GAME_OVER_TITLE;
        Tagline.text = GAME_OVER_TAGLINE;
        setActiveTitleAndTagLine(true);
    }

    public void RestartGame(){
        
    }

    public void UseJoker(){
        StartCoroutine(InternalUseJoker());
    }

    private IEnumerator InternalUseJoker(){
        Debug.Log("UseJoker entered");
        setActiveTitleAndTagLine(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1;
        setActiveTitleAndTagLine(false);
    }

    private void setActiveTitleAndTagLine(bool isActive){
        TitleText.SetActive(isActive);
        TagLineText.SetActive(isActive);
    }
}
