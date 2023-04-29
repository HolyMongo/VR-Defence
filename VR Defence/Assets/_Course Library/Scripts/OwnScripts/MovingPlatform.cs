using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

  
}
