using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace GosuslugiSignInPasswordTest
{
    public class Tests
    {
        private IWebDriver driver;


        // Подготовка состояния перед запуском каждого тестового метода в классе
        // Выполняется инициализация тестового окружения
        [SetUp]
        public void Setup()
        {
            // Настройка и запуск браузера Edge
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("start-maximized"); // Максимизация окна

            EdgeDriverService service = EdgeDriverService.CreateDefaultService();
            driver = new EdgeDriver(service, options);

            // Установка неявного ожидания на 30 секунд
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        // Освобождение ресурсов после завершения выполнения каждого теста
        // Закрытие драйвера браузера
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
        // Тест для экрана компьютера
        public void SignInPasswordTestOnDesktop()
        {
            try
            {
                // 1.Переход на страницу gosuslugi.ru
                driver.Url = "https://www.gosuslugi.ru/";

                // 2.Нажатие кнопки «Войти»
                // Находим элемент по ClassName
                IWebElement signInLink = driver.FindElement(By.ClassName("login-button"));

                // Нажимаем на элемент
                signInLink.Click();

                // 3.Нажатие кнопки «Не удается войти?»
                IWebElement cannotLoginButton = driver.FindElement(By.XPath("//div[@class='mt-40 text-center']//button[@class='plain-button-inline']"));
                cannotLoginButton.Click();

                // 4.В появившейся форме «Не удается войти?» нажать «восстановление пароля»
                IWebElement recoveryPasswordButton = driver.FindElement(By.XPath("//li[@class='mb-24']//button[@class='plain-button-inline']"));
                recoveryPasswordButton.Click();

                // Ожидаем перехода на страницу восстановления пароля
                Thread.Sleep(5000);

                // 5.Проверить что открылась форма «Восстановление пароля»
                // Проверяем, что мы находимся на url восстановления пароля
                Assert.IsTrue(driver.Url.Contains("/login/recovery"), "Форма восстановления пароля не открыта");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Тест неудачен: {ex.Message}");
                throw;
            }
        }

        [Test]
        // Тест для экрана телефона
        public void SignInPasswordTestOnMobile()
        {
            try
            {
                // Эмуляция мобильного устройства Galaxy S5
                EdgeOptions options = new EdgeOptions();
                options.EnableMobileEmulation("Galaxy S5");
                driver = new EdgeDriver(options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                // 1.Переход на страницу gosuslugi.ru
                driver.Url = "https://www.gosuslugi.ru/";

                // 2.Нажатие кнопки «Войти»
                // Находим элемент по ClassName
                IWebElement signInLink = driver.FindElement(By.ClassName("login-button"));

                // Нажимаем на элемент
                signInLink.Click();

                // 3.Нажатие кнопки «Не удается войти?»
                IWebElement cannotLoginButton = driver.FindElement(By.XPath("//div[@class='mt-40 text-center']//button[@class='plain-button-inline']"));
                cannotLoginButton.Click();

                // 4.В появившейся форме «Не удается войти?» нажать «восстановление пароля»
                IWebElement recoveryPasswordButton = driver.FindElement(By.XPath("//li[@class='mb-24']//button[@class='plain-button-inline']"));
                recoveryPasswordButton.Click();

                // Ожидаем перехода на страницу восстановления пароля
                Thread.Sleep(5000);

                // 5.Проверить что открылась форма «Восстановление пароля»
                // Проверяем, что мы находимся на url восстановления пароля
                Assert.IsTrue(driver.Url.Contains("/login/recovery"), "Форма восстановления пароля не открыта");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Тест неудачен: {ex.Message}");
                throw;
            }
        }
    }
}