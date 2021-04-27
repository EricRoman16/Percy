using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    public Sprite Up;
    public Sprite Down;
    public Sprite Right;
    public Sprite Left;

    public SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        SR.sprite = Down;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SR.sprite = Left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SR.sprite = Down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SR.sprite = Right;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SR.sprite = Up;
        }
    }
}
