using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private GameControl GameController;
    private float moveSpeed = 0.05f;
    private int itemCounter = 0;

    public Text blumentopfText, gräsliText, giesskanneText, kompostText, rasenmäherText, schaufelText;

    private bool HasJoker = true;

    Rigidbody2D rb;
    Vector2 mousePosition;
    Vector2 position = new Vector2(1.93f, -14.83f);

    public GameObject[] items;
    
    void Start()
    {
        GameController = GetComponent<GameControl>();
        rb = GetComponent<Rigidbody2D>();
        items = GameObject.FindGameObjectsWithTag("Item");

        blumentopfText.text = "1. Rose";
        gräsliText.text = "2. Gras";
        giesskanneText.text = "3. Giessekanne";
        kompostText.text = "4. Kompost";
        rasenmäherText.text = "5. Rasenmäher";
        schaufelText.text = "6. Schaufel";   

    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item")) {

            if (items[itemCounter].name == other.name && itemCounter < items.Length)
            {
                other.gameObject.SetActive(false);
                SoundManager.PlaySound("item");
                CheckItemList();               
                itemCounter++;
            }

            if (itemCounter == 1){
                GameController.Win();
            }
        } else if (other.gameObject.CompareTag("Enemy")){
            if (HasJoker){
                GameController.UseJoker();
                HasJoker = false;
            } else {
                SoundManager.MuteMainTheme();
                SoundManager.PlaySound("gameOver");
                GameController.GameOver();
            }
        }
    }

    void CheckItemList()
    { 
        if (itemCounter == 0)
        {
            blumentopfText.text = "1. Rose" + "\u2714";
        } else if (itemCounter == 1)
        {
            gräsliText.text = "2. Gras" + "\u2714";
        } else if (itemCounter == 2)
        {
            giesskanneText.text = "3. Giessekanne" + "\u2714";
        } else if (itemCounter == 3)
        {
            kompostText.text = "4. Kompost" + "\u2714";
        } else if (itemCounter == 4)
        {
            rasenmäherText.text = "5. Rasenmäher" + "\u2714";
        } else if (itemCounter == 5)
        {
            schaufelText.text = "6. Schaufel" + "\u2714";
        }
    }
}


