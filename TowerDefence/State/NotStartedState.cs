using System;
using TowerDefence.Core;

namespace TowerDefence.State {
    public class NotStartedState : GameState {
        public NotStartedState(Game game) : base(game) {
            game.Running = false;
        }

        public override string OnStart() {
            Game.Running = true;
            Game.GameState = new RunningState(Game);
            return "Running";
        }

        public override string OnPause() {
            return "Not started";
        }

        public override string OnSurrender() {
            return "Not started";
        }
    }
}
