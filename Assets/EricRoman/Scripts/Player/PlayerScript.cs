using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2;

    public Vector2 ForceTarget;

    public bool speedUpgrade;
    public bool smokeUpgrade;
    public bool shieldUpgrade;
    public int healthUpgrade;
    public int scrap;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (speedUpgrade)
        {
            case true:
                ForceTarget = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                rb2.AddForce(ForceTarget);
                break;
            default:
                ForceTarget = new Vector2(Input.GetAxis("Horizontal") / 2, Input.GetAxis("Vertical") / 2);
                rb2.AddForce(ForceTarget);
                break;
        }

    }

    
}
