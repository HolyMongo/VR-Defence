using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCorrectColors : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubes;
    [SerializeField] private List<GameObject> backgrounds;
    private bool isCorrectCombination;

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
            Debug.Log("Correct Combo!");
        }
    }
}
