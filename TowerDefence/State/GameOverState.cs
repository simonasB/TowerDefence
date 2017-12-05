using TowerDefence.Core;

namespace TowerDefence.State {
    public class GameOverState : GameState{
        public GameOverState(Game game) : base(game) {
            Game.Running = false;
        }

        public override string OnStart() {
            Game.Running = true;
            Game.GameState = new RunningState(Game);
            return "Running";
        }

        public override string OnPause() {
            return "Game over";
        }

        public override string OnSurrender() {
            return "Game over";
        }
    }
}
