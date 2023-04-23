namespace CrossoverGame.Tools
{
    public partial class JsonHelper
    {
        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }
}
