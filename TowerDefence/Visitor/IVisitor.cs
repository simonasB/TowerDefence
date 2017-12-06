using TowerDefence.Minions;
using TowerDefence.Towers;

namespace TowerDefence.Visitor
{
    public interface IVisitor
    {
        decimal TotalMoney { get; set; }
        int TowersAmount { get; set; }
        void Visit(AbstractTower tower);
        void Visit(Minion minion);
    }
}
