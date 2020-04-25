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
    private SpriteRenderer block;
    /// <summary>
    /// Front sprite renderer
    /// </summary>
    private SpriteRenderer front;
    /// <summary>
    /// Cardback sprite renderer
    /// </summary>
    private SpriteRenderer back;
    /// <summary>
    /// Frame sprite renderer. Used for displaying playable or special effects cards.
    /// </summary>
    private SpriteRenderer frame;
    /// <summary>
    /// property of value
    /// </summary>
    public string Value { get { return value; } }

    /// <summary>
    /// Setting the card up. Loading and settings up its visuals, and value
    /// </summary>
    /// <param name="_front">Front Sprite of the card.</param>
    /// <param name="_back">Cardback Sprite of the card.</param>
    /// <param name="_value">Value of the card.</param>
    public void build(string _block, string _front, string _frame, string _back, string _value)
    {
        value = _value; // setting value
        block = transform.Find("Block").GetComponent<SpriteRenderer>(); //SpriteRenderer is what makes the sprite visible.
        front = transform.Find("Front").GetComponent<SpriteRenderer>(); //SpriteRenderer is what makes the sprite visible.
        frame = transform.Find("Frame").GetComponent<SpriteRenderer>(); //This can be used to show current playable cards, or cards that have special effect, etc...
        back = transform.Find("Back").GetComponent<SpriteRenderer>(); //It can give it color, draw mode, sorting layer, etc...

        block.sprite = Resources.Load<Sprite>(_block); //setting the front sprite
        front.sprite = Resources.Load<Sprite>(_front); //setting the front sprite
        frame.sprite = Resources.Load<Sprite>(_frame); //setting the frame sprite
        back.sprite = Resources.Load<Sprite>(_back); //setting the back sprite

        block.enabled = false;
        frame.enabled = false;
    }

    /// <summary>
    /// Dont need to know. It sets the drawing order, so it defines which sprite is in front.
    /// </summary>
    /// <param name="i">Order value.</param>
    public void SetOrderInLayer(int i)
    {
        block.sortingOrder = i;
        front.sortingOrder = i;
        frame.sortingOrder = i;
        back.sortingOrder = i;
    }

    /// <summary>
    /// Toggles the cards frame.
    /// </summary>
    /// <param name="toState">State to put the frame in.</param>
    public void ToggleFrame(bool toState)
    {
        frame.enabled = toState;
    }

    /// <summary>
    /// Toggles blocking layer.
    /// </summary>
    /// <param name="toState">Block state to set.</param>
    public void ToggleBlock(bool toState)
    {
        block.enabled = toState;
    }
}