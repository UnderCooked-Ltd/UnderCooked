using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLifeCycle : MonoBehaviour
{
    public float Lifetime;
    public float Speed;

    public bool IsAlive = true;

    float m_XAxis, m_YAxis;

    private RectTransform m_RectTransform;

    // Start is called before the first frame update
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        this.gameObject.SetActive(true);
        StartCoroutine(Timer());
    }

    public void SetPosition(float x, float y)
    {
        m_XAxis = x;
        m_YAxis = y;
    }

    public float GetWidth()
    {
        return m_RectTransform.sizeDelta.x;
    }

    public void MoveBy(float x, float y)
    {
        float Elapsed = Time.deltaTime;
        m_XAxis += Math.Min(x, Math.Sign(x) * Speed * Elapsed);
        m_YAxis += Math.Min(y, Math.Sign(y) * Speed * Elapsed);
    }

    // Update is called once per frame
    void Update()
    {
        m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(Lifetime);
        IsAlive = false;
    }
}
