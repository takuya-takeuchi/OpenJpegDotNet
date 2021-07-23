using Prism;
using Prism.Ioc;
using ViewJpeg2000.Services;
using FileAccessService = ViewJpeg2000.UWP.Services.FileAccessService;

namespace ViewJpeg2000.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new ViewJpeg2000.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.RegisterSingleton<IFileAccessService, FileAccessService>();
        }
    }
}
