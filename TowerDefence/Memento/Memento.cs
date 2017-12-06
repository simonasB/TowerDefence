using System.Collections.Generic;
using TowerDefence.Core;
using TowerDefence.Towers;

namespace TowerDefence.Memento {
    public class Memento {
        private readonly List<AbstractTower> _state;

        public Memento(List<AbstractTower> state) {
            _state = state;
        }

        public void GetState(Game originator) {
            originator.SetTowersState(this._state);
        }
    }
}
