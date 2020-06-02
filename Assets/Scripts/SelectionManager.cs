using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material highlightMaterial;

    public Material defaultMaterial;

    [Header("Items")] //Items
    [SerializeField] private string selectableTag = "Selectable"; //Another Items
    public static bool isSelected = false;
    [SerializeField] private string keyItemTag = "KeyItem"; //Another Items
    public static bool keySelected = false;

    [Header("Puzzles")] //Puzzles
    [SerializeField] private string puzzleChestTag = "PuzzleChest"; //CHEST PUZZLE
    public static bool puzzleChestSelected = false;
    [SerializeField] private string puzzleSafeTag = "PuzzleSafe"; //CHEST PUZZLE
    public static bool puzzleSafeSelected = false;

    [Header("Switches")] //Light Switch
    [SerializeField] private string switchSpawnTag = "SwitchSpawn"; //Spawn Switch
    public static bool switchSpawnSelected = false;
    [SerializeField] private string switchPianoTag = "SwitchPiano"; //Spawn Switch
    public static bool switchPianoSelected = false;
    [SerializeField] private string switchKitchenTag = "SwitchKitchen"; //Spawn Switch
    public static bool switchKitchenSelected = false;
    [SerializeField] private string switchLivingTag = "SwitchLiving"; //Spawn Switch
    public static bool switchLivingSelected = false;
    [SerializeField] private string switchKidsTag = "SwitchKids"; //Spawn Switch
    public static bool switchKidsSelected = false;


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
            keySelected = false;
            puzzleChestSelected = false;
            puzzleSafeSelected = false;
            switchSpawnSelected = false;
            switchPianoSelected = false;
            switchKitchenSelected = false;
            switchLivingSelected = false;
            switchKidsSelected = false;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Selected
            var selection = hit.transform;
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

            //Key Item Selected
            if (selection.CompareTag(keyItemTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    keySelected = true;
                }
                _selection = selection;
            }

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
        }
    }
}
