using System;
using TowerDefence.Minions;
using TowerDefence.Minions.Beasts;
using TowerDefence.Minions.Dragons;

namespace TowerDefence.Core {
    public class GameLevel {
        public int HitPoints { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        // Minion spawning interval
        public int SpawnDelayMilis { get; set; }
        // How many times to spawn minion
        public int Count { get; set; }
        public bool Ground { get; set; }
        public decimal Money { get; set; }
        public float Speed { get; set; }
        public int Points { get; set; }
        public bool Active { get; set; }

        public DateTime LastTimeSpawn { get; set; }

        public GameLevel()
        {
            LastTimeSpawn = DateTime.Now;
        }

        public Minion SpawnOne(Map map)
        {
            LastTimeSpawn = DateTime.Now;
            Count--;

            Minion enemy = null;
            if (Ground)
                enemy = new StrongDragon(Speed, HitPoints, 100, map) { Height = Height, Width = Width, Money = Money, Points = Points };
            else
                enemy = new StrongBeast(Speed, HitPoints, 100, map) { Height = Height, Width = Width, Money = Money, Points = Points };

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
