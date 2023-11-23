using DevExpress.Mvvm.CodeGenerators;
using MapsterMapper;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.jobs;

[TransientService, GenerateViewModel]
public partial class JobNewViewModel : BaseViewModel
{
    private readonly IMapper mapper;

    [GenerateProperty] private JobDataView _product;
    

    public JobNewViewModel(DataBag bag, IMapper mapper) : base(bag)
    {
        this.mapper = mapper;
        Product     = mapper.Map<JobDataView>(bag.Job);
        BackView    = Operations.CheckWorkspace;
        NextView    = Operations.ShiftStart;
    }
}