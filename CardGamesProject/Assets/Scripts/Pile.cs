using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pile of used cards.
/// </summary>
public class Pile : MonoBehaviour
{
    /// <summary>
    /// GameManager Reference to be able to call game over methods, or tell it to refresh the deck, etc.
    /// </summary>
    private GameManager gameManager;
    /// <summary>
    /// Contained cards.
    /// </summary>
    private List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        cards.Add(card);
        PositionLastCard();
    }

    /// <summary>
    /// Puts cards to corresponding positions.
    /// </summary>
    private void PositionCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.parent = transform; //order in hierarchy
            cards[i].transform.localPosition = new Vector3(Random.Range(0, 0.3f),  0.005f * i, Random.Range(0, 0.3f)); //set position based on index
            cards[i].transform.localRotation = Quaternion.Euler(-90, 165 + Random.Range(0,30), 0); // rotation
            cards[i].SetOrderInLayer(i); // dont need to know (sets order in layer, which defines which sprite to draw later, so which one is in front)
        }
    }

    /// <summary>
    /// Position only the last one. Cosmetics....
    /// </summary>
    private void PositionLastCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (i == cards.Count - 1)
            {
                cards[i].transform.parent = transform; //order in hierarchy
                cards[i].transform.localPosition = new Vector3(Random.Range(0, 0.3f), 0.005f * i, Random.Range(0, 0.3f)); //set position based on index
                cards[i].transform.localRotation = Quaternion.Euler(-90, 165 + Random.Range(0, 30), 0); // rotation
            }
            cards[i].SetOrderInLayer(i); // dont need to know (sets order in layer, which defines which sprite to draw later, so which one is in front)
        }
    }

}