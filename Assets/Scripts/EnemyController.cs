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
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        direction = 2; 
    }

    void Update()
    {     
    }

    void OnCollisionEnter(Collision col){
        direction = 3;
    }

    void FixedUpdate()
    {
        this.transform.position += directions[direction] * movementSpeed;
    }
}
