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

    /// <summary>
    /// Unity uses this method to initialize objects. (Awake (creation) - Start (initialization) - Update(usual updates by frames))
    /// </summary>
    private void Awake()
    {
        hand = transform.Find("Hand").GetComponent<Hand>();
    }

    /// <summary>
    /// Get reference to hand.
    /// </summary>
    /// <returns>The players hand.</returns>
    public Hand GetHand() {
        return hand;
    }

}