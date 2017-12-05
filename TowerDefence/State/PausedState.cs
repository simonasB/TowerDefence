using System;
using TowerDefence.Core;

namespace TowerDefence.State
{
    public class PausedState : GameState
    {
        public PausedState(Game game) : base(game) {
            Game.Running = false;
        }

        public override string OnStart() {
            Game.Running = true;
            Game.GameState = new RunningState(Game);
            return "Running";
        }

        public override string OnPause() {
            return "Paused";
        }

        public override string OnSurrender() {
            Game.Running = false;
            Game.GameState = new GameOverState(Game);
            return "Game over";
        }
    }
}
