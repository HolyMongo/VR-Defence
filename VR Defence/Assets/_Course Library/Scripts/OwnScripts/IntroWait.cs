using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroWait : MonoBehaviour
{
    public float VideoLength = 5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro());
    }


    //Before switching to the next scene
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(VideoLength);

        SceneManager.LoadSceneAsync(1);
    }
}
