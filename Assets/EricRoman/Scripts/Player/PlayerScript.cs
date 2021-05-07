using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    public CollisionDetectorScript north;
    public CollisionDetectorScript east;
    public CollisionDetectorScript south;
    public CollisionDetectorScript west;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !west)
        {
            transform.position += new Vector3(Mathf.Floor(Input.GetAxisRaw("Horizontal")), 0f, 0f);
            //Vector3.Lerp(transform.position, transform.position + new Vector3(-1f, 0f, 0f), .1f);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !east)
        {
            transform.position += new Vector3(Mathf.Floor(Input.GetAxisRaw("Horizontal")), 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.W) && !north)
        {
            transform.position += new Vector3(0f, Mathf.Floor(Input.GetAxisRaw("Vertical")), 0f);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !south)
        {
            transform.position += new Vector3(0f, Mathf.Floor(Input.GetAxisRaw("Vertical")), 0f);
        }
    }

    
}
