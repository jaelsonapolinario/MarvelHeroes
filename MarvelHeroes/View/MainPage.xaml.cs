using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarvelHeroes.ViewModel;
using Xamarin.Forms;

namespace MarvelHeroes.View
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private HeroesViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = HeroesViewModel.Instance;
        }

        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            var items = _viewModel.Heroes;

            if (items != null && e.Item == items[items.Count - 5])
            {
                _viewModel.GetHeroes();
            }
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var listView = ((ListView)sender);
            var hero = (Model.Result)listView.SelectedItem;
            listView.SelectedItem = null;
            if (hero != null && _viewModel.HeroeSelected != hero)
            {
                _viewModel.HeroeSelected = hero;
                Navigation.PushAsync(new DetailsPage());
            }

        }
    }
}
