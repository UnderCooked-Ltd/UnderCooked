using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IngredientInteraction : GrabbableObject
{

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (!Hand.HasObject())
        {
            base.OnSelectEnter(interactor);
            Hand.SetObject(this.transform.gameObject);
        }
        else
        {
            // HEUUU
        }
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
    }

}
