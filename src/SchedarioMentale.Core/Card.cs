namespace SchedarioMentale.Core;

public class Card
{
    public int Number { get; }

    public Card(int number)
    {
        Number = number;
    }

    public string FormattedNumber => Number.ToString().PadLeft(2, '0');
}