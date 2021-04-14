using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public GameObject Player;
    public bool FollowPlayer = true;
    public bool Peeking;

    public float smoothSpd = 0.05f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float yy = Player.transform.position.y - worldPosition.y;
        float xx = Player.transform.position.x - worldPosition.x;


        float a = Mathf.Atan(yy / xx);
        Debug.Log(a);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Peeking = true;
            FollowPlayer = false;
        }
        else
        {
            Peeking = false;
            FollowPlayer = true;
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float a = Player.transform.position.x - mousePosition.x;
        float b = Player.transform.position.y - mousePosition.y;
        float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        float theta = Mathf.Asin(b / c); // this is in radians!!!

        float b2 = Mathf.Sin(theta);
        float a2 = Mathf.Cos(theta);

        offset = new Vector3(a2, b2, -10f);
        if (Peeking)
        {
            Vector3 desiredPosition = Player.transform.position + (2 * offset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpd);
            transform.position = smoothedPosition;
            
        }
    }

    void LateUpdate()
    {
        if (FollowPlayer)
            transform.position = Player.transform.position + new Vector3(0f,0f,-10f);

    }
}
