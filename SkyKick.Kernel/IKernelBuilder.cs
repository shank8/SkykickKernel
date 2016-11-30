using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyKick.Kernel
{
    internal interface IKernelBuilder
    {
        IKernel BuildKernel();
        IKernel CreateKernel();
        IKernel CreateKernel(Func<IKernel, IKernel> Binder);
    }
}
