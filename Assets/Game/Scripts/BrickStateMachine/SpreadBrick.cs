using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBrick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BrickSpread")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Player.instance.SpreadBrick(gameObject);
        }
    }
}
