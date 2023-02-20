using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CounterTopInteraction : GrabbableObject
{

    private GameObject m_Position;
    private GameObject m_KnifePosition;

    void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).gameObject.tag == Tags.Position_Tag)
                m_Position = this.gameObject.transform.GetChild(i).gameObject;
            else if (this.gameObject.transform.GetChild(i).gameObject.tag == Tags.Knife_Position_Tag)
                m_KnifePosition = this.gameObject.transform.GetChild(i).gameObject;
        }
    }


    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (Hand.HasObject())
        {
            GameObject go = Hand.GetObject();
            go.GetComponent<GrabbableObject>().Drop(interactor);
            if (go.tag == Tags.Knife_Tag)
            {
                go.transform.position = m_KnifePosition.transform.position;
                go.transform.rotation = Quaternion.identity;
            }
            else
            {
                go.transform.position = m_Position.transform.position;
                go.transform.rotation = Quaternion.identity;
            }
            go.GetComponent<Rigidbody>().isKinematic = true;
            Hand.DropObject();
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
