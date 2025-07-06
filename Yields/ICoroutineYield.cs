namespace Engine.Coroutines.Yields
{
    public interface ICoroutineYield
    {
        bool ShouldResume(float dt);
    }
}