namespace Game.Utilities
{
    public class Decorator<T>
    {
        public readonly T Value;

        public Decorator(T diContainer)
        {
            Value = diContainer;
        }
    }
}
