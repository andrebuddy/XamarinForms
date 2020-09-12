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
    public partial class ApplicationProperties : ContentPage
    {
        public ApplicationProperties()
        {
            InitializeComponent();

            // due to 2 way binding, if we do it like this, the data is auto saved and retrieved
            BindingContext = Application.Current;
        }
    }
}