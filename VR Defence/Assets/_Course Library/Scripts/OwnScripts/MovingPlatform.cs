using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 platformVelocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Platform")
        {
            platformVelocity = hit.transform.GetComponent<Rigidbody>().velocity;
            characterController.Move(platformVelocity * Time.deltaTime);
            transform.SetParent(hit.transform);
        }
        else
        {
            transform.parent = null;
        }
    }

    private void FixedUpdate()
    {
        if (transform.parent != null)
        {
            characterController.Move(platformVelocity * Time.deltaTime);
        }
    }
}

