using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Canvas canvas;
    public List<CardLifeCycle> cardPrefabs; // the list of card prefabs to randomly choose from
    public int numCards; // the number of images you want to generate
    public float scalingDuration = 0.5f;

    public float startX; // the starting x position of the images
    public float startY; // the starting y position of the images
    public float margin; // spacing between each image

    private int _cardsCount;

    private CardLifeCycle[] _currentCards;
    private CardLifeCycle[] _nextCards;

    // Start is called before the first frame update
    private void Start()
    {
        _currentCards = new CardLifeCycle[numCards];
        _nextCards = new CardLifeCycle[numCards];

        while (_cardsCount < numCards) AddCard();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!ManageCards())
            // cards are still moving
            return;

        if (_cardsCount < numCards)
        {
            var card = AddCard();
        }
    }

    private bool ManageCards()
    {
        var notMoving = true;
        float shiftBy = 0;
        var j = 0;

        for (var i = 0; i < _cardsCount; i++)
            if (_currentCards[i].isAlive)
            {
                _currentCards[i].MoveBy(shiftBy, 0);
                _nextCards[j++] = _currentCards[i];
                notMoving = notMoving && !_currentCards[i].IsMoving();
            }
            else
            {
                shiftBy -= _currentCards[i].GetWidth() + margin;
                startX -= _currentCards[i].GetWidth() + margin;
                StartCoroutine(_currentCards[i].ScaleDown(scalingDuration));
            }

        _currentCards = _nextCards;
        _cardsCount = j;
        return notMoving;
    }

    private CardLifeCycle AddCard()
    {
        var index = Random.Range(0, cardPrefabs.Count); // randomly choose a card prefab index

        var card = Instantiate(cardPrefabs[index], canvas.transform);

        _currentCards[_cardsCount++] = card;
        startX += card.GetWidth() / 2;

        card.SetPosition(startX, startY);
        card.gameObject.SetActive(true);

        startX += card.GetWidth() / 2 + margin;

        card.rectTransform.localScale = Vector3.zero;
        StartCoroutine(card.Scale(scalingDuration, Vector3.one));

        return card;
    }

    public bool ScheduleDestroy(string targetTag)
    {
        for (var i = 0; i < _cardsCount; i++)
        {
            if (!_currentCards[i].CompareTag(targetTag)) continue;

            _currentCards[i].isAlive = false;
            return true;
        }

        return false;
    }
}