using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StoveInteraction : GrabbableObject
{

    private GameObject m_Position;

    void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).gameObject.tag == Tags.Position_Tag)
                m_Position = this.gameObject.transform.GetChild(i).gameObject;
        }
    }


    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (Hand.HasObject())
        {
            GameObject go = Hand.GetObject();
            if (go.tag == Tags.Pan_Tag)
            {
                go.GetComponent<GrabbableObject>().Drop(interactor);

                go.transform.position = m_Position.transform.position;
                go.transform.rotation = Hand.GetObject().transform.rotation;
                go.GetComponent<PanInteraction>().setIsOnStove(true);

                go.GetComponent<Rigidbody>().isKinematic = true;
                Hand.DropObject();
            }
        }
        else
        {
            // HEU
        }
    }



    protected override void OnSelectExit(XRBaseInteractor interactor)
    {

    }


}
