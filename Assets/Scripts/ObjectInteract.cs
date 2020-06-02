using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{

    //[Header("ObjectsFPS")] //Objects on camera (like weapons on fps)

    int keyCount = 0;

    [Header("Chest Puzzle")]
    public GameObject keyChest, closedChest, openedChest;
    public static bool isChestOpened = false;

    [Header("Code Puzzle")]
    public GameObject codePanel, closedSafe, openedSafe;
    public static bool isSafeOpened = false;

    [Header("Switches")]
    [SerializeField] private bool spawnTurnedOn = false;
    [SerializeField] private bool livingTurnedOn = false;
    [SerializeField] private bool kitchenTurnedOn = false;
    [SerializeField] private bool pianoTurnedOn = false;
    [SerializeField] private bool kidsTurnedOn = false;
    public GameObject switchSpawnRoom, lightSpawnRoom, 
        switchLivingRoom, lightLivingOne, lightLivingTwo, lightLivingThree, lightLivingFour,
        switchKitchen, lightKitchenOne, lightKitchenTwo, 
        switchPianoRoom, lightPianoRoom,
        switchKids, lightKidsRoom;

    

    // Start is called before the first frame update
    void Awake()
    {
        keyChest.SetActive(true);
        closedChest.SetActive(true);
        openedChest.SetActive(false);

        codePanel.SetActive(false);
        closedChest.SetActive(true);
        openedChest.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;

        //Switches OFF
        lightSpawnRoom.SetActive(false);
        lightLivingOne.SetActive(false);
        lightLivingTwo.SetActive(false);
        lightLivingThree.SetActive(false);
        lightLivingFour.SetActive(false);
        lightKitchenOne.SetActive(false);
        lightKitchenTwo.SetActive(false);
        lightPianoRoom.SetActive(false);

        //Switches Conditions FALSE
        spawnTurnedOn = false;
        spawnTurnedOn = false;
        livingTurnedOn = false;
        kitchenTurnedOn = false;
        pianoTurnedOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*---------------       Items     ---------------*/
        if (Input.GetMouseButtonDown(0) && SelectionManager.isSelected == true)
        {
            Destroy(gameObject);
            Debug.Log("Destruyendo");
        }
        //Key
        if (Input.GetMouseButtonDown(0) && SelectionManager.keySelected == true)
        {
            keyCount += 1;
            keyChest.SetActive(false);
            Debug.Log(keyCount);
        }

        /*---------------       Puzzles     ---------------*/

        //Chest Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleChestSelected == true)
        {
            isChestOpened = false;
            Debug.Log(keyCount);
            if(keyCount >= 1)
            {
                isChestOpened = true;
                if (isChestOpened)
                {
                    closedChest.SetActive(false);
                    openedChest.SetActive(true);
                }
                keyCount--;
            }
        }

        //Code Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleSafeSelected == true)
        {
            codePanel.SetActive(true);

            if (isSafeOpened)
            {
                codePanel.SetActive(false);
                closedSafe.SetActive(false);
                openedSafe.SetActive(true);
            }
        }

        /*---------------       Switches     ---------------*/

        //Switch Spawn
        if (Input.GetMouseButtonDown(0) && SelectionManager.switchSpawnSelected == true) 
        {
            //Rotate Model 
            switchSpawnRoom.transform.Rotate(0, 0, 180);

            //Turn on - off Lights
            if (spawnTurnedOn == false)
            {
                spawnTurnedOn = true;
                lightSpawnRoom.SetActive(true);

            }
            else if (spawnTurnedOn == true)
            {
                spawnTurnedOn = false;
                lightSpawnRoom.SetActive(false);
            }
        }

        //Switch Living
        if (Input.GetMouseButtonDown(0) && SelectionManager.switchLivingSelected == true)
        {
            //Rotate Model 
            switchLivingRoom.transform.Rotate(0, 0, 180);

            //Turn on - off Lights
            if (livingTurnedOn == false)
            {
                livingTurnedOn = true;
                lightLivingOne.SetActive(true);
                lightLivingTwo.SetActive(true);
                lightLivingThree.SetActive(true);
                lightLivingFour.SetActive(true);
            }
            else if (livingTurnedOn == true)
            {
                livingTurnedOn = false;
                lightLivingOne.SetActive(false);
                lightLivingTwo.SetActive(false);
                lightLivingThree.SetActive(false);
                lightLivingFour.SetActive(false);
            }
        }

        //Switch Kitchen
        if (Input.GetMouseButtonDown(0) && SelectionManager.switchKitchenSelected == true)
        {
            //Rotate Model 
            switchKitchen.transform.Rotate(0, 0, 180);

            //Turn on - off Lights
            if (kitchenTurnedOn == false)
            {
                kitchenTurnedOn = true;
                lightKitchenOne.SetActive(true);
                lightKitchenTwo.SetActive(true);

            }
            else if (kitchenTurnedOn == true)
            {
                kitchenTurnedOn = false;
                lightKitchenOne.SetActive(false);
                lightKitchenTwo.SetActive(false);
            }
        }

        //Switch Piano
        if (Input.GetMouseButtonDown(0) && SelectionManager.switchPianoSelected == true)
        {
            //Rotate Model 
            switchPianoRoom.transform.Rotate(0, 0, 180);

            //Turn on - off Lights
            if (pianoTurnedOn == false)
            {
                pianoTurnedOn = true;
                lightPianoRoom.SetActive(true);
            }
            else if (pianoTurnedOn == true)
            {
                pianoTurnedOn = false;
                lightPianoRoom.SetActive(false);
            }
        }

        //Switch Kids
        if (Input.GetMouseButtonDown(0) && SelectionManager.switchKidsSelected == true)
        {
            //Rotate Model 
            switchKids.transform.Rotate(0, 0, 180);

            //Turn on - off Lights
            if (kidsTurnedOn == false)
            {
                kidsTurnedOn = true;
                lightKidsRoom.SetActive(true);
            }
            else if (kidsTurnedOn == true)
            {
                kidsTurnedOn = false;
                lightKidsRoom.SetActive(false);
            }
        }
    }
    
    

}
