using System.Collections.Generic;
using TowerDefence.Common;
using TowerDefence.Minions;
using TowerDefence.Minions.Beasts;
using TowerDefence.Minions.Dragons;

namespace TowerDefence.Wave.LevelProducers
{
    public class MediumProducer : IWaveProducer
    {
        private readonly IFactoryProvider<IMinionFactory> _minionFactoryProvider;

        public MediumProducer(IFactoryProvider<IMinionFactory> minionFactoryProvider)
        {
            _minionFactoryProvider = minionFactoryProvider;
        }

        public Wave Produce() {
            var minions = new Stack<Minion>();

            var beastFactory = _minionFactoryProvider.GetFactory(nameof(BeastFactory));
            var dragonFactory = _minionFactoryProvider.GetFactory(nameof(DragonFactory));

            minions.Push(beastFactory.CreateWeakMinion());
            minions.Push(beastFactory.CreateStrongMinion());
            minions.Push(dragonFactory.CreateStrongMinion());

            return new Wave {
                Minions = minions
            };
        }
    }
}
