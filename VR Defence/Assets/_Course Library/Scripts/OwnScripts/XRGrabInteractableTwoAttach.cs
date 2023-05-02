using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

 


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
       
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }

            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
            }
        
      


        base.OnSelectEntered(args);
    }
    //protected override void OnSelectExited(SelectExitEventArgs args)
    //{
    //    if (args.interactableObject.transform.CompareTag("Socket"))
    //    {
    //        attachTransform = defaultAttachTransform;
    //    }
       

    //    base.OnSelectExited(args);
    //}
   
}
