using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing game rules. It handles turns, card effects etc...
/// </summary>
public class GameManager : MonoBehaviour {
    /// <summary>
    /// List of current players
    /// </summary>
    private List<Player> players;
    /// <summary>
    /// List of decks. For example UNO has only one deck,but Speed have two.
    /// </summary>
    private List<Deck> decks;
    /// <summary>
    /// Stack of played cards. Same as decks... UNO have only one, Speed have 2, solitaire have 7
    /// </summary>
    private List<Pile> piles;
    /// <summary>
    /// List of cards. Need only to setup table. Not used anywhere else.
    /// </summary>
    private List<Card> cards; 

}