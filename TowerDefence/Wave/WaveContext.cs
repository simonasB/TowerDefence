using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Wave.Levels;

namespace TowerDefence.Wave
{
    class WaveContext
    {
        private IWaveProducer waveProducer;

        public WaveContext(IWaveProducer waveProducer)
        {
            this.waveProducer = waveProducer;
        }

        public void changeProducer(IWaveProducer waveProducer)
        {
            this.waveProducer = waveProducer;
        }

        public Wave getCurrentWave()
        {
            return waveProducer.produce();
        }

    }
}
