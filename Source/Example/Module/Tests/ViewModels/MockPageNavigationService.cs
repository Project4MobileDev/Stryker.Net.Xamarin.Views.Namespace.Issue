using System.Threading.Tasks;
using Prism.Behaviors;
using Prism.Common;
using Prism.DryIoc;
using Prism.Logging;
using Prism.Navigation;

namespace Example.Module.UnitTests.ViewModels
{
    // Mocking the Prism NavigationService is tricky because it uses static extension methods which can't be mocked.
    // The non-extension methods can be mocked fine using Moq.
    // See Brian Lagunas and Dan Siegel's recommendations for how to best mock the extension methods.
    // In one of the threads linked below Brian Lagunas suggested that the INavigateInternal interface should be made public to make mocking the NavigationService easier.
    // https://github.com/PrismLibrary/Prism/issues/1312
    // https://stackoverflow.com/questions/43883453/unit-test-prism-navigation
    // https://github.com/PrismLibrary/Prism/issues/1365
    public class MockPageNavigationService : PageNavigationService
    {
        public string LastNavigationString { get; private set; }
        public INavigationParameters LastNavigationParameters { get; private set; }
        public bool? LastUseModalNavigationSetting { get; private set; }
        public bool LastAnimatedSetting { get; private set; }

        public MockPageNavigationService() : base(new DryIocContainerExtension(new DryIoc.Container()), new ApplicationProvider(), new PageBehaviorFactory(), new DebugLogger())
        {
        }

        protected override Task<INavigationResult> NavigateInternal(string name, INavigationParameters parameters, bool? useModalNavigation, bool animated)
        {
            LastNavigationString = name;
            LastNavigationParameters = parameters;
            LastUseModalNavigationSetting = useModalNavigation;
            LastAnimatedSetting = animated;

            return Task.FromResult<INavigationResult>(new NavigationResult { Success = true });
        }

        protected override Task<INavigationResult> GoBackInternal(INavigationParameters parameters, bool? useModalNavigation, bool animated)
        {
            LastNavigationParameters = parameters;
            LastUseModalNavigationSetting = useModalNavigation;
            LastAnimatedSetting = animated;

            return Task.FromResult<INavigationResult>(new NavigationResult { Success = true });
        }
    }
}
