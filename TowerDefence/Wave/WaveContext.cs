using TowerDefence.Wave.LevelProducers;

namespace TowerDefence.Wave
{
    public class WaveContext
    {
        private IWaveProducer _waveProducer;

        public WaveContext(IWaveProducer waveProducer)
        {
            this._waveProducer = waveProducer;
        }

        public void ChangeProducer(IWaveProducer waveProducer)
        {
            this._waveProducer = waveProducer;
        }

        public Wave GetCurrentWave()
        {
            return _waveProducer.Produce();
        }

    }
}
