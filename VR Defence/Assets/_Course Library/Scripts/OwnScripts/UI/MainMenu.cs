using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] List<string> _scenes = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayTutorial()
    {
        SceneManager.LoadScene(_scenes[0]);
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene(_scenes[2]);
    }
}
