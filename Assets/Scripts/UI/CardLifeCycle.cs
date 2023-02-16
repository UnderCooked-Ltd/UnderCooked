using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CardLifeCycle : MonoBehaviour
{
    public float lifetime;
    public Vector2 destination;
    public bool isAlive = true;
    public RectTransform rectTransform;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(Timer());
    }

    public void SetPosition(float x, float y)
    {
        rectTransform.anchoredPosition = new Vector2(x, y);
        destination = rectTransform.anchoredPosition;
    }

    public float GetWidth()
    {
        return rectTransform.sizeDelta.x;
    }

    public void MoveBy(float x, float y)
    {
        destination.x += x;
        destination.y += y;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the GameObject from it's current position to destination over time
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, destination, Time.deltaTime * speed);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(lifetime);
        isAlive = false;
    }
}