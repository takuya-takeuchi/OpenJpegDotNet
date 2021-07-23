using System;
using Prism.Commands;
using Prism.Navigation;
using SkiaSharp;
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
            this.Title = "Yolo V3";

            this._FileDownloadService = fileAccessService;
            this._ImageService = detectService;
            this._ShowImageCommand = new Lazy<DelegateCommand>(this.ShowImageCommandFactory);
        }

        #endregion

        #region Properties

        private readonly Lazy<DelegateCommand> _ShowImageCommand;

        private DelegateCommand ShowImageCommandFactory()
        {
            return new DelegateCommand(async () =>
            {
                byte[] content = null;

                try
                {
                    content = await this._FileDownloadService.GetFileContent(this.Url);
                }
                catch (Exception e)
                {
                    return;
                }

                var detectResult = this._ImageService.Detect(content);
                if (detectResult == null) 
                    return;

                var surface = SKSurface.Create(new SKImageInfo(detectResult.Width, detectResult.Height, SKColorType.Rgba8888));
                using var paint = new SKPaint();
                using var bitmap = SKBitmap.Decode(result);

                surface.Canvas.DrawBitmap(bitmap, 0, 0, paint);
                paint.StrokeWidth = 3;
                paint.TextSize = 48;
                paint.IsAntialias = true;
                paint.TextEncoding = SKTextEncoding.Utf8;

                string[] classNames =
                {
                    "background",
                    "aeroplane",
                    "bicycle",
                    "bird",
                    "boat",
                    "bottle",
                    "bus",
                    "car",
                    "cat",
                    "chair",
                    "cow",
                    "diningtable",
                    "dog",
                    "horse",
                    "motorbike",
                    "person",
                    "pottedplant",
                    "sheep",
                    "sofa",
                    "train",
                    "tvmonitor"
                };

                foreach (var box in detectResult.Boxes)
                {
                    paint.Color = SKColors.Red;
                    paint.Style = SKPaintStyle.Stroke;
                    surface.Canvas.DrawRect(box.Rect.X, box.Rect.Y, box.Rect.Width, box.Rect.Height, paint);

                    paint.Color = SKColors.Black;
                    paint.Style = SKPaintStyle.Fill;
                    surface.Canvas.DrawText(classNames[box.Label], new SKPoint(box.Rect.X + 5, box.Rect.Y + 5), paint);
                }
                this.SelectedImage = ImageSource.FromStream(() => surface.Snapshot().Encode().AsStream());
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