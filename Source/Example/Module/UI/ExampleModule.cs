using Example.Module.ViewModels;
using Example.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Example.Module
{
    /// <summary>
    /// Represents the main Example module.
    /// </summary>
    public class ExampleModule : IModule
    {
        /// <summary>
        /// This method is used by the PRISM module system and is called to register
        /// views, view-models, services and other classes to the IoC container.
        /// </summary>
        /// <param name="containerRegistry">The registry for the PRISM IoC container.</param>
        void IModule.RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register the module views, view-models and navigation:
            containerRegistry.RegisterForNavigation<ExampleModulePage, ExampleModulePageViewModel>();
        }

        /// <summary>
        /// This method is used by the PRISM module system and is called once all
        /// the modules have registered their types with the IoC container and after
        /// this module has been initialized.
        /// </summary>
        /// <param name="containerProvider">The PRISM IoC container.</param>
        void IModule.OnInitialized(IContainerProvider containerProvider)
        {
            // Method intentionally left empty.
        }
    }
}
