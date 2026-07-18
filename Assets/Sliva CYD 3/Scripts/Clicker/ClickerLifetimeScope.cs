using VContainer;
using VContainer.Unity;

namespace SlivaCYD3.Clicker
{
    public class ClickerLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ClickerModel>(Lifetime.Singleton);
        }
    }
}