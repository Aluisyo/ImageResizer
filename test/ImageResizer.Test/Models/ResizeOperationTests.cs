using ImageResizer.Properties;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using Xunit;

namespace ImageResizer.Models
{
    public class ResizeOperationTests
    {
        // TODO
        // copies container palette
        // copies frame metadata
        // copies frame color contexts
        // transforms
        //     ignores orientation
        //     converts units
        //     shrinks only
        //     uses fit
        //         crops when fill
        // keeps date modified
        // replaces originals
        // works with read-only codecs
        // uniquifies output filename
        // names output using format
        // outputs to destination directory
        [Fact]
        public void Execute_copies_container_palette()
        {
            //var images = new[]
            //{
            //    "Test.jpg",
            //    "Test.png",
            //    "Test.tif",
            //    "Test1.gif",
            //    "Test2.gif"
            //};
            //foreach (var image in images)
            //{
            //    var decoder = BitmapDecoder.Create(
            //        new Uri(image, UriKind.Relative),
            //        BitmapCreateOptions.PreservePixelFormat,
            //        BitmapCacheOption.None);
            //    if (decoder.Palette != null)
            //    {
            //        Debugger.Break();
            //    }
            //}


            using (var directory = new TestDirectory())
            {
                var operation = new ResizeOperation(
                    "Test1.gif",
                    directory.Path,
                    new Settings
                    {
                        Sizes =
                        {
                            new ResizeSize
                            {
                                Name = "Test",
                                Width = 96,
                                Height = 96
                            }
                        },
                        SelectedSizeIndex = 0
                    });

                operation.Execute();

                var image = BitmapDecoder.Create(
                    new Uri(Path.Combine(directory.Path, "Test1 (Test).gif")),
                    BitmapCreateOptions.PreservePixelFormat,
                    BitmapCacheOption.None);
                Assert.NotNull(image.Palette);
            }
        }
    }
}
