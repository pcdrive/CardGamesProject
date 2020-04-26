using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hand of the player.
/// </summary>
public class Hand : MonoBehaviour {
    /// <summary>
    /// Contained cards.
    /// </summary>
    private List<Card> cards = new List<Card>();
    /// <summary>
    /// Deck to draw cards from.
    /// </summary>
    private Deck deck;
    /// <summary>
    /// Is this hand the owner of the current turn.
    /// </summary>
    private bool isInTurn = false;
    /// <summary>
    /// Is the current players hand or it is a dummy.
    /// </summary>
    public bool isPlayer = false;

    /// <summary>
    /// Delegate of end turn.
    /// </summary>
    /// <param name="sender">The player owning this hand.</param>
    /// <param name="chosenCard">The card chosen to throw on the pile.</param>
    public delegate void EndOfTurnEvent(Player sender, Card chosenCard);
    /// <summary>
    /// Turn end event.
    /// </summary>
    public event EndOfTurnEvent EndOfTurn;
    /// <summary>
    /// Delegate for setting card frame.
    /// </summary>
    /// <param name="c">Card.</param>
    public delegate void IsCardAvailable(Card c);
    /// <summary>
    /// Delegate instance.
    /// </summary>
    public IsCardAvailable isCardAvailable;
    /// <summary>
    /// Delegate for setting card block.
    /// </summary>
    /// <param name="c">Card.</param>
    public delegate void IsCardUnavailable(Card c);
    /// <summary>
    /// Delegate instance.
    /// </summary>
    public IsCardAvailable isCardUnavailable;

    /// <summary>
    /// sets the deck to draw form.
    /// </summary>
    /// <param name="d">Deck to draw from.</param>
    public void SetDeck(Deck d) {
        deck = d;
    }

    /// <summary>
    /// Start the players turn.
    /// </summary>
    public void SetTurn()
    {
        isInTurn = true;

        if (isPlayer) //If this hand is the users hand....
        {
            foreach (Card card in cards)
            {
                if (isCardAvailable != null)
                    isCardAvailable(card);
                if (isCardUnavailable != null)
                    isCardUnavailable(card);
            }
        }
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
            cards[i].SetCardTransform(new Vector3((i * 1) - ((cards.Count - 1) / 2.0f), 0, 0), new Vector3(0, 180, 0)); //Set card position and rotation.
            cards[i].SetOrderInLayer(-i); // dont need to know (sets order in layer, which defines which sprite to draw later, so which one is in front)
        }
    }

    /// <summary>
    /// Thowring a card to the pile.
    /// </summary>
    /// <param name="c">Card chosen to throw.</param>
    public void ChooseCard(Card c)
    {
        if (EndOfTurn != null)
        {
            cards.Remove(c);
            EndTurn(c);
        }
        PositionCards();
    }
    /// <summary>
    /// ForTestOnly!!! TODO: REMOVE THIS
    /// </summary>
    /// <param name="c"></param>
    public void ChooseCard(int idx)
    {
        if (EndOfTurn != null && isInTurn)
        {
            Card c = cards[idx];
            cards.RemoveAt(idx);
            EndTurn(c);
        }
        PositionCards();
    }

    /// <summary>
    /// End the users turn, and do whatever needed on turn end. Also passes the chosen card to the player.
    /// </summary>
    /// <param name="c">Chosen card.</param>
    private void EndTurn(Card c)
    {
        isInTurn = false;
        EndOfTurn(transform.parent.GetComponent<Player>(), c);
        foreach (Card card in cards)
        {
            card.ToggleBlock(false);
            card.ToggleFrame(false);
        }
    }
}