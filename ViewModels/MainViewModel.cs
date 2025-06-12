using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyMangaApp.Services;
namespace MyMangaApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly MangaDexApiServices _apiService;
        private string _searchText;
        private string _searchResult;



        public MainViewModel()
        {
            _apiService = new MangaDexApiServices();
            SearchCommand = new RelayCommand(async () => await SearchMangaAsync());
        }
        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(); }
        }
        public string SearchResult
        {
            get => _searchResult;
            set { _searchResult = value; OnPropertyChanged(); }
        }

        public ICommand SearchCommand { get; }

        private async Task SearchMangaAsync()
        {
            var result = await _apiService.SearchMangaAsync(SearchText);
            SearchResult = result;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}