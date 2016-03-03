
* Mô tả ứng dụng: ứng dụng được thiết kế dạng tab gồm 2 page: Nearby và Detail.
	- Page Nearby: liệt kê các vị trị xung quanh. Hiển thị trên list là tên các địa điểm xung quanh mình, icon của loại địa điểm và khoảng cách từ mình đến địa điểm đó, để giúp người dùng có thể chọn được địa điểm thích hợp nhất. Thông tin về các vị trí xung quanh được lấy về từ API của Foursquare. 
	- Page Detail: thông tin chi tiết của các vị trí xung quanh, bao gồm các thông tin sau: 
		+ Tên địa điểm:
		+ Địa chỉ: địa chỉ chi tiết.
		+ Mô tả: nhận xét người dùng. 
		+ Likes: số lượng like.
		+ Rating: điểm đánh giá của người dùng.
		+ Photos: danh sách các ảnh được người dùng chia sẻ từ địa điểm đó.	

* Các xử lý tối ưu:
	- Về UI: Ứng dụng có thể chạy trên nhiều thiết bị có kích thước khác nhau mà không bị bở giao diện. 
	- Về UX: Ứng dụng có sự phối hợp màu sắc để làm nổi bật các thông tin chính.
	- Về mô hình: sử dụng mô hình MVVM.
	- Về sử lý: try catch những lỗi có thể xảy ra và hiển thị chỉ dẫn gần nhất với người sử dụng.
	- Về API: sử dụng cơ chế Access token đã đăng kí ở trang chủ.
	
* Hướng dẫn sử dụng: 
	- Page Nearby: 
		+ Click vào item chuyển sang page Detail.
		+ Click vào Refresh load lại trang Nearby.
	- Page Detail:
		+ Xem thông tin chi tiết. 
		+ Xem list photo bằng cách lướt ngang list đó. 


