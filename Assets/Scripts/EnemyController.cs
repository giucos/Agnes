using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 0.015f;
    
    private Rigidbody2D myRigidbody;

    private int direction;
    private static Vector3[] directions = { Vector3.up, Vector3.right, Vector3.down, Vector3.left };
    Vector2 position = new Vector2(8.4f, -12.1f);

    private Vector3 oldPosition;
    private int StillFrameCounter = 0;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        direction = 0; 
        oldPosition = position;
    }

    void Update()
    {     
        if (this.transform.position == oldPosition)  {
            StillFrameCounter++;

            if (StillFrameCounter >= 20) {
                setNewRandomdirection();
            }
        } else {
            oldPosition = this.transform.position;
            StillFrameCounter = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        setNewRandomdirection();
        
        // Debug.Log("Collision detected + direction" + direction.ToString() + " old direction " + oldDirection.ToString());
    }

    void FixedUpdate()
    {
        this.transform.position += directions[direction] * movementSpeed;
    }

    void setNewRandomdirection(){
        int oldDirection = direction;
        do {
            direction = Random.Range(0,4);
        } while (direction == oldDirection);
    }
}
