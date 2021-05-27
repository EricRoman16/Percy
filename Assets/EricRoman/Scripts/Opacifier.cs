using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opacifier : MonoBehaviour
{
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;

    public Transform target;
    public float smoothSpd = 0.125f;
    public Vector3 offset;
    public float smoothSizeSpd = 0.125f;
    float desiredSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        // makes all elements all clear
        
        b1.image.color = new Color(255, 255, 255, 0);
        b2.image.color = new Color(255, 255, 255, 0);
        b3.image.color = new Color(255, 255, 255, 0);
        b4.image.color = new Color(255, 255, 255, 0);
        b5.image.color = new Color(255, 255, 255, 0);
        b6.image.color = new Color(255, 255, 255, 0);
        b7.image.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        b1.image.color = new Color(255, 255, 255, 0);
        b2.image.color = new Color(255, 255, 255, 0);
        b3.image.color = new Color(255, 255, 255, 0);
        b4.image.color = new Color(255, 255, 255, 0);
        b5.image.color = new Color(255, 255, 255, 0);
        b6.image.color = new Color(255, 255, 255, 0);
        b7.image.color = new Color(255, 255, 255, 0);
    }

    public void ZoomIn()
    {

    }
    public void ZoomOut()
    {

    }

    void FixedUpdate()
    {
        Vector2 smoothedSize;
        smoothedSize = Vector2.Lerp(new Vector2(b1.image.color.a, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        b1.image.color = new Color(255, 255, 255, smoothedSize.x);
        smoothedSize = Vector2.Lerp(new Vector2(b2.image.color.a, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        b2.image.color = new Color(255, 255, 255, smoothedSize.x);
        smoothedSize = Vector2.Lerp(new Vector2(b3.image.color.a, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        b3.image.color = new Color(255, 255, 255, smoothedSize.x);
        smoothedSize = Vector2.Lerp(new Vector2(b4.image.color.a, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        b4.image.color = new Color(255, 255, 255, smoothedSize.x);
        smoothedSize = Vector2.Lerp(new Vector2(b5.image.color.a, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        b5.image.color = new Color(255, 255, 255, smoothedSize.x);
        smoothedSize = Vector2.Lerp(new Vector2(b6.image.color.a, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        b6.image.color = new Color(255, 255, 255, smoothedSize.x);
        smoothedSize = Vector2.Lerp(new Vector2(b7.image.color.a, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        b7.image.color = new Color(255, 255, 255, smoothedSize.x);

        //If focus is upon whole scene, make it so world space buttons are not functional
    }
}
