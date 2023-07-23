using System;
using System.Collections.ObjectModel;
using System.Threading;
using Domain.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello My Crawler Bot");
        Console.ReadKey();

        new DriverManager().SetUpDriver(new ChromeConfig());

        IWebDriver driver = new ChromeDriver();

        var hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7029/Hubs/LogHub")
            .WithAutomaticReconnect()
            .Build();

        await hubConnection.StartAsync();

        try
        {
            await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Bot started"));

            driver.Navigate().GoToUrl("https://finalproject.dotnet.gg");

            //Console.WriteLine(DateTimeOffset.Now + "---->" + "Siteye gidildi.");
            
            await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Siteye gidildi"));


            Random random = new Random();

            Thread.Sleep(random.Next(10, 41) * 100); // Siteye gittikten sonraki bekleme süresi

            ReadOnlyCollection<IWebElement> sayfaNumarası = driver.FindElements(By.CssSelector(".page-item"));

            //Console.WriteLine(DateTimeOffset.Now + "---->" + (sayfaNumarası.Count - 1) + " adet sayfa bulundu.");
            
            await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Toplam " + (sayfaNumarası.Count-1) + " adet sayfa bulunduğu tespit edildi."));


            IReadOnlyCollection<IWebElement> cardBody = driver.FindElements(By.CssSelector(".card.h-100"));

            //Console.WriteLine(DateTimeOffset.Now + "---->" + $"1. sayfada {cardBody.Count} adet ürün bulundu.");
            
            await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"1. sayfa tarandı. Toplam {cardBody.Count} adet ürün bulundu."));


            foreach (IWebElement cards in cardBody)
            {
                IWebElement name = cards.FindElement(By.CssSelector(".fw-bolder.product-name"));

                bool isProductOnSale(string element)
                {
                    try
                    {
                        cards.FindElement(By.CssSelector(element));
                        return true;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                }

                if (isProductOnSale(".sale-price"))
                {
                    IWebElement salePrice = cards.FindElement(By.CssSelector(".sale-price"));
                    IWebElement price = cards.FindElement(By.CssSelector(".text-muted.text-decoration-line-through.price"));

                    Console.WriteLine(DateTimeOffset.Now + "---->" + "Product Name:" + name.Text + "\n" +
                                      "Old Price:" + price.Text + "\n" + "Sale Price:" + salePrice.Text);
                }
                else
                {
                    IWebElement price = cards.FindElement(By.CssSelector(".price"));

                    Console.WriteLine(DateTimeOffset.Now + "---->" + "Product:" + name.Text + "\n" + "Price" + price.Text);
                }
            }

            for (int i = 2; i < sayfaNumarası.Count; i++)
            {
                driver.Navigate().GoToUrl($"https://finalproject.dotnet.gg/?currentPage={i}");

                //Console.WriteLine(DateTimeOffset.Now + "---->" + $"{i}. sayfaya geçildi");

                Thread.Sleep(random.Next(10, 41) * 100);

                IReadOnlyCollection<IWebElement> card = driver.FindElements(By.CssSelector(".card.h-100"));

                //Console.WriteLine(DateTimeOffset.Now + "---->" + $"{i}. sayfayda {card.Count} adet ürün bulundu.");
                
                await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"{i}. sayfa tarandı. Toplam {cardBody.Count} adet ürün bulundu."));


                foreach (IWebElement cards in card)
                {
                    IWebElement name = cards.FindElement(By.CssSelector(".fw-bolder.product-name"));

                    bool isProductOnSale(string element)
                    {
                        try
                        {
                            cards.FindElement(By.CssSelector(element));
                            return true;
                        }
                        catch (NoSuchElementException)
                        {
                            return false;
                        }
                    }

                    if (isProductOnSale(".sale-price"))
                    {
                        IWebElement salePrice = cards.FindElement(By.CssSelector(".sale-price"));
                        IWebElement price = cards.FindElement(By.CssSelector(".text-muted.text-decoration-line-through.price"));

                        Console.WriteLine(DateTimeOffset.Now + "---->" + "Product Name:" + name.Text + "\n" +
                                          "Old Price:" + price.Text + "\n" + "Sale Price:" + salePrice.Text);
                    }
                    else
                    {
                        IWebElement price = cards.FindElement(By.CssSelector(".price"));

                        Console.WriteLine(DateTimeOffset.Now + "---->" + "Product Name:" + name.Text + "\n" +
                                          "Price:" + price.Text);
                    }
                }
            }
        }
        catch (Exception exception)
        {
            driver.Quit();
        }

        LogDto CreateLog(string message) => new LogDto(message);
    }
}
