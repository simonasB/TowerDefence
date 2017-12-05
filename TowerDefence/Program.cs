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
            //SecondPartPatternsDemo();
            LoggerChainTest();

            Console.ReadLine();
        }

        static void LoggerChainTest()
        {
            Console.WriteLine("Starting chained logger test");
            Console.WriteLine();

            Logger.Instance().Log(LogLevel.INFO, "Testing info message");
            Logger.Instance().Log(LogLevel.DEBUG, "Testing debug message");
            Logger.Instance().Log(LogLevel.ERROR, "Testing error message");
            Logger.Instance().Log(LogLevel.FATAL, "Testing fatal message");

            Console.WriteLine();
            Console.WriteLine("Chained logging test completed");
        }

        static void FirstPartPatternsDemo() {
            Logger.Instance().Log(LogLevel.INFO, "Test logging");

            ITowerFactory towerFactory = LoadFactory();

            AbstractTower tower = towerFactory.CreateTower(new MediumAttack());

            Console.WriteLine(tower.Name);
            Console.WriteLine(tower.Damage);
            Console.WriteLine(tower.Range);

            tower.Attack(null);
            Console.WriteLine("Damage before: " + tower.Damage);
            MissedAttacksTowerDecorator missedAttacksTowerDecorator = new MissedAttacksTowerDecorator(tower);
            Console.WriteLine("Damage after: " + missedAttacksTowerDecorator.Damage);
            missedAttacksTowerDecorator.Attack(null);

            var factory = GetFactory<IMinionFactory>(nameof(BeastFactory));

            var minion = factory.CreateIntermediateMinion();
            Logger.Instance().Log(LogLevel.INFO, $"Health:{minion.Health}, Name: {minion.Name}");

            ReflectionFactoryProvider<IMinionFactory> reflectiveMinionFactory =
                new ReflectionFactoryProvider<IMinionFactory>();

            // Strategy pattern example using Wave
            WaveContext waveContext = new WaveContext(new HardProducer(reflectiveMinionFactory));
            var wave = waveContext.GetWave();
            Logger.Instance().Log(LogLevel.INFO, $"Wave minion count: {wave.Minions.Count}");

            waveContext = new WaveContext(new EasyProducer(reflectiveMinionFactory));
            wave = waveContext.GetWave();
            Logger.Instance().Log(LogLevel.INFO, $"Wave minion count: {wave.Minions.Count}");
            // End of strategy pattern example
        }

        static void SecondPartPatternsDemo() {
            var tower = new ArcherTower(new HardAttack());
            var killedMinionsDecorator = new KilledMinionsTowerDecorator(tower);
            killedMinionsDecorator.Attack(null);

            // Adapter
            IDatabaseAdapter ravenDb = new RavenDbAdapter(DocumentStoreHolder.Store);
            IDatabaseAdapter liteDb = new LiteDBAdapter(new LiteRepository(Path.Combine(Directory.GetCurrentDirectory(), "liteDb.db")));

            SaveGameInfo(ravenDb);
            SaveGameInfo(liteDb);
        }

        private static void SaveGameInfo(IDatabaseAdapter databaseAdapter) {           
            var playerName = "player1";

            databaseAdapter.Save(new GameInfo {PlayerName = playerName });

            var gameInfo = databaseAdapter.Retrieve(playerName);

            Logger.Instance().Log(LogLevel.INFO, $"Database: {databaseAdapter.GetType().Name}, Id: {gameInfo.Id}, PlayerName: {gameInfo.PlayerName}");
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
