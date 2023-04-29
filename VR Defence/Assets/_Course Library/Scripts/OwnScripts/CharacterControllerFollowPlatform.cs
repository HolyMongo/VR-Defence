using UnityEngine;

public class CharacterControllerFollowPlatform : MonoBehaviour
{
  

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Platform")
        {
           
            transform.SetParent(hit.transform);
        }
        else
        {
            transform.parent = null;
        }
    }

}


