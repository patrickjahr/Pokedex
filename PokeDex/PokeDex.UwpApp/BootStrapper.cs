using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PokeDex.Core.Repositories;
using PokeDex.Core.Services;
using PokeDex.Core.ViewModel;
using PokeDex.UwpApp.Services;
using PokeDex.UwpApp.Views;

namespace PokeDex.UwpApp
{
    public class BootStrapper
    {
        public BootStrapper()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IResourceService, ResWrapper>();
            SimpleIoc.Default.Register<ILocalStorageService, LocalStorageService>();
            SimpleIoc.Default.Register<IPackageStorageService, PackageStorageService>();
            SimpleIoc.Default.Register<IPokemonRepositories, PokemonRepositories>();

            SimpleIoc.Default.Register<PokemonOverviewViewModel>();
            SimpleIoc.Default.Register<PokemonDetailViewModel>();
        }

        public PokemonOverviewViewModel PokemonOverviewViewModel
            => SimpleIoc.Default.GetInstance<PokemonOverviewViewModel>();

        public PokemonDetailViewModel PokemonDetailViewModel
            => SimpleIoc.Default.GetInstance<PokemonDetailViewModel>();
    }
}