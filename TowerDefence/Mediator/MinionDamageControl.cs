using System.Collections.Generic;
using System.Linq;
using TowerDefence.Core;
using TowerDefence.Minions;

namespace TowerDefence.Mediator {
    public class MinionDamageControl : IMinionDamageControl {
        private readonly IList<Minion> _minionsUnderGuidance = new List<Minion>();

        public void ReceiveMinionLocation(Minion reportingMinion) {
            foreach (var currentMinionUnderGuidance in _minionsUnderGuidance.Where(o => o != reportingMinion)) {
                if (Calc.Distance(currentMinionUnderGuidance.Center, reportingMinion.Center) < 2) {
                    currentMinionUnderGuidance.HitPoints -= reportingMinion.LastReceivedDamage / 4;
                }
            }
        }

        public void RegisterMinionUnderGuidance(Minion minion) {
            if (!_minionsUnderGuidance.Contains(minion)) {
                _minionsUnderGuidance.Add(minion);
            }
        }
    }
}
