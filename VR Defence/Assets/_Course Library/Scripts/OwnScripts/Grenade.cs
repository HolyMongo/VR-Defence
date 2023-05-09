using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grenade : MonoBehaviour
{
    public GameObject pS;
  //  public float timer;
    [SerializeField] private float beforeExploading = 5f;
    bool activated;

    //Text
    [SerializeField] TextMeshProUGUI barText;
    public GameObject barObj;

    void Start()
    {
       // timer = 0;
        activated = false;

        barText.text = "0";
        barObj.SetActive(false);
    }

    void Update()
    {
        if (activated)
        {
            barObj.SetActive(true);
          //  float remainingTime = beforeExploading;

            
             barText.text = Mathf.Floor(beforeExploading).ToString();
             beforeExploading -= Time.deltaTime;
            
           
            if (0 >= beforeExploading)  
            {
                Explode();
            }
        }
    }

    public void Activated()
    {
        activated = true;
    }

    void Explode()
    {
        Instantiate(pS, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
