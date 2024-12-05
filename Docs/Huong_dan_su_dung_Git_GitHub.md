
# Hướng dẫn sử dụng Git và GitHub trên cùng một nhánh

## Mục tiêu:
- Đảm bảo tất cả thành viên trong đội luôn làm việc trên cùng một phiên bản dự án mới nhất.
- Tối ưu hóa quá trình cộng tác và quản lý code.
- Tránh xung đột code và đảm bảo tính toàn vẹn của dự án.

## Công cụ:
- **Git**: Hệ thống quản lý phiên bản phân tán.
- **GitHub**: Nền tảng lưu trữ và quản lý code trên đám mây.

## Quy trình làm việc:

### Người quản lý Project:
1. **Tạo repository trên GitHub:**
   - Đăng nhập vào tài khoản GitHub.
   - Tạo một repository mới và đặt tên phù hợp với dự án.
   - Khởi tạo file `README.md` để mô tả dự án.
   
2. **Clone repository về máy:**
   - Mở terminal/command prompt.
   - Chuyển đến thư mục muốn lưu project.
   - Sử dụng lệnh `git clone <địa chỉ_repository>` để clone repository về máy.
   
3. **Cập nhật code:**
   - Thường xuyên cập nhật code mới lên repository trên GitHub.
   - Sử dụng các lệnh `git add`, `git commit`, `git push` để thực hiện việc này.
   - **Lưu ý**: Chỉ có một nhánh chính (`master/main`) cho toàn bộ dự án.

### Thành viên tham gia:
1. **Clone repository:**
   - Thực hiện tương tự như bước 2 của người quản lý project.

2. **Làm việc:**
   - Mở thư mục project đã clone.
   - Thực hiện các thay đổi cần thiết.

3. **Commit và push:**
   - Sử dụng các lệnh `git add`, `git commit`, `git push` để cập nhật các thay đổi lên repository trên GitHub.

4. **Pull trước khi làm việc:**
   - **Quan trọng**: Trước khi bắt đầu làm việc, luôn luôn thực hiện lệnh `git pull` để đảm bảo code trên máy bạn là mới nhất. Điều này giúp tránh xung đột code.

## Các lệnh Git cần nhớ:
- `git clone <địa chỉ_repository>`: Clone repository từ GitHub về máy.
- `git add <tên_file>`: Thêm file vào staging area.
- `git commit -m "Thông điệp commit"`: Tạo một commit với thông điệp mô tả.
- `git push`: Đẩy các commit lên repository trên GitHub.
- `git pull`: Lấy các thay đổi mới nhất từ repository về máy.
- `git status`: Kiểm tra trạng thái của repository.
- `git log`: Xem lịch sử các commit.

## Lưu ý:
- **Một nhánh duy nhất**: Để đảm bảo tính đơn giản và tránh xung đột, chúng ta chỉ sử dụng một nhánh chính cho toàn bộ dự án.
  
- **Cập nhật thường xuyên**: Mỗi thành viên nên thường xuyên push các thay đổi của mình lên để đảm bảo mọi người luôn làm việc trên cùng một phiên bản.
  
- **Pull trước khi làm việc**: Đây là bước cực kỳ quan trọng để tránh xung đột code.
  
- **Thông điệp commit rõ ràng**: Viết thông điệp commit rõ ràng, ngắn gọn và mô tả chính xác những thay đổi đã thực hiện.
  
- **Sử dụng branch (tùy chọn)**: Nếu cần thực hiện các tính năng mới hoặc thử nghiệm mà không ảnh hưởng đến code chính, có thể sử dụng branch. Tuy nhiên, cần merge branch vào nhánh chính khi hoàn thành.
