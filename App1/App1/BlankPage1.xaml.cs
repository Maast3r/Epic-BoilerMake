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
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class BlankPage1 : Page
    {
        public String json;
        public BlankPage1()
        {
            this.InitializeComponent();

            
            makePage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            json = e.Parameter as string;
        }

        private void makePage()
        {
            for (int i = 0; i < 3; i++)
            {
                var drug = new Canvas();
                drug.MaxWidth = 475;
                drug.MinHeight = 0;
                drug.Margin = new Thickness(17, i * 400 + 24, 0, 0);

                var medicineTitle = new TextBlock();
                medicineTitle.Text = "Vicodin";
                medicineTitle.FontFamily = new FontFamily("Microsoft Sans Serif");
                medicineTitle.FontSize = 20;
                medicineTitle.FontWeight = Windows.UI.Text.FontWeights.Bold;
                medicineTitle.Margin = new Thickness(37, 38, 0, 0);
                medicineTitle.MaxWidth = 100;

                var remaining = new TextBlock();
                remaining.Text = "10/100 remaining";
                remaining.FontFamily = new FontFamily("Microsoft Sans Serif");
                remaining.FontSize = 16;
                remaining.Margin = new Thickness(138, 43, 0, 0);
                remaining.MaxWidth = 196;

                var instructions = new TextBlock();
                instructions.Text = "Take 20 everyday or else you done goofed.";
                instructions.TextWrapping = TextWrapping.Wrap;
                instructions.MaxWidth = 275;
                instructions.FontFamily = new FontFamily("Microsoft Sans Serif");
                instructions.FontSize = 18;
                instructions.Margin = new Thickness(37, 83, 0, 0);

                var dose = new TextBlock();
                dose.Text = "Dose: 1000mg";
                dose.FontFamily = new FontFamily("Microsoft Sans Serif");
                dose.FontSize = 18;
                dose.Margin = new Thickness(37, 135, 0, 0);
                dose.MaxWidth = 123;

                var drugTimes = new TextBlock();
                drugTimes.Text = "Times Windows will remind you:";
                drugTimes.FontFamily = new FontFamily("Microsoft Sans Serif");
                drugTimes.FontSize = 18;
                drugTimes.Margin = new Thickness(38, 170, 0, 0);
                drugTimes.MaxWidth = 331;

                var reminders = new Canvas();
                int x = 0;
                int y = 1;
                for (int j = 0; j < 7; j++)
                {
                    var reminder = new TextBlock();
                    reminder.Text = "12:66am";
                    reminder.FontFamily = new FontFamily("Microsoft Sans Serif");
                    reminder.FontSize = 18;
                    reminder.Margin = new Thickness(x * 100 + 10, 22 * y, 0, 0);
                    reminder.Width = 75;
                    reminder.Height = 25;
                    x += 1;
                    if (j % 3 == 0 && j != 0)
                    {
                        y += 1;
                        x = 0;
                    }
                    reminders.Children.Add(reminder);
                }
                reminders.Margin = new Thickness(38, 180, 0, 0);
                reminders.MaxWidth = 400;

                var reFill = new TextBlock();
                reFill.Text = "Refill now. You're out of time.";
                reFill.FontFamily = new FontFamily("Microsoft Sans Serif");
                reFill.FontSize = 18;
                reFill.Margin = new Thickness(37, 265, 0, 0);

                var updateButton = new Button();
                var updateText = new TextBlock();
                updateText.Text = "Update Reminder Times and Information";
                updateText.FontSize = 18;
                updateText.TextAlignment = TextAlignment.Center;
                updateText.TextWrapping = TextWrapping.Wrap;
                updateButton.Content = updateText;
                updateButton.FontFamily = new FontFamily("Microsoft Sans Serif");
                updateButton.Margin = new Thickness(315, 50, 0, 0);
                updateButton.Width = 125;
                updateButton.Height = 75;
                updateButton.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                updateButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 172, 67));

                var refillButton = new Button();
                refillButton.Content = "I got a refill";
                refillButton.FontFamily = new FontFamily("Microsoft Sans Serif");
                refillButton.FontSize = 18;
                refillButton.Margin = new Thickness(315, 145, 0, 0);
                refillButton.Width = 122;
                refillButton.Height = 35;
                refillButton.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                refillButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 88, 185, 87));
                
                drug.Children.Add(medicineTitle);
                drug.Children.Add(remaining);
                drug.Children.Add(instructions);
                drug.Children.Add(dose);
                drug.Children.Add(drugTimes);
                drug.Children.Add(reminders);
                drug.Children.Add(reFill);
                drug.Children.Add(updateButton);
                drug.Children.Add(refillButton);
                drug.Height = 375;
                
                wrapper.Children.Add(drug);

                var seperator = new Canvas();
                seperator.Width = 450;
                seperator.Height = 1;
                seperator.MinHeight = 1;
                seperator.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));
                seperator.Margin = new Thickness(35, 375, 0, 0);
                wrapper.Children.Add(seperator);
                
            }
            wrapper.Height = 375*3;
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Test: " + wrapper.ActualHeight);

            m.ShowAsync();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
