using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWeapon : MonoBehaviour
{
    public int spinningSpeed = 200;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
   void Update()
    {
        // Rotate the weapon around the rotation center
        obj.transform.RotateAround(transform.position, Vector3.up, spinningSpeed * Time.deltaTime);
    }
}
