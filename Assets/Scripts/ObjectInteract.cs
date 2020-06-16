using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteract : MonoBehaviour
{

    //[Header("ObjectsFPS")] //Objects on camera (like weapons on fps)

    int keyCount = 2; 
    public int endItemsCount = 0; 
    bool objectsCanvasActive = false;

    [Header("End Puzzle")]
    public GameObject listEndCanvas, teddyBearOne, teddyBearTwo, medkit, cruz, whiskyBottle, gameCart;

    [Header("Chest Puzzle")]
    public GameObject keyChest, closedChest, openedChest;
    public static bool isChestOpened = false;

    [Header("Door Calab Puzzle")]
    public GameObject keyDoorCalab, doorCalabClose, doorCalabOpen;
    public static bool isCalabOpened = false;

    [Header("Code Puzzle")]
    public GameObject codePanel, closedSafe, openedSafe, postItCanvas;
    public static bool isSafeOpened = false;
    private bool puzzleSafeIsActive = false;
    private bool puzzleSafeIsSolved = false;

    [Header("Jigsaw One Puzzle")]
    public GameObject jigsawOnePanel;
    private bool puzzleJigsawOneIsActive = false;
    public static bool isJigsawOneIsCorrect = false;
    public static bool isJigsawOneIsSolved = false;

    [Header("Door End Room Puzzle")]
    public GameObject doorEndClose, doorEndOpen;

    [Header("Door Gun Room Puzzle")]
    public GameObject doorGunClose, doorGunOpen;

    [Header("Switches")]
    [SerializeField] private bool spawnTurnedOn = false;
    [SerializeField] private bool livingTurnedOn = false;
    [SerializeField] private bool kitchenTurnedOn = false;
    [SerializeField] private bool pianoTurnedOn = false;
    [SerializeField] private bool kidsTurnedOn = false;
    [SerializeField] private bool bathSpawnTurnedOn = false;
    public GameObject
        switchSpawnRoom, lightSpawnRoom,
        switchLivingRoom, lightLivingOne, lightLivingTwo, lightLivingThree, lightLivingFour,
        switchKitchen, lightKitchenOne, lightKitchenTwo,
        switchPianoRoom, lightPianoRoom,
        switchKids, lightKidsRoom,
        switchBathSpawn, lightBathSpawn;

    [Header("Lamps")]
    [SerializeField] private bool spawnLampOneTurnedOn = false;
    [SerializeField] private bool spawnLampTwoTurnedOn = false;
    [SerializeField] private bool kidsOneLampTurnedOn = false;
    [SerializeField] private bool kidsTwoLampTurnedOn = false;
    [SerializeField] private bool libraryLampTurnedOn = false;
    public GameObject
        lampSpawnOne, lampSpawnTwo,
        lampLibrary,
        lampKidsOne, lampKidsTwo;

    [Header("Text Lights")]
    public GameObject
        //Switches
        textSpawnOn, textSpawnOff,
        textLivingOn, textLivingOff,
        textBathSpawnOn, textBathSpawnOff,
        textKitchenOn, textKitchenOff,
        textKidsOn, textKidsOff,
        textPianoOn, textPianoOff,
        //Lamps
        textLampOneSpawnOn, textLampOneSpawnOff,
        textLampTwoSpawnOn, textLampTwoSpawnOff,
        textLampLibraryOn, textLampLibraryOff,
        textLampOneKidsOn, textLampOneKidsOff,
        textLampTwoKidsOn, textLampTwoKidsOff;

    [Header("Text Doors")]
    public GameObject
        gunDoorText,
        calabDoorText, calabDoorTextKey, calabDoorTextSpork, calabDoorTextScrewDriver,
        chestText, chestTextKey, chestTextSpork, chestTextScrewDriver,
        safeText,
        endDoorText;

    [Header("Items Grabbed for Game Timer")]
    public GameObject flashLightItem, flashLightCamera;
    //End Puzzle items
    public static bool teddyOneGrabbed = false;
    public static bool teddyTwoGrabbed = false;
    public static bool crossGrabbed = false;
    public static bool whiskyBottleGrabbed = false;
    public static bool medkitGrabbed = false;
    public static bool cartridgeGrabbed = false;
    //Other items
    public static bool screwDriverGrabbed = false;
    


    // Start is called before the first frame update
    void Awake()
    {
        endItemsCount = 0;

        //Items Grabbed for Game Timer
        flashLightItem.SetActive(true);
        flashLightCamera.SetActive(false);
        teddyOneGrabbed = false;
        teddyTwoGrabbed = false;
        crossGrabbed = false;
        whiskyBottleGrabbed = false;
        medkitGrabbed = false;
        cartridgeGrabbed = false;
        //Other items
        screwDriverGrabbed = false;

        //End Puzzle
        listEndCanvas.SetActive(false); 
        teddyBearOne.SetActive(true);
        teddyBearTwo.SetActive(true);
        medkit.SetActive(true);
        cruz.SetActive(true);
        whiskyBottle.SetActive(true);
        
        //Chest Puzzle
        keyChest.SetActive(true);
        closedChest.SetActive(true);
        openedChest.SetActive(false);

        //Calabozo Puzzle
        keyDoorCalab.SetActive(true);
        doorCalabOpen.SetActive(false);

        //Safe Puzzle
        postItCanvas.SetActive(false);
        codePanel.SetActive(false);
        closedChest.SetActive(true);
        openedChest.SetActive(false);
        puzzleSafeIsSolved = false;

        //End Door Puzzle
        doorEndClose.SetActive(true);
        doorEndOpen.SetActive(false);

        //Gun Door Puzzle
        doorGunClose.SetActive(true);
        doorGunOpen.SetActive(false);

        //Jigsaw One Puzzle
        jigsawOnePanel.SetActive(false);
        puzzleJigsawOneIsActive = false;
        isJigsawOneIsCorrect = false;
        isJigsawOneIsSolved = false;

        //Switches OFF
        lightSpawnRoom.SetActive(false);
        lightLivingOne.SetActive(false);
        lightLivingTwo.SetActive(false);
        lightLivingThree.SetActive(false);
        lightLivingFour.SetActive(false);
        lightKitchenOne.SetActive(false);
        lightKitchenTwo.SetActive(false);
        lightPianoRoom.SetActive(false);
        lightKidsRoom.SetActive(false);
        lightBathSpawn.SetActive(false);

        //Switches Conditions FALSE
        spawnTurnedOn = false;
        spawnTurnedOn = false;
        livingTurnedOn = false;
        kitchenTurnedOn = false;
        pianoTurnedOn = false;
        kidsTurnedOn = false;
        bathSpawnTurnedOn = false;

        //Lamps 
        spawnLampOneTurnedOn = false;
        spawnLampTwoTurnedOn = false;
        kidsOneLampTurnedOn = false;
        kidsTwoLampTurnedOn = false;
        libraryLampTurnedOn = false;
        lampSpawnOne.SetActive(false);
        lampSpawnTwo.SetActive(false);
        lampLibrary.SetActive(false);
        lampKidsOne.SetActive(false);
        lampKidsTwo.SetActive(false);

        //Text Switches Lights
        textSpawnOn.SetActive(false);
        textSpawnOff.SetActive(false);
        textLivingOn.SetActive(false);
        textLivingOff.SetActive(false);
        textKidsOn.SetActive(false);
        textKidsOff.SetActive(false);
        textKitchenOn.SetActive(false);
        textKitchenOff.SetActive(false);
        textPianoOn.SetActive(false);
        textPianoOff.SetActive(false);

        //Text Lamps Lights
        textLampOneSpawnOn.SetActive(false);
        textLampOneSpawnOff.SetActive(false);
        textLampTwoSpawnOn.SetActive(false);
        textLampTwoSpawnOff.SetActive(false);
        textLampLibraryOn.SetActive(false);
        textLampLibraryOff.SetActive(false);
        textLampOneKidsOn.SetActive(false);
        textLampOneKidsOff.SetActive(false);
        textLampTwoKidsOn.SetActive(false);
        textLampTwoKidsOff.SetActive(false);

        //Text Doors 
        endDoorText.SetActive(false);
        gunDoorText.SetActive(false);
        calabDoorText.SetActive(false);
        calabDoorTextKey.SetActive(false);
        calabDoorTextSpork.SetActive(false);
        calabDoorTextScrewDriver.SetActive(false);

        //Text Chest/Safe
        safeText.SetActive(false);
        chestText.SetActive(false);
        chestTextKey.SetActive(false);
        chestTextSpork.SetActive(false);
        chestTextScrewDriver.SetActive(false);


}

    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
        objectsCanvasActive = false;
        endItemsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectsCanvasActive == true && Input.GetKeyDown(KeyCode.Escape))
        {
            objectsCanvasActive = false;
        }
        if (objectsCanvasActive == false)
        {
            listEndCanvas.SetActive(false); //Disable Canvas
            postItCanvas.SetActive(false); //Disable Canvas
            codePanel.SetActive(false); //Disbale Canvas
            puzzleSafeIsActive = false; //Cursos...Lock Cursor

            //Lock Camera and Movement
            FPSController.lockRotation = false; //Lock camera rotation
            FPSController.lockMovement = false; //Lock movement
            //Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
        }


        /*---------------       Items     ---------------*/
        //Any item with tag ItemSelected
        if (Input.GetMouseButtonDown(0) && SelectionManager.isSelected == true)
        {
            /*Destroy(gameObject);
            Debug.Log("Destruyendo");*/

            //FlashLight
            flashLightItem.SetActive(false);
            flashLightCamera.SetActive(true);

            //Audio
            AudioManagerScript.isGrabbing = true;

        }

        //List End Item
        if (Input.GetMouseButtonDown(0) && SelectionManager.listEndItemSelected == true)
        {
            listEndCanvas.SetActive(true); //Active Canvas
            objectsCanvasActive = true;

            //Lock Camera and Movement
            FPSController.lockRotation = true; //Lock camera rotation
            FPSController.lockMovement = true; //Lock movement

        }

        //Post it Item
        if (Input.GetMouseButtonDown(0) && SelectionManager.postItSafeSelected == true)
        {
            postItCanvas.SetActive(true); //Active Canvas
            objectsCanvasActive = true;

            //Lock Camera and Movement
            FPSController.lockRotation = true; //Lock camera rotation
            FPSController.lockMovement = true; //Lock movement

        }

        //Key Chest
        if (Input.GetMouseButtonDown(0) && SelectionManager.keyChestSelected == true)
        {
            keyCount += 1;
            keyChest.SetActive(false);
            //Audio
            AudioManagerScript.isGrabbing = true;
        }

        //ScrewDrive
        if (Input.GetMouseButtonDown(0) && SelectionManager.keyCalabSelected == true)
        {
            keyCount += 1;
            keyDoorCalab.SetActive(false);
            screwDriverGrabbed = true;
            //Audio
            AudioManagerScript.isGrabbing = true;
        }

        //Teddy Bear One
        if (Input.GetMouseButtonDown(0) && SelectionManager.teddyOneItemSelected == true)
        {
            teddyBearOne.SetActive(false);
            endItemsCount += 1;
            teddyOneGrabbed = true;
            //Audio
            AudioManagerScript.isGrabbing = true;
        }

        //Teddy Bear Two
        if (Input.GetMouseButtonDown(0) && SelectionManager.teddyTwoItemSelected == true)
        {
            teddyBearTwo.SetActive(false);
            endItemsCount += 1;
            teddyTwoGrabbed = true;
            //Audio
            AudioManagerScript.isGrabbing = true;
        }

        //Medkit
        if (Input.GetMouseButtonDown(0) && SelectionManager.medkitItemSelected == true)
        {
            medkit.SetActive(false);
            endItemsCount += 1;
            medkitGrabbed = true;
            //Audio
            AudioManagerScript.isGrabbing = true;
        }

        //Cruz
        if (Input.GetMouseButtonDown(0) && SelectionManager.cruzItemSelected == true)
        {
            cruz.SetActive(false);
            endItemsCount += 1;
            crossGrabbed = true;
            //Audio
            AudioManagerScript.isGrabbing = true;
        }

        //Whisky Bottle
        if (Input.GetMouseButtonDown(0) && SelectionManager.whiskyItemSelected == true)
        {
            whiskyBottle.SetActive(false);
            endItemsCount += 1;
            whiskyBottleGrabbed = true;
            //Audio
            AudioManagerScript.isGrabbing = true;
        }

        //Game Cartridge Bottle
        if (Input.GetMouseButtonDown(0) && SelectionManager.gameItemSelected == true)
        {
            gameCart.SetActive(false);
            endItemsCount += 1;
            cartridgeGrabbed = true;
            //Audio
            AudioManagerScript.isGrabbing = true;
        }


        /*---------------       Puzzles     ---------------*/
        //Chest Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleChestSelected == true)
        {
            //Audio
            AudioManagerScript.toOpenChest = true;
            isChestOpened = false;

            if(isChestOpened == false && keyCount <= 0)
            {
                //Random Text
                float theNumber;
                theNumber = Random.Range(1, 4);

                switch (theNumber)
                {
                    case 1:
                        chestTextKey.SetActive(true);
                        Invoke("WaitSeconds", 1.25f);
                        break;
                    case 2:
                        chestTextSpork.SetActive(true);
                        Invoke("WaitSeconds", 1.25f);
                    break;
                    case 3:
                        chestTextScrewDriver.SetActive(true);
                        Invoke("WaitSeconds", 1.25f);
                    break;
                    
                }
            }
            
            if (keyCount >= 1)
            {
                isChestOpened = true;
                if (isChestOpened)
                {
                    closedChest.SetActive(false);
                    openedChest.SetActive(true);
                    chestTextKey.SetActive(false);
                    chestTextSpork.SetActive(false);
                    chestTextScrewDriver.SetActive(false);
                }
                keyCount--;
            }

        }

        //Door Calabozo Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleCalabSelected == true)
        {
            //Audio
            AudioManagerScript.toOpenDoor = true;
            isCalabOpened = false;

            if (isCalabOpened == false && keyCount <= 0)
            {
                //Random Text
                float theNumber2;
                theNumber2 = Random.Range(1, 4);

                switch (theNumber2)
                {
                    case 1:
                        calabDoorTextKey.SetActive(true);
                        Invoke("WaitSeconds", 1.25f);
                        break;
                    case 2:
                        calabDoorTextSpork.SetActive(true);
                        Invoke("WaitSeconds", 1.25f);
                        break;
                    case 3:
                        calabDoorTextScrewDriver.SetActive(true);
                        Invoke("WaitSeconds", 1.25f);
                        break;

                }
            }

            if (keyCount >= 1)
            {
                isCalabOpened = true;
                if (isCalabOpened)
                {
                    doorCalabClose.SetActive(false);
                    doorCalabOpen.SetActive(true);
                }
                keyCount--;
            }
        }

        //Code Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleSafeSelected == true)
        {
            //Audio
            AudioManagerScript.toOpenSafe = true;

            puzzleSafeIsActive = true;
            codePanel.SetActive(true);
            objectsCanvasActive = true;

            //Lock Camera and Movement
            FPSController.lockRotation = true; //Lock camera rotation
            FPSController.lockMovement = true; //Lock movement
        }
        if (!puzzleSafeIsSolved)
        {safeText.SetActive(true);
            if (isSafeOpened)
            {
                codePanel.SetActive(false);
                closedSafe.SetActive(false);
                openedSafe.SetActive(true);
                puzzleSafeIsSolved = true;
            }
            if (puzzleSafeIsActive == true)
            {
                //Unlock cursor
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                //Lock cursor
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {
            //Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            //Unlock Camera and Movement
            FPSController.lockRotation = false; //Unlock camera rotation
            FPSController.lockMovement = false; //Unlcok movement
        }
        
        //JigsawOne Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleJigsawOneSelected == true)
        {
            puzzleJigsawOneIsActive = true;
            jigsawOnePanel.SetActive(true);
            objectsCanvasActive = true;

            //Lock Camera and Movement
            FPSController.lockRotation = true; //Lock camera rotation
            FPSController.lockMovement = true; //Lock movement
        }
        if(!isJigsawOneIsSolved)
        {
            if (isJigsawOneIsCorrect)
            {
                jigsawOnePanel.SetActive(false);
                isJigsawOneIsSolved = true;
            }
            if (puzzleJigsawOneIsActive == true)
            {
                //Unlock cursor
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            //Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            //Unlock Camera and Movement
            FPSController.lockRotation = false; //Unlock camera rotation
            FPSController.lockMovement = false; //Unlcok movement
        }

        //Door Gun Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleGunRoomSelected == true)
        {
            //Audio
            AudioManagerScript.toOpenDoor = true;

            doorGunClose.SetActive(false);
            doorGunOpen.SetActive(true);
        }
        else
        {
            //Audio
            AudioManagerScript.toOpenDoor = false;
        }


        /*---------------       Light Switches     ---------------*/
        //Switch Spawn
        if (Input.GetMouseButtonDown(0) && SelectionManager.switchSpawnSelected == true) 
        {
            //Rotate Model 
            switchSpawnRoom.transform.Rotate(0, 0, 180);

            //Show Text
            textSpawnOn.SetActive(true);

            //Turn on - off Lights
            if (spawnTurnedOn == false)
            {
                spawnTurnedOn = true;
                lightSpawnRoom.SetActive(true);

                //Audio
                AudioManagerScript.toSwitchOn = true;

            }
            else if (spawnTurnedOn == true)
            {
                spawnTurnedOn = false;
                lightSpawnRoom.SetActive(false);

                //Audio
                AudioManagerScript.toSwitchOff = true;
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
                //Audio
                AudioManagerScript.toSwitchOn = true;
                livingTurnedOn = true;
                lightLivingOne.SetActive(true);
                lightLivingTwo.SetActive(true);
                lightLivingThree.SetActive(true);
                lightLivingFour.SetActive(true);
            }
            else if (livingTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
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
                //Audio
                AudioManagerScript.toSwitchOn = true;
                kitchenTurnedOn = true;
                lightKitchenOne.SetActive(true);
                lightKitchenTwo.SetActive(true);

            }
            else if (kitchenTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
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
                //Audio
                AudioManagerScript.toSwitchOn = true;
                pianoTurnedOn = true;
                lightPianoRoom.SetActive(true);
            }
            else if (pianoTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
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
                //Audio
                AudioManagerScript.toSwitchOn = true;
                kidsTurnedOn = true;
                lightKidsRoom.SetActive(true);
            }
            else if (kidsTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
                kidsTurnedOn = false;
                lightKidsRoom.SetActive(false);
            }
        }

        //Switch Bathroom Spawn
        if (Input.GetMouseButtonDown(0) && SelectionManager.switchBathroomSelected == true)
        {
            //Rotate Model 
            switchBathSpawn.transform.Rotate(0, 0, 180);

            //Turn on - off Lights
            if (bathSpawnTurnedOn == false)
            {
                //Audio
                AudioManagerScript.toSwitchOn = true;
                bathSpawnTurnedOn = true;
                lightBathSpawn.SetActive(true);
            }
            else if (bathSpawnTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
                bathSpawnTurnedOn = false;
                lightBathSpawn.SetActive(false);
            }
        }


        /*---------------       Lamps Lights     ---------------*/
        //Spawn Lamp One
        if (Input.GetMouseButtonDown(0) && SelectionManager.lampSpawnOneSelected == true)
        {
            //Turn on - off Lights
            if (spawnLampOneTurnedOn == false)
            {
                //Audio
                AudioManagerScript.toSwitchOn = true;
                spawnLampOneTurnedOn = true;
                lampSpawnOne.SetActive(true);

            }
            else if (spawnLampOneTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
                spawnLampOneTurnedOn = false;
                lampSpawnOne.SetActive(false);
            }
        }

        //Spawn Lamp Two
        if (Input.GetMouseButtonDown(0) && SelectionManager.lampSpawnTwoSelected == true)
        {
            //Turn on - off Lights
            if (spawnLampTwoTurnedOn == false)
            {
                //Audio
                AudioManagerScript.toSwitchOn = true;
                spawnLampTwoTurnedOn = true;
                lampSpawnTwo.SetActive(true);

            }
            else if (spawnLampTwoTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
                spawnLampTwoTurnedOn = false;
                lampSpawnTwo.SetActive(false);
            }
        }

        //Library Lamp
        if (Input.GetMouseButtonDown(0) && SelectionManager.lampLibrarySelected == true)
        {
            //Turn on - off Lights
            if (libraryLampTurnedOn == false)
            {
                //Audio
                AudioManagerScript.toSwitchOn = true;
                libraryLampTurnedOn = true;
                lampLibrary.SetActive(true);

            }
            else if (libraryLampTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
                libraryLampTurnedOn = false;
                lampLibrary.SetActive(false);
            }
        }

        //Kids Room Lamp One
        if (Input.GetMouseButtonDown(0) && SelectionManager.lampKidsOneSelected == true)
        {
            //Turn on - off Lights
            if (kidsOneLampTurnedOn == false)
            {
                //Audio
                AudioManagerScript.toSwitchOn = true;
                kidsOneLampTurnedOn = true;
                lampKidsOne.SetActive(true);

            }
            else if (kidsOneLampTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
                kidsOneLampTurnedOn = false;
                lampKidsOne.SetActive(false);
            }
        }

        //Kids Room Lamp Two
        if (Input.GetMouseButtonDown(0) && SelectionManager.lampKidsTwoSelected == true)
        {
            //Turn on - off Lights
            if (kidsTwoLampTurnedOn == false)
            {
                //Audio
                AudioManagerScript.toSwitchOn = true;
                kidsTwoLampTurnedOn = true;
                lampKidsTwo.SetActive(true);

            }
            else if (kidsTwoLampTurnedOn == true)
            {
                //Audio
                AudioManagerScript.toSwitchOff = true;
                kidsTwoLampTurnedOn = false;
                lampKidsTwo.SetActive(false);
            }
        }


        /*---------------       Text Lights Switches     ---------------*/
        //Switch Spawn Text
        if (SelectionManager.switchSpawnSelected == true)
        {
            //Turn on - off text
            if (spawnTurnedOn == false)
            {
                textSpawnOn.SetActive(true);
                textSpawnOff.SetActive(false);
            }
            else if (spawnTurnedOn == true)
            {
                textSpawnOn.SetActive(false);
                textSpawnOff.SetActive(true);
            }
        }
        else
        {
            textSpawnOn.SetActive(false);
            textSpawnOff.SetActive(false);
        }

        //Switch Bathroom Spawn Text
        if (SelectionManager.switchBathroomSelected == true)
        {
            //Turn on - off text
            if (bathSpawnTurnedOn == false)
            {
                textBathSpawnOn.SetActive(true);
                textBathSpawnOff.SetActive(false);
            }
            else if (bathSpawnTurnedOn == true)
            {
                textBathSpawnOn.SetActive(false);
                textBathSpawnOff.SetActive(true);
            }
        }
        else
        {
            textBathSpawnOn.SetActive(false);
            textBathSpawnOff.SetActive(false);
        }

        //Switch Living Text
        if (SelectionManager.switchLivingSelected == true)
        {
            //Turn on - off text
            if (livingTurnedOn == false)
            {
                textLivingOn.SetActive(true);
                textLivingOff.SetActive(false);
            }
            else if (livingTurnedOn == true)
            {
                textLivingOn.SetActive(false);
                textLivingOff.SetActive(true);
            }
        }
        else
        {
            textLivingOn.SetActive(false);
            textLivingOff.SetActive(false);
        }

        //Switch Kitchen Text
        if (SelectionManager.switchKitchenSelected == true)
        {
            //Turn on - off text
            if (kitchenTurnedOn == false)
            {
                textKitchenOn.SetActive(true);
                textKitchenOff.SetActive(false);
            }
            else if (kitchenTurnedOn == true)
            {
                textKitchenOn.SetActive(false);
                textKitchenOff.SetActive(true);
            }
        }
        else
        {
            textKitchenOn.SetActive(false);
            textKitchenOff.SetActive(false);
        }

        //Switch Kids Text
        if (SelectionManager.switchKidsSelected == true)
        {
            //Turn on - off text
            if (kidsTurnedOn == false)
            {
                textKidsOn.SetActive(true);
                textKidsOff.SetActive(false);
            }
            else if (kidsTurnedOn == true)
            {
                textKidsOn.SetActive(false);
                textKidsOff.SetActive(true);
            }
        }
        else
        {
            textKidsOn.SetActive(false);
            textKidsOff.SetActive(false);
        }

        //Switch Piano Text
        if (SelectionManager.switchPianoSelected == true)
        {
            //Turn on - off text
            if (pianoTurnedOn == false)
            {
                textPianoOn.SetActive(true);
                textPianoOff.SetActive(false);
            }
            else if (pianoTurnedOn == true)
            {
                textPianoOn.SetActive(false);
                textKidsOff.SetActive(true);
            }
        }
        else
        {
            textPianoOn.SetActive(false);
            textPianoOff.SetActive(false);
        }


        /*---------------       Text Lights Lamps     ---------------*/
        //Lamp One Spawn Text
        if (SelectionManager.lampSpawnOneSelected == true)
        {
            //Turn on - off text
            if (spawnLampOneTurnedOn == false)
            {
                textLampOneSpawnOn.SetActive(true);
                textLampOneSpawnOff.SetActive(false);
            }
            else if (spawnLampOneTurnedOn == true)
            {
                textLampOneSpawnOn.SetActive(false);
                textLampOneSpawnOff.SetActive(true);
            }
        }
        else
        {
            textLampOneSpawnOn.SetActive(false);
            textLampOneSpawnOff.SetActive(false);
        }

        //Lamp Two Spawn Text
        if (SelectionManager.lampSpawnTwoSelected == true)
        {
            //Turn on - off text
            if (spawnLampTwoTurnedOn == false)
            {
                textLampTwoSpawnOn.SetActive(true);
                textLampTwoSpawnOff.SetActive(false);
            }
            else if (spawnLampTwoTurnedOn == true)
            {
                textLampTwoSpawnOn.SetActive(false);
                textLampTwoSpawnOff.SetActive(true);
            }
        }
        else
        {
            textLampTwoSpawnOn.SetActive(false);
            textLampTwoSpawnOff.SetActive(false);
        }

        //Lamp Library Text
        if (SelectionManager.lampLibrarySelected == true)
        {
            //Turn on - off text
            if (libraryLampTurnedOn == false)
            {
                textLampLibraryOn.SetActive(true);
                textLampLibraryOff.SetActive(false);
            }
            else if (libraryLampTurnedOn == true)
            {
                textLampLibraryOn.SetActive(false);
                textLampLibraryOff.SetActive(true);
            }
        }
        else
        {
            textLampLibraryOn.SetActive(false);
            textLampLibraryOff.SetActive(false);
        }

        //Lamp Kids One Text
        if (SelectionManager.lampKidsOneSelected == true)
        {
            //Turn on - off text
            if (kidsOneLampTurnedOn == false)
            {
                textLampOneKidsOn.SetActive(true);
                textLampOneKidsOff.SetActive(false);
            }
            else if (kidsOneLampTurnedOn == true)
            {
                textLampOneKidsOn.SetActive(false);
                textLampOneKidsOff.SetActive(true);
            }
        }
        else
        {
            textLampOneKidsOn.SetActive(false);
            textLampOneKidsOff.SetActive(false);
        }

        //Lamp Kids Two Text
        if (SelectionManager.lampKidsTwoSelected == true)
        {
            //Turn on - off text
            if (kidsTwoLampTurnedOn == false)
            {
                textLampTwoKidsOn.SetActive(true);
                textLampTwoKidsOff.SetActive(false);
            }
            else if (kidsTwoLampTurnedOn == true)
            {
                textLampTwoKidsOn.SetActive(false);
                textLampTwoKidsOff.SetActive(true);
            }
        }
        else
        {
            textLampTwoKidsOn.SetActive(false);
            textLampTwoKidsOff.SetActive(false);
        }


        /*---------------       Text Doors     ---------------*/
        //Gun Room Door
        if (SelectionManager.puzzleGunRoomSelected == true)
        {
            gunDoorText.SetActive(true);
        }
        else
        {
            gunDoorText.SetActive(false);
        }
        
        //Calab Room Door
        if (SelectionManager.puzzleCalabSelected == true)
        {
            calabDoorText.SetActive(true);
        }
        else
        {
            calabDoorText.SetActive(false);
        }
        
        //End Room Door
        if (SelectionManager.puzzleEndRoomSelected == true)
        {
            endDoorText.SetActive(true);
        }
        else
        {
            endDoorText.SetActive(false);
        }

        /*---------------       Text Chest/Safe     ---------------*/
        
        //Safe - Kids Room
        if (SelectionManager.puzzleSafeSelected == true)
        {
            safeText.SetActive(true);
        }
        else
        {
            safeText.SetActive(false);
        }
       
        //Chest - Spawn Room
        if (SelectionManager.puzzleChestSelected == true)
        {
            chestText.SetActive(true);
        }
        else
        {
            chestText.SetActive(false);
        }



        /*---------------       WIN CONDITION     ---------------*/
        if (endItemsCount >= 6)
        {
            doorEndClose.SetActive(false);
            doorEndOpen.SetActive(true);
        }
        else
        {
            doorEndClose.SetActive(true);
            doorEndOpen.SetActive(false);
        }

    }

    void WaitSeconds()
    {
        chestTextKey.SetActive(false);
        chestTextSpork.SetActive(false);
        chestTextScrewDriver.SetActive(false);
        calabDoorTextKey.SetActive(false);
        calabDoorTextSpork.SetActive(false);
        calabDoorTextScrewDriver.SetActive(false);
    }
}
