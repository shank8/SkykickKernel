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
        // This may not be needed for anything
        private IKernel Kernel { get; set; }

        public IKernel CreateKernel()
        {
            // Build kernel using override
            Kernel = BuildKernel();
            return Kernel;
        }
        public IKernel CreateKernel(Func<IKernel, IKernel> Binder)
        {
            // Build kernel using override
            Kernel = BuildKernel();

            // Then invoke the kernel customizing Func
            return Binder.Invoke(Kernel);
        }

        public abstract IKernel BuildKernel();
    }
}
