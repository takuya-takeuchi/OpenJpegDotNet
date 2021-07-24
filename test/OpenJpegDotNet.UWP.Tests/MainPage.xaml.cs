using System;
using System.IO;
using System.Linq;
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

                var raw = reader.ReadRawBitmap();
                this._Image.Source = await ToBitmapSource(raw);
            }
        }

        #endregion

        #region Helpers

        private static async Task<BitmapImage> ToBitmapSource(RawBitmap rawBitmap)
        {
            var raw = rawBitmap.Data.ToArray();
            var width = rawBitmap.Width;
            var height = rawBitmap.Height;
            var channel = rawBitmap.Channel;
            var data = new byte[width * height * 4];

            unsafe
            {
                fixed (byte* pRaw = &raw[0])
                fixed (byte* dst = &data[0])
                {
                    var src = pRaw;
                    for (var y = 0; y < height; y++)
                    {
                        var index = y * width * 4;
                        for (var x = 0; x < width; x++)
                        {
                            dst[index] = src[2];
                            dst[index + 1] = src[1];
                            dst[index + 2] = src[0];
                            index += 4;
                            src += channel;
                        }
                    }
                }
            }

            var writeableBitmap = new WriteableBitmap((int)width, (int)height);
            using (var imras = new InMemoryRandomAccessStream())
            {

                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.BmpEncoderId, imras);
                encoder.SetPixelData(BitmapPixelFormat.Rgba8,
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

        #endregion

        #endregion

    }

}
