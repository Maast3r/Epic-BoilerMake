using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public String drug;
        public BlankPage2()
        {
            this.InitializeComponent();

            makeDrugPage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            drug = e.Parameter as string;
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("what is this: " + drug);

            m.ShowAsync();
        }

        private void makeDrugPage()
        {
            var title = new TextBlock();
            title.Text = "Vicodin for Mary Poppins";
            title.FontFamily = new FontFamily("Microsoft Sans Serif");
            title.FontSize = 26;
            title.TextAlignment = TextAlignment.Center;
            title.FontWeight = Windows.UI.Text.FontWeights.Bold;
            title.Margin = new Thickness(60, 50, 0, 0);
            title.MaxWidth = 800;
            wrapper2.Children.Add(title);

            var pillsRemainingTitle = new TextBlock();
            pillsRemainingTitle.Text = "Pills Remaining:";
            pillsRemainingTitle.FontFamily = new FontFamily("Microsoft Sans Serif");
            pillsRemainingTitle.FontSize = 20;
            pillsRemainingTitle.TextAlignment = TextAlignment.Center;
            pillsRemainingTitle.Margin = new Thickness(60, 100, 0, 0);
            wrapper2.Children.Add(pillsRemainingTitle);

            var pills = new TextBlock();
            pills.Text = "14/20";
            pills.FontFamily = new FontFamily("Microsoft Sans Serif");
            pills.FontSize = 20;
            pills.TextAlignment = TextAlignment.Center;
            pills.Margin = new Thickness(60, 150, 0, 0);
            wrapper2.Children.Add(pills);

            var refillsRemainingTitle = new TextBlock();
            refillsRemainingTitle.Text = "Refills Remaining:";
            refillsRemainingTitle.FontFamily = new FontFamily("Microsoft Sans Serif");
            refillsRemainingTitle.FontSize = 20;
            refillsRemainingTitle.TextAlignment = TextAlignment.Center;
            refillsRemainingTitle.Margin = new Thickness(60, 200, 0, 0);
            wrapper2.Children.Add(refillsRemainingTitle);

            var refills = new TextBlock();
            refills.Text = "14/20";
            refills.FontFamily = new FontFamily("Microsoft Sans Serif");
            refills.FontSize = 20;
            refills.TextAlignment = TextAlignment.Center;
            refills.Margin = new Thickness(60, 250, 0, 0);
            wrapper2.Children.Add(refills);

            var reminderTitle = new TextBlock();
            reminderTitle.Text = "Reminder Times:";
            reminderTitle.FontFamily = new FontFamily("Microsoft Sans Serif");
            reminderTitle.FontSize = 20;
            reminderTitle.TextAlignment = TextAlignment.Center;
            reminderTitle.Margin = new Thickness(60, 300, 0, 0);
            wrapper2.Children.Add(reminderTitle);

            for (int i=0; i<3; i++)
            {
                var reminderTime = new TimePicker();
                reminderTime.FontFamily = new FontFamily("Microsoft Sans Serif");
                reminderTime.FontSize = 20;
                reminderTime.Margin = new Thickness(60, 350 + i * 50, 0, 0);
                wrapper2.Children.Add(reminderTime);
            }

            var reminderMessageTitle = new TextBlock();
            reminderMessageTitle.Text = "Reminder Message:";
            reminderMessageTitle.FontFamily = new FontFamily("Microsoft Sans Serif");
            reminderMessageTitle.FontSize = 20;
            reminderMessageTitle.TextAlignment = TextAlignment.Center;
            reminderMessageTitle.Margin = new Thickness(60, 350 + 4 * 50, 0, 0);
            wrapper2.Children.Add(reminderMessageTitle);

            var reminder2 = new TextBox();
            reminder2.FontFamily = new FontFamily("Microsoft Sans Serif");
            reminder2.FontSize = 20;
            reminder2.TextAlignment = TextAlignment.Center;
            reminder2.Margin = new Thickness(60, 400 + 4 * 50, 0, 0);
            reminder2.Width = 300;
            wrapper2.Children.Add(reminder2);

            var applyButton = new Button();
            var applyText = new TextBlock();
            applyText.Text = "Apply Changes";
            applyText.FontSize = 20;
            applyText.TextAlignment = TextAlignment.Center;
            applyText.TextWrapping = TextWrapping.Wrap;
            applyButton.Content = applyText;
            applyButton.FontFamily = new FontFamily("Microsoft Sans Serif");
            applyButton.Margin = new Thickness(60, 450 + 4 * 50, 0, 0);
            applyButton.Width = 400;
            applyButton.Height = 75;
            applyButton.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            applyButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 88, 185, 87));
            applyButton.Name = "pls";
            applyButton.Click += new RoutedEventHandler(back);
            wrapper2.Children.Add(applyButton);

        }

        private void back(object handler, RoutedEventArgs e)
        {
            //rootFrame.Navigate(typeof(BlankPage2));
            String test = ((Button)handler).Name;
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Test: " + test);

            m.ShowAsync();
            (Window.Current.Content as Frame).Navigate(typeof(BlankPage1), test);
            //throw new NotImplementedException();
        }
    }
}
