using TowerDefence.Core;

namespace TowerDefence.Memento {
    public class Memento {
        private Game _state;

        public Memento(Game state) {
            _state = state;
        }

        public void GetState(Originator originator) {
            originator.RestoreState(this);
        }
    }
}
