using System;
using System.Timers;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using MapsterMapper;
using TraceavitProDesktop.assets;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.jobs;

[TransientService, GenerateViewModel]
public partial class JobProcessViewModel : BaseViewModel
{
    private readonly IMapper mapper;
    [GenerateProperty] private string _userName;
    [GenerateProperty] private string _userRole;
    [GenerateProperty] private JobDataView _job;
    [GenerateProperty] private StationType _stationType;


    public JobProcessViewModel(DataBag bag, IMapper mapper) : base(bag)
    {
        this.mapper = mapper;
        UserName = $"{bag.User?.Name} {bag.User?.Surname}";

        //todo потом разкоментить
       // if (bag.Settings.StationType!=StationType.Labeler)
       // {
       //     bag.Settings.StationType = 
       //         bag.Job.ArticleRef.ArticlePlanpalBoxCount is > 0 ? 
       //             StationType.PackerNoBox : 
       //             StationType.Packer;
       // }


        StationType = bag.Settings.StationType;

        UserRole = StationType switch
        {
            StationType.Labeler => Strings.JobProcessViewModel_JobProcessViewModel_Labeler,
            StationType.Packer => Strings.JobProcessViewModel_JobProcessViewModel_Packer,
            StationType.PackerNoBox => Strings.JobProcessViewModel_JobProcessViewModel_Packer,
            _ => ""
        };

        Job = mapper.Map<JobDataView>(bag.Job);
    }

    public DelegateCommand PauseCommand => new(async () => await ShowNextView(Operations.PauseReason));

    public DelegateCommand EndCommand => new(async () => { await ShowNextView(Operations.EndWorkConfirm); });

    public DelegateCommand PrintRepeatCommand => new(() => { });

    public DelegateCommand PrintPaletteCommand => new(() => { });
}

