using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCorrectColors : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubes;
    [SerializeField] private List<GameObject> backgrounds;
    private bool isCorrectCombination;
    [SerializeField] private GameObject door;
    private Vector3 startPos;

    private void Start()
    {
        startPos = door.transform.position;
    }
    public void CheckIfColorsAreCorect()
    {
        isCorrectCombination = true;
        Debug.Log("Checking Combo");
        for (int i = 0; i < cubes.Count; i++)
        {
            if (cubes[i].GetComponent<MeshRenderer>().material.name != backgrounds[i].GetComponent<MeshRenderer>().material.name)
            {
                Debug.Log("Wrong Combo on: " + i);
                isCorrectCombination = false;
                break;
            }
            else
            {
                Debug.Log("Right Combination on: " + i);
            }
        }

        if (isCorrectCombination)
        {
            InvokeRepeating("OpenDoor", 0, 0.1f);
        }
    }

    public void OpenDoor()
    {
        Debug.Log("Test to move door");
        if (door.transform.rotation.x >= -0.9)
        {
            door.transform.Rotate(door.transform.rotation.x - 0.5f, 0, 0);
        }
    }

    
}
