﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Project31_8
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            //driver.Navigate().GoToUrl("https://www.google.com/");
            //string title = driver.Title;
            driver.Manage().Window.Maximize();
            IWebElement element = driver.FindElement(By.Id("twotabsearchtextbox"));
            //IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("T shirts");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement clickElement = driver.FindElement(By.Id("nav-search-submit-button"));
            //clickElement.SendKeys(Keys.Enter);
            clickElement.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Quit();
            //Console.WriteLine(title);   
        }
    }
}