using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    public Canvas canvas;
    public List<RawImage> cardPrefabs;  // the list of card prefabs to randomly choose from
    public float timeInterval;  // the interval between each image generation
    public int numCards;  // the number of images you want to generate
    public float startX;  // the starting x position of the images
    public float startY;  // the starting y position of the images
    public float margin;  // spacing between each image

    private List<RawImage> cards = new List<RawImage>();

    void Start()
    {
        StartCoroutine(GenerateCards());
    }

    IEnumerator GenerateCards()
    {
        while (true)
        {
            if (cards.Count < numCards)
            {
                AddCard();
                yield return new WaitForSeconds(timeInterval);
            }
        }
    }

    void AddCard()
    {
        int index = Random.Range(0, cardPrefabs.Count);  // randomly choose a card prefab index

        RawImage card = Instantiate(cardPrefabs[index], canvas.transform);

        card.rectTransform.anchoredPosition = new Vector2(startX, startY);
        startX += card.rectTransform.sizeDelta.x + margin;

        CardTimer cardTimer = card.GetComponent<CardTimer>();
        cardTimer.callback = () => { PopCard(card); };

        card.gameObject.SetActive(true);
        cards.Add(card);
    }

    void PopCard(RawImage thisCard)
    {
        thisCard.gameObject.SetActive(true);

        int i = 0;
        for (; i < cards.Count; i++)
        {
            if (cards[i].Equals(thisCard))
            {
                break;
            }
        }
        cards.RemoveAt(i);

        for (; i < cards.Count; i++)
        {
            RawImage otherCard = cards[i];
            Vector3 currentPosition = otherCard.rectTransform.anchoredPosition;

            if (currentPosition.x > thisCard.rectTransform.anchoredPosition.x)
            {
                StartCoroutine(MoveCard(otherCard, new Vector2(currentPosition.x - (thisCard.rectTransform.sizeDelta.x + margin), currentPosition.y)));
            }
        }
        startX -= thisCard.rectTransform.sizeDelta.x + margin;
    }

    IEnumerator MoveCard(RawImage card, Vector2 targetPosition)
    {
        Vector2 startPosition = card.rectTransform.anchoredPosition;
        float startTime = Time.time;

        while (Time.time < startTime + 0.5f)
        {
            float t = (Time.time - startTime) / 0.5f;
            card.rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        card.rectTransform.anchoredPosition = targetPosition;
    }
}
