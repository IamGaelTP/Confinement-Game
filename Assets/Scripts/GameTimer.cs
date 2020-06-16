using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    [Header("Player Starts")]
    public static float timeOfDay;
    public GameObject erasePlayer, mainPlayer, crosshair;
    private float counter = 20f;

    [Header("Rooms to Close")]
    public GameObject
        closedPianoRoom,
        closedLibraryRoom,
        closedToiletRoom,
        closedBathroom,
        closedCorridorTopFloor,
        enableToiletDoor,
        enableLibraryDoor,
        enableBathroomDoor;


    void Awake()
    {
        mainPlayer.SetActive(false);
        crosshair.SetActive(false);

        closedPianoRoom.SetActive(false);
        closedLibraryRoom.SetActive(false);
        closedToiletRoom.SetActive(false);
        closedBathroom.SetActive(false);
        closedCorridorTopFloor.SetActive(false);
        enableToiletDoor.SetActive(true);
        enableLibraryDoor.SetActive(true);
        enableBathroomDoor.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime;
            counter = timeOfDay; 
        }

        //Erase START Player Animation
        if (counter >= 11.0f && counter <= 13.0f)
        {
            erasePlayer.SetActive(false);
            mainPlayer.SetActive(true);
            crosshair.SetActive(true);
        }

        //CLOSE ROOMS
        if(ObjectInteract.teddyOneGrabbed == true && ObjectInteract.screwDriverGrabbed == true)
        {
            //Close Piano Room
            closedPianoRoom.SetActive(true);
        }
        else if (ObjectInteract.teddyTwoGrabbed == true && ObjectInteract.screwDriverGrabbed == true)
        {
            //Close Piano Room
            closedPianoRoom.SetActive(true);
        }

        if (ObjectInteract.teddyOneGrabbed == true && ObjectInteract.cartridgeGrabbed == true)
        {
            //Close Library
            closedLibraryRoom.SetActive(true);
            enableLibraryDoor.SetActive(false);
        }

        if (ObjectInteract.teddyOneGrabbed == true && ObjectInteract.screwDriverGrabbed == true && ObjectInteract.crossGrabbed == true)
        {
            //Close Corridor to Piano-Kids Room
            //closedCorridorTopFloor.SetActive(true);
            //Close Bathroom
            closedBathroom.SetActive(true);
            enableBathroomDoor.SetActive(false);
        }

        if (ObjectInteract.crossGrabbed == true && ObjectInteract.teddyOneGrabbed == true && ObjectInteract.teddyTwoGrabbed == true && 
            ObjectInteract.screwDriverGrabbed == true && ObjectInteract.cartridgeGrabbed == true)
        {
            //Close Toilet
            closedToiletRoom.SetActive(true);
            enableToiletDoor.SetActive(false);
        }



    }
}
