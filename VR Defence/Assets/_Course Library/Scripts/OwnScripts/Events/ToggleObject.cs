using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObject1;
    [SerializeField] private GameObject gameObject2;
    [SerializeField] private bool isActive;

    public void ToggelGameobjects()
    {
        isActive = !isActive;
        gameObject1.SetActive(isActive);
        gameObject2.SetActive(isActive);
    }
}
