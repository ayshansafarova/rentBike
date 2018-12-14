using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Bikely.Tests
{
    [TestClass]
    public class SeleniumTests
    {
        public ChromeDriver driver;
        public WebDriverWait waiting;
        public ITakesScreenshot screenshotDriver;

        //test scenario 1 - login
        [TestMethod]
        public void UserLogin()
        {
            try
            {
                string url = "http://localhost:5580/Account/Login";
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                driver.FindElementById("UserName").SendKeys("reyhana");
                driver.FindElementById("Password").SendKeys("@Reyhana1997");
                driver.FindElementByClassName("m-login__btn").Click();

                waiting = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                waiting.Until(w => w.FindElement(By.ClassName("m-alert")));
                //driver.Close();
                //driver.Dispose();
            }
            catch
            {
                screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile("E:/Bikely/Bikely/assets/screenshots", ScreenshotImageFormat.Png);
                driver.Quit();
            }
        }
        
        //test scenario 2 - Registration
        [TestMethod]
        public void UserRegister()
        {
            //renter type user registration
            try
            {
                string url = "http://localhost:5580/Account/Register";
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                driver.FindElementById("m_inputmask_9").SendKeys("adele@mail.ru");
                driver.FindElementById("UserName").SendKeys("adele");
                driver.FindElementById("Password").SendKeys("@Adel1992");
                driver.FindElementById("ConfirmPassword").SendKeys("@Adel1992");

                var list = driver.FindElementByClassName("dropdown-toggle");
                list.Click();
                driver.FindElement(By.CssSelector("li[data-original-index='3']")).Click();
                driver.FindElementByClassName("m-login__btn").Click();
               
                waiting = new WebDriverWait(driver, new TimeSpan(0, 0, 7));
                waiting.Until(w => w.FindElement(By.ClassName("m-alert")));
                //driver.Close();
                //driver.Dispose();
            }
            catch
            {
                screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile("E:/Bikely/Bikely/assets/screenshots", ScreenshotImageFormat.Png);
                driver.Quit();
            }
        }
    }
}
