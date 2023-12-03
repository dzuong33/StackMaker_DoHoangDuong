using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBrick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BrickPickup")
        {
            other.gameObject.tag = "normal";
            other.gameObject.transform.SetParent(null);
            Player.instance.stackBricks.Add(other.gameObject);
            Player.instance.PickUpBrick(other.gameObject);
        }
        
    }
    
}
