using UnityEngine;
public class CharacterControllerFollowPlatform : MonoBehaviour
{
    private Vector3 platformVelocity;

    private Vector3 playerScale;

    private void Start()
    {
        // Store the initial scale of the player
        playerScale = transform.localScale;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
        if (hit.transform.tag == "Platform")
        {
           
            Rigidbody platformRigidbody = hit.transform.GetComponent<Rigidbody>();
            if (platformRigidbody != null)
            {
                // Calculate the movement vector that the player needs to make
                // in order to stay on the platform
                Vector3 movement = platformVelocity * Time.deltaTime;

                // Apply the movement to the player using the Move method
                CharacterController characterController = GetComponent<CharacterController>();
                CollisionFlags flags = characterController.Move(movement);

                // If the player collided with something while moving, adjust the movement
                // vector so that the player doesn't get stuck in the object
                if ((flags & CollisionFlags.Sides) != 0)
                {
                    movement = Vector3.ProjectOnPlane(movement, hit.normal);
                    characterController.Move(movement);
                }

                // Set the platform velocity for the next frame
                platformVelocity = platformRigidbody.velocity;
            }

            // Make the player a child of the platform so that it moves with it
            transform.SetParent(hit.transform);
        }
        else
        {
            // Remove the player as a child of the platform
            transform.parent = null;
            transform.localScale = playerScale;
        }
    }


}



