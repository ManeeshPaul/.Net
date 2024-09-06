using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project31_8
{
    internal class FillForm31_8
    {
        static void Main1(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms");

            IWebElement elementName1 = driver.FindElement(By.Id("et_pb_contact_name_0"));
            elementName1.SendKeys("Arun");

            IWebElement elementMessage1 = driver.FindElement(By.Id("et_pb_contact_message_0"));
            elementMessage1.SendKeys("Hello Arun");

            IWebElement elementSubmit1 = driver.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//button[@type='submit']"));
            elementSubmit1.Click();


            IWebElement elementName2 = driver.FindElement(By.Id("et_pb_contact_name_1"));
            elementName2.SendKeys("Arun");

            IWebElement elementMessage2 = driver.FindElement(By.Id("et_pb_contact_message_1"));
            elementMessage2.SendKeys("Hello Arun");

            IWebElement captchaField = driver.FindElement(By.Name("et_pb_contact_captcha_1"));
            string firstDigit = captchaField.GetAttribute("data-first_digit");
            string secondDigit= captchaField.GetAttribute("data-second_digit");

            // Convert values to integers and compute the sum
            int firstDigitValue = int.Parse(firstDigit);
            int secondDigitValue = int.Parse(secondDigit);
            int captchaSum = firstDigitValue + secondDigitValue;

            // Convert the sum to a string and enter it into the CAPTCHA field
            string captchaValue = captchaSum.ToString();
            Console.WriteLine($"Entering CAPTCHA value: {captchaValue}"); // Debug line to verify value

            // Clear the CAPTCHA field before entering the new value
            captchaField.Clear();
            captchaField.SendKeys(captchaValue);

            IWebElement elementSubmit2 = driver.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//button[@type='submit']"));
            elementSubmit2.Click();


        }
    }
}
