using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMan : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        //RenderSettings.ambientIntensity = 5;
        //RenderSettings.ambientIntensity = 2;
        //RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        //RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        //RenderSettings.ambientIntensity = 5;

        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientSkyColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
