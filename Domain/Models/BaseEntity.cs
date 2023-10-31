
namespace Domain.Models
{
    public abstract class BaseEntity
    {
        public abstract string TableName { get; }
        public abstract string IdKey { get; }
        public abstract string InsertQuery { get; }
        public abstract string UpdateQuery { get; }

        private static readonly Dictionary<string, BaseEntity> _entites = new Dictionary<string, BaseEntity>();
        public static BaseEntity CreateEmptyInstance<T>()
        {
            var key = typeof(T).FullName;
            if (!_entites.ContainsKey(key))
            {
                var obj = Activator.CreateInstance<T>() as BaseEntity;
                _entites.Add(key, obj);
                
            }
            return _entites[key];

        }
    }
}
