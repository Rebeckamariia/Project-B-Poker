using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);
 
        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count;
        #endregion
 
        #region ToString() related
        public override string ToString()
        {
            string s = "";
            int count = 0;
           
           foreach (var item in cards)
           {
             s += $"{item, -10}";
             count++;
 
             if(count % 13 == 0){
                s += "\n";
             }
             else{
                s += " ";
             }
 
           }
            return s;
        }
        #endregion
 
        #region Shuffle and Sorting
        public void Shuffle()
        {
            Random rnd = new Random();
            int n = cards.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int randomIndex = rnd.Next(i, n);
                PlayingCard temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }
        public void Sort()
        {
            cards.Sort();
        }
        #endregion
 
        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear();
        }
        public void CreateFreshDeck()
        {
            cards = new List<PlayingCard>(MaxNrOfCards);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    cards.Add(new PlayingCard
                    {
                        Color = (PlayingCardColor)i,
                        Value = (PlayingCardValue)j,
                    });
                }
            }
        }
        #endregion
 
        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            if (cards.Count > 0)
            {
                PlayingCard topCard = cards[0];
                cards.RemoveAt(0);
                return topCard;
 
 
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
 