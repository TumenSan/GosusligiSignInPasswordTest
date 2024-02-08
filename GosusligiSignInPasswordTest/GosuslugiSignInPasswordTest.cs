using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace GosuslugiSignInPasswordTest
{
    public class Tests
    {
        private IWebDriver driver;


        // ���������� ��������� ����� �������� ������� ��������� ������ � ������
        // ����������� ������������� ��������� ���������
        [SetUp]
        public void Setup()
        {
            // ��������� � ������ �������� Edge
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("start-maximized"); // ������������ ����

            EdgeDriverService service = EdgeDriverService.CreateDefaultService();
            driver = new EdgeDriver(service, options);

            // ��������� �������� �������� �� 30 ������
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        // ������������ �������� ����� ���������� ���������� ������� �����
        // �������� �������� ��������
        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        [Test]
        // ���� ��� ������ ����������
        public void SignInPasswordTestOnDesktop()
        {
            try
            {
                // 1.������� �� �������� gosuslugi.ru
                driver.Url = "https://www.gosuslugi.ru/";

                // 2.������� ������ ������
                // ������� ������� �� ClassName
                IWebElement signInLink = driver.FindElement(By.ClassName("login-button"));

                // �������� �� �������
                signInLink.Click();

                // 3.������� ������ ��� ������� �����?�
                IWebElement cannotLoginButton = driver.FindElement(By.XPath("//div[@class='mt-40 text-center']//button[@class='plain-button-inline']"));
                cannotLoginButton.Click();

                // 4.� ����������� ����� ��� ������� �����?� ������ ��������������� �������
                IWebElement recoveryPasswordButton = driver.FindElement(By.XPath("//li[@class='mb-24']//button[@class='plain-button-inline']"));
                recoveryPasswordButton.Click();

                // ������� �������� �� �������� �������������� ������
                Thread.Sleep(5000);

                // 5.��������� ��� ��������� ����� ��������������� �������
                // ���������, ��� �� ��������� �� url �������������� ������
                Assert.IsTrue(driver.Url.Contains("/login/recovery"), "����� �������������� ������ �� �������");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"���� ��������: {ex.Message}");
                throw;
            }
        }

        [Test]
        // ���� ��� ������ ��������
        public void SignInPasswordTestOnMobile()
        {
            try
            {
                // �������� ���������� ���������� Galaxy S5
                EdgeOptions options = new EdgeOptions();
                options.EnableMobileEmulation("Galaxy S5");
                driver = new EdgeDriver(options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                // 1.������� �� �������� gosuslugi.ru
                driver.Url = "https://www.gosuslugi.ru/";

                // 2.������� ������ ������
                // ������� ������� �� ClassName
                IWebElement signInLink = driver.FindElement(By.ClassName("login-button"));

                // �������� �� �������
                signInLink.Click();

                // 3.������� ������ ��� ������� �����?�
                IWebElement cannotLoginButton = driver.FindElement(By.XPath("//div[@class='mt-40 text-center']//button[@class='plain-button-inline']"));
                cannotLoginButton.Click();

                // 4.� ����������� ����� ��� ������� �����?� ������ ��������������� �������
                IWebElement recoveryPasswordButton = driver.FindElement(By.XPath("//li[@class='mb-24']//button[@class='plain-button-inline']"));
                recoveryPasswordButton.Click();

                // ������� �������� �� �������� �������������� ������
                Thread.Sleep(5000);

                // 5.��������� ��� ��������� ����� ��������������� �������
                // ���������, ��� �� ��������� �� url �������������� ������
                Assert.IsTrue(driver.Url.Contains("/login/recovery"), "����� �������������� ������ �� �������");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"���� ��������: {ex.Message}");
                throw;
            }
        }
    }
}