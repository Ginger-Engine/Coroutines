using Engine.Core.Stages;

namespace Engine.Coroutines;

public class CoroutinesStage(CoroutinesManager coroutinesManager) : IStage
{
    public Type[] Before { get; set; } = [];
    public Type[] After { get; set; } = [typeof(LogicStage)];
    public void Start() {}

    public void Update(float dt)
    {
        coroutinesManager.Update(dt);
    }
}