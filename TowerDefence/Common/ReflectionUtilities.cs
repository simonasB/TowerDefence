using System;
using System.Collections.Generic;
using System.Reflection;

namespace TowerDefence.Common {
    public static class ReflectionUtilities {
        public static Dictionary<string, Type> GetTypesImplementingInterface(Type interfaceType) {
            var types = new Dictionary<string, Type>();

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in typesInThisAssembly) {
                if (type.GetInterface(interfaceType.ToString()) != null) {
                    types.Add(type.Name, type);
                }
            }

            return types;
        }
    }
}
