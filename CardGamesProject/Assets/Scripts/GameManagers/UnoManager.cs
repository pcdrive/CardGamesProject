using System.Collections;
using UnityEngine;

/// <summary>
/// UNO Game Manager class
/// </summary>
public class UnoManager : GameManager {

    /// <summary>
    /// Current amount of cards to draw for the next player.
    /// </summary>
    private uint drawSum = 0;
    /// <summary>
    /// Value of the last card.
    /// </summary>
    private string lastCardsValue = "";

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
            p.GetHand().isCardAvailable = SetCardFrame;
            p.GetHand().isCardUnavailable = SetCardBlock;
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
        while (!char.IsDigit(starter.Value[starter.Value.Length - 1]) || starter.Value[starter.Value.Length - 2] != '_') // Cannot start with non numeric card.
        {
            decks[0].ShuffleInCard(starter);
            starter = decks[0].DrawCard();
        }
        piles[0].AddCard(starter); // Add top card of the remaining deck to pile to start the game with;
        lastCardsValue = starter.Value;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // TESTING
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        //StartCoroutine(TestRun());
        currentPlayer = players[Random.Range(0, players.Count)];
        currentPlayer.GetHand().SetTurn();
    }

    /// <summary>
    /// Handles the event of the EndTurn.
    /// </summary>
    /// <param name="sender">The player who owned the turn.</param>
    /// <param name="c">The chosen card for the pile.</param>
    public void PlayerEndOfTurn(Player sender, Card c)
    {
        piles[0].AddCard(c);
        Player next;

        if (c.Value.Contains("_R")) // reverse
        {
            roundDirection = !roundDirection;
        }

        if (c.Value.Contains("_X")) //one round out
            next = GetNextPlayer(sender, 1, roundDirection);
        else
            next = GetNextPlayer(sender, 0, roundDirection);



        next.GetHand().SetTurn();
        currentPlayer = next;
        lastCardsValue = c.Value;
        if (char.IsDigit(c.Value[c.Value.Length - 1]) && c.Value.ToLower()[c.Value.Length - 2] == 'p')
        {
            drawSum += uint.Parse(c.Value[c.Value.Length - 1] + "");
        }
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
                    card.GetComponent<Card>().build("UI/UNO/CardFrame", "UI/UNO/" + color + "_" + i, "UI/UNO/CardSelectionFrame", "UI/UNO/UNOBack", color + "_" + i); //Building the card. Sets the visuals.
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
                    card.GetComponent<Card>().build("UI/UNO/CardFrame", "UI/UNO/" + color + "_" + type, "UI/UNO/CardSelectionFrame", "UI/UNO/UNOBack", color + "_" + type); //Building the card. Sets the visuals.
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
                card.GetComponent<Card>().build("UI/UNO/CardFrame", "UI/UNO/" + type, "UI/UNO/CardSelectionFrame", "UI/UNO/UNOBack", type); //Building the card. Sets the visuals.
                cards.Add(card.GetComponent<Card>());
            }
        }
    }

    /// <summary>
    /// Sets frame for cards that are available to use.
    /// </summary>
    /// <param name="card">Card to check.</param>
    public override void SetCardFrame(Card card)
    {
        if (IsCardAvailable(card))
        {
            card.ToggleFrame(true);
        }
    }

    /// <summary>
    /// Sets block for cards that are available to use.
    /// </summary>
    /// <param name="card">Card to check.</param>
    public override void SetCardBlock(Card card)
    {
        if (!IsCardAvailable(card))
        {
            card.ToggleBlock(true);
        }
    }

    /// <summary>
    /// Returns in the given card is playable in the current turn.
    /// </summary>
    /// <param name="card">The card to check.</param>
    /// <returns>Availability of the card in the current turn.</returns>
    private bool IsCardAvailable(Card card)
    {
        bool res = false;

        if (drawSum != 0)
        {
            if (lastCardsValue.Contains("P4"))
            {
                if (card.Value.Contains("P4"))
                    res = true;
                else
                    res = false;
            }
            if (lastCardsValue.Contains("P2"))
            {
                if (card.Value.Contains("P2"))
                    res = true;
                else
                    res = false;
            }
        }
        else
        {
            string[] lastSplit = lastCardsValue.Split('_');
            string[] cardSplit = card.Value.Split('_');
            if (char.IsDigit(lastCardsValue[lastCardsValue.Length - 1]) && lastCardsValue.ToLower()[lastCardsValue.Length - 2] == '_')
            {
                if ((lastCardsValue.Contains("Red") && (card.Value.Contains("Red") || card.Value.Contains("Color") || card.Value.Contains("P4"))) ||
                    (lastCardsValue.Contains("Green") && (card.Value.Contains("Green") || card.Value.Contains("Color") || card.Value.Contains("P4"))) ||
                    (lastCardsValue.Contains("Blue") && (card.Value.Contains("Blue") || card.Value.Contains("Color") || card.Value.Contains("P4"))) ||
                    (lastCardsValue.Contains("Yellow") && (card.Value.Contains("Yellow") || card.Value.Contains("Color") || card.Value.Contains("P4"))) ||
                    (lastSplit[lastSplit.Length - 1].Equals(cardSplit[cardSplit.Length - 1]))
                    )
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
        }

        return res;
    }
}