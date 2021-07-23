﻿using Prism.Commands;
using Xamarin.Forms;

namespace ViewJpeg2000.ViewModels.Interfaces
{

    public interface IMainPageViewModel
    {

        DelegateCommand FilePickCommand
        {
            get;
        }

        ImageSource SelectedImage
        {
            get;
        }

        string Title
        {
            get;
        }

    }

}