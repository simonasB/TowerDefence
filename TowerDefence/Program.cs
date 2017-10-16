using System;
using System.IO;
using System.Reflection;
using LiteDB;
using TowerDefence.Common;
using TowerDefence.Database;
using TowerDefence.Database.Entities;
using TowerDefence.Database.RavenDb;
using TowerDefence.Minions;
using TowerDefence.Minions.Beasts;
using TowerDefence.Towers;
using TowerDefence.Towers.Factories;
using TowerDefence.Wave.LevelProducers;
using TowerDefence.Wave;
using TowerDefence.Towers.Attack;
using TowerDefence.Towers.Decorator;

namespace TowerDefence {
    public class Program {
        public static void Main(string[] args) {
            SecondPartPatternsDemo();

            Console.ReadLine();
        }

        static void FirstPartPatternsDemo() {
            Logger.Instance().Info("Test logging");

            ITowerFactory towerFactory = LoadFactory();

            AbstractTower tower = towerFactory.CreateTower(new MediumAttack());

            Console.WriteLine(tower.Name);
            Console.WriteLine(tower.Damage);
            Console.WriteLine(tower.Range);

            tower.Attack();
            Console.WriteLine("Damage before: " + tower.Damage);
            MissedAttacksTowerDecorator missedAttacksTowerDecorator = new MissedAttacksTowerDecorator(tower);
            Console.WriteLine("Damage after: " + missedAttacksTowerDecorator.Damage);
            missedAttacksTowerDecorator.Attack();

            var factory = GetFactory<IMinionFactory>(nameof(BeastFactory));

            var minion = factory.CreateIntermediateMinion();
            Logger.Instance().Info($"Health:{minion.Health}, Name: {minion.Name}");

            ReflectionFactoryProvider<IMinionFactory> reflectiveMinionFactory =
                new ReflectionFactoryProvider<IMinionFactory>();

            // Strategy pattern example using Wave
            WaveContext waveContext = new WaveContext(new HardProducer(reflectiveMinionFactory));
            var wave = waveContext.GetWave();
            Logger.Instance().Info($"Wave minion count: {wave.Minions.Count}");

            waveContext = new WaveContext(new EasyProducer(reflectiveMinionFactory));
            wave = waveContext.GetWave();
            Logger.Instance().Info($"Wave minion count: {wave.Minions.Count}");
            // End of strategy pattern example
        }

        static void SecondPartPatternsDemo() {
            // Decorator 
            var tower = new ArcherTower(new HardAttack());
            var killedMinionsDecorator = new KilledMinionsTowerDecorator(tower);
            killedMinionsDecorator.Attack();

            // Adapter
            IDatabaseAdapter ravenDb = new RavenDbAdapter(DocumentStoreHolder.Store);
            IDatabaseAdapter liteDb = new LiteDBAdapter(new LiteRepository(Path.Combine(Directory.GetCurrentDirectory(), "liteDb.db")));

            SaveGameInfo(ravenDb);
            SaveGameInfo(liteDb);

            // Bridge

            // Any other
        }

        private static void SaveGameInfo(IDatabaseAdapter databaseAdapter) {           
            var playerName = "player1";

            databaseAdapter.Save(new GameInfo {PlayerName = playerName });

            var gameInfo = databaseAdapter.Retrieve(playerName);

            Logger.Instance().Info($"Database: {databaseAdapter.GetType().Name}, Id: {gameInfo.Id}, PlayerName: {gameInfo.PlayerName}");
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
