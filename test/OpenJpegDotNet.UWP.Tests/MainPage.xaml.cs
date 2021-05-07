using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace OpenJpegDotNet.UWP.Tests
{

    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        #region Constructors

        public MainPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        #region Event Handlers

        private async void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            var data = await File.ReadAllBytesAsync("Bretagne1_0.j2k");
            using (var reader = new IO.Reader(data))
            {
                var result = reader.ReadHeader();
                if (!result)
                    return;

                using (var bitmap = reader.ReadData())
                    this._Image.Source = await ToBitmapSource(bitmap);
            }
        }

        #endregion

        #region Helperss

        private static async Task<BitmapImage> ToBitmapSource(Bitmap bitmap)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;
            var pixelFormat = bitmap.PixelFormat;

            BitmapData bitmapData = null;

            try
            {
                var rect = new Rectangle(0, 0, width, height);
                bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
                
                var data = new byte[width * height * 4];

                unsafe
                {
                    var src = (byte*)bitmapData.Scan0;
                    fixed (byte* dst = &data[0])
                    {
                        for (var y = 0; y < height; y++)
                        {
                            var index = y * width * 4;
                            for (var x = 0; x < width; x++)
                            {
                                dst[index] = *++src;
                                dst[index + 1] = *++src;
                                dst[index + 2] = *++src;
                                ++src;
                                index += 4;
                            }
                        }
                    }
                }
                var writeableBitmap = new WriteableBitmap(width, height);
                using (var imras = new InMemoryRandomAccessStream())
                {

                    var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.BmpEncoderId, imras);
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                         BitmapAlphaMode.Ignore,
                                         (uint)writeableBitmap.PixelWidth,
                                         (uint)writeableBitmap.PixelHeight,
                                         96.0,
                                         96.0,
                                         data);

                    await encoder.FlushAsync();
                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(imras);

                    return bitmapImage;
                }
            }
            finally
            {
                if (bitmapData != null)
                    bitmap.UnlockBits(bitmapData);
            }
        }

        #endregion

        #endregion

    }

}
