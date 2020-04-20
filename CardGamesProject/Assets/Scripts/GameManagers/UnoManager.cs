using System.Collections;
using UnityEngine;

/// <summary>
/// UNO Game Manager class
/// </summary>
public class UnoManager : GameManager {

    /// <summary>
    /// Counter-clockwise rounds by default;
    /// </summary>
    bool roundDirection = false;
    /// <summary>
    /// ONLY FOR TESTING. TODO: REMOVE THIS
    /// </summary>
    Player currentPlayer;

    /// <summary>
    /// Unity uses this method to initialize objects. (Awake (creation) - Start (initialization) - Update(usual updates by frames))
    /// </summary>
    private void Start()
    {
        instance = this;

        SetupCards();

        decks[0].SetCards(cards);
        decks[0].Shuffle();

        //TODO: Player count
        SortPlayerList(5);

        foreach (Player p in players) // set hand reference to deck to draw cards from.
        {
            p.GetHand().SetDeck(decks[0]);
        }

        for (int i = 0; i < 7; i++) // draw 7 cards to everyones hand.
        {
            foreach (Player p in players)
            {
                p.GetHand().DrawCard();
                p.GetHand().EndOfTurn += PlayerEndOfTurn;
            }
        }

        Card starter = decks[0].DrawCard();
        while (!char.IsDigit(starter.Value[starter.Value.Length - 1])) // Cannot start with non numeric card.
        {
            decks[0].ShuffleInCard(starter);
            starter = decks[0].DrawCard();
        }
        piles[0].AddCard(starter); // Add top card of the remaining deck to pile to start the game with;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // TESTING
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        StartCoroutine(TestRun());
    }

    private IEnumerator TestRun()
    {
        currentPlayer = players[Random.Range(0, players.Count)];
        currentPlayer.GetHand().SetTurn();
        for (int i = 0; i < 10; i++)
        {
            currentPlayer.GetHand().ChooseCard(0);
            yield return new WaitForSeconds(1f);
        }
    }

    public void PlayerEndOfTurn(Player sender, Card c)
    {
        piles[0].AddCard(c);
        // TODO: Card Effects
        Player next = GetNextPlayer(sender, 0, roundDirection);
        next.GetHand().SetTurn();
        currentPlayer = next;
    }

    /// <summary>
    /// Gets the next player from the sorted list.
    /// </summary>
    /// <param name="current">Current player.</param>
    /// <param name="offset">Offset for players who are left out of a round.</param>
    /// <param name="clockwise">Clockwise or counter-clockwise.</param>
    /// <returns></returns>
    private Player GetNextPlayer(Player current, int offset, bool clockwise)
    {

        int idx = players.IndexOf(current);

        idx += clockwise ? (1 + offset) : (-1 - offset);

        if (idx >= players.Count)
        {
            return players[idx - players.Count]; // Offset
        }
        if (idx < 0)
        {
            return players[players.Count + idx];
        }
        return players[idx];
    }

    /// <summary>
    /// Set up cards the the current game. Set up visuals, values, etc...
    /// </summary>
    private void SetupCards()
    {
        GameObject card; //This will hold the card objects until they are added to the list;
        for (int n = 0; n < 2; n++)
        {
            for (int j = 0; j < 4; j++)
            {
                string color;
                string type;
                for (int i = 0; i < 10; i++)
                {
                    color = "Red";
                    if (j >= 1)
                        color = "Blue";
                    if (j >= 2)
                        color = "Yellow";
                    if (j >= 3)
                        color = "Green";

                    card = Instantiate(CardPrefab); // Creating a clone of the card prefab
                    card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
                    card.AddComponent<Card>(); // adding the card script to the object.
                    card.GetComponent<Card>().build("UI/UNO/" + color + "_" + i, "UI/UNO/UNOBack", color + "_" + i); //Building the card. Sets the visuals.
                    cards.Add(card.GetComponent<Card>());
                }

                for (int i = 0; i < 3; i++)
                {
                    color = "Red";
                    type = "X";
                    if (j >= 1)
                        color = "Blue";
                    if (j >= 2)
                        color = "Yellow";
                    if (j >= 3)
                        color = "Green";
                    if (i == 1)
                        type = "R";
                    if (i == 2)
                        type = "P2";

                    card = Instantiate(CardPrefab); // Creating a clone of the card prefab
                    card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
                    card.AddComponent<Card>(); // adding the card script to the object.
                    card.GetComponent<Card>().build("UI/UNO/" + color + "_" + type, "UI/UNO/UNOBack", color + "_" + type); //Building the card. Sets the visuals.
                    cards.Add(card.GetComponent<Card>());
                }
            }
            for (int j = 0; j < 4; j++)
            {
                string type = "Color";
                if (j >= 2)
                    type = "P4";

                card = Instantiate(CardPrefab); // Creating a clone of the card prefab
                card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
                card.AddComponent<Card>(); // adding the card script to the object.
                card.GetComponent<Card>().build("UI/UNO/" + type, "UI/UNO/UNOBack", type); //Building the card. Sets the visuals.
                cards.Add(card.GetComponent<Card>());
            }
        }
    }

}