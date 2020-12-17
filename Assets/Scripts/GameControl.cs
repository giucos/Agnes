using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl: MonoBehaviour 
{
    GameObject JokerText;
    void Start(){
        FindJokerText();
        DeactivateJokerText();
    }

    private void FindJokerText(){
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("JokerText");

        if (Objects.Length > 0){
            JokerText = Objects[0];
        } else
        {
            Debug.Log("Kein JokerText Objekt gefunden");
        }
    }

    public void UseJoker(){
        StartCoroutine(InternalUseJoker());
    }

    private IEnumerator InternalUseJoker(){
        Debug.Log("UseJoker entered");
        JokerText.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1;
        DeactivateJokerText();
    }

    public void DeactivateJokerText(){
        JokerText.SetActive(false);
    }
}
