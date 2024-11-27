using System;

namespace ProjectPartB_B1

{
class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();

            System.Console.WriteLine("Let's play a game of cards with 2 players!");
            TryReadNrOfCards(out int NrOfCards);
            TryReadNrOfRounds(out int NrOfRounds);
           
            for (int round = 1; round < NrOfRounds+1; round++)
            {
            System.Console.WriteLine($"\nPlaying round number: {round}");   
            System.Console.WriteLine("------------------------");
            Deal(myDeck, NrOfCards,player1, player2);
            System.Console.WriteLine($"\nGave cards to a players from the top of the deck. Deck has now {myDeck.Count}");
             
            System.Console.WriteLine($"\nPlayer1 hand with {NrOfCards} cards."); 
            System.Console.WriteLine($"Player1 lowest card in hand is {player1.Lowest} and the highest card is {player1.Highest}");
            System.Console.WriteLine(player1);

            System.Console.WriteLine($"\nPlayer2 hand with {NrOfCards} cards."); 
            System.Console.WriteLine($"Player2 lowest card in hand is {player2.Lowest} and the highest card is {player2.Highest}");
            System.Console.WriteLine(player2);
             
             DetermineWinner(player1, player2);
             player1.Clear();
             player2.Clear();
            }
        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            NrOfCards = 0;
            while (true)
            {
                System.Console.WriteLine("How many cards to deal to each player (1-5 cards or Q to Quit)?");
                string input = Console.ReadLine();
                if (int.TryParse(input, out NrOfCards) && NrOfCards >= 1 && NrOfCards <= 5) 
                {
                    return true;
                }
                if (input.ToLower().Trim()=="q")
                {
                    System.Console.WriteLine("Quitting the game... Have a nice day!");
                    NrOfCards = default;
                    Environment.Exit(0);
                }
                System.Console.WriteLine("Wrong input, please try again!");
            }
        }

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            NrOfRounds = 0;
            while (true)
            {
                System.Console.WriteLine("How many rounds should we play (1-5 or Q to Quit)?");
                string input = Console.ReadLine();
                if (int.TryParse(input, out NrOfRounds) && NrOfRounds >= 1 && NrOfRounds <= 5)
                {
                    return true;
                }
                if (input.ToLower().Trim()=="Q")
                {
                    System.Console.WriteLine("Quitting the game... Have a nice day!");
                    NrOfRounds = default;
                    return false;
                }
                System.Console.WriteLine("Wrong input, please try again!");
            }
        }

        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        { 
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                if (myDeck.Count >= 0)
                {
                    player1.Add(myDeck.RemoveTopCard());
                }
                if (myDeck.Count >= 0)
                {
                    player2.Add(myDeck.RemoveTopCard());
                }
                else System.Console.WriteLine("There is now cards in the deck");   
            }
        }
        
        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2) 
        {
            if (player1.Highest.CompareTo(player2.Highest) >= 0)
            {
                System.Console.WriteLine("\nPlayer 1 wins!!!"); 
                System.Console.WriteLine("------------------");  

                if (player1.Highest.Equals(player2.Highest))
                {
                    System.Console.WriteLine("\nIt's a tie!!!");
                    System.Console.WriteLine("------------------");     
                }
            }
            else
            {
                System.Console.WriteLine("\nPlayer 2 wins!!!");
                System.Console.WriteLine("------------------");  
            }    
        }
    }
}