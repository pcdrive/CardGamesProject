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
}