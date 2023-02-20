using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardLifeCycle : MonoBehaviour
{
    public Vector2 destination;
    public RectTransform rectTransform;
    public float speed = 2f;

    public bool isAlive = true;

    public float lifetime;
    public Image progressBar;
    private float _remainingTime;

    // Start is called before the first frame update
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        _remainingTime = lifetime;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    private void Update()
    {
        //Moves the GameObject from it's current position to destination over time
        rectTransform.anchoredPosition = Vector2.Lerp(
            rectTransform.anchoredPosition, destination, Time.deltaTime * speed);

        //Update the progress bar
        progressBar.fillAmount = _remainingTime / lifetime;
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

    public bool IsMoving(double threshold = 10)
    {
        return Vector2.Distance(rectTransform.anchoredPosition, destination) > threshold;
    }

    private IEnumerator Timer()
    {
        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            yield return null;
        }

        isAlive = false;
    }

    public IEnumerator Scale(float duration, Vector3 targetScale)
    {
        var initialScale = rectTransform.localScale;
        var timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            rectTransform.localScale = Vector3.Lerp(initialScale, targetScale, timer / duration);
            yield return null;
        }

        rectTransform.localScale = targetScale;
    }

    public IEnumerator ScaleDown(float duration)
    {
        yield return StartCoroutine(Scale(duration, Vector3.zero));
        Destroy(gameObject);
    }
}