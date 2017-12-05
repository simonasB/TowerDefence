using System;
using TowerDefence.Minions;
using TowerDefence.Minions.Dragons;
using TowerDefence.Wave;

namespace TowerDefence.Core {
    public class GameLevel {
        // Minion spawning interval
        public int SpawnDelayMilis { get; set; }
        // How many times to spawn minion
        public int Count { get; set; }
        public bool Active { get; set; }

        public int Level { get; set; }

        public WaveContext WaveContext { get; set; }

        private Wave.Wave _wave;

        public DateTime LastTimeSpawn { get; set; }

        public GameLevel()
        {
            LastTimeSpawn = DateTime.Now;
        }

        public Minion SpawnOne(Map map)
        {
            if (_wave == null || _wave.Minions.Count == 0) {
                _wave = WaveContext.GetWave();
            }

            LastTimeSpawn = DateTime.Now;
            Count--;

            var enemy = _wave.Minions.Pop();
            //enemy = new StrongDragon(Speed, HitPoints, 100, map) { Height = Height, Width = Width, Money = Money, Points = Points };

            enemy.PositionEnemyForStart(map);

            return enemy;
        }

        public bool CanSpawn()
        {
            if (Count == 0) return false;
            return Calc.TimePassed(SpawnDelayMilis, LastTimeSpawn);
        }
    }
}
