namespace SchedarioMentale.Core;

public class Session
{
    public Card[] Cards { get; }

    public Session(Card[] cards)
    {
        Cards = cards;
    }
}