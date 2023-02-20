using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PanInteraction : GrabbableObject
{

    private GameObject m_Raw_Beef;
    private GameObject m_Cooked_Beef;
    private bool m_IsCooking = false;
    private bool m_IsCooked = false;
    public int CookingTime_s;
    private float elapsed_time = 0;

    public void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.tag == Tags.Raw_Beef_Tag)
                m_Raw_Beef = transform.GetChild(i).gameObject;
            else if (transform.GetChild(i).gameObject.tag == Tags.Cooked_Beef_Tag)
                m_Cooked_Beef = transform.GetChild(i).gameObject;
        }
    }

    public void Update()
    {
        if(m_IsCooking)
        {
            elapsed_time += Time.deltaTime;
            if ((float)CookingTime_s < elapsed_time)
            {
                m_Raw_Beef.SetActive(false);
                m_Cooked_Beef.SetActive(true);
                m_IsCooked = true;
                m_IsCooking = false;
            }
        }
    }

    private void StartCooking()
    {
        m_IsCooking = true;
        m_Raw_Beef.SetActive(true);
        elapsed_time = 0;
    }

    private bool CanPutObject(GameObject go)
    {
        return go.tag == Tags.Raw_Beef_Tag && !m_Raw_Beef.activeInHierarchy;
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (!Hand.HasObject())
        {
            base.OnSelectEnter(interactor);
            Hand.SetObject(this.transform.gameObject);
        }
        else if (CanPutObject(Hand.GetObject()))
        {
            base.OnSelectExit(interactor);
            StartCooking();
            Hand.DeleteObject();
        }
        else
        {
            // HEUUUU
        }
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    { }

    // called by plate using "Hand.GetObject().GetComponent<PanInteraction>().MyFunction();"
    public void RemoveBeef()
    {
        // must be cooked
        m_IsCooked = false;
        m_Cooked_Beef.SetActive(false);
    }

    public bool HasCookedBeef()
    {
        return m_IsCooked;
    }

}
