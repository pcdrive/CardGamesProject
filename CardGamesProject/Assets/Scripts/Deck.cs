using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a deck, holding cards.
/// </summary>
public class Deck : MonoBehaviour {
    /// <summary>
    /// GameManager Reference to be able to call game over methods, or tell it to refresh the deck, etc.
    /// </summary>
    private GameManager gameManager;
    /// <summary>
    /// Contained cards.
    /// </summary>
    private List<Card> cards;

    /// <summary>
    /// Sets card list. Used at initialization of the game.
    /// </summary>
    /// <param name="list">New list of cards.</param>
    public void SetCards(List<Card> list)
    {
        cards = list;
        PositionCards();
    }

    /// <summary>
    /// Shuffles the cards by creating a new list and add random cards from the original one to random places int he new one.
    /// </summary>
    public void Shuffle() 
    {
        List<Card> res = new List<Card>();

        while (cards.Count != 0)
        {
            int random = Random.Range(0, cards.Count - 1);
            res.Add(cards[random]);
            cards.RemoveAt(random);
        }

        cards = res;

        PositionCards();
    } 

    /// <summary>
    /// Draws a card fron top of the deck.
    /// </summary>
    /// <returns>The card drawn.</returns>
    public Card DrawCard()
    {
        if (cards.Count == 0) return null;
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    /// <summary>
    /// Shuffle a card into the deck.
    /// </summary>
    /// <param name="card">Card to shuffle in.</param>
    public void ShuffleInCard(Card card)
    {
        cards.Insert(Random.Range(0, cards.Count - 1), card);
        PositionCards();
    }

    /// <summary>
    /// Sets the cards into position to look like a firm deck on the desk. ^^
    /// TODO: card -> position Lerp
    /// </summary>
    private void PositionCards()
    {
        int i = 0;
        foreach (Card card in cards)
        {
            Transform cardTransform = card.gameObject.transform;
            cardTransform.parent = transform;
            cardTransform.rotation = Quaternion.Euler(90, 0, 0);
            cardTransform.localPosition = new Vector3(0, 0.005f * (i++), 0);
        }
    }
}