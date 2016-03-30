using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Testing.Resources

{
    public class Screenshots
    {
        public static void TakeScreenshot(string saveLocation, IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;

            var location = GetDirectoryName() + saveLocation + "/" + capabilities.BrowserName + "_" +
                           DateTime.Now.ToString("yyyyMdd_HHmmss") + ".png";

            if (capabilities.BrowserName == "chrome")
            {
                GetEntereScreenshot(driver)
                .Save(location, System.Drawing.Imaging.ImageFormat.Png);
            }

            else
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(location, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public static Bitmap GetEntereScreenshot(IWebDriver driver)
        {
            Bitmap stitchedImage = null;
            try
            {
                long totalwidth1 =
                    (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.offsetWidth");
                //documentElement.scrollWidth”);
                long totalHeight1 = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.parentNode.scrollHeight");
                int totalWidth = (int)totalwidth1;
                int totalHeight = (int)totalHeight1;
                // Get the Size of the Viewport
                long viewportWidth1 =
                    (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.clientWidth");
                //documentElement.scrollWidth”);
                long viewportHeight1 = (long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight");
                //documentElement.scrollWidth”);
                int viewportWidth = (int)viewportWidth1;
                int viewportHeight = (int)viewportHeight1;
                // Split the Screen in multiple Rectangles
                var rectangles = new List<Rectangle>();
                // Loop until the Total Height is reached
                for (int i = 0; i < totalHeight; i += viewportHeight)
                {
                    int newHeight = viewportHeight;
                    // Fix if the Height of the Element is too big
                    if (i + viewportHeight > totalHeight)
                    {
                        newHeight = totalHeight - i;
                    }
                    // Loop until the Total Width is reached
                    for (int ii = 0; ii < totalWidth; ii += viewportWidth)
                    {
                        int newWidth = viewportWidth;
                        // Fix if the Width of the Element is too big
                        if (ii + viewportWidth > totalWidth)
                        {
                            newWidth = totalWidth - ii;
                        }
                        // Create and add the Rectangle
                        Rectangle currRect = new Rectangle(ii, i, newWidth, newHeight);
                        rectangles.Add(currRect);
                    }
                }


                // Build the Image
                stitchedImage = new Bitmap(totalWidth, totalHeight);
                // Get all Screenshots and stitch them together
                Rectangle previous = Rectangle.Empty;
                foreach (var rectangle in rectangles)
                {
                    // Calculate the Scrolling (if needed)
                    if (previous != Rectangle.Empty)
                    {

                        int xDiff = (rectangle.Right - previous.Right);
                        int yDiff = (rectangle.Bottom - previous.Bottom);
                        // Scroll
                        //selenium.RunScript(String.Format(“window.scrollBy({0}, {1})”, xDiff, yDiff));
                        ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0},{1})", xDiff, yDiff));
                        System.Threading.Thread.Sleep(200);
                    }
                    // Take Screenshot
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    // Build an Image out of the Screenshot
                    Image screenshotImage;
                    using (MemoryStream memStream = new MemoryStream(screenshot.AsByteArray))
                    {
                        screenshotImage = Image.FromStream(memStream);
                    }
                    // Calculate the Source Rectangle
                    Rectangle sourceRectangle = new Rectangle(viewportWidth - rectangle.Width,
                    viewportHeight -
                    rectangle.Height,
                    rectangle.Width,
                    rectangle.Height)
                    ;
                    // Copy the Image
                    using (Graphics g = Graphics.FromImage(stitchedImage))
                    {
                        g.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                    }
                    // Set the Previous Rectangle
                    previous = rectangle;
                }
            }
            catch
                (Exception
                    ex)
            {
                // handle
            }
            return stitchedImage;
        }

        public static string GridPath()
        {
            return TheFilePath().Replace("Testing", "Grid");
        }

        public static string GetDirectoryName()
        {
            return TheFilePath() + "Screenshots//";
        }

        public static string TheFilePath()
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));

        }
    }
}