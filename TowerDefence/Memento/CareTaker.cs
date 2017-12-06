using System.Collections.Generic;

namespace TowerDefence.Memento {
    public class CareTaker {
        private readonly List<Memento> _statesList;

        public CareTaker() {
            _statesList = new List<Memento>();
        }

        public void Add(Memento state) {
            _statesList.Add(state);
        }

        public Memento Get(int index) {
            Memento restoredState = _statesList[index];
            _statesList.RemoveAt(index);
            return restoredState;
        }

        public int Size() {
            return _statesList.Count;
        }
    }
}
