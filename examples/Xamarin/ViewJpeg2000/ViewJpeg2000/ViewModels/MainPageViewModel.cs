using System;
using System.IO;
using System.Runtime.InteropServices;
using Prism.Commands;
using Prism.Navigation;
using SkiaSharp;
using ViewJpeg2000.Models;
using ViewJpeg2000.Services;
using ViewJpeg2000.Services.Interfaces;
using ViewJpeg2000.ViewModels.Interfaces;
using Xamarin.Forms;

namespace ViewJpeg2000.ViewModels
{

    public sealed class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {

        #region Fields

        private readonly IFileDownloadService _FileDownloadService;

        private readonly IImageService _ImageService;

        #endregion

        #region Constructors

        public MainPageViewModel(INavigationService navigationService,
                                 IFileDownloadService fileAccessService,
                                 IImageService detectService)
            : base(navigationService)
        {
            this.Title = "View Jpeg2000";

            this._FileDownloadService = fileAccessService;
            this._ImageService = detectService;
            this._ShowImageCommand = new Lazy<DelegateCommand>(this.ShowImageCommandFactory);
            this.Url = "https://github.com/takuya-takeuchi/OpenJpegDotNet/blob/main/test/OpenJpegDotNet.Tests/TestImages/Bretagne1_0.j2k?raw=true";
        }

        #endregion

        #region Properties

        private readonly Lazy<DelegateCommand> _ShowImageCommand;

        private DelegateCommand ShowImageCommandFactory()
        {
            return new DelegateCommand(async () =>
            {
                try
                {
                    var content = await this._FileDownloadService.GetFileContent(this.Url);
                    var raw = this._ImageService.ToPng(content);

                    var rawPixel = raw.Image;
                    using var bitmap = new SKBitmap(new SKImageInfo(raw.Width, raw.Height, SKColorType.Bgra8888));
                    var pixels = bitmap.GetPixels();

                    var width = raw.Width;
                    var height = raw.Height;
                    var channel = raw.Channel;
                    var bpp = bitmap.BytesPerPixel;
                    var stride = bitmap.RowBytes;
                    var bgra = new byte[width * height * bpp];
                    for (var h = 0; h < height; h++)
                        for (var w = 0; w < width; w++)
                            Array.Copy(rawPixel, h * (width * channel) + w * channel, bgra, h * stride + w * bpp, channel);
                    // disable transparent
                    for (var index = 0; index < width * height; index++)
                        bgra[index * bpp + 3] = 255;
                    Marshal.Copy(bgra, 0, pixels, bgra.Length);

                    var data = bitmap.Encode(SKEncodedImageFormat.Jpeg, 100);
                    this.Image = ImageSource.FromStream(() => data.AsStream());
                }
                catch (Exception e)
                {
                    return;
                }
            });
        }

        public DelegateCommand ShowImageCommand => this._ShowImageCommand.Value;

        private ImageSource _Image;

        public ImageSource Image
        {
            get => this._Image;
            private set
            {
                this._Image = value;
                this.RaisePropertyChanged();
            }
        }

        private string _Url;

        public string Url
        {
            get => this._Url;
            private set
            {
                this._Url = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}