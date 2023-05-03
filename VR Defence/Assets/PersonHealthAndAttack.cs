using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHealthAndAttack : MonoBehaviour
{
  
    private PlayerHealth pH;
    //Eyes
    public GameObject eye1;
    public GameObject eye2;

    //Activate Eyebrows
    public GameObject Eyebrow1;
    public GameObject Eyebrow2;
    void Start()
    {

        pH = GameObject.Find("XR Rig").GetComponent<PlayerHealth>();
     
     
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eye1.transform.LookAt(pH.transform);
            eye2.transform.LookAt(pH.transform);
            Eyebrow1.SetActive(true);
            Eyebrow2.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eye1.transform.LookAt(pH.transform);
            eye2.transform.LookAt(pH.transform);

            Eyebrow1.SetActive(true);
            Eyebrow2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Eyebrow1.SetActive(false);
        Eyebrow2.SetActive(false);
    }
    void Update()
    {
        
        
          
        
    }
}
