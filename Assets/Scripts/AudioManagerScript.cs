using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
   // public AudioManager audiosource;

    public static bool isWalking = false;
    public static bool isGrabbing = false;
    public static bool toOpenChest = false;
    public static bool toOpenSafe = false;
    public static bool toSwitchOn = false;
    public static bool toSwitchOff = false;
    public static bool toOpenDoor = false;
    public static bool toCloseDoor = false;

    public AudioSource audioSource;

    public AudioClip walkingSteps;
    public AudioClip grabbingObjects;
    public AudioClip chestClick;
    public AudioClip safeClick;
    public AudioClip lightOnSwitch;
    public AudioClip lightOffSwitch;
    public AudioClip openDoor;
    public AudioClip closedDoor;

    public static bool alreadyDidOnce = false, aKeyIsBeingPressed = false;
    public bool itemSelected = false;


    void Awake()
    {
        audioSource.clip = walkingSteps;
        itemSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject soundGameObject = new GameObject("Sound");
        //audioSource = soundGameObject.AddComponent<AudioSource>();

        //Walk
        // If a movement key started or stopped getting pressed//
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            aKeyIsBeingPressed = true;
        }
        else
        {
            aKeyIsBeingPressed = false;
        }

        if(aKeyIsBeingPressed == true && !audioSource.isPlaying)
        {
            PlayWalkSound();
        }
        /*else if (!aKeyIsBeingPressed && audioSource.isPlaying)
        {
            PlaySound(false);
        }*/

        //Grab
        if (isGrabbing == true)
        {
            Debug.Log("FUNCION GRABBING");
            itemSelected = true;
        }

        if (Input.GetMouseButtonDown(0) && itemSelected)
        {
            PlayGrabSound();
        }
        else if (Input.GetMouseButtonDown(0) && !itemSelected)
        {
            Debug.Log("NOW, IS NOT GRABBING");
            isGrabbing = false;
            audioSource.clip = walkingSteps;
        }

        //Open Chest
        if (toOpenChest == true)
        {
            PlayOpenChestSound();
        }

        //OpenSafe
        if (toOpenSafe == true)
        {
            PlayOpenSafeSound();
        }

        //Light Switch On
        if (toSwitchOn == true)
        {
            PlaySwitchOnSound();
        }

        //Light Switch off
        if (toSwitchOff == true)
        {
            PlaySwitchOffSound();
        }

        //Open Door
        if (toOpenDoor == true)
        {
            PlayOpenDoorSound();
        }
        
    }

    public void PlaySound(bool Activate)
    {
        //Grab
        if(Activate)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void PlayGrabSound()
    {
        PlaySound(false);
        audioSource.clip = grabbingObjects;
        PlaySound(true);

        itemSelected = false;
        isGrabbing = false;

        Debug.Log("ITEM SELECTED: " + itemSelected);
        Debug.Log("IS GRABBING: " + isGrabbing);
    }

    public void PlayWalkSound()
    {
        PlaySound(false);
        audioSource.clip = walkingSteps;
        PlaySound(true);
    }

    public void PlayOpenChestSound()
    {
        PlaySound(false);
        audioSource.clip = chestClick;
        PlaySound(true);

        toOpenChest = false;
    }

    public void PlayOpenSafeSound()
    {
        PlaySound(false);
        audioSource.clip = safeClick;
        PlaySound(true);
        
        toOpenSafe = false;
    }

    public void PlaySwitchOnSound()
    {
        PlaySound(false);
        audioSource.clip = lightOnSwitch;
        PlaySound(true);
        
        toSwitchOn = false;
        toSwitchOff = false;
    }

    public void PlaySwitchOffSound()
    {
        PlaySound(false);
        audioSource.Stop();
        audioSource.clip = lightOffSwitch;
        PlaySound(true);
        
        toSwitchOn = false;
        toSwitchOff = false;
    }

    public void PlayOpenDoorSound()
    {
        PlaySound(false);
        audioSource.clip = openDoor;
        PlaySound(true);

        toOpenDoor = false;
    }


}
