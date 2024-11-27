using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related
       
        public readonly SortedSet<PlayingCard> list = [];

        public void Add(PlayingCard card)
        { 
            cards.Add(card);
        }
        #endregion


        #region Highest Card related
        public PlayingCard Highest 
        {
            get
            {
               if (cards.Count == 0)
               {
                return null;
               }
               PlayingCard currentHighest = cards[0];

               for (int i = 0; i < cards.Count; i++)
               {
                    if (cards[i].CompareTo(currentHighest) > 0)
                    {
                        currentHighest = cards[i];
                    }
               }
               return currentHighest;
            }
        }


        public PlayingCard Lowest
        {
            get
            {if (cards.Count == 0)
               {
                return null;
               }
               PlayingCard currentLowest = cards[0];

               for (int i = 0; i < cards.Count; i++)
               {
                    if (cards[i].CompareTo(currentLowest) < 0)
                    {
                        currentLowest = cards[i];
                    }
               }
               return currentLowest;
            }
          }
        }
        #endregion
    }
