using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : EnemyControllerBase
{
    // Start is called before the first frame update
     
    override public void setNewDirection(){
        int oldDirection = direction;
        
        do {
            direction = Random.Range(0,4);
        } while (direction == oldDirection);
    }
}
