using Ninject;
using System;
using SkyKick.Kernel;

namespace TheKernel
{
    class TheExampleKernel
    {
        static void Main(string[] args)
        {

            // Every root runtime service gets its own KernelBuilder
            // in which it overrides the CreateKernel() method in order to load
            // the necessary NinjectModules
            //
            var builder = new ApiKernelBuilder();

            // Simple Kernel
            var simple_kernel = builder.CreateKernel();

            // Custom Kernel with extra bindings
            var custom_kernel = builder.CreateKernel(kernel =>
            {
                kernel.Rebind<IUserService>().To<MockUserService>();
                return kernel;
            });

            var simple_controller = simple_kernel.Get<IUserController>();

            // Run Work() using default resolution of IUserService
            simple_controller.Work();

            var custom_controller = custom_kernel.Get<IUserController>();
            
            // Run Work() using Mock resolution of IUserService
            custom_controller.Work();

            Console.ReadKey();
        }
    }

    public class ApiKernelBuilder : KernelBuilder
    {
        public override IKernel BuildKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new NinjectModule());

            return kernel;
        }
    }

    public interface IUserController
    {
        Guid id { get; set; }
        void Work();
    }

    public class UserController : IUserController
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;    
        }
        public Guid id { get; set; }

        public void Work()
        {
            _UserService.DoSomething();
        }

    }

    public interface IUserService
    {
        void DoSomething();
    }

    public class UserService : IUserService
    {
        public void DoSomething()
        {
            Console.WriteLine("Hello World");
        }
    }

    public class MockUserService : IUserService
    {
        public void DoSomething()
        {
            Console.WriteLine("I am a mock!");
        }
    }
}
