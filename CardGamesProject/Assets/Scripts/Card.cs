using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents a card. Attach to a card prefab to make it work.
/// </summary>
public class Card : MonoBehaviour {

    /// <summary>
    /// Value of the card like: "Spades 5" or "Red 0"
    /// </summary>
    private string value;
    /// <summary>
    /// Front sprite renderer
    /// </summary>
    private SpriteRenderer front;
    /// <summary>
    /// Cardback sprite renderer
    /// </summary>
    private SpriteRenderer back;

    /// <summary>
    /// Setting the card up. Loading and settings up its visuals, and value
    /// </summary>
    /// <param name="_front">Front Sprite of the card.</param>
    /// <param name="_back">Cardback Sprite of the card.</param>
    /// <param name="_value">Value of the card.</param>
    public void build(string _front, string _back, string _value)
    {
        value = _value; // setting value
        front = transform.Find("Front").GetComponent<SpriteRenderer>(); //SpriteRenderer is what makes the sprite visible.
        back = transform.Find("Back").GetComponent<SpriteRenderer>(); //It can give it color, draw mode, sorting layer, etc...

        front.sprite = Resources.Load<Sprite>(_front); //setting the front sprite
        back.sprite = Resources.Load<Sprite>(_back); //setting the back sprite
    }

}