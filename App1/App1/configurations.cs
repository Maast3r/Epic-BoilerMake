using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace App1
{
    public partial class Configurations : Page
    {
        public List<Scenario> scenes = new List<Scenario> {
        new Scenario() {Title = "Register new patient", ClassType = typeof(App1.BlankPage1) },
    };
    }


    public class Scenario
    {
        public string Title { get; set; }

        public Type ClassType { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}



