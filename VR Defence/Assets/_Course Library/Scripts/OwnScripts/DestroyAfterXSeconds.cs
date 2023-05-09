using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXSeconds : MonoBehaviour
{
    private float beforeDestroying = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        beforeDestroying -= Time.deltaTime;


        if (0 >= beforeDestroying)
        {
            Explode();
        }
    }
    void Explode()
    {
       
        Destroy(gameObject);
    }
}
