using System;
using System.Net;
using System.Reflection;
using TowerDefence.Common;
using TowerDefence.Minions;
using TowerDefence.Minions.Beasts;
using TowerDefence.Towers;
using TowerDefence.Towers.Factories;
using TowerDefence.Wave.LevelProducers;

namespace TowerDefence {
    public class Program {
        public static void Main(string[] args) {
            Logger.Instance().Info("Test logging");

            ITowerFactory towerFactory = LoadFactory();

            ITower tower = towerFactory.CreateTower();

            Console.WriteLine(tower.Name);
            Console.WriteLine(tower.Damage);
            Console.WriteLine(tower.Range);

            var factory = GetFactory<IMinionFactory>(nameof(BeastFactory));

            var minion = factory.CreateIntermediateMinion();
            Logger.Instance().Info($"Health:{minion.Health}, Name: {minion.Name}");

            var wave = ProduceWave();

            Logger.Instance().Info($"Wave minion count: {wave.Minions.Count}");

            Console.ReadLine();
        }

        static ITowerFactory LoadFactory()
        {
            // string factoryName = "TowerDefence.Factories.ArcherTowerFactory";
            string factoryName = "TowerDefence.Towers.Factories.CannonTowerFactory";
            return Assembly.GetExecutingAssembly().CreateInstance(factoryName) as ITowerFactory;
        }

        static T GetFactory<T>(string name) where T : class {
            return new FactoryProvider<T>().GetFactory(name);
        }

        static Wave.Wave ProduceWave() {
            return new HardProducer(new FactoryProvider<IMinionFactory>()).Produce();
        }
    }
}
