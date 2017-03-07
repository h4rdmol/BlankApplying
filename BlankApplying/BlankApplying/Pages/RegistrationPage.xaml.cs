using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Net.Http;
using BlankApplying.Models;

namespace BlankApplying.Pages
{
    public partial class RegistrationPage : ContentPage
    {
        string answer, keyword;
        string query;
        int countryId, cityId;
        List<string> _countries, _cities, _universities;
        Data data;
        UniversitiesData data2;
        User user;
        HttpClient httpClient;
        IEnumerable<string> searchResult;

        public RegistrationPage()
        {
            InitializeComponent();
            this.Appearing += OnAppearing;

            // initializing required properties
            user = new User();
            httpClient = new HttpClient();
            _countries = new List<string>();
            _cities = new List<string>();
            _universities = new List<string>();

        }
        private async void OnAppearing(object sender, EventArgs e)
        {
            FirstName_Entry.Focus();
            await getCountriesList();
            Countries_SearchBar.IsEnabled = true;

        }
        private async void OnClicked(object sender, EventArgs e)
        {
            user.userFirstName = FirstName_Entry.Text;
            user.userSecondName = SecondName_Entry.Text;
            await Navigation.PushAsync(new DisplayInformationPage(user));
        }


        private void Countries_SearchBar_OnFocused(object sender, EventArgs e)
        {
            if (Countries_SearchBar.IsEnabled == false)
                Countries_SearchBar.Unfocus();
            else
                CountiresListView.ItemsSource = _countries;

        }
        private void Countries_SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            ResetFields();

            keyword = Countries_SearchBar.Text;
            searchResult = _countries.Where(countryName => countryName.ToLower().Contains(keyword.ToLower()));
            CountiresListView.ItemsSource = searchResult;
        }
        private void Countries_SearchBar_OnTextChanged(object sender, EventArgs e)
        {
            if (Countries_SearchBar.Text != "")
                CountiresListView.IsVisible = true;
            else
                CountiresListView.IsVisible = false;
            ResetFields();
            if (Countries_SearchBar.Text != null)
            {
                keyword = Countries_SearchBar.Text;
                searchResult = _countries.Where(countryName => countryName.ToLower().Contains(keyword.ToLower()));
                CountiresListView.ItemsSource = searchResult;
            }
        }


