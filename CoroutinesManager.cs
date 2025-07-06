using System.Collections;

namespace Engine.Coroutines
{
    public class CoroutinesManager
    {
        private readonly HashSet<Coroutine> _coroutines = [];

        public Coroutine Start(Func<IEnumerable> func)
        {
            Coroutine coroutine = new Coroutine(func().GetEnumerator());
            _coroutines.Add(coroutine);
            return coroutine;
        }

        public void Stop(Coroutine coroutine) => StopCoroutine(coroutine);

        public void Update(float dt)
        {
            var coroutineList = new List<Coroutine>();
            foreach (Coroutine coroutine in _coroutines)
            {
                if (!coroutine.Step(dt))
                    coroutineList.Add(coroutine);
            }
            foreach (Coroutine coroutine in coroutineList)
                StopCoroutine(coroutine);
        }

        private void StopCoroutine(Coroutine coroutine)
        {
            _coroutines.Remove(coroutine);
            coroutine.Dispose();
        }
    }
}