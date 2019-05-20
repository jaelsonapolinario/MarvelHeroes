using System;
using System.Collections.Generic;
using MarvelHeroes.ViewModel;
using Xamarin.Forms;

namespace MarvelHeroes.View
{
    public partial class DetailsPage : ContentPage
    {
        private HeroesViewModel _viewModel;
        public DetailsPage()
        {
            InitializeComponent();

            _viewModel = HeroesViewModel.Instance;
            BindingContext = _viewModel.HeroeSelected;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
