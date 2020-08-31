using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage1 : ContentPage
    {
        public MyTabbedPage1()
        {
            InitializeComponent();
        }
    }
}