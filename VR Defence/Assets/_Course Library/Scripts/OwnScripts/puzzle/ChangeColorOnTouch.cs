using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnTouch : MonoBehaviour
{
    [SerializeField] private List<Material> materials;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private int currentIndex;


    float testTimer = 1;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Test!!");
        if (collision.collider.CompareTag("Hand"))
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test!! trigger");
        if (other.CompareTag("Hand"))
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

    private void Update()
    {
        testTimer -= Time.deltaTime;

        if (testTimer < 0)
        {
            testTimer = 3;
            currentIndex++;
            if (currentIndex > materials.Count - 1)
            {
                currentIndex = 0;
            }
            Debug.Log("updated material");
            mesh.material = materials[currentIndex];
        }
    }

}
