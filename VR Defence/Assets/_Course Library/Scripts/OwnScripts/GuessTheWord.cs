using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuessTheWord : MonoBehaviour
{
    [SerializeField] private GameObject Port;


    private Renderer material;
    private bool isDissolving = false;
    private float fade = 1f;

    void Start()
    {
        material = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;             
                Destroy(gameObject);

            }

            material.material.SetFloat("_Fade", fade);
        }
    }
    public void YES()
    {
        isDissolving = true;
    }
    public void No()
    {
        Debug.Log("Did not destroy it");
    }
}
