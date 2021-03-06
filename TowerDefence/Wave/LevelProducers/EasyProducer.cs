﻿using System;
using System.Collections.Generic;
using TowerDefence.Common;
using TowerDefence.Minions;
using TowerDefence.Minions.Beasts;
using TowerDefence.Minions.Dragons;

namespace TowerDefence.Wave.LevelProducers
{
    public class EasyProducer : IWaveProducer
    {
        private readonly IFactoryProvider<IMinionFactory> _minionFactoryProvider;

        public EasyProducer(IFactoryProvider<IMinionFactory> minionFactoryProvider)
        {
            _minionFactoryProvider = minionFactoryProvider;
        }
        public Wave Produce()
        {
            var minions = new Stack<Minion>();

            var beastFactory = _minionFactoryProvider.GetFactory(nameof(BeastFactory));

            minions.Push(beastFactory.CreateWeakMinion());

            return new Wave
            {
                Minions = minions
            };
        }
    }
}
