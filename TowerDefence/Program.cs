using System;
using System.Reflection;
using TowerDefence.Common;
using TowerDefence.Minions;
using TowerDefence.Minions.Beasts;
using TowerDefence.Towers;
using TowerDefence.Towers.Factories;
using TowerDefence.Wave.LevelProducers;
using TowerDefence.Wave;
using TowerDefence.Towers.Attack;
using TowerDefence.Towers.Decorators;

namespace TowerDefence {
    public class Program {
        public static void Main(string[] args) {
            Logger.Instance().Info("Test logging");

            ITowerFactory towerFactory = LoadFactory();

            AbstractTower tower = towerFactory.CreateTower(new MediumAttack());

            Console.WriteLine(tower.Name);
            Console.WriteLine(tower.Damage);
            Console.WriteLine(tower.Range);

            tower.Attack();
            Console.WriteLine("Damage before: " + tower.Damage);
            MissedAttacks missedAttacks = new MissedAttacks(tower);
            Console.WriteLine("Damage after: " + missedAttacks.Damage);
            missedAttacks.Attack();

            var factory = GetFactory<IMinionFactory>(nameof(BeastFactory));

            var minion = factory.CreateIntermediateMinion();
            Logger.Instance().Info($"Health:{minion.Health}, Name: {minion.Name}");

            ReflectionFactoryProvider<IMinionFactory> reflectiveMinionFactory = new ReflectionFactoryProvider<IMinionFactory>();

            // Strategy pattern example using Wave
            WaveContext waveContext = new WaveContext(new HardProducer(reflectiveMinionFactory));
            var wave = waveContext.GetWave();
            Logger.Instance().Info($"Wave minion count: {wave.Minions.Count}");

            waveContext = new WaveContext(new EasyProducer(reflectiveMinionFactory));
            wave = waveContext.GetWave();
            Logger.Instance().Info($"Wave minion count: {wave.Minions.Count}");
            // End of strategy pattern example

            Console.ReadLine();
        }

        static ITowerFactory LoadFactory()
        {
            // string factoryName = "TowerDefence.Factories.ArcherTowerFactory";
            string factoryName = "TowerDefence.Towers.Factories.CannonTowerFactory";
            return Assembly.GetExecutingAssembly().CreateInstance(factoryName) as ITowerFactory;
        }

        static T GetFactory<T>(string name) where T : class {
            return new ReflectionFactoryProvider<T>().GetFactory(name);
        }
    }
}
