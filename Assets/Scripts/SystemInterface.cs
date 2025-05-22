using System;

namespace Systems
{
    public interface ISystem
    {
        public static Action<ISystem> SystemCreated = delegate { };
    }
}