using AutoMapper;

namespace Sample.IDomainServices.AutoMapper
{
    public class AutoMapperInit
    {
        public static void BuildMap()
        {
            Mapper.Initialize(o => o.AddProfile<ModelAutoMapperProfiler>());
           // Mapper.AssertConfigurationIsValid();
        }
    }

    //public class AutoMapperConfig
    //{
    //    public static IMapper RegisterMap()
    //    {
    //        var mapperConfiguration = new MapperConfiguration(cfg =>
    //        {
    //            cfg.AddProfile<ModelAutoMapperProfiler>();
    //        });

    //        return mapperConfiguration.CreateMapper();
    //    }
    //}
}
