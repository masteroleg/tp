using Logictime.Protobuf;
using Mapster;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.infrastructure;

public class MapperConfig
{
    public static TypeAdapterConfig GetMappingConfig()
    {
        var config = new TypeAdapterConfig();

        config.NewConfig<JobData, JobDataView>()
              //.Map(data => data.ArticleRef.ArticleProductImage,() => new byte[]{})
            ;

        return config;
    }
}