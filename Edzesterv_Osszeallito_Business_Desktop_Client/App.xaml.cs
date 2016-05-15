using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;

namespace Edzesterv_Osszeallito_Business_Desktop_Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
            LogInView logInView = new LogInView();
            logInView.DataContext = new LogInViewModel(logInView);
            logInView.Closing += LogInView_Closing;
            logInView.Show();

            Current.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        }

        private void LogInView_Closing(object sender, CancelEventArgs e)
        {
            GC.Collect(); // collects all unused memory
            GC.WaitForPendingFinalizers(); // wait until GC has finished its work
            GC.Collect();
        }

        private void MainView_Closing(object sender, CancelEventArgs e)
        {
            Current.Shutdown();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception, e.IsTerminating);
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception, false);
            e.Handled = true;
        }

        private void HandleException(Exception exception, bool isTerminating)
        {
            if (exception == null)
                return;

            Trace.TraceError(exception.ToString());

            if (!isTerminating)
            {
                StringBuilder exceptionSB = new StringBuilder();
                exceptionSB.Append(exception.ToString());
                ExceptionView exceptionView = new ExceptionView();
                exceptionView.DataContext = new ExceptionViewModel(exceptionSB.ToString(), exceptionView);
                exceptionView.ShowDialog();
            }
        }
    }
}
