using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing game rules. It handles turns, card effects etc...
/// </summary>
public class GameManager : MonoBehaviour {

    /// <summary>
    /// List of cards. Need only to setup table. Not used anywhere else.
    /// </summary>
    protected List<Card> cards = new List<Card>();

    /// <summary>
    /// Counter-clockwise rounds by default;
    /// </summary>
    protected bool roundDirection = false;
    /// <summary>
    /// The actual player.
    /// </summary>
    protected Player currentPlayer;


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

    /// <summary>
    /// Sets frame for cards that are available to use.
    /// </summary>
    /// <param name="card">Card to check.</param>
    virtual public void SetCardFrame(Card card) { }

    /// <summary>
    /// Sets block for cards that are available to use.
    /// </summary>
    /// <param name="card">Card to check.</param>
    virtual public void SetCardBlock(Card card) { }

    /// <summary>
    /// Sort the player list, to for a round in the game. Player world positions are optimized by view not by game order.
    /// </summary>
    /// <param name="playerCount">Number of active players.</param>
    protected void SortPlayerList(int playerCount)
    {
        List<Player> res = new List<Player>();
        switch (playerCount)
        {
            case 1:
                res.Add(players[0]);
                break;
            case 2:
                res.Add(players[0]);
                res.Add(players[1]);
                break;
            case 3:
                res.Add(players[0]);
                res.Add(players[2]);
                res.Add(players[1]);
                break;
            case 4:
                res.Add(players[0]);
                res.Add(players[2]);
                res.Add(players[1]);
                res.Add(players[3]);
                break;
            case 5:
                res.Add(players[0]);
                res.Add(players[4]);
                res.Add(players[2]);
                res.Add(players[1]);
                res.Add(players[3]);
                break;
        }

        players = res;
    }
}