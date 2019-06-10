using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Example.Module.ViewModels
{
    public class ExampleModulePageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand NavigateBack { get; }

        public ExampleModulePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateBack = new DelegateCommand(async () => await GoBack());
        }

        public async Task GoBack()
        {
            await _navigationService.GoBackAsync(null, true, false);
        }
    }
}