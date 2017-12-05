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
            var minions = new Stack<Minion>();

            var beastFactory = _minionFactoryProvider.GetFactory(nameof(BeastFactory));
            var dragonFactory = _minionFactoryProvider.GetFactory(nameof(DragonFactory));

            minions.Push(beastFactory.CreateStrongMinion());
            minions.Push(beastFactory.CreateStrongMinion());

            minions.Push(dragonFactory.CreateStrongMinion());
            minions.Push(dragonFactory.CreateIntermediateMinion());

            return new Wave {
                Minions = minions
            };
        }
    }
}
