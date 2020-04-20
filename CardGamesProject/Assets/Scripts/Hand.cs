using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hand of the player.
/// </summary>
public class Hand : MonoBehaviour {
    /// <summary>
    /// GameManager Reference to be able to call game over methods, or tell it to refresh the deck, etc.
    /// </summary>
    private GameManager gameManager;
    /// <summary>
    /// Contained cards.
    /// </summary>
    private List<Card> cards = new List<Card>();
    /// <summary>
    /// Deck to draw cards from.
    /// </summary>
    private Deck deck;

    public void SetDeck(Deck d) {
        deck = d;
    }

    /// <summary>
    /// Draw a card from the deck
    /// </summary>
    public void DrawCard()
    {
        if (deck == null) return;
        cards.Add(deck.DrawCard());
        PositionCards();
    }

    /// <summary>
    /// Puts cards to corresponding positions.
    /// </summary>
    private void PositionCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.parent = transform; //order in hierarchy
            cards[i].transform.localPosition = new Vector3((i * 1) - ((cards.Count - 1) / 2.0f), 0, 0); //set position based on index
            cards[i].transform.localRotation = Quaternion.Euler(0, 180, 0); // rotation
            cards[i].SetOrderInLayer(-i); // dont need to know (sets order in layer, which defines which sprite to draw later, so which one is in front)
        }
    }

}