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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    partial class MainPage
    {

        //internal Frame rootFrame;


        public MainPage()
        {
            this.InitializeComponent();

            button.Click += new RoutedEventHandler(button_Click_1);

            //rootFrame = new Frame();
        }

        private void firstNameForm_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //String firstName = firstNameForm.Text;
            //String lastName = lastNameForm.Text;
            //String DOB = DOBForm.Text;
            //String gender = "";
            //if ((bool)maleButton.IsChecked)
            //{
             //   gender = "m";
            //}
            //else if ((bool)femaleButton.IsChecked)
            //{
             //   gender = "f";
            //}
            //String address = AddressForm.Text != null ? AddressForm.Text : "";
           // String phone = PhoneForm.Text != null ? PhoneForm.Text : "";
            //Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Test: " + firstName + " " + lastName + " " + DOB + " " + gender + " " + address + " " + phone);

            //m.ShowAsync();
        }

        private void text1_Copy_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            String firstName = firstNameForm.Text;
            String lastName = lastNameForm.Text;
            String DOB = DOBForm.Text;
            String gender = "";
            if ((bool)maleButton.IsChecked)
            {
               gender = "m";
            }
            else if ((bool)femaleButton.IsChecked)
            {
               gender = "f";
            }
            String address = AddressForm.Text != null ? AddressForm.Text : "";
            String phone = PhoneForm.Text != null ? PhoneForm.Text : "";
            //Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog("Test: " + firstName + " " + lastName + " " + DOB + " " + gender + " " + address + " " + phone);

            //m.ShowAsync();
            //rootFrame.Navigate(typeof(BlankPage1));

            (Window.Current.Content as Frame).Navigate(typeof(BlankPage1), "test");
        }
    }
}
