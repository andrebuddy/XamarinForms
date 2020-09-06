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
    public partial class DateTimeCell : ViewCell
    {
        public static readonly BindableProperty LabelPropperty = 
            BindableProperty.Create("Label", typeof(string), typeof(DateTimeCell));
        public string Label 
        {
            get { return (string)GetValue(LabelPropperty); }
            set { SetValue(LabelPropperty, value); }
        }

        public DateTimeCell()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}