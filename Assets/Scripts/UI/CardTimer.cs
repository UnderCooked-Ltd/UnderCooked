using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTimer : MonoBehaviour
{
    public float time;  // the time in seconds before the card should disappear
    public Action callback;  // the callback function to execute before destroying the card


    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);

        if (callback != null)
        {
            callback();
        }

        Destroy(gameObject);
    }
}
