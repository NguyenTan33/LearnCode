# 📌 BẢN TÓM TẮT CỨU SINH (CHEATSHEET) - ÔN TẬP NHANH 5 PHÚT MỖI NGÀY

---

## 🏛️ I. 4 TRỤ CỘT OOP (HƯỚNG ĐỐI TƯỢNG)

| Trụ Cột | Câu thần chú nhớ nhanh | Từ khóa C# | Ví dụ đời thực |
| :--- | :--- | :--- | :--- |
| **1. Đóng gói** *(Encapsulation)* | Bảo vệ dữ liệu nội bộ, cấm sửa bậy | `private`, `{ get; private set; }` | Nắp bình xăng xe máy, số dư tài khoản ngân hàng. |
| **2. Kế thừa** *(Inheritance)* | Cha truyền con nối, tái sử dụng code (IS-A) | `:`, `base(...)` | `Laptop` và `Phone` kế thừa từ `Product`. |
| **3. Đa hình** *(Polymorphism)* | 1 mệnh lệnh, mỗi con tự xử lý khác nhau | `virtual` (Cha), `override` (Con) | Nút bật nguồn: Bật Tivi thì sáng màn hình, bật Quạt thì quạt quay. |
| **4. Trừu tượng** *(Abstraction)* | Che giấu quy trình bên trong, tạo hợp đồng | `abstract class`, `interface` | Vô lăng ô tô, củ sạc Type-C (`IRechargeable`). |

---

## ⚡ II. VŨ KHÍ LINQ THẦN TỐC (THAY THẾ VÒNG LẶP)

```csharp
// 1. LỌC: Lấy sản phẩm còn hàng
var available = products.Where(p => p.Quantity > 0).ToList();

// 2. BIẾN ĐỔI: Chỉ lấy danh sách Tên sản phẩm
List<string> names = products.Select(p => p.Name).ToList();

// 3. SẮP XẾP: Giá tăng dần (.OrderBy) hoặc giảm dần (.OrderByDescending)
var sorted = products.OrderBy(p => p.Price).ToList();

// 4. TÌM KIẾM AN TOÀN: Tìm 1 món, không thấy trả về null (không sập app)
var found = products.FirstOrDefault(p => p.Id == 101);

// 5. THỐNG KÊ: Tính tổng tiền kho hàng
decimal totalValue = products.Sum(p => p.Price * p.Quantity);
```

---

## 📦 III. 4 CẤU TRÚC DỮ LIỆU CỐT LÕI (BỘ ĐỒ NGHỀ THỰC CHIẾN)

### 1. `Dictionary<TKey, TValue>` (Bảng băm tra cứu O(1))
* **Hình ảnh**: Tủ gửi đồ có đánh số ô tủ (Key) và đồ vật bên trong (Value).
* **Cú pháp vàng**:
  ```csharp
  Dictionary<int, Product> dict = products.ToDictionary(p => p.Id);
  if (dict.TryGetValue(id, out Product item)) { /* tìm thấy trong O(1) */ }
  ```

### 2. `HashSet<T>` (Tập hợp duy nhất - Chống trùng lặp O(1))
* **Hình ảnh**: Máy quét CCCD bỏ phiếu / Thùng phiếu chống gian lận.
* **Cú pháp vàng**:
  ```csharp
  HashSet<string> set = new HashSet<string>();
  if (!set.Add(email)) { /* Trùng lặp, bắt quả tang ngay! */ }
  bool exists = set.Contains(email); // Tốc độ O(1)
  set.IntersectWith(otherList);      // Lấy phần chung (Giao)
  set.UnionWith(otherList);          // Gộp danh sách lọc trùng (Hợp)
  set.ExceptWith(otherList);         // Loại trừ (Hiệu)
  ```

### 3. `Queue<T>` (Hàng đợi FIFO - Vào trước ra trước)
* **Hình ảnh**: Xếp hàng mua vé xem phim / Bốc số bệnh viện / Máy in.
* **Cú pháp vàng**:
  ```csharp
  Queue<string> queue = new Queue<string>();
  queue.Enqueue("Khách 1");             // Xếp vào cuối hàng
  string next = queue.Dequeue();        // Lấy người đầu hàng ra phục vụ
  string peek = queue.Peek();           // Dòm người đầu hàng mà không lấy ra
  if (queue.TryDequeue(out var item))   // Lấy ra an toàn 100% không sợ rỗng
  ```

### 4. `Stack<T>` (Ngăn xếp LIFO - Vào sau cùng ra đầu tiên)
* **Hình ảnh**: Ống đựng cầu lông / Chồng đĩa rửa chén / Nút Undo Ctrl+Z.
* **Cú pháp vàng**:
  ```csharp
  Stack<string> stack = new Stack<string>();
  stack.Push("Hành động mới");         // Nhét lên đỉnh ống
  string last = stack.Pop();           // Nhấc món trên đỉnh ra (Undo)
  string top = stack.Peek();           // Dòm đỉnh ống
  if (stack.TryPop(out var item))      // Lấy ra an toàn không sợ rỗng
  ```

---
*Mỗi sáng mở file này đọc lướt 3 phút trước khi gõ code, não bạn sẽ tự động ghim vào bộ nhớ dài hạn suốt đời!*