        private async void Cities_SearchBar_OnFocused(object sender, EventArgs e)
        {
            if (Cities_SearchBar.IsEnabled == false)
                Cities_SearchBar.Unfocus();
            else
            {
                await getCitiesList();
                CitiesListView.ItemsSource = _cities;
            }
        }
        private void Cities_SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            ResetFields(0);
            keyword = Cities_SearchBar.Text;
            searchResult = _cities.Where(cityName => cityName.ToLower().Contains(keyword.ToLower()));
            CitiesListView.ItemsSource = searchResult;

        }
        private void Cities_SearchBar_OnTextChanged(object sender, EventArgs e)
        {
            if (Cities_SearchBar.Text != "")
                CitiesListView.IsVisible = true;
            else
                CitiesListView.IsVisible = false;
            ResetFields(0);
            if (Cities_SearchBar.Text != null)
            {
                keyword = Cities_SearchBar.Text;
                searchResult = _cities.Where(cityName => cityName.ToLower().Contains(keyword.ToLower()));
                CitiesListView.ItemsSource = searchResult;
            }
        }


        private async void Universities_SearchBar_OnFocused(object sender, EventArgs e)
        {
            if (Universities_SearchBar.IsEnabled == false)
                Universities_SearchBar.Unfocus();
            else
            {
                await getUniversitiesList();
                UniversitiesListView.ItemsSource = _universities;
            }

        }
        private void Universities_SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            if (Universities_SearchBar.Text != "")
                UniversitiesListView.IsVisible = true;
            else
                UniversitiesListView.IsVisible = false;
            if (Universities_SearchBar.Text != null)
            {
                keyword = Universities_SearchBar.Text;
                searchResult = _universities.Where(universityName => universityName.ToLower().Contains(keyword.ToLower()));
                UniversitiesListView.ItemsSource = searchResult;
            }

        }
        private void Universities_SearchBar_OnTextChanged(object sender, EventArgs e)
        {
            if (Universities_SearchBar.Text != "")
                UniversitiesListView.IsVisible = true;
            else
                UniversitiesListView.IsVisible = false;
            if (Universities_SearchBar.Text != null)
            {
                keyword = Universities_SearchBar.Text;
                searchResult = _universities.Where(universityName => universityName.ToLower().Contains(keyword.ToLower()));
                UniversitiesListView.ItemsSource = searchResult;
            }

        }


        private void CountiresListView_OnItemSeleceted(object sender, EventArgs e)
        {
            for (int i = 0; i < data.countries.Count; i++)
            {
                if (data.countries[i].title.Contains(CountiresListView.SelectedItem.ToString()))
                {
                    this.countryId = data.countries[i].cid;
                    Countries_SearchBar.Text = data.countries[i].title;
                    user.userCountry = data.countries[i].title;
                    Cities_SearchBar.IsEnabled = true;
                }
            }
            CountiresListView.IsVisible = false;
        }
        private void CitiesListView_OnItemSelected(object sender, EventArgs e)
        {
            for (int i = 0; i < data.countries.Count; i++)
            {
                if (data.countries[i].title.Contains(CitiesListView.SelectedItem.ToString()))
                {
                    this.cityId = data.countries[i].cid;
                    Cities_SearchBar.Text = data.countries[i].title;
                    user.userCity = data.countries[i].title;
                    Universities_SearchBar.IsEnabled = true;
                }
            }
            CitiesListView.IsVisible = false;
        }
        private void UniversitiesListView_OnItemSelected(object sender, EventArgs e)
        {
            for (int i = 0; i < data2.response.items.Count; i++)
            {
                if (data2.response.items[i].title.Contains(UniversitiesListView.SelectedItem.ToString()))
                {
                    this.cityId = data2.response.items[i].id;
                    Universities_SearchBar.Text = data2.response.items[i].title;
                    user.userUniversity = data2.response.items[i].title;
                }
            }
            UniversitiesListView.IsVisible = false;
            if ((FirstName_Entry.Text != null && SecondName_Entry.Text != null) && (FirstName_Entry.Text != "" && SecondName_Entry.Text != ""))
                ApplyButton.IsEnabled = true;
        }

        public async Task<int> getCountriesList()
        {
            this.answer = await httpClient.GetStringAsync("https://api.vk.com/method/database.getCountries?need_all=1&count=300");

            data = JsonConvert.DeserializeObject<Data>(answer);
            for (int i = 0; i < data.countries.Count; i++)
                _countries.Add(data.countries[i].title);
            return 0;
        }
        public async Task<int> getCitiesList()
        {
            query = @"https://api.vk.com/method/database.getCities?country_id=" + countryId + "&count=500&v5.62";
            this.answer = await httpClient.GetStringAsync(query);
            data = JsonConvert.DeserializeObject<Data>(answer);
            for (int i = 0; i < data.countries.Count; i++)
                _cities.Add(data.countries[i].title);
            return 0;
        }
        public async Task<int> getUniversitiesList()
        {
            query = @"https://api.vk.com/method/database.getUniversities?city_id=" + cityId + "&count=50&v=5.62";
            this.answer = await httpClient.GetStringAsync(query);
            data2 = JsonConvert.DeserializeObject<UniversitiesData>(answer);
            for (int i = 0; i < data2.response.items.Count; i++)
                _universities.Add(data2.response.items[i].title);
            return 0;
        }

        public void ResetFields()
        {
            Cities_SearchBar.IsEnabled = false;
            Cities_SearchBar.Text = null;
        }
        public void ResetFields(int i)
        {
            Universities_SearchBar.IsEnabled = false;
            Universities_SearchBar.Text = null;
        }

    }

    class Data
    {
        [JsonProperty("response")]
        public List<Countries> countries { get; set; }
    }

    class UniversitiesData
    {
        public Response response { get; set; }
    }
}

