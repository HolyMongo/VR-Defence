using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string teleport;

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(teleport);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        SceneManager.LoadScene(teleport);
    }
}