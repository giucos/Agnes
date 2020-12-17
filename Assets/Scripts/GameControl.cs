using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl: MonoBehaviour 
{
    private const string JOKER_TITLE = "JOKER";
    private const string JOKER_TAGLINE = "Glück gehabt!";
    private const string GAME_OVER_TITLE = "ERWISCHT";
    private const string GAME_OVER_TAGLINE = "Probiers nochmals"; 
    private const string WIN_TITLE = "GEWONNEN!";
    private const string WIN_TAGLINE = "";
    
    GameObject RestartButton;
    GameObject TitleTextGo;
    GameObject TaglineTextGo;
    GameObject Panel;

    void Start(){
        FindTitleAndTagline();
        RestartButton.SetActive(false);
        setActiveTitleAndTagLine(false);
    }

    private void FindTitleAndTagline(){
        GameObject[] Buttons = GameObject.FindGameObjectsWithTag("RestartButton");
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("JokerText");
        GameObject[] Panels = GameObject.FindGameObjectsWithTag("OverlayPanel");
        Panel = Panels[0];
        RestartButton = Buttons[0];


        if (Objects.Length == 2){
            Debug.Log(Objects[0].ToString() + Objects[1].ToString() + "aus Array");
            if (Objects[0].name == "TitleText") {
                TitleTextGo = Objects[0];
                TaglineTextGo = Objects[1];
            } else {
                TitleTextGo = Objects[1];
                TaglineTextGo = Objects[0];
            }
            Debug.Log(TitleTextGo.ToString() + TaglineTextGo.ToString() + "zugewiesen Objekte");
        } else
        {
            Debug.Log("Kein Title/Tagline Objekt gefunden");
        }
    }

    public void Win(){
        RestartButton.SetActive(true);
        TitleTextGo.GetComponent<Text>().text = WIN_TITLE;
        TaglineTextGo.GetComponent<Text>().text = WIN_TAGLINE;
        setActiveTitleAndTagLine(true);
        Time.timeScale = 0;
    }

    public void GameOver(){
        RestartButton.SetActive(true);
        TitleTextGo.GetComponent<Text>().text = GAME_OVER_TITLE;
        TaglineTextGo.GetComponent<Text>().text = GAME_OVER_TAGLINE;
        setActiveTitleAndTagLine(true);
        Time.timeScale = 0;
    }

    public void RestartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UseJoker(){
        TitleTextGo.GetComponent<Text>().text = JOKER_TITLE;
        TaglineTextGo.GetComponent<Text>().text = JOKER_TAGLINE;
        StartCoroutine(InternalUseJoker());
    }

    private IEnumerator InternalUseJoker(){
        Debug.Log("UseJoker entered");
        setActiveTitleAndTagLine(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        setActiveTitleAndTagLine(false);
    }

    private void setActiveTitleAndTagLine(bool isActive){
        TitleTextGo.SetActive(isActive);
        TaglineTextGo.SetActive(isActive);
        Panel.SetActive(isActive);
    }
}
