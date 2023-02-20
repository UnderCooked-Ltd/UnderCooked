using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateInteraction : GrabbableObject
{
    private GameObject m_Meal;
    private List<GameObject> m_Ingredients;

    void Start()
    {
        m_Meal = this.gameObject.transform.GetChild(0).gameObject;
        m_Ingredients = new List<GameObject>();
        for (int i = 0; i < m_Meal.transform.childCount; i++)
        {
            m_Ingredients.Add(m_Meal.transform.GetChild(i).gameObject);
        }
    }

    private void ActivateIngredient(GameObject go)
    {
        string tag = go.tag;
        if (go.tag == Tags.Pan_Tag)
        {
            if (!Hand.GetObject().GetComponent<PanInteraction>().HasCookedBeef())
                return;
            tag = Tags.Cooked_Beef_Tag;
        }
        foreach (GameObject ing in m_Ingredients)
        {
            if (ing.tag == tag)
                ing.SetActive(true);
        }
    }

    private bool CanPutObject(GameObject go) 
    {
        string tag = go.tag;
        if (go.tag == Tags.Pan_Tag)
        {
            if (!Hand.GetObject().GetComponent<PanInteraction>().HasCookedBeef())
                return false;
            tag = Tags.Cooked_Beef_Tag;
        }
        foreach (GameObject ing in m_Ingredients)
        {
            if (ing.tag == tag)
                return !ing.activeInHierarchy;            
        }
        return false;
    }

    private void RemoveObject(GameObject go, XRBaseInteractor interactor)
    {
        if (go.tag == Tags.Pan_Tag)
        {
            go.GetComponent<PanInteraction>().RemoveBeef();
        }
        else
        {
            base.OnSelectExit(interactor);
            Hand.DeleteObject();
        }
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
            ActivateIngredient(Hand.GetObject());
            RemoveObject(Hand.GetObject(), interactor);
        }
        else
        {
            // HEUUUU
        }
    }



    protected override void OnSelectExit(XRBaseInteractor interactor)
    {

    }


}
