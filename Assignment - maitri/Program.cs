using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace maitri
{
    class Program
    {
        static IWebDriver driver = new ChromeDriver();
        static IWebElement radioEle;
        static IWebElement suggestionele;
        static IWebElement dropdownele;
        static IWebElement checkboxele;
        static IWebElement switchwindowele;
        
        

        public static object ObjectRepository { get; private set; }

        static void Main(string[] args)
        {
            String Url = "http://www.qaclickacademy.com/practice.php ";
            driver.Navigate().GoToUrl(Url);
            radioEle = driver.FindElement(By.ClassName("radioButton"));
            dropdownele=driver.FindElement(By.Id("dropdown-class-example"));
            checkboxele = driver.FindElement(By.Id("checkbox-example"));

            //function call
            //Assignment();
            //dropdownMethod();
            //checkboxMethod();
            //suggestionclass();
            switchwindow();




        }

        // Radio Button
        public static void Assignment()
        {
            IWebElement radio1 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            System.Console.WriteLine("click on Radio button 1");

            IWebElement radio2 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            System.Console.WriteLine("click on Radio button 2");

            IWebElement radio3 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            System.Console.WriteLine("click on Radio button 3");
        }


        //suggestion class
        public static void suggestionclass()
        {
            IWebElement selection = driver.FindElement(By.Id("autocomplete"));
            selection.SendKeys("United");
            IList<IWebElement> selectionbox = driver.FindElements(By.XPath("//div[@class='ui-menu-item-wrapper']"));
            foreach(var selement in selectionbox)
            {
                if(selement.Text.Contains("United States (USA)"))
                {
                    selement.Click();

                }
               
            }
            


        }
        

        //Dropdown
        public static void dropdownMethod()
        {
            IWebElement dropdown = driver.FindElement(By.Id("dropdown-class-example"));
            SelectElement drop= new SelectElement(dropdown);
            int[] options = {0,1,2,3 };
            foreach(var item in options)
            {

                drop.SelectByIndex(item);
                Thread.Sleep(2000);
                //Console.WriteLine(item.Text);
            }
            driver.Quit();  

        }
        //checkbox
        public static void checkboxMethod()
        {
            //checkbox-1
            string option = "1";

            IWebElement checkbox1 = driver.FindElement(By.Id("checkBoxOption1"));
            checkbox1.Click();
            Thread.Sleep(1000);
            checkbox1.Click();

            Thread.Sleep(1000);
            Console.WriteLine(checkbox1.GetAttribute("value"));

            //checkbox-2
            string option2 = "2";

            IWebElement checkbox2 = driver.FindElement(By.Id("checkBoxOption2"));
            checkbox2.Click();
            Thread.Sleep(1000);
            checkbox2.Click();

            Thread.Sleep(1000);
            Console.WriteLine(checkbox2.GetAttribute("value"));


            //checkbox3

            string option3 = "3";

            IWebElement checkbox3 = driver.FindElement(By.Id("checkBoxOption3"));
            checkbox3.Click();
            Thread.Sleep(1000);
            checkbox3.Click();

            Thread.Sleep(1000);
            Console.WriteLine(checkbox3.GetAttribute("value"));
            checkbox3.Click();
            Thread.Sleep(1000);
            checkbox3.Click();
            Thread.Sleep(1000);

            int i = 0;
            while (i <= 3)
            {
                IWebElement checkall = driver.FindElement(By.Id("checkBoxOption" + i + ""));
                checkall.Click();   
                

            }
            i++;
                


        }

        //switchwindow
        public static void switchwindow()
        {
            IWebElement switchwind = driver.FindElement(By.Id("openwindow"));
            switchwind.Click();
            Thread.Sleep(1000);
            
            IWebElement switchwindowreturn = driver.FindElement(By.XPath("//a[text()='Practice']"));
        }
        //switchtab
        public static void switchTab()
        {
            IWebElement switchtab = Driver.FindElement(By.Id("opentab"));
            switchtab.Click();
            Thread.Sleep(3000);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        //Alertexample

        public static void alertExample()
        {
            IWebElement alertbox = Driver.FindElement(By.Id("name"));
            alertbox.Click();
            alertbox.SendKeys("maitri");
            Thread.Sleep(4000);
            IWebElement alertbutton = Driver.FindElement(By.Id("alertbtn"));
            alertbutton.Click();
            Thread.Sleep(2000);
            Driver.SwitchTo().Alert().Accept();
        }

        public static void webtable()
        {
            IWebElement wtable = Driver.FindElement(By.Id("product"));
            wtable.Click();
            Actions actions = new Actions(Driver);
            actions.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();


        }


        public static void hover()
        {
            //IWebElement hoverel = Driver.FindElement(By.Id("mousehover"));
            var element = Driver.FindElement(By.Id("mousehover"));
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();           
            Thread.Sleep(2000);
            IWebElement Top = Driver.FindElement(By.XPath("//a[@href='#top']"));
            action.MoveToElement(element).Perform();
            Top.Click();
            Thread.Sleep(2000);

        }

    }
}
