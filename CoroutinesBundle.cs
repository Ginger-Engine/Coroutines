using Engine.Core;
using GignerEngine.DiContainer;

namespace Engine.Coroutines;

public class CoroutinesBundle : IBundle
{
    public void InstallBindings(DiBuilder builder)
    {
        builder.Bind<CoroutinesManager>();
        builder.Bind<CoroutinesStage>();
    }
}