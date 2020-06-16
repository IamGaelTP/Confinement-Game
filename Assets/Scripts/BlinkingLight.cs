using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    Light blinkingLight;
    public float minDelay;
    public float maxDelay;


    void Awake()
    {
        blinkingLight = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            blinkingLight.enabled = !blinkingLight.enabled;
        }
    }
}
