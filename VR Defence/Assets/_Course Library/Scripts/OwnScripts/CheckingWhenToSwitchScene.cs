using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckingWhenToSwitchScene : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj == null)
        {
            SceneManager.LoadSceneAsync(7);
        }
    }
}
