﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBase : MonoBehaviour
{
    private const int MAX_STOP_FRAME_COUNT = 20;
    internal float movementSpeed = 0.09f; 
    internal int direction;
    internal static Vector3[] directions = { Vector3.up, Vector3.right, Vector3.down, Vector3.left };
    
    private Vector3 oldPosition;

    private int StillFrameCounter = 0;
    
    void Start()
    {
        direction = 0; 
        oldPosition = this.transform.position;
    }

    void Update()
    {     
        if (this.transform.position == oldPosition)  {
            StillFrameCounter++;

            if (StillFrameCounter >= MAX_STOP_FRAME_COUNT) {
                setNewDirection();
            }
        } else {
            oldPosition = this.transform.position;
            StillFrameCounter = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        setNewDirection();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Safezone")){
            setNewDirection();
        }
    }

    void FixedUpdate()
    {
        this.transform.position += directions[direction] * movementSpeed;
    }

    virtual public void setNewDirection(){
        Debug.Log("Base Class setNewDirection entered");
    }
}
