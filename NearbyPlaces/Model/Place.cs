using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NearbyPlaces.Model
{
    public class Place
    {
        //Tên địa điểm
        private string _placeName;
        //Khoảng cách đến vị trí hiện tại
        private string _distance;
        //Đường dẫn icon loại địa điểm
        private string _icon;
        //Địa chỉ chi tiết địa điểm
        private string _address;
        //Tất cả ảnh người dùng chia sẻ về địa điểm đó
        private ObservableCollection<string> _listPhoto;
        //Lượt like địa điểm
        private string _likes;
        //Mô tả về địa điểm của mọi người
        private string _discription;
        //Id của địa điểm
        private string _idPlace;
        //Điểm đánh giá địa điểm.
        private string _rate;


        public string Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged("Rate");
            }
        }
        public string IdPlace
        {
            get { return _idPlace; }
            set
            {
                _idPlace = value;
                OnPropertyChanged("IdPlace");
            }
        }
        public ObservableCollection<string> ListPhoto
        {
            get { return _listPhoto; }
            set
            {
                _listPhoto = value;
                OnPropertyChanged("ListPhoto");
            }
        }

        public string Likes
        {
            get { return _likes; }
            set
            {
                _likes = value;
                OnPropertyChanged("Likes");
            }
        }

        public string Discription
        {
            get { return _discription; }
            set
            {
                _discription = value;
                OnPropertyChanged("Discription");
            }
        }

        public string PlaceName
        {
            get { return _placeName; }
            set
            {
                _placeName = value;
                OnPropertyChanged("PlaceName");
            }
        }

        public string Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged("Distance");
            }
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        //Hàm tạo với tham số làm kiểu Item2 (Item2 một kiểu chứa venue get về)
        public Place(Item2 item)
        {
            //Tên địa điểm
            this.PlaceName = item.venue.name;
            //Khoảng cách
            if (item.venue.location.distance>999)
            {
                double x = (double)item.venue.location.distance / 1000;
                x = Math.Round(x, 1);
                this.Distance = x.ToString() + " km";
            }
            else
            {
                this.Distance = item.venue.location.distance.ToString() + " m";
            }
            
            //Địa chỉ chi tiết
            this.Address = item.venue.location.address+ "," + item.venue.location.city + "," + item.venue.location.country;
            //Đường dẫn icon
            string url;
            if (item.venue.categories.Count != 0)
            {
                url = item.venue.categories[0].icon.prefix + "64" + item.venue.categories[0].icon.suffix;
            }
            else
            {
                url = "/Assets/none.png";
            }
            this.Icon = url;
            //Id của venue
            this.IdPlace = item.venue.id;
            
            if (item.tips == null)
            {
                //Lượt like
                this.Likes = "0";
                //Mô tả địa điểm
                this.Discription = "Chưa có mô tả nào!";
            }
            else
            {
                if (item.tips[0].likes==null)
                {
                    //Lượt like
                    this.Likes = "0";
                }
                else
                {
                    //Mô tả địa điểm
                    this.Likes = item.tips[0].likes.count.ToString();
                }
                
                //Mô tả địa điểm.
                this.Discription = item.tips[0].text;
            }           
            //Đánh giá
            this.Rate = item.venue.rating.ToString();
            //
            this.ListPhoto = new ObservableCollection<string>();
        }
        //Update list photo khi click vào detail
        public void UpdatePhoto(string photo)
        {
            //Add đường dẫn photo vào list hiển thị
            this.ListPhoto.Add(photo);
        }
        //
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
