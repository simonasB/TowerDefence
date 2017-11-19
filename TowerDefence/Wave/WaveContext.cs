using TowerDefence.Wave.LevelProducers;

namespace TowerDefence.Wave
{
    public class WaveContext
    {
        private readonly IWaveProducer _waveProducer;

        public WaveContext(IWaveProducer waveProducer)
        {
            this._waveProducer = waveProducer;
        }

        public Wave GetWave()
        {
            return _waveProducer.Produce();
        }

    }
}
