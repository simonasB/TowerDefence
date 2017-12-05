using TowerDefence.Core;

namespace TowerDefence.State {
    public class RunningState : GameState {
        public RunningState(Game game) : base(game) {
        }

        public override string OnStart() {
            return "Running";
        }

        public override string OnPause() {
            Game.Running = false;
            Game.GameState = new PausedState(Game);
            return "Paused";
        }

        public override string OnSurrender() {
            Game.Running = false;
            Game.GameState = new GameOverState(Game);
            return "Game over";
        }
    }
}
