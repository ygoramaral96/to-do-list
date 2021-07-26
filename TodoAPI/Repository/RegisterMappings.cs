using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using TodoApi.Repository.Mappers;

namespace Repository
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new TodoItemMap());
                config.ForDommel();
            });
        }
    }
}