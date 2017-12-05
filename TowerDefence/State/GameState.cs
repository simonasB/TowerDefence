using TowerDefence.Core;

namespace TowerDefence.State {
    public abstract class GameState {
        protected readonly Game Game;

        protected GameState(Game game) {
            Game = game;
        }

        public abstract string OnStart();
        public abstract string OnPause();
        public abstract string OnSurrender();
    }
}
