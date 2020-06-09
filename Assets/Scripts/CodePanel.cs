using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{

    [SerializeField]
    public Text codeText;
    string codeTextValue = "";

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if(codeTextValue == "1582") //CORRECT CODE
        {
            Invoke("WaitSeconds", 1.0f);
        }

        if (codeTextValue.Length >= 4 && codeTextValue != "1234") 
        {
            codeTextValue = "";
        }
    }

    private void WaitSeconds()
    {
        ObjectInteract.isSafeOpened = true;
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

}
