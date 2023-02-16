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

    private CardLifeCycle[] currentCards;
    private CardLifeCycle[] nextCards;

    private int cardCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.currentCards= new CardLifeCycle[numCards];
        this.nextCards= new CardLifeCycle[numCards];
    }

    // Update is called once per frame
    void Update()
    {
        ManageCards();
    }

    void ManageCards()
    {
        float shiftBy = 0;
        foreach (CardLifeCycle card in this.currentCards)
        {
            if (card == null)
            {
                break;
            }
            if (card.IsAlive)
            {
                card.MoveBy(shiftBy, 0);
            }
            else
            {
                shiftBy -= card.GetWidth() + margin;
            }
        }
    }

    void AddCard(float x, float y)
    {
        int index = Random.Range(0, cardPrefabs.Count);  // randomly choose a card prefab index

        RawImage card = Instantiate(cardPrefabs[index], canvas.transform);

        CardLifeCycle cardLife = card.GetComponent<CardLifeCycle>();
        cardLife.SetPosition(x, y);

        currentCards[cardCount] = cardLife;
    }
}
