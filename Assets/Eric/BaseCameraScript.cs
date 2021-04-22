using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCameraScript : MonoBehaviour
{
    public Camera cam;

    public GameObject FittingStation;
    public GameObject MissionSelection;
    public GameObject ArtDisplay;
    public GameObject CraftingStation;
    public GameObject CrashedShip;


    public Transform target;
    public float smoothSpd = 0.125f;
    public Vector3 offset;
    //public float smoothSizeSpd = 0.125f;
    //float desiredSize;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, -10f);
        cam.orthographicSize = 3;
    }

    public void ShowFittingStation()
    {
        target = FittingStation.transform;
    }
    public void ShowMissionSelection()
    {
        target = MissionSelection.transform;
    }
    public void ShowArtDisplay()
    {
        target = ArtDisplay.transform;
    }
    public void ShowCraftingStation()
    {
        target = CraftingStation.transform;
    }
    public void ShowCrashedShip()
    {
        target = CrashedShip.transform;
    }


    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpd);
        transform.position = smoothedPosition;

        //Vector2 smoothedSize = Vector2.Lerp(new Vector2(cam.orthographicSize, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        //cam.orthographicSize = smoothedSize.x;
    }
}
