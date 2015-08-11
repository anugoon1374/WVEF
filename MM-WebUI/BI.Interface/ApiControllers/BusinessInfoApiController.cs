using BI.Core.Models;
using BI.Core.Service;
using BI.Interface.Infrastructure.Mappers;
using BI.Interface.ViewModels;

namespace BI.Interface.ApiControllers
{
    public class BusinessInfoApiController : DataAccessApiController<BusinessInfo, BusinessInfoCreateViewModel, BusinessInfoEditViewModel>
    {
        public BusinessInfoApiController(IDataService<BusinessInfo> dataService, IMapper<BusinessInfo, BusinessInfoCreateViewModel> createViewModelMapper, IMapper<BusinessInfo, BusinessInfoEditViewModel> editViewModelMapper) :
            base(dataService, createViewModelMapper, editViewModelMapper)
        {
        }
    }
}