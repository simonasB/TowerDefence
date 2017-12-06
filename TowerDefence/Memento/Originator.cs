using TowerDefence.Core;

namespace TowerDefence.Memento {
    public class Originator {
        private Game _state;

        public Originator(Game state) {
            _state = state;
        }

        public Memento SaveState() {
            return new Memento(_state);
        }

        public void RestoreState(Memento restoreState) {
            restoreState.GetState(this);
        }

        public void SetState(Game newState) {
            _state = newState;
        }
    }
}