using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeliveryPointInteraction : GrabbableObject
{

    public CardManager cardManager;
    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (Hand.HasObject())
        {
            GameObject go = Hand.GetObject();
            if (go.tag == Tags.Plate_Tag)
            {
                GameObject m_Meal = go.transform.GetChild(0).gameObject;
                List<GameObject> m_Ingredients = new List<GameObject>();
                for (int i = 0; i < m_Meal.transform.childCount; i++)
                {
                    if(m_Meal.transform.GetChild(i).gameObject.activeInHierarchy)
                        m_Ingredients.Add(m_Meal.transform.GetChild(i).gameObject);
                }

                bool Bread_Meat = true;
                foreach (string tag in Tags.Bread_Meat_Recipe)
                {
                    bool found = false;
                    foreach (GameObject ing in m_Ingredients)
                        if (tag == ing.tag)
                            found = true;
                    if (!found)
                        Bread_Meat = false;
                }
                if (Bread_Meat)
                    // call card manager
                    return;



                bool Burger = true;
                foreach(string tag in Tags.Burger_Recipe)
                {
                    bool found = false;
                    foreach (GameObject ing in m_Ingredients)
                        if (tag == ing.tag)
                            found = true;
                    if (!found)
                        Burger = false;
                }
                if (Burger)
                    // call card manager
                    return;

                
                Hand.DeleteObject();
            }
            else
            {
                // HEU
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
