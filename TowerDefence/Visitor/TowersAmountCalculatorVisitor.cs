using System;
using TowerDefence.Minions;
using TowerDefence.Towers;

namespace TowerDefence.Visitor
{
    public class TowersAmountCalculatorVisitor : IVisitor
    {
        public decimal TotalMoney { get; set; }
        public int TowersAmount { get; set; }
        public TowersAmountCalculatorVisitor()
        {
            TotalMoney = 0;
            TowersAmount = 0;
        }

        public void Visit(AbstractTower tower)
        {
            TowersAmount = Convert.ToInt32(Math.Floor(TotalMoney/tower.Price));
        }

        public void Visit(Minion minion)
        {
            TotalMoney += minion.Money;
        }
    }
}
