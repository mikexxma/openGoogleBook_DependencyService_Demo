using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenBooks_Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OpenBooks(object sender, EventArgs e)
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    Device.OpenUri(new Uri("itms-books"));
                    break;
                case TargetPlatform.Android:
                    DependencyService.Get<OpenBookInterface>().openBooks();
                    break;
            }
        }
    }
}
