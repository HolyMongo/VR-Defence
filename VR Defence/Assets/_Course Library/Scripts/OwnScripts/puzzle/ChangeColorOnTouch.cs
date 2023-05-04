using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnTouch : MonoBehaviour
{
    [SerializeField] private List<Material> materials;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private int currentIndex;
    [SerializeField] private GameObject cubeToChange;


    void Start()
    {
        mesh = cubeToChange.GetComponent<MeshRenderer>();
    }

    public void UpdateColor()
    {
        currentIndex++;
        if (currentIndex > materials.Count - 1)
        {
            currentIndex = 0;
        }
        Debug.Log("Test!!");
        mesh.material = materials[currentIndex];
    }
}
