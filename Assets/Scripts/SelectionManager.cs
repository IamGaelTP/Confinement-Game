using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material highlightMaterial;

    public Material defaultMaterial;

    [Header("Items")] //Items
    [SerializeField] private string selectableTag = "Selectable"; //Another Items
    public static bool isSelected = false;
    [SerializeField] private string listEndItemTag = "ListEndItem"; //List item of the end puzzle
    public static bool listEndItemSelected = false;
    [SerializeField] private string keyChestTag = "KeyChest"; //Key for Chest
    public static bool keyChestSelected = false;
    [SerializeField] private string keyCalabTag = "KeyCalab"; //Key for Calabozo Door
    public static bool keyCalabSelected = false;
    [SerializeField] private string medkitItemTag = "MedkitItem"; //Medkit for End Puzzle
    public static bool medkitItemSelected = false;
    [SerializeField] private string teddyOneItemTag = "TeddyItemOne"; //Teddy bear for End Puzzle
    public static bool teddyOneItemSelected = false;
    [SerializeField] private string teddyTwoItemTag = "TeddyItemTwo"; //Teddy bear for End Puzzle
    public static bool teddyTwoItemSelected = false;
    [SerializeField] private string cruzItemTag = "CruzItem"; //Cross for End Puzzle
    public static bool cruzItemSelected = false;
    [SerializeField] private string whiskyItemTag = "WhiskyItem"; //Whisky for End Puzzle
    public static bool whiskyItemSelected = false;
    [SerializeField] private string gameItemTag = "GameItem"; //Game cartridge Cartucho for End Puzzle
    public static bool gameItemSelected = false;

    [Header("Puzzles")] //Puzzles
    [SerializeField] private string puzzleChestTag = "PuzzleChest"; //Chest Puzzle
    public static bool puzzleChestSelected = false;
    [SerializeField] private string puzzleCalabTag = "PuzzleCalab"; //Chest Puzzle
    public static bool puzzleCalabSelected = false;
    [SerializeField] private string puzzleSafeTag = "PuzzleSafe"; //Safe Puzzle
    public static bool puzzleSafeSelected = false;
    [SerializeField] private string postItSafeTag = "PostItSafe"; //Safe Puzzle
    public static bool postItSafeSelected = false;
    [SerializeField] private string puzzleJigsawOneTag = "PuzzleJigsawOne"; //Jigsaw Puzzle
    public static bool puzzleJigsawOneSelected = false;
    [SerializeField] private string puzzleGunRoomTag = "PuzzleGunRoom"; //Puzzle GunRoom
    public static bool puzzleGunRoomSelected = false;
    [SerializeField] private string puzzleEndRoomTag = "PuzzleEndRoom"; //Puzzle GunRoom
    public static bool puzzleEndRoomSelected = false;


    [Header("Switches")] //Light Switch
    [SerializeField] private string switchSpawnTag = "SwitchSpawn"; //Spawn Switch
    public static bool switchSpawnSelected = false;
    [SerializeField] private string switchBathroomTag = "SwitchBathroom"; //Spawn Nathroom Switch
    public static bool switchBathroomSelected = false;
    [SerializeField] private string switchPianoTag = "SwitchPiano"; //Living Switch
    public static bool switchPianoSelected = false;
    [SerializeField] private string switchKitchenTag = "SwitchKitchen"; //Kitchen Switch
    public static bool switchKitchenSelected = false;
    [SerializeField] private string switchLivingTag = "SwitchLiving"; //Living Switch
    public static bool switchLivingSelected = false;
    [SerializeField] private string switchKidsTag = "SwitchKids"; //Kids Switch
    public static bool switchKidsSelected = false;

    [Header("Switches")] //Light Lamps
    [SerializeField] private string lampSpawnOneTag = "LampSpawnOne"; //Spawn Lamp One
    public static bool lampSpawnOneSelected = false;
    [SerializeField] private string lampSpawnTwoTag = "LampSpawnTwo"; //Spawn Lamp Two
    public static bool lampSpawnTwoSelected = false;
    [SerializeField] private string lampLibraryTag = "LampLibrary"; //Library Lamp
    public static bool lampLibrarySelected = false;
    [SerializeField] private string lampKidsOneTag = "LampKidsOne"; //Kids One Lamp
    public static bool lampKidsOneSelected = false;
    [SerializeField] private string lampKidsTwoTag = "LampKidsTwo"; //Kids Two Lamp
    public static bool lampKidsTwoSelected = false;


    Transform _selection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            //No Selected
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
            isSelected = false;
            //Items
            listEndItemSelected = false;
            keyChestSelected = false;
            keyCalabSelected = false;
            medkitItemSelected = false;
            teddyOneItemSelected = false;
            teddyTwoItemSelected = false;
            cruzItemSelected = false;
            whiskyItemSelected = false;
            //Puzzles
            puzzleChestSelected = false;
            puzzleSafeSelected = false;
            postItSafeSelected = false;
            puzzleJigsawOneSelected = false;
            puzzleCalabSelected = false;
            puzzleEndRoomSelected = false;
            puzzleGunRoomSelected = false;
            //Switches
            switchSpawnSelected = false;
            switchBathroomSelected = false;
            switchPianoSelected = false;
            switchKitchenSelected = false;
            switchLivingSelected = false;
            switchKidsSelected = false;
            //Lamps
            lampSpawnOneSelected = false;
            lampSpawnTwoSelected = false;
            lampLibrarySelected = false;
            lampKidsOneSelected = false;
            lampKidsTwoSelected = false;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3))
        {
            //Selected
            var selection = hit.transform;


            /*---------------       Items     ---------------*/

            //Items selected
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    isSelected = true;
                }
                _selection = selection;
            }

            //End List Selected
            if (selection.CompareTag(listEndItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    listEndItemSelected = true;
                }
                _selection = selection;
            }

            //Post it Safe Selected
            if (selection.CompareTag(postItSafeTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    postItSafeSelected = true;
                }
                _selection = selection;
            }

            //Key Chest Selected
            if (selection.CompareTag(keyChestTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    keyChestSelected = true;
                }
                _selection = selection;
            }

            //Key Calab Selected
            if (selection.CompareTag(keyCalabTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    keyCalabSelected = true;
                }
                _selection = selection;
            }

            //Medkit Selected
            if (selection.CompareTag(medkitItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    medkitItemSelected = true;
                }
                _selection = selection;
            }

            //Teddy One Selected
            if (selection.CompareTag(teddyOneItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    teddyOneItemSelected = true;
                }
                _selection = selection;
            }

            //Teddy Two Selected
            if (selection.CompareTag(teddyTwoItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    teddyTwoItemSelected = true;
                }
                _selection = selection;
            }

            //Cruz Selected
            if (selection.CompareTag(cruzItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    cruzItemSelected = true;
                }
                _selection = selection;
            }

            //Whsky Bottle Selected
            if (selection.CompareTag(whiskyItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    whiskyItemSelected = true;
                }
                _selection = selection;
            }
            
            //Game Cartridge Selected
            if (selection.CompareTag(gameItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    gameItemSelected = true;
                }
                _selection = selection;
            }


            /*---------------       Puzzles     ---------------*/

            //Puzzle Chest Selected
            if (selection.CompareTag(puzzleChestTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    puzzleChestSelected = true;
                }
                _selection = selection;
            }

            //Puzzle Safe Selected
            if (selection.CompareTag(puzzleSafeTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    puzzleSafeSelected = true;
                }
                _selection = selection;
            }

            //Puzzle Door Calab Selected
            if (selection.CompareTag(puzzleCalabTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    puzzleCalabSelected = true;
                }
                _selection = selection;
            }

            //Puzzle JigsawOne Selected
            if (selection.CompareTag(puzzleJigsawOneTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    puzzleJigsawOneSelected = true;
                }
                _selection = selection;
            }

            //Puzzle Gun Room Selected
            if (selection.CompareTag(puzzleGunRoomTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    puzzleGunRoomSelected = true;
                }
                _selection = selection;
            }

            //Puzzle End Room Selected
            if (selection.CompareTag(puzzleEndRoomTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    puzzleEndRoomSelected = true;
                }
                _selection = selection;
            }


            /*---------------       Switches     ---------------*/

            //Switch Spawn Selected
            if (selection.CompareTag(switchSpawnTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    switchSpawnSelected = true;
                }
                _selection = selection;
            }

            //Switch Piano Selected
            if (selection.CompareTag(switchPianoTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    switchPianoSelected = true;
                }
                _selection = selection;
            }

            //Switch Kitchen Selected
            if (selection.CompareTag(switchKitchenTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    switchKitchenSelected = true;
                }
                _selection = selection;
            }

            //Switch Living Selected
            if (selection.CompareTag(switchLivingTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    switchLivingSelected = true;
                }
                _selection = selection;
            }

            //Switch Kids Selected
            if (selection.CompareTag(switchKidsTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    switchKidsSelected = true;
                }
                _selection = selection;
            }

            //Switch Bathroom Spawn Selected
            if (selection.CompareTag(switchBathroomTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    switchBathroomSelected = true;
                }
                _selection = selection;
            }


            /*---------------       Lamps     ---------------*/
            //Lamp One Spawn Selected
            if (selection.CompareTag(lampSpawnOneTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    lampSpawnOneSelected = true;
                }
                _selection = selection;
            }


            //Lamp Two Spawn Selected
            if (selection.CompareTag(lampSpawnTwoTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    lampSpawnTwoSelected = true;
                }
                _selection = selection;
            }

            //Lamp Library Selected
            if (selection.CompareTag(lampLibraryTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    lampLibrarySelected = true;
                }
                _selection = selection;
            }

            //Lamp Kids One Selected
            if (selection.CompareTag(lampKidsOneTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    lampKidsOneSelected = true;
                }
                _selection = selection;
            }

            //Lamp Kids Two Selected
            if (selection.CompareTag(lampKidsTwoTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    lampKidsTwoSelected = true;
                }
                _selection = selection;
            }

        }
    }
}
