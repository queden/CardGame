using System;
using System.Collections.Generic;
using System.Text;


class Card
{
    /// <summary>
    /// Initializes a card, setting it as not enabled
    /// </summary>
    public Card()
    {
        enabled = false;
    }
    /// <summary>
    /// Boolean of whether the card has been revealed
    /// </summary>
    public bool enabled { get; set; }
    /// <summary>
    /// Type of the card that determines what value it holds
    /// </summary>
    public CardTypes type { get; set; }
    /// <summary>
    /// Prints the cards type if enabled, X if not
    /// </summary>
    /// <returns>Representation of the card depending on if it is enabled</returns>
    public string PrintCard()
    {
        string card = "";
        if (enabled)
        {
            card += this.type;
        }
        else
        {
            card += "X";
        }
        return card;
    }
}

