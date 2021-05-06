using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D North;
    public BoxCollider2D South;
    public BoxCollider2D East;
    public BoxCollider2D West;
    public CompositeCollider2D Obstacle;
    public bool north;
    public bool east;
    public bool south;
    public bool west;//bad coding but whatever
    void Start()
    {
        //Obstacle = GameObject.Find("Obsticles");
    }

    // Update is called once per frame
    void Update()
    {
        if (West.IsTouching(Obstacle)){
            west = true;
        }
        else
        {
            west = false;
        }
        if (North.IsTouching(Obstacle)){
            north = true;
        }
        else
        {
            north = false;
        }
        if (East.IsTouching(Obstacle)){
            east = true;
        }
        else
        {
            east = false;
        }
        if (South.IsTouching(Obstacle)){
            south= true;
        }
        else
        {
            south = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(Mathf.Floor(Input.GetAxisRaw("Horizontal")), 0f, 0f);
            //Vector3.Lerp(transform.position, transform.position + new Vector3(-1f, 0f, 0f), .1f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(Mathf.Floor(Input.GetAxisRaw("Horizontal")), 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, Mathf.Floor(Input.GetAxisRaw("Vertical")), 0f);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0f, Mathf.Floor(Input.GetAxisRaw("Vertical")), 0f);
        }
    }

    
}
