using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ColorPuzzle : MonoBehaviour
{
    XRRayInteractor ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ray.interactionLayers == 3)
        {
            Debug.Log("Working maybe?");
        }
    }
}
