using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenGruppeB
{
    public class Dealer : ThreadProxy
    {
        // Singleton pattern, makes sure only one instance of Dealer is created
        private static readonly Dealer Instance = new Dealer();
        public static Dealer GetDealer()
        {
            return Instance;
        }

        private readonly Deck _deck = Deck.GetDeck();
        private readonly object _lock = new object();
        public bool HasCards => _deck.IsEmpty();

        protected override void Task()
        {
            //throw new NotImplementedException();
        }

        public ICard GiveCard()
        {
            lock (_lock)
            {
                if (HasCards)
                {
                    return _deck.CardFromDeck();
                }
                return null;
            }
        }

        public void TakeCard(ICard card)
        {
            lock (_lock)
            { 
                _deck.CardToDeck(card);
            }
        }
    }
}
