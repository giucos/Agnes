using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private float moveSpeed = 0.03f;
    private int count;
    private int itemCounter = 0;
    private bool HasJoker = true;
    //public Text countText;
    //public Text winText;

    Rigidbody2D rb;
    Vector2 mousePosition;
    Vector2 position = new Vector2(2.77f, -6.16f);

    public GameObject[] items;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        //winText.text = "";
        //SetCountText();
        items = GameObject.FindGameObjectsWithTag("Item");
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
        if (other.gameObject.CompareTag("Item")){

            if(items[itemCounter].name == other.name && itemCounter < items.Length)
            {
                other.gameObject.SetActive(false);
                itemCounter++;
            }           

            //SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy")){
            if (HasJoker){
                HasJoker = false;
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //void SetCountText()
    //{
    //    countText.text = "Count: " + count.ToString();
    //    if (count >= 3)
    //    {
    //        winText.text = "You Win!";
    //    }
    //}
}


