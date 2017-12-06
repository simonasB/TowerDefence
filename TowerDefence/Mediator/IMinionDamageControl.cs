using TowerDefence.Minions;

namespace TowerDefence.Mediator {
    public interface IMinionDamageControl {
        void ReceiveMinionLocation(Minion reportingMinion);
        void RegisterMinionUnderGuidance(Minion minion);
    }
}
