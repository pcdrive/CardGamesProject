using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing game rules. It handles turns, card effects etc...
/// </summary>
public class GameManager : MonoBehaviour {

    /// <summary>
    /// static reference to this (the current game manager) object.
    /// </summary>
    public static GameManager instance;
    /// <summary>
    /// List of current players
    /// </summary>
    public List<Player> players = new List<Player>();
    /// <summary>
    /// List of decks. For example UNO has only one deck,but Speed have two.
    /// </summary>
    public List<Deck> decks = new List<Deck>();
    /// <summary>
    /// Stack of played cards. Same as decks... UNO have only one, Speed have 2, solitaire have 7
    /// </summary>
    public List<Pile> piles = new List<Pile>();
    /// <summary>
    /// List of cards. Need only to setup table. Not used anywhere else.
    /// </summary>
    protected List<Card> cards = new List<Card>();

    /// <summary>
    /// The cards prefab. The excact object the user will see. This will hold the images,
    /// and the "Card" script in it for the game to work.
    /// </summary>
    public GameObject CardPrefab;
    /// <summary>
    /// Same as the card pref, but this reprezents the player. Not sure we need this, but i can come handy, if
    /// we want to use dinamic number of players instead of a default 2 or 4. 
    /// Girls like cosmetics anyway.....
    /// </summary>
    public GameObject PlayerPrefab;

    /// <summary>
    /// Unity uses this method to initialize objects. (Awake (creation) - Start (initialization) - Update(usual updates by frames))
    /// </summary>
    private void Start()
    {
    }
}