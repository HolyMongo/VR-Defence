using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //       // collision.collider.transform.parent = transform;
    //       collision.gameObject.transform.SetParent(gameObject.transform, true);
    //        Debug.Log("Collision");
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        other.gameObject.transform.SetParent(gameObject.transform, true);
    //      // other.transform.parent = transform;
    //        Debug.Log("trigger");
    //    }
    //}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //transform.parent = other.transform;
            other.transform.SetParent(transform);
            // other.transform.parent = transform;
            Debug.Log("trigger");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //transform.parent = other.transform;
            other.transform.parent = null;
            // other.transform.parent = transform;
            Debug.Log("Null");
        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //transform.parent = other.transform;
    //        collision.transform.parent = transform;
    //        // other.transform.parent = transform;
    //        Debug.Log("trigger");
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //transform.parent = other.transform;
    //        collision.transform.parent = null;
    //        // other.transform.parent = transform;
    //        Debug.Log("Null");
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        other.gameObject.transform.parent = null;
    //    }
    //}

   
}
