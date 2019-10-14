using Autofac;

namespace LibrarySystem
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var engine = scope.Resolve<IEngine>();
                engine.Start();
            }
        }
    }
}