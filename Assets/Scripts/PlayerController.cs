using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private float moveSpeed = 0.05f;
    private int itemCounter = 0;

    public Text blumentopfText, gräsliText, giesskanneText, kompostText, rasenmäherText, schaufelText;

    private bool HasJoker = true;

    Rigidbody2D rb;
    Vector2 mousePosition;
    Vector2 position = new Vector2(2.77f, -6.16f);

    public GameObject[] items;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        items = GameObject.FindGameObjectsWithTag("Item");
        blumentopfText.text = "1. Pflücke die Rose";
        gräsliText.text = "2. Ernte das Gras";
        giesskanneText.text = "3. Giesse die Blumen";
        kompostText.text = "4. Kompostiere den Abfall";
        rasenmäherText.text = "5. Mähe den Rasen";
        schaufelText.text = "6. Hole die Schaufel";
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
                CheckItemList();               
                itemCounter++;

            }
        } else if (other.gameObject.CompareTag("Enemy")){
            if (HasJoker){
                HasJoker = false;
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void CheckItemList()
    { 
        if (itemCounter == 0)
        {
            blumentopfText.text = "1. Pflücke die Rose" + "\u2714";
        } else if (itemCounter == 1)
        {
            gräsliText.text = "2. Ernte das Gras" + "\u2714";
        } else if (itemCounter == 2)
        {
            giesskanneText.text = "3. Giesse die Blumen" + "\u2714";
        } else if (itemCounter == 3)
        {
            kompostText.text = "4. Kompostiere den Abfall" + "\u2714";
        } else if (itemCounter == 4)
        {
            rasenmäherText.text = "5. Mähe den Rasen" + "\u2714";
        } else if (itemCounter == 5)
        {
            schaufelText.text = "6. Hole die Schaufel" + "\u2714";
        }
    }

}


