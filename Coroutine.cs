using Engine.Coroutines.Yields;
using System.Collections;

namespace Engine.Coroutines
{
    public class Coroutine : IDisposable
    {
        private readonly IEnumerator _enumerator;
        private object? _currentYield;

        public Coroutine(IEnumerator enumerator) => _enumerator = enumerator;

        public bool Step(float dt)
        {
            if (_currentYield is ICoroutineYield currentYield && !currentYield.ShouldResume(dt))
                return true;
            if (!_enumerator.MoveNext())
                return false;
            _currentYield = _enumerator.Current;
            return true;
        }

        public void Dispose()
        {
            if (_enumerator is not IDisposable enumerator) return;
            enumerator.Dispose();
        }
    }
}