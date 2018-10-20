using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Sheephead.UnitTests")]

namespace Sheephead
{
    public class Game
    {
        #region Consts
        private const int HAND_SIZE = 10;
        private const int BLIND_SIZE = 2;
        #endregion

        #region Properties
        public Player[] Players { get; private set; }
        public Blind Blind { get; private set; }

        public Deck Deck { get; private set; }

        private int _dealerIndex = 0;
        public Player Dealer { get { return Players[_dealerIndex]; } }

        private int? _pickerIndex = null;
        public Player Picker
        {
            get
            {
                if (_pickerIndex == null) return null;

                return Players[_pickerIndex.Value];
            }
        }

        private int _leadIndex;
        #endregion

        #region Constructor
        public Game(Player player1, Player player2, Player player3)
        {
            Players = new Player[] { player1, player2, player3 };
            Deck = new Deck();

            _dealerIndex = 0;
            _leadIndex = 1;
        }
        #endregion

        #region Public Methods
        public void PlayHand()
        {
            Deck.Shuffle();
            Deal();
            FindPicker();

            if (Picker != null)
            {
                Picker.Pick(Blind);
                Picker.Bury();

                for (int i = 0; i < HAND_SIZE; i++)
                    PlayTrick();

                ScoreHand();
            }

            PassDeal();
        }
        #endregion

        #region Private Methods
        internal void Deal()
        {
            for (int i = 0; i < HAND_SIZE; i++)
            {
                Players[_dealerIndex + 1 % 3].Hand.AddCard(Deck[(3 * i) + 1]);
                Players[_dealerIndex + 2 % 3].Hand.AddCard(Deck[(3 * i) + 2]);
                Players[_dealerIndex + 3 % 3].Hand.AddCard(Deck[(3 * i) + 3]);
            }

            Blind.AddCard(Deck[30]);
            Blind.AddCard(Deck[31]);
        }







        private void PassDeal()
        {
            foreach (var p in Players)
            {
                p.Tricks.Clear();
            }

            _dealerIndex = (_dealerIndex + 1) % 3;
            _leadIndex = (_leadIndex + 1) % 3;
        }

        private void ScoreHand()
        {
            var pickerScore = Picker.ScoreHand();
            var partnersScore = Players
                .Where(p => !Object.ReferenceEquals(Picker, p))
                .Sum(p => p.ScoreHand());

            // TODO: Update scores
        }

        private void PlayTrick()
        {
            var trick = new Card[Players.Length];
            var playOrderIndex = 0;

            for (int i = _leadIndex; i < Players.Length; i = (i + 1) % 3)
            {
                trick[playOrderIndex] = Players[i].PlayCard();
                // TODO: Verify play is valid
                playOrderIndex = playOrderIndex + 1;
            }

            var trickWinnerIndex = DetermineTrickWinner(trick);

            Players[trickWinnerIndex].Tricks.Add(trick);
            _leadIndex = trickWinnerIndex;

        }

        private int DetermineTrickWinner(Card[] trick)
        {
            throw new NotImplementedException();
        }

        private void FindPicker()
        {
            var pickerFound = false;
            var onTheEnd = false;
            var playerToAskIndex = _dealerIndex;

            while (!pickerFound && !onTheEnd)
            {
                playerToAskIndex = (playerToAskIndex + 1) % 3;
                onTheEnd = (playerToAskIndex == _dealerIndex);

                if (Players[playerToAskIndex].WantsToPick())
                {
                    pickerFound = true;
                    _pickerIndex = playerToAskIndex;
                }
            }
        }
        #endregion
    }
}
