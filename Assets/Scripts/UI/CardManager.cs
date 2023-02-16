using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Canvas canvas;
    public List<RawImage> cardPrefabs;  // the list of card prefabs to randomly choose from
    public int numCards;  // the number of images you want to generate

    public float startX;  // the starting x position of the images
    public float startY;  // the starting y position of the images
    public float margin;  // spacing between each image

    private CardLifeCycle[] _currentCards;
    private CardLifeCycle[] _nextCards;

    private int _cardsCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _currentCards= new CardLifeCycle[numCards];
        _nextCards= new CardLifeCycle[numCards];
        
        while (_cardsCount < numCards)
        {
            AddCard(startX, startY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManageCards();
        if (_cardsCount < numCards)
        {
            CardLifeCycle card = AddCard(startX, startY + 250);
            card.MoveBy(0, -250);
        }
    }

    void ManageCards()
    {
        float shiftBy = 0;
        int j = 0;
        
        for (int i = 0; i < _cardsCount; i++)
        {
            if (_currentCards[i].isAlive)
            {
                _currentCards[i].MoveBy(shiftBy, 0);
                _nextCards[j++] = _currentCards[i];
            }
            else
            {
                shiftBy -= _currentCards[i].GetWidth() + margin;
                startX -= _currentCards[i].GetWidth() + margin;
                Destroy(_currentCards[i].gameObject);
            }
        }

        _currentCards = _nextCards;
        _cardsCount = j;
    }

    CardLifeCycle AddCard(float x, float y)
    {
        int index = Random.Range(0, cardPrefabs.Count);  // randomly choose a card prefab index

        RawImage card = Instantiate(cardPrefabs[index], canvas.transform);

        CardLifeCycle cardLife = card.GetComponent<CardLifeCycle>();
        cardLife.SetPosition(x, y);
        cardLife.gameObject.SetActive(true);

        _currentCards[_cardsCount++] = cardLife;
        startX += cardLife.GetWidth() + margin;

        return cardLife;
    }
}
