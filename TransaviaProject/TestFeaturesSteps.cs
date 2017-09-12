using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TransaviaProject
{
    [Binding]
    public class TestFeaturesSteps
    {
        public static IWebDriver driver;
        [Given(@"I'm on the Transavia Online check-in page")]
        public void GivenIMOnTheTransaviaOnlineCheck_InPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.transavia.com/en-NL/my-transavia/check-in/login/");
            //IWebElement menuLink = driver.FindElement(By.LinkText("Online check-in"));
            //menuLink.Click();
        }

        [Given(@"I have entered all mandatory fields")]
        public void GivenIHaveEnteredAllMandatoryFields()
        {
            IWebElement bookingNumber = driver.FindElement(By.Id("retrieveBookingByLastname_RecordLocator"));
            bookingNumber.SendKeys("ZZZ567");
        }
        
        [When(@"I press on the Log In button")]
        [Then(@"the information of the desired booking should appear")]
        public void WhenIPressOnTheLogInButton()
        {
            IWebElement logIn = driver.FindElement(By.ClassName("button button-primary"));
            logIn.Click();
        }

        [Given(@"I have entered a booking number with (.*) characters")]
        public void GivenIHaveEnteredABookingNumberWithCharacters(int p0)
        {
            IWebElement bookingNumber = driver.FindElement(By.Id("retrieveBookingByLastname_RecordLocator"));
            bookingNumber.SendKeys("ABC8765432654");
        }

        [Then(@"the user should get a warning message that the field doesn't allow more than (.*) characters")]
        public void ThenTheUserShouldGetAWarningMessageThatTheFieldDoesnTAllowMoreThanCharacters(int p0)
        {
            IWebElement errMsgText = driver.FindElement(By.XPath("//form[@id='retrieveBooking']//ul//p"));
            Assert.IsTrue(errMsgText.Text.Contains("Your booking number has a minimum of 4 and a maximum of 12 characters"));
        }

    }
}
