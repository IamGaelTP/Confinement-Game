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

    [Header("Switches")]
    [SerializeField] private bool spawnTurnedOn = false;
    [SerializeField] private bool livingTurnedOn = false;
    [SerializeField] private bool kitchenTurnedOn = false;
    [SerializeField] private bool pianoTurnedOn = false;
    [SerializeField] private bool kidsTurnedOn = false;
    public GameObject
        switchSpawnRoom, lightSpawnRoom,
        switchLivingRoom, lightLivingOne, lightLivingTwo, lightLivingThree, lightLivingFour,
        switchKitchen, lightKitchenOne, lightKitchenTwo,
        switchPianoRoom, lightPianoRoom,
        switchKids, lightKidsRoom;

    [Header("Text Lights")]
    [SerializeField] private bool txt_SpawnTurnedOn = false;
    [SerializeField] private bool txt_LivingTurnedOn = false;
    public GameObject
        textSpawnOn, textSpawnOff,
        textLivingOn, textLivingOff;



    // Start is called before the first frame update
    void Awake()
    {
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

        //Switches Conditions FALSE
        spawnTurnedOn = false;
        spawnTurnedOn = false;
        livingTurnedOn = false;
        kitchenTurnedOn = false;
        pianoTurnedOn = false;
        kidsTurnedOn = false;

        //Text Lights
        textSpawnOn.SetActive(false);
        textSpawnOff.SetActive(false);
        txt_SpawnTurnedOn = false;
        textLivingOn.SetActive(false);
        textLivingOff.SetActive(false);
        txt_LivingTurnedOn = false;

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
            Destroy(gameObject);
            Debug.Log("Destruyendo");
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
        }
        
        //Key Calabozo Door
        if (Input.GetMouseButtonDown(0) && SelectionManager.keyCalabSelected == true)
        {
            keyCount += 1;
            keyDoorCalab.SetActive(false);
        }
        
        //Teddy Bear One
        if (Input.GetMouseButtonDown(0) && SelectionManager.teddyOneItemSelected == true)
        {
            teddyBearOne.SetActive(false);
            endItemsCount += 1;
        }
        
        //Teddy Bear Two
        if (Input.GetMouseButtonDown(0) && SelectionManager.teddyTwoItemSelected == true)
        {
            teddyBearTwo.SetActive(false);
            endItemsCount += 1;
        }
        
        //Medkit
        if (Input.GetMouseButtonDown(0) && SelectionManager.medkitItemSelected == true)
        {
            medkit.SetActive(false);
            endItemsCount += 1;
        }
        
        //Cruz
        if (Input.GetMouseButtonDown(0) && SelectionManager.cruzItemSelected == true)
        {
            cruz.SetActive(false);
            endItemsCount += 1;
        }
        
        //Whisky Bottle
        if (Input.GetMouseButtonDown(0) && SelectionManager.whiskyItemSelected == true)
        {
            whiskyBottle.SetActive(false);
            endItemsCount += 1;
        }
        
        //Game Cartridge Bottle
        if (Input.GetMouseButtonDown(0) && SelectionManager.gameItemSelected == true)
        {
            gameCart.SetActive(false);
            endItemsCount += 1;
        }

        /*---------------       Puzzles     ---------------*/

        //Chest Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleChestSelected == true)
        {
            isChestOpened = false;
            Debug.Log(keyCount);
            if (keyCount >= 1)
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

        //Door Calabozo Puzzle
        if (Input.GetMouseButtonDown(0) && SelectionManager.puzzleCalabSelected == true)
        {
            isCalabOpened = false;
            Debug.Log(keyCount);
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
            puzzleSafeIsActive = true;
            codePanel.SetActive(true);
            objectsCanvasActive = true;

            //Lock Camera and Movement
            FPSController.lockRotation = true; //Lock camera rotation
            FPSController.lockMovement = true; //Lock movement
        }
        if(!puzzleSafeIsSolved)
        {
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



        //WIN CONDITION
        if (endItemsCount >= 6)
        {
            //EXIT GAME
            Application.Quit();
        }
    }
}
