using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTest;

namespace Project31_8
{
    internal class SauceDemo
    {
        public static void Main2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

            string selectedUsername = "standard_user";

            // Locate the username input field and enter the selected username
            IWebElement elementUserName = driver.FindElement(By.Id("user-name"));
            elementUserName.SendKeys(selectedUsername);


            //password

            string password = "secret_sauce";


            IWebElement elementPassword = driver.FindElement(By.Id("password"));
            elementPassword.SendKeys(password);


            IWebElement elementLogin = driver.FindElement(By.Id("login-button"));
            elementLogin.Click();


            //LoginPage login=new LoginPage(driver);

            //login.EnterUserName("standard_user");
            //login.EnterPassword("secret_sauce");   
            //login.ClickLoginButton();


            IWebElement elementAddToCart = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            elementAddToCart.Click();


            
            IWebElement elementCart = driver.FindElement(By.Id("shopping_cart_container"));
            elementCart.Click();
        }
    }
}
