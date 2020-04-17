using UnityEngine;

/// <summary>
/// Players class.
/// </summary>
public class Player : MonoBehaviour {
    /// <summary>
    /// GameManager Reference to be able to call game over methods, or tell it to refresh the deck, etc.
    /// </summary>
    private GameManager gameManager;
    /// <summary>
    /// The players hand.
    /// </summary>
    private Hand hand;

}