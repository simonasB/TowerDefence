using System;
using System.Reflection;
using TowerDefence.Factories;
using TowerDefence.Towers;

namespace TowerDefence {
    public class Program {
        public static void Main(string[] args) {
            Logger.Instance().Info("Test logging");
            Console.ReadLine();

            ITowerFactory towerFactory = LoadFactory();

            ITower tower = towerFactory.CreateTower();

            Console.WriteLine(tower.getName());
            Console.WriteLine(tower.getDamage());
            Console.WriteLine(tower.getRange());
        }

        static ITowerFactory LoadFactory()
        {
            // string factoryName = "TowerDefence.Factories.ArcherTowerFactory";
            string factoryName = "TowerDefence.Factories.CannonTowerFactory";
            return Assembly.GetExecutingAssembly().CreateInstance(factoryName) as ITowerFactory;
        }
    }
}
