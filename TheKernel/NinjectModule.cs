using Ninject.Extensions.Conventions;

namespace TheKernel
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
                 x.FromThisAssembly()
                     .SelectAllClasses()
                         .BindDefaultInterface());
        }
    }
}
