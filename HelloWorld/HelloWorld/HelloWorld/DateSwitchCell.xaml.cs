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
    public partial class DateSwitchCell : ViewCell
    {
        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create("Label", typeof(string), typeof(DateSwitchCell));
        public string Label { 
            get { return (string)GetValue(LabelProperty); } 
            set { SetValue(LabelProperty, value); } 
        }

        public DateSwitchCell()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}