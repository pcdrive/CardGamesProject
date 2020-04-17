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
    private List<Card> cards;

}