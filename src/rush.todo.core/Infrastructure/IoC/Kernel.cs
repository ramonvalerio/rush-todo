using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace rush.todo.core.Infrastructure.IoC
{
    public abstract class Kernel
    {
        private readonly static Dictionary<string, IContainer> _containers;

        static Kernel()
        {
            _containers = new Dictionary<string, IContainer>();
        }

        public static void RegisterAssembliesBySolutionName(string solutionName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains(solutionName)).ToList();
            var loadedPaths = assemblies.Select(x => x.Location).ToArray();

            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"{solutionName}.*.dll");
            var toLoad = referencedPaths.Where(x => !loadedPaths.Contains(x, StringComparer.InvariantCultureIgnoreCase)).ToList();
            toLoad.ForEach(path => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));

            foreach (var assembly in assemblies)
            {
                var builder = new ContainerBuilder();
                builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("AppService")).AsImplementedInterfaces().SingleInstance();
                builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().SingleInstance();
                builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().SingleInstance();
                builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("Context")).AsImplementedInterfaces();

                if (!_containers.ContainsKey(assembly.GetName().Name))
                    _containers.Add(assembly.GetName().Name, builder.Build());
            }
        }

        public static T GetInstance<T>() where T : class
        {
            var assemblyName = typeof(T).Assembly.GetName().Name;

            if (!_containers.ContainsKey(assemblyName) || !_containers[assemblyName].IsRegistered<T>())
                throw new Exception("Instance not found.");

            return _containers[assemblyName].Resolve<T>();
        }
    }
}
