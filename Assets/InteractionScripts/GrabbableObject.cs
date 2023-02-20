using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableObject : XRGrabInteractable
{

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
    }



    protected override void OnSelectExit(XRBaseInteractor interactor)
    {    }

    public void Drop(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
    }
}
