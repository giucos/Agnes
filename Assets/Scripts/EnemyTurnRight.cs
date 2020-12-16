using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnRight : EnemyControllerBase
{
    private int directionChangeCounter = 0;
    
    override public void setNewDirection(){
        directionChangeCounter++;

        if ((directionChangeCounter % 4) == 1){
            if (direction >= 3){
                direction = 0;
            }
            direction++;
        } else {
            if (direction <= 0){
                direction = 3;
            }
            direction--;
        }
    }
}
