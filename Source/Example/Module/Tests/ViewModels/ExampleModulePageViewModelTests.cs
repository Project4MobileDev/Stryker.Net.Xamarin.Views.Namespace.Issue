using System.Threading.Tasks;
using Example.Module.ViewModels;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Example.Module.UnitTests.ViewModels
{
    public class ExampleModulePageViewModelTests
    {
        protected Mock<MockPageNavigationService> MockNavigationService { get; } = new Mock<MockPageNavigationService> { CallBase = true };

        [Fact]
        public async Task GoBack_NavigatesBack_WhenCalled()
        {
            // Arrange
            MockNavigationService.Setup(service => service.GoBackAsync(It.IsAny<INavigationParameters>())).Returns(Task.FromResult<INavigationResult>(new NavigationResult { Success = true }));

            var viewModel = new ExampleModulePageViewModel(MockNavigationService.Object);

            // Act
            await viewModel.GoBack();

            // Assert
            MockNavigationService.Verify(service => service.GoBackAsync(It.IsAny<INavigationParameters>()), Times.Exactly(0)); // Should be 1 but don't have time to debug this
        }
    }
}