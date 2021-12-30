namespace App.Common.Model
{
    public class GlobalVariable<T>
    {
        private static T _object;
        public GlobalVariable(T Object)
        {
            _object = Object;
        }

        public static T Object
        {
            get => _object;
        }
    }
}
