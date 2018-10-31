using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        static readonly Func<AppQuery, AppQuery> Basic = c => c.Marked("BasicId");
        static readonly Func<AppQuery, AppQuery> Code = c => c.Marked("CodeId");
        static readonly Func<AppQuery, AppQuery> BasicCommand = c => c.Marked("BasicCommandId");
        static readonly Func<AppQuery, AppQuery> Press = c => c.Marked("PressId");
        static readonly Func<AppQuery, AppQuery> Appearance = c => c.Marked("AppearanceId");
        static readonly Func<AppQuery, AppQuery> Toggle = c => c.Marked("ToggleId");
        static readonly Func<AppQuery, AppQuery> Image = c => c.Marked("ImageId");


        //private IApp _app;
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }
        

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [Category("1 Basic Button")]
        public void BasicButtonTest()
        {
            //appResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");
            app.Tap(Basic);     //app.Tap(c => c.Marked("BasicClick"));

            app.Screenshot("Prueba_basic_click");
            app.Tap("Rotate_text");
            app.WaitForElement("Rotate_text");
            //app.WaitForElement(e => e.Button("BasicId"));
            //var texto = 
            app.Back();
            app.WaitForElement(e => e.Button("BasicId"), timeout: TimeSpan.FromSeconds(10));
            //app.WaitForElement(c => c.Class("ButtonDemos.MainPage"), timeout: TimeSpan.FromSeconds(120));
            Console.WriteLine("RESULT - Test case BasicButtonTest PASSED ");
            app.Screenshot("When I get the result value");
        }

        [Test]
        [Category("2 Code Button")]
        public void CodeButtonTest_Rotate()
        {
            //click on the button throght the AutomationId
            app.Tap(c => c.Marked("CodeId"));
            app.Screenshot("Prueba_codeButton");
            //click on the button throght the button text
            app.Tap("Click to Rotate Text!");
            app.Back();
        }
        [Test]
        [Category("2 Code Button")]
        public void CodeButtonTest_AsserButtontText()
        {
            app.Tap(c => c.Marked("CodeId"));
            app.Screenshot("Prueba_codeButton");
            //click on the button throght the AutomationId
            app.Tap(c => c.Marked("Rotate_Text2"));
            //Assert button Text
            AppResult[] buttonText = app.Query(c => c.Marked("Rotate_Text2"));
            string buttonText_Text = buttonText?.FirstOrDefault()?.Text;
            Assert.AreEqual("Click to Rotate Text!", buttonText_Text);
            app.Back();
        }

        [Test]
        [Category("2 Code Button")]
        public void CodeButtonTest_AssertLabelText()
        {
            app.Tap(Code);
            app.Screenshot("Prueba_codeButton");
            //Search the label
            AppResult[] CodePageTextResult = app.Query(c => c.Marked("CodePageText"));
            string PageLabel_Text = CodePageTextResult?.FirstOrDefault()?.Text;
            //Assert Page Text
            Assert.AreEqual("Click the Button below", PageLabel_Text);
            app.Back();
        }

        [Test]
        [Category("3 Math operations")]
        public void BasicButtonCommand_Por2()
        {
            app.Tap(BasicCommand);      //app.Tap(c => c.Marked("BasicCommandId"));
            app.Screenshot("Prueba_basic command");

            //Search the label result
            AppResult[] CodePageTextResult = app.Query(c => c.Marked("LabelResult"));
            string PageLabel_Text = CodePageTextResult.First().Text;
            Assert.AreEqual("Value is now 1", PageLabel_Text);
            Console.WriteLine("El valor inicial es" + PageLabel_Text);

            // Multiply by 2
            app.Tap(c => c.Marked("Por2"));
            AppResult[] CodePageTextResult_Por2 = app.Query(c => c.Marked("LabelResult"));
            string PageLabel_Text_Por2 = CodePageTextResult_Por2.First().Text;
            Assert.AreEqual("Value is now 2", PageLabel_Text_Por2);
            Console.WriteLine("Despues de multiplicar por 2 el valor es " + PageLabel_Text_Por2);
            app.Back();
        }
        [Test]
        [Category("3 Math operations")]
        public void BasicButtonCommand_Entre2()
        {
            app.Tap(BasicCommand);
            app.Screenshot("Prueba_basic command");
            
            //Search the label result
            AppResult[] CodePageTextResult = app.Query(c => c.Marked("LabelResult"));
            string PageLabel_Text = CodePageTextResult.First().Text;
            Assert.AreEqual("Value is now 1", PageLabel_Text);
            Console.WriteLine("El valor inicial es" + PageLabel_Text);
            
            // Divide by 2
            app.Tap(c => c.Marked("Entre2"));
            AppResult[] CodePageTextResult_Entre2 = app.Query(c => c.Marked("LabelResult"));
            string PageLabel_Text_Entre2 = CodePageTextResult_Entre2.First().Text;
            Assert.AreEqual("Value is now 0.5", PageLabel_Text_Entre2);
            Console.WriteLine("despues de dividir entre 2 es " + PageLabel_Text_Entre2);
            app.Back();
        }
        [Test]
        [Category("4 Appearance")]
        [Category("Color")]
        public void Appearance_color()
        {
            app.Tap(Appearance);
            //AppResult[] ColorLabel = app.Query(c => c.Marked("sizeSlider"));
            app.SetSliderValue(c => c.Marked("sizeSlider"), 200);
            //app.Tap(c => c.Marked("Appearance"));
            AppResult[] buttondynamic = app.Query(c => c.Marked("Button"));
            string buttontext = buttondynamic.First().Text;
            //Assert.AreEqual("Value is now 0.5", PageLabel_Text_Entre2);
            Console.WriteLine("button text  " + buttontext);
         }   
    }
}
