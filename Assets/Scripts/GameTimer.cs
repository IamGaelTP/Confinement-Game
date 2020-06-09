using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public static float timeOfDay;
    public GameObject erasePlayer, mainPlayer, crosshair;
    private float counter = 20f;

    void Awake()
    {
        mainPlayer.SetActive(false);
        crosshair.SetActive(false);
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


    }
}
