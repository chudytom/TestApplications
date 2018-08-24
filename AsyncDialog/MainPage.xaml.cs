using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AsyncDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();
        int i = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Tick += Timer_Tick;
            i = 0;
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Start();
            CheckHappiness();
            Debug.Write("Button method");
        }

        private async void CheckHappiness()
        {
            MessageDialog dialog = new MessageDialog("Czy jesteś szczęśliwy");
            string happyMessage = "Szczęśliwy i radosny!";
            dialog.Commands.Add(new UICommand(happyMessage));
            dialog.Commands.Add(new UICommand("Smutny jak listopadowa pogoda"));
            dialog.DefaultCommandIndex = 1;
            Debug.Write("CheckHappiness before await");
            IUICommand result = await dialog.ShowAsync();
            Debug.Write("CheckHappiness after ShowDialog");
            if (result != null && result.Label == happyMessage)
                response.Text = "Użytkownik jest szczęśliwy";
            else
                response.Text = "Użytkownik jest smutny";
            timer.Stop();
        }

        private void Timer_Tick(object sender, object e)
        {
            ticker.Text = "Chwila nr  " + i++;
        }
    }
}
