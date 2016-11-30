using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyKick.Kernel
{
    public abstract class KernelBuilder : IKernelBuilder
    {
        public IKernel CreateKernel()
        {
            // Build kernel using override
            var kernel = BuildKernel();

            return kernel;
        }

        public IKernel CreateKernel(Func<IKernel, IKernel> Binder)
        {
            // Build kernel using override
            var kernel = BuildKernel();

            // Then invoke the kernel customizing Func
            return Binder.Invoke(kernel);
        }

        public abstract IKernel BuildKernel();
    }
}
