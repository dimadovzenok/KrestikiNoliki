using System.ComponentModel;
using Xamarin.Forms;
using Krestikinoliki.ViewModels;

namespace Krestikinoliki.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}