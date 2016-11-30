using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyKick.Kernel
{
    /// <summary>
    /// KernelBuilder allows use to define what gets loaded into a kernel using the BuildKernel
    /// override, however, each CreateKernel() call will generate a new instance of the kernel
    /// allowing seperation of kernels if needed
    /// </summary>
    public abstract class KernelBuilder : IKernelBuilder
    {
        /// <summary>
        /// Create a new instance of the kernel defined in BuildKernel and returns it
        /// </summary>
        /// <returns></returns>
        public IKernel CreateKernel()
        {
            // Build kernel using override
            var kernel = BuildKernel();

            return kernel;
        }

        /// <summary>
        /// Create a new instance of the kernel defined in BuildKernel, applies custom bindings and returns it
        /// </summary>
        /// <param name="Binder"></param>
        /// <returns></returns>
        public IKernel CreateKernel(Func<IKernel, IKernel> Binder)
        {
            // Build kernel using override
            var kernel = BuildKernel();

            // Then invoke the kernel customizing Func
            return Binder.Invoke(kernel);
        }

        /// <summary>
        /// Abstract method used to define Kernel
        /// </summary>
        /// <returns></returns>
        public abstract IKernel BuildKernel();
    }
}
