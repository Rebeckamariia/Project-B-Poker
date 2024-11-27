using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		
		
		public int CompareTo(PlayingCard card1)
        {
			if (Value > card1.Value)
				return 1;
			else if (Value < card1.Value)
				return -1;
			else 
				return 0;
        }

		#endregion

        #region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
			
			get
			{
			string suitsvalue =  Color  switch
                {
                    PlayingCardColor.Clubs => "\u2663",
                    PlayingCardColor.Diamonds => "\u2666",
                    PlayingCardColor.Hearts => "\u2665",
                    PlayingCardColor.Spades => "\u2660",
                    _ => "",
                };
 				return $"{suitsvalue} {Value}";
			}
		}

		public override string ToString() => ShortDescription;
        #endregion
    }
}
