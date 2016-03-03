using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NearbyPlaces.Model;
using Newtonsoft.Json;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NearbyPlaces.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Detail : Page
    {
        public Detail()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                //lấy tham số từ page trước
                Place place = (e.Parameter as Place);
                //Setup biến client
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //
                HttpResponseMessage response = await client.GetAsync(new Uri("https://api.foursquare.com/v2/venues/" + place.IdPlace + "/photos?oauth_token=BFOWNUPCIQQWAAPPTQXGRO5DY3MEFVZSR4YXJP0YAPU0GKL4&v=20160228"));
                if (response.IsSuccessStatusCode)
                {
                    // //Text đọc từ json
                    string str = await response.Content.ReadAsStringAsync();
                    ////Map json vào class
                    RootObjectPhoto photoOfVenues = JsonConvert.DeserializeObject<RootObjectPhoto>(str);
                    //Lấy từng photo ra update vào địa điểm
                    foreach (var photo in photoOfVenues.response.photos.items)
                    {
                        place.UpdatePhoto(photo.prefix + photo.width + "x" + photo.height + photo.suffix);
                    }
                }         
                //
                this.DataContext = place;
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.ToString());
                await dialog.ShowAsync();
            }
        }
    }
}
