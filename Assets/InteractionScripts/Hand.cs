using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    static private GameObject objectInHand = null;

    static public void SetObject(GameObject o)
    {
        objectInHand = o;
    }

    static public GameObject GetObject()
    {
        return objectInHand;
    }

    static public void DeleteObject()
    {
        Destroy(objectInHand);
        objectInHand = null;
    }

    static public void DropObject()
    {     
        objectInHand = null;
    }

    static public bool HasObject()
    {
        return objectInHand != null;
    }
}
