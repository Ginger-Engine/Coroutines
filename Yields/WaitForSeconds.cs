namespace Engine.Coroutines.Yields
{
    public class WaitForSeconds : ICoroutineYield
    {
        private float _timeRemaining;

        public WaitForSeconds(float seconds) => _timeRemaining = seconds;

        public bool ShouldResume(float dt)
        {
            _timeRemaining -= dt;
            return _timeRemaining <= 0.0;
        }
    }
}