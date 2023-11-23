using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using Logictime.Protobuf;
using MapsterMapper;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.jobs;

[TransientService, GenerateViewModel]
public partial class JobSelectViewModel : BaseViewModel
{
    [GenerateProperty] private ObservableCollection<JobDataView> productsList;
    [GenerateProperty] private JobDataView       selectedProduct;
    private readonly           IMapper           mapper;

    public JobSelectViewModel( IMapper mapper, DataBag bag) : base(bag)
    {
        this.mapper     = mapper;
        SelectedProduct = new();
        ProductsList    = new();

        BackView = bag.PreviousView;
        NextView = Operations.JobNew;

        bag.JobsList?.ForEach(x => ProductsList.Add(mapper.Map<JobDataView>(x)));
        if (ProductsList.Count > 0)
        {
            ProductsList[0].IsSelected = true;
            SelectedProduct            = ProductsList[0];
            bag.Job                    = mapper.Map<JobData>(SelectedProduct);
        }
    }

    public DelegateCommand<JobDataView> SelectProductCommand => new(p =>
    {
        SelectedProduct.IsSelected = false;

        var product = ProductsList.FirstOrDefault(x => x.Id == p.Id);
        if (product != null)
        {
            product.IsSelected = true;
            SelectedProduct    = product;
        }
        bag.Job = mapper.Map<JobData>(SelectedProduct);
    });
}