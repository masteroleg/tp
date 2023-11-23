using Logictime.Protobuf;
using Logictime.Protobuf.Contract;
using MapsterMapper;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;

namespace BackApiTest;

public class MappingTest
{
    private IMapper mapper;


    [SetUp]
    public void Setup()
    {
        mapper = new Mapper(MapperConfig.GetMappingConfig());
    }

    [Test(Author = "AVK", Description = "Mapping JobData to JobDataView")]
    public void Mapping()
    {
        var data = mapper.Map<JobDataView>(new JobData()
        {
            ArticleRef = new Article
            {
                ArticleProductImage = new byte[] { }
            }
        });
    }
}