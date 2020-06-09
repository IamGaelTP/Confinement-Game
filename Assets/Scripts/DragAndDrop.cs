using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("JigsawOnePiece"))
                {
                    SelectedPiece = hit.transform.gameObject;
                    Debug.Log("SELECCIONADO");
                }

            }   
        }
        if (SelectedPiece != null)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            SelectedPiece.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }
    }
}
