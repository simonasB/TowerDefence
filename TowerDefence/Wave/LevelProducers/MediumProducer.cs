using System;
using TowerDefence.Common;
using TowerDefence.Minions;

namespace TowerDefence.Wave.LevelProducers
{
    public class MediumProducer : IWaveProducer
    {
        private readonly IFactoryProvider<IMinionFactory> _minionFactoryProvider;

        public MediumProducer(IFactoryProvider<IMinionFactory> minionFactoryProvider)
        {
            _minionFactoryProvider = minionFactoryProvider;
        }

        public Wave Produce()
        {
            throw new NotImplementedException();
        }
    }
}
