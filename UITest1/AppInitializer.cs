using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            //if (platform == Platform.Android)
            //{
            //    return ConfigureApp.Android.StartApp();
            //}
            if (platform == Platform.Android)
            {
                return ConfigureApp
                .Android
                .ApkFile(@"C:\Users\738458\Documents\GitHub\ButtonDemos\ButtonDemos\ButtonDemos.Android\bin\Release\com.companyname.ButtonDemos.apk")
                //.EnableLocalScreenshots("C:\\XamarinTest\\ButtonDemos\\ButtonDemos\\ButtonDemos.Android\bin\\Release\")
                .EnableLocalScreenshots()
                .StartApp();
            }


            return ConfigureApp.iOS.StartApp();
        }
    }
}