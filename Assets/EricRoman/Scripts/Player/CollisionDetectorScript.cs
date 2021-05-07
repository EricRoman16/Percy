using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectorScript : MonoBehaviour
{
    public bool wallHere = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            wallHere = true;
        }
        else
        {
            wallHere = false;
        }
    }
}
