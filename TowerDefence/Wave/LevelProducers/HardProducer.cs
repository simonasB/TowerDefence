using System.Collections.Generic;
using TowerDefence.Common;
using TowerDefence.Minions;
using TowerDefence.Minions.Beasts;
using TowerDefence.Minions.Dragons;

namespace TowerDefence.Wave.LevelProducers
{
    public class HardProducer : IWaveProducer
    {
        private readonly IFactoryProvider<IMinionFactory> _minionFactoryProvider;

        public HardProducer(IFactoryProvider<IMinionFactory> minionFactoryProvider)
        {
            _minionFactoryProvider = minionFactoryProvider;
        }
        public Wave Produce() {
            var minions = new List<Minion>();

            var beastFactory = _minionFactoryProvider.GetFactory(nameof(BeastFactory));
            var dragonFactory = _minionFactoryProvider.GetFactory(nameof(DragonFactory));

            minions.Add(beastFactory.CreateStrongMinion());
            minions.Add(beastFactory.CreateStrongMinion());

            minions.Add(dragonFactory.CreateStrongMinion());
            minions.Add(dragonFactory.CreateIntermediateMinion());

            return new Wave {
                Minions = minions
            };
        }
    }
}
