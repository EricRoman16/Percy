using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BaseCameraScript : MonoBehaviour
{
    public Camera cam;

    public GameObject MainPoint;
    public GameObject FittingStation;
    public GameObject MissionSelection;
    public GameObject ArtDisplay;
    public GameObject CraftingStation;
    public GameObject CrashedShip;

    public string at = "MainPoint"; 

    public Transform target;
    public float smoothSpd = 0.125f;
    public Vector3 offset;
    public float smoothSizeSpd = 0.125f;
    float desiredSize = 3;

    // Start is called before the first frame update
    void Start()
    {
        target = MainPoint.transform;
        cam.orthographicSize = 3;
    }

    public void ShowFittingStation()
    {
        if(at != "FittingStation")
        {
            target = FittingStation.transform;
            desiredSize = 1.5f;
            at = "FittingStation";
        }
        else
        {
            target = MainPoint.transform;
            desiredSize = 3f;
            at = "MainPoint";
        }
    }
    public void ShowMissionSelection()
    {
        if (at != "MissionSelection")
        {
            target = MissionSelection.transform;
            desiredSize = 1.5f;
            at = "MissionSelection";
        }
        else
        {
            target = MainPoint.transform;
            desiredSize = 3f;
            at = "MainPoint";
        }
    }
    public void ShowArtDisplay()
    {
        if (at != "ArtDisplay")
        {
            target = ArtDisplay.transform;
            desiredSize = 1.5f;
            at = "ArtDisplay";
        }
        else
        {
            target = MainPoint.transform;
            desiredSize = 3f;
            at = "MainPoint";
        }
    }
    public void ShowCraftingStation()
    {
        if (at != "CraftingStation")
        {
            target = CraftingStation.transform;
            desiredSize = 1.5f;
            at = "CraftingStation";
        }
        else
        {
            target = MainPoint.transform;
            desiredSize = 3f;
            at = "MainPoint";
        }
    }
    public void ShowCrashedShip()
    {
        if (at != "CrashedShip")
        {
            target = CrashedShip.transform;
            desiredSize = 1.5f;
            at = "CrashedShip";
        }
        else
        {
            target = MainPoint.transform;
            desiredSize = 3f;
            at = "MainPoint";
        }
    }

    public void LoadMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpd);
        transform.position = smoothedPosition;

        Vector2 smoothedSize = Vector2.Lerp(new Vector2(cam.orthographicSize, 0), new Vector2(desiredSize, 0), smoothSizeSpd);
        cam.orthographicSize = smoothedSize.x;

        //If focus is upon whole scene, make it so world space buttons are not functional
    }
}
