using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace MyPlay
{
    public class Browsers
    {
        //Set Tag and Name
        public void setTag(TestContext testContext, DesiredCapabilities _desiredCapabilities) //Tag test depending on name after BFC_
        {
            _desiredCapabilities.SetCapability("name", testContext.TestName);

            if (testContext.TestName.Substring(4, 8).Contains("Conta"))
            {
                _desiredCapabilities.SetCapability("tags", "ContactUsForm");
            }
            if (testContext.TestName.Substring(4, 8).Contains("NewsL"))
            {
                _desiredCapabilities.SetCapability("tags", "NewsLetterSignup");
            }
            if (testContext.TestName.Substring(4, 8).Contains("Partn"))
            {
                _desiredCapabilities.SetCapability("tags", "PartnersPage");
            }
        }
        //https://wiki.saucelabs.com/display/DOCS/Platform+Configurator?_ga=1.17396733.515752744.1451998283#/
        // Manually enter browser e.g. Firefox, Windows 7, 42.0
        public void BrowserManual(string browserName, string platform, string version, DesiredCapabilities _desiredCapabilities)
        {
            _desiredCapabilities.SetCapability("browserName", browserName);
            _desiredCapabilities.SetCapability("platform", platform);
            _desiredCapabilities.SetCapability("version", version);
        }

        // Windows
        public void WindowsChrome(DesiredCapabilities _desiredCapabilities, string OSversion)
        {
            _desiredCapabilities.SetCapability("browserName", "Chrome");
            _desiredCapabilities.SetCapability("platform", "Windows " + OSversion);
            _desiredCapabilities.SetCapability("version", "46.0");
        }

        public void WindowsIE11(DesiredCapabilities _desiredCapabilities, string OSversion)
        {
            _desiredCapabilities.SetCapability("browserName", "Internet Explorer");
            _desiredCapabilities.SetCapability("platform", "Windows " + OSversion);
            _desiredCapabilities.SetCapability("version", "11.0");
        }
        public void WindowsFireFox(DesiredCapabilities _desiredCapabilities, string OSversion)
        {
            _desiredCapabilities.SetCapability("browserName", "Firefox");
            _desiredCapabilities.SetCapability("platform", "Windows " + OSversion);
            _desiredCapabilities.SetCapability("version", "42.0");
        }
        public void WindowsEdge(DesiredCapabilities _desiredCapabilities)
        {
            _desiredCapabilities.SetCapability("browserName", "MicrosoftEdge");
            _desiredCapabilities.SetCapability("platform", "Windows 10");
            _desiredCapabilities.SetCapability("version", "20.10240");
        }

        // MAC
        public void MacChrome(DesiredCapabilities _desiredCapabilities, string OSversion)
        {
            _desiredCapabilities.SetCapability("browserName", "Chrome");
            _desiredCapabilities.SetCapability("platform", "OS X 10" + OSversion);
            _desiredCapabilities.SetCapability("version", "46.0");
        }

        public void MacSafari(DesiredCapabilities _desiredCapabilities, string OSversion)
        {
            //Browser version .11 = 9, .10 = 8, .09 = 7
            if (OSversion == "")
            {
                OSversion = ".11";
            }
            _desiredCapabilities.SetCapability("browserName", "Safari");
            _desiredCapabilities.SetCapability("platform", "OS X 10" + OSversion);
            switch (OSversion)
            {
                case ".11":
                    _desiredCapabilities.SetCapability("version", "9");
                    break;
                case ".10":
                    _desiredCapabilities.SetCapability("version", "8");
                    break;
                case ".09":
                    _desiredCapabilities.SetCapability("version", "7");
                    break;
            }
        }

        //iPhones
        public void iPhoneSafari(DesiredCapabilities _desiredCapabilities, string browserVersion, string devicenumber) //9.2, 9.1, 9.0, 8.4, 8.3, 8.2, 8.1, 8.0
        {
            _desiredCapabilities.SetCapability("browserName", "iPhone");
            _desiredCapabilities.SetCapability("platform", "OS X 10.10");
            _desiredCapabilities.SetCapability("version", browserVersion);
            _desiredCapabilities.SetCapability("deviceName", "iPhone " + devicenumber);
            _desiredCapabilities.SetCapability("deviceOrientation", "portrait");
        }

        //iPads
        public void iPadSafari(DesiredCapabilities _desiredCapabilities, string browserVersion) //9.2, 9.1, 9.0, 8.4, 8.3, 8.2, 8.1, 8.0
        {
            _desiredCapabilities.SetCapability("browserName", "iPhone");
            _desiredCapabilities.SetCapability("platform", "OS X 10.10");
            _desiredCapabilities.SetCapability("version", browserVersion);
            _desiredCapabilities.SetCapability("deviceName", "iPad 2");
            _desiredCapabilities.SetCapability("deviceOrientation", "portrait");
        }

        //Android
        public void androidPhone(DesiredCapabilities _desiredCapabilities, string osVersion, string deviceName)
        {
            _desiredCapabilities.SetCapability("browserName", "android");
            _desiredCapabilities.SetCapability("platform", "Linux");
            _desiredCapabilities.SetCapability("version", osVersion);
            _desiredCapabilities.SetCapability("deviceName", deviceName);
            _desiredCapabilities.SetCapability("deviceOrientation", "portrait");
        }
    }

}