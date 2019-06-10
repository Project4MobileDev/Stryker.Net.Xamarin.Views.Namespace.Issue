using Example.Module.Views;
using Xunit;
using Moq;
using Prism.Ioc;
using Prism.Modularity;

namespace Example.Module.UnitTests
{
    public class ExampleModuleTests
    {
        [Fact]
        public void RegisterTypes_RegistersExampleModulePage_WhenCalled()
        {
            // Arrange
            var mockRegistry = new Mock<IContainerRegistry>();

            // The RegisterForNavigation is an extension method so to test it we check that it calls through to Register(Type, Type, string)
            mockRegistry.Setup(r => r.Register(typeof(object), typeof(ExampleModulePage), It.IsAny<string>()));

            IModule module = new ExampleModule();

            // Act
            module.RegisterTypes(mockRegistry.Object);

            // Assert
            mockRegistry.Verify(r => r.Register(typeof(object), typeof(ExampleModulePage), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void OnInitialized_DoesNotThrowError_WhenCalled()
        {
            // Arrange
            var mockContainer = new Mock<IContainerProvider>();
            IModule module = new ExampleModule();

            // Act
            var ex = Record.Exception(() => module.OnInitialized(mockContainer.Object));

            // Assert
            Assert.Null(ex);
        }
    }
}
