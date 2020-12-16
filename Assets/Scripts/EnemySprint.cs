using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprint : EnemyControllerBase
{
    private int directionChangeCounter = 0; 

    override public void setNewDirection(){
        int oldDirection = direction;

        do {
            direction = Random.Range(0,4);
        } while (direction == oldDirection);

        if (directionChangeCounter % 10 == 0)
        {
            this.movementSpeed *= 1.5f;
            Debug.Log("SpeedChange" + movementSpeed.ToString());
        } else if(directionChangeCounter % 10 == 1)
        {
            this.movementSpeed /= 1.5f;
            Debug.Log("SpeedBack" + movementSpeed.ToString());
        }

        directionChangeCounter++;
    }
}
