using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NearbyPlaces.Model;
using Newtonsoft.Json;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace NearbyPlaces.ViewModel
{
    public class NearbyVM
    {
        //List địa điểm xung quanh mình
        private ObservableCollection<Place> _listPlaces;
        public ObservableCollection<Place> ListPlaces
        {
            get { return _listPlaces; }
            set
            {
                _listPlaces = value;
                OnPropertyChanged("ListPlaces");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public NearbyVM()
        {
            ListPlaces = new ObservableCollection<Place>();
            //Lấy địa điểm xung quanh cho vào list
            getNearbyPlaces();

        }

        //Lấy tọa độ GPS
        //Yêu cầu: bật GPS
        private async Task<Geoposition> getCoordinates()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                return await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5), timeout: TimeSpan.FromSeconds(10));
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Chưa mở GPS. Vui lòng bật GPS trước khi vào ứng dụng.");
                await dialog.ShowAsync();
                return null;
            }
        }
        //Lấy tất cả địa điểm xung quanh cho vào list
        private async void getNearbyPlaces()
        {
            Geoposition pos = await getCoordinates();
            if (pos==null)
            {
                return;
            }
            try
            {
                // Setup biến client
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = await client.GetAsync(new Uri("https://api.foursquare.com/v2/venues/explore?ll=" + pos.Coordinate.Latitude +","+ pos.Coordinate.Longitude + "&oauth_token=BFOWNUPCIQQWAAPPTQXGRO5DY3MEFVZSR4YXJP0YAPU0GKL4&v=20160228"));
                if (response.IsSuccessStatusCode)
                {
                    //Text đọc từ json
                    string str = await response.Content.ReadAsStringAsync();
                    //Map json vào class
                    RootObject nearbyVenues = JsonConvert.DeserializeObject<RootObject>(str);
                    //
                    foreach (var item in nearbyVenues.response.groups[0].items)
                    {
                        ////Add list
                        ListPlaces.Add(new Place(item));
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Lỗi ứng dụng. Vui lòng khởi động lại ứng dụng.");
                await dialog.ShowAsync();
            }
        }
    }
}
