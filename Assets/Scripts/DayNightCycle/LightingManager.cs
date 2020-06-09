using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class LightingManager : MonoBehaviour
{

    //References
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightningPreset preset;

    //Variables
    [SerializeField, Range(-0, 240)] private float timeOfDay;

    void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, -170, 0));
        }
    } 

    void OnValidate()
    {
        if (directionalLight != null)
            return;
        if(RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (preset == null)
            return;
        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 240; //Clamp between 0-24
            UpdateLighting(timeOfDay / 240f);
        }
        else
        {
            UpdateLighting(timeOfDay / 240f);
        }
    }
}
