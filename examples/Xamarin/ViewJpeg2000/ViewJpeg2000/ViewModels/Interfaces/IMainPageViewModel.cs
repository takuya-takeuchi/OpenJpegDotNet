using Prism.Commands;
using Xamarin.Forms;

namespace ViewJpeg2000.ViewModels.Interfaces
{

    public interface IMainPageViewModel
    {

        DelegateCommand ShowImageCommand
        {
            get;
        }

        ImageSource Image
        {
            get;
        }

        string Url
        {
            get;
        }

        string Title
        {
            get;
        }

    }

}