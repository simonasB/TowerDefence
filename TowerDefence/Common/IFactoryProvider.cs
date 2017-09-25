using System;
using System.Collections.Generic;

namespace TowerDefence.Common {
    public interface IFactoryProvider<out TFactory> {
        TFactory GetFactory(string name);
    }

    public class FactoryProvider<TFactory> : IFactoryProvider<TFactory> where TFactory : class {
        private readonly Dictionary<string, Type> _factories =
            ReflectionUtilities.GetTypesImplementingInterface(typeof(TFactory));

        public TFactory GetFactory(string name) {
            if (_factories.TryGetValue(name, out var type)) {
                TFactory factory;

                if ((factory = Activator.CreateInstance(type) as TFactory) != null) {
                    return factory;
                }
            }

            throw new Exception($"Cannot get Factory: {name} of Type: {typeof(TFactory).Name}");
        }
    }
}
