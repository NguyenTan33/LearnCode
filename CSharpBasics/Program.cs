using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpBasics
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            //Bai1();
            //Bai2();
            //Bai3();
            //Bai4();
            //Bai5();
            //bai6();
            //bai7();
            //bai8();
            //bai9();
            //bai10();
            //bai11();
            //bai12();
            //bai13().Wait();
            //Tram1_Dictionary();
            //Tram2_HashSet();
            //Tram3_Stack();
            //Tram4_Queue();
            OnTap_4CauTrucDuLieu();

            Console.ReadLine();
        }

        public static void Bai1()
        {

            string Phone = "iPhone 15 Pro Max";
            decimal Price = 30000000m;
            int Quantity = 25;
            decimal RateSale = 0.1m;
            bool IsAvailable = true;
            decimal AfterSale = Price * (1 - RateSale);
            Console.WriteLine("=== THÔNG TIN SẢN PHẨM ===");
            Console.WriteLine($"Tên máy: {Phone}");
            Console.WriteLine($"Giá niêm yết: {Price:N0} VNĐ"); // In ra: 30,000,000 VNĐ
            Console.WriteLine($"Giảm giá: {RateSale * 100}%");
            Console.WriteLine($"Giá khuyến mãi: {AfterSale:N0} VNĐ");
            Console.WriteLine($"Số lượng còn: {Quantity}");
            Console.WriteLine($"Trạng thái: {(IsAvailable ? "Còn hàng" : "Hết hàng")}");
        }

        public static void Bai2()
        {
            string phoneName = "iPhone 15 Pro Max";
            decimal price = 30000000m;
            int quantity = 25;
            decimal discountRate = 0.1m;
            bool isAvailable = true;
            decimal finalPrice = price * (1 - discountRate);
            decimal totalPrice = 0;

            Console.Write("Nhập số lượng bạn muốn mua: ");
            string input = Console.ReadLine();
            int buyQuantity = int.Parse(input);

            if (buyQuantity <= 0)
            {
                Console.WriteLine("Số lượng mua phải lớn hơn 0.");
                return;
            }

            if (buyQuantity > quantity)
            {
                Console.WriteLine($"Kho chỉ còn {quantity} máy, không đủ bán!");
                return;
            }


            if (buyQuantity < 3 && buyQuantity >= 1)
            {
                totalPrice = price * buyQuantity;
            }
            else
            {
                totalPrice = finalPrice * buyQuantity;
            }

            quantity -= buyQuantity;
            isAvailable = quantity > 0;

            Console.WriteLine("=== THÔNG TIN SẢN PHẨM ===");
            Console.WriteLine($"Tên máy: {phoneName}");
            Console.WriteLine($"Giá niêm yết: {price:N0} VNĐ");
            Console.WriteLine($"Giảm giá: {discountRate * 100}%");
            Console.WriteLine($"Giá khuyến mãi: {totalPrice:N0} VNĐ");
            Console.WriteLine($"Số lượng còn lại: {quantity}");
            Console.WriteLine($"Trạng thái: {(isAvailable ? "Còn hàng" : "Hết hàng")}");

        }

        public static void Bai3()
        {
            string phoneName = "iPhone 15 Pro Max";
            decimal price = 30000000m;
            int quantity = 25;
            decimal discountRate = 0.1m;
            bool isAvailable = true;
            decimal finalPrice = price * (1 - discountRate);
            decimal totalPrice = 0;

        vitrimualai:

            if (!isAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sản phẩm đã hết hàng!");
                Console.ResetColor();
                return;
            }
            int buyQuantity;
            while (true)
            {
                Console.Write("Nhập số lượng bạn muốn mua: ");
                if (int.TryParse(Console.ReadLine(), out buyQuantity) && buyQuantity > 0 && buyQuantity <= quantity)
                {
                    break; // Hợp lệ 100% thì thoát khỏi vòng lặp nhập liệu
                }

                // Nếu xuống được đây nghĩa là nhập sai:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vui lòng nhập số hợp lệ từ 1 đến {quantity}!");
                Console.ResetColor();
            }

            if (buyQuantity < 3 && buyQuantity >= 1)
            {
                totalPrice = price * buyQuantity;
            }
            else
            {
                totalPrice = finalPrice * buyQuantity;
            }

            quantity -= buyQuantity;
            isAvailable = quantity > 0;

            Console.WriteLine("=== THÔNG TIN SẢN PHẨM ===");
            Console.WriteLine($"Tên máy: {phoneName}");
            Console.WriteLine($"Giá niêm yết: {price:N0} VNĐ");
            Console.WriteLine($"Giảm giá: {discountRate * 100}%");
            Console.WriteLine($"Giá khuyến mãi: {totalPrice:N0} VNĐ");
            Console.WriteLine($"Số lượng còn lại: {quantity}");
            Console.WriteLine($"Trạng thái: {(isAvailable ? "Còn hàng" : "Hết hàng")}");

            Console.WriteLine("Bạn có muốn mua tiếp không Y/N ?");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "y":
                    goto vitrimualai;
                case "n":
                    Console.WriteLine("Cảm ơn bạn đã mua hàng!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Kết thúc chương trình.");
                    break;
            }
        }

        public static void Bai4()
        {
            string[] phonesName = new string[5] { "iPhone 15 Pro Max", "Samsung Galaxy Ultra", "Nokia 350", "Xiaomi V1", "OPPO A54" };
            List<decimal> prices = new List<decimal>() { 30000000m, 25000000m, 5000000m, 10000000m, 7000000m };
            int quantity = 25;
            decimal discountRate = 0.1m;
            bool isAvailable = true;
            decimal totalPrice = 0;

            Console.WriteLine("=== DANH SÁCH SẢN PHẨM TRONG KHO ===");
            for (int i = 0; i < phonesName.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {phonesName[i]} - Giá: {prices[i]:N0} VNĐ");
            }
            Console.WriteLine("======================================");

        vitrimualai:
            if (!isAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sản phẩm đã hết hàng!");
                Console.ResetColor();
                return;
            }

            int selectedPhoneIndex = 0;
            int buyQuantity = 0;
            while (true)
            {
                Console.Write("Nhập mã máy (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out selectedPhoneIndex) || selectedPhoneIndex < 1 || selectedPhoneIndex > phonesName.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Vui lòng nhập mã máy hợp lệ từ 1 đến {phonesName.Length}!");
                    Console.ResetColor();
                    continue;
                }

                Console.Write("Nhập số lượng bạn muốn mua: ");
                if (!int.TryParse(Console.ReadLine(), out buyQuantity) || buyQuantity < 1 || buyQuantity > quantity)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Vui lòng nhập số lượng hợp lệ từ 1 đến {quantity}!");
                    Console.ResetColor();
                    continue;
                }
                break;
            }

            if (buyQuantity < 3 && buyQuantity >= 1)
            {
                totalPrice = prices[selectedPhoneIndex - 1] * buyQuantity;
            }
            else
            {
                totalPrice = (prices[selectedPhoneIndex - 1] - (prices[selectedPhoneIndex - 1] * discountRate)) * buyQuantity;
            }

            quantity -= buyQuantity;
            isAvailable = quantity > 0;

            Console.WriteLine("=== THÔNG TIN SẢN PHẨM ===");
            Console.WriteLine($"Tên máy: {phonesName[selectedPhoneIndex - 1]}");
            Console.WriteLine($"Giá niêm yết: {prices[selectedPhoneIndex - 1]:N0} VNĐ");
            Console.WriteLine($"Giảm giá: {discountRate * 100}%");
            Console.WriteLine($"Giá khuyến mãi: {totalPrice:N0} VNĐ");
            Console.WriteLine($"Số lượng còn lại: {quantity}");
            Console.WriteLine($"Trạng thái: {(isAvailable ? "Còn hàng" : "Hết hàng")}");

            Console.WriteLine("Bạn có muốn mua tiếp không Y/N ?");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "y":
                    goto vitrimualai;
                case "n":
                    Console.WriteLine("Cảm ơn bạn đã mua hàng!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Kết thúc chương trình.");
                    break;
            }
        }


        public static void Bai5()
        {
            decimal discountRate = 0.1m;
            bool isShopping = true;

            List<Product> products = new List<Product>
            {
                  new Laptop(2, "Dell XPS 15", 38000000m, 8, 32, "Intel Core i9"),
                  new Accessory(3, "Tai nghe bluetooth", 300000m, 12, "Bảo hành 10 tháng"),
            };

            // VÒNG LẶP CHÍNH MUA SẮM
            while (isShopping)
            {
                Console.WriteLine("\n=== DANH SÁCH SẢN PHẨM TRONG KHO ===");
                foreach (var p in products)
                {
                    p.DisplayInfo();
                }

                // -------------------------------------------------------------
                // BƯỚC 1: CHỌN SẢN PHẨM (Khai báo biến selectedProduct ở ngoài để dùng chung)
                // -------------------------------------------------------------
                Product selectedProduct = null;
                while (true)
                {
                    Console.Write("\nNhập mã máy bạn muốn mua: ");
                    if (int.TryParse(Console.ReadLine(), out int inputId))
                    {
                        // Tìm sản phẩm trong danh sách
                        foreach (var p in products)
                        {
                            if (p.Id == inputId)
                            {
                                selectedProduct = p;
                                break; // Tìm thấy rồi thì dừng tìm kiếm
                            }
                        }

                        if (selectedProduct != null)
                        {
                            // Kiểm tra xem máy có còn hàng không
                            if (selectedProduct.Quantity <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Máy này hiện đã hết hàng, vui lòng chọn máy khác!");
                                Console.ResetColor();
                                selectedProduct = null; // Reset lại để chọn lại máy khác
                                continue;
                            }
                            break; // Chọn máy thành công -> Thoát bước 1
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mã sản phẩm không tồn tại, vui lòng nhập lại!");
                    Console.ResetColor();
                }

                // -------------------------------------------------------------
                // BƯỚC 2: NHẬP SỐ LƯỢNG MUỐN MUA
                // -------------------------------------------------------------
                int buyQuantity = 0;
                while (true)
                {
                    Console.Write($"Nhập số lượng muốn mua (Tối đa {selectedProduct.Quantity}): ");
                    if (int.TryParse(Console.ReadLine(), out buyQuantity) && buyQuantity > 0 && buyQuantity <= selectedProduct.Quantity)
                    {
                        break; // Nhập số lượng hợp lệ -> Thoát bước 2
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Số lượng không hợp lệ! Vui lòng nhập từ 1 đến {selectedProduct.Quantity}");
                    Console.ResetColor();
                }

                // -------------------------------------------------------------
                // BƯỚC 3: TRỪ KHO BẰNG PHƯƠNG THỨC ĐÓNG GÓI & TÍNH TIỀN
                // -------------------------------------------------------------
                selectedProduct.ReduceQuantity(buyQuantity);

                decimal totalPrice = (buyQuantity >= 3)
                    ? (selectedProduct.Price * (1 - discountRate)) * buyQuantity
                    : selectedProduct.Price * buyQuantity;

                // -------------------------------------------------------------
                // BƯỚC 4: IN HÓA ĐƠN
                // -------------------------------------------------------------
                Console.WriteLine("\n=== HÓA ĐƠN MUA HÀNG ===");
                Console.WriteLine($"Tên máy: {selectedProduct.Name}");
                Console.WriteLine($"Giá niêm yết: {selectedProduct.Price:N0} VNĐ");
                Console.WriteLine($"Số lượng mua: {buyQuantity} cái");
                Console.WriteLine($"Giảm giá: {(buyQuantity >= 3 ? "10%" : "0%")}");
                Console.WriteLine($"Tổng tiền phải trả: {totalPrice:N0} VNĐ");
                Console.WriteLine($"Số lượng còn lại trong kho: {selectedProduct.Quantity}");

                // -------------------------------------------------------------
                // BƯỚC 5: HỎI MUA TIẾP
                // -------------------------------------------------------------
                Console.Write("\nBạn có muốn mua tiếp không? (Y/N): ");
                string answer = Console.ReadLine()?.Trim().ToLower();

                if (answer != "y")
                {
                    Console.WriteLine("Cảm ơn bạn đã mua hàng tại cửa hàng. Hẹn gặp lại!");
                    isShopping = false; // Thoát vòng lặp chính
                }

            }
        }

        public static void bai6()
        {
            List<Product> products = new List<Product>()
            {
                  new Laptop(3, "Dell XPS 15", 38000000m, 8, 32, "Intel Core i9"),
                  new Accessory(1, "Tai nghe bluetooth", 300000m, 12, "Bảo hành 10 tháng"),
            };

            foreach (Product product in products)
            {
                product.DisplayInfo();
                if (product is Laptop laptop)
                {
                    Console.WriteLine($"RAM: {laptop.RamGB} GB, CPU: {laptop.Cpu}");
                }
                else if (product is Accessory accessory)
                {
                    Console.WriteLine($"Bảo hành: {accessory.Warranty}");
                }
            }
        }

        public static void bai7()
        {
            List<Product> products = new List<Product>()
            {
                  new Laptop(2, "Dell XPS 15", 38000000m, 8, 32, "Intel Core i9"),
                  new Accessory(3, "Tai nghe bluetooth", 300000m, 12, "Bảo hành 10 tháng"),
            };

            foreach (Product product in products)
            {
                product.DisplayInfo();
            }
        }

        public static void bai8()
        {
            List<Product> products = new List<Product>()
            {

                new Laptop(2, "MacBook Pro M3", 45000000m, 5, 16, "M3 Pro"),
                new Accessory(3, "Ốp lưng silicon", 150000m, 50, "Không bảo hành")
            };

            List<IRechargeable> chargingStation = new List<IRechargeable>();

            foreach (Product p in products)
            {
                if (p is IRechargeable device)
                {
                    chargingStation.Add(device);
                }
            }

            Console.WriteLine("=== THIẾT BỊ CẦN SẠC ===");
            foreach (IRechargeable chargingstation in chargingStation)
            {
                chargingstation.Charge();
            }
        }

        public static void bai9()
        {
            List<Product> products = new List<Product>()
            {
                new Phone(1, "iPhone 15 Pro Max", 30000000m, 10, 4422),
                new Laptop(2, "MacBook Pro M3", 45000000m, 5, 16, "M3 Pro"),
                new Accessory(3, "Tai nghe Bluetooth", 500000m, 20, "12 tháng"),
                new Phone(4, "Xiaomi Redmi Note 13", 4500000m, 15, 5000),
                new Laptop(5, "Asus TUF Gaming", 22000000m, 0, 16, "Ryzen 7"), // Hết hàng
                new Accessory(6, "Củ sạc 65W", 600000m, 0, "6 tháng") // Hết hàng
            };

            var hetHangProducts = products.Where(p => p.Quantity == 0).ToList();

            var conHangProducts = products.Where(p => p.Quantity > 0 && p.Price > 10000000m).ToList();

            var conhangxapxeptangdan = products.Where(p => p.Quantity > 0).OrderBy(p => p.Price).ToList();
            foreach (var product in conhangxapxeptangdan)
            {
                product.DisplayInfo();
            }
        }

        public static void bai10()
        {
            List<Product> products = new List<Product>()
            {
                new Phone(1, "iPhone 15 Pro Max", 30000000m, 10, 4422),
                new Laptop(2, "MacBook Pro M3", 45000000m, 5, 16, "M3 Pro"),
                new Accessory(3, "Tai nghe Bluetooth", 500000m, 20, "12 tháng"),
                new Phone(4, "Xiaomi Redmi Note 13", 4500000m, 15, 5000),
                new Laptop(5, "Asus TUF Gaming", 22000000m, 0, 16, "Ryzen 7"), // Hết hàng
                new Accessory(6, "Củ sạc 65W", 600000m, 0, "6 tháng") // Hết hàng
            };

            var nameProducts = products.Where(p => p.Quantity > 0).Select(p => p.Name).ToList();

            foreach (var name in nameProducts)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Nhập ID sản phẩm cần tìm kiếm: ");
            int searchId = int.Parse(Console.ReadLine());
            var searchProducts = products.FirstOrDefault(p => p.Id == searchId);

            if (searchProducts != null)
            {
                searchProducts.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm với ID đã nhập.");
            }

            var searchProductsByQuantity = products.Any(p => p.Quantity == 0);

            if (searchProductsByQuantity)
            {
                Console.WriteLine("Có sản phẩm đã hết hàng.");
            }
            else
            {
                Console.WriteLine("Tất cả sản phẩm đều còn hàng.");
            }

            var totalValue = products.Sum(p => p.Price * p.Quantity);

            Console.WriteLine($"Tổng giá trị tồn kho: {totalValue:N0} VNĐ");
        }

        public static void bai11()
        {
            int Id;

            List<Product> products = new List<Product>()
            {
                new Phone(101, "iPhone 15 Pro Max", 30000000m, 10, 4422),
                new Laptop(102, "MacBook Pro M3", 45000000m, 5, 16, "M3 Pro"),
                new Accessory(103, "Tai nghe Bluetooth", 500000m, 20, "12 tháng"),
                new Phone(104, "Xiaomi Redmi Note 13", 4500000m, 15, 5000),
                new Laptop(105, "Asus TUF Gaming", 22000000m, 8, 16, "Ryzen 7"),
                new Accessory(106, "Củ sạc 65W", 600000m, 30, "6 tháng")
            };

            Dictionary<int, Product> productDict = products.ToDictionary(p => p.Id);

            foreach (var product in productDict.Keys)
            {
                Console.Write($"{product} ");
            }

            Console.WriteLine("\nNhập ID sản phẩm cần tìm kiếm: ");
            while (!int.TryParse(Console.ReadLine(), out Id) || Id < 0)
            {
                Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ lớn hơn hoặc bằng 0.");
            }

            if (productDict.TryGetValue(Id, out Product foundProduct))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[TÌM THẤY TỨC THÌ TRONG 0.000001 GIÂY]:");
                Console.ResetColor();
                foundProduct.DisplayInfo();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nKhông tìm thấy sản phẩm nào có ID = {Id} trong từ điển!");
                Console.ResetColor();
            }
        }

        public static void bai12()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== 1. THỬ NGHIỆM HASHSET (CHỐNG TRÙNG LẶP & BLACKLIST) ===");
            Console.ResetColor();

            List<string> rawEmails = new List<string>()
            {
                "tuan@gmail.com",
                "lan@yahoo.com",
                "tuan@gmail.com", // Trùng
                "spam_bot@darkweb.com",
                "tuan@gmail.com"
            };


            HashSet<string> cleanEmails = new HashSet<string>(rawEmails);

            Console.WriteLine($"Số email thô ban đầu: {rawEmails.Count}");
            Console.WriteLine($"Số email sạch sau khi lọc bằng HashSet: {cleanEmails.Count}");


            HashSet<string> blacklist = new HashSet<string>() { "spam_bot@darkweb.com", "hacker@evil.com" };

            string checkEmail = "spam_bot@darkweb.com";
            if (blacklist.Contains(checkEmail)) // Kiểm tra tốc độ O(1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[CẢNH BÁO]: Email '{checkEmail}' nằm trong Blacklist, cấm nhận quà!");
                Console.ResetColor();
            }



            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 2. THỬ NGHIỆM QUEUE (XỬ LÝ ĐƠN HÀNG TUẦN TỰ) ===");
            Console.ResetColor();

            Queue<string> orderQueue = new Queue<string>();


            orderQueue.Enqueue("Đơn #1: iPhone 15 của Anh Tuấn");
            orderQueue.Enqueue("Đơn #2: MacBook Pro của Chị Lan");
            orderQueue.Enqueue("Đơn #3: Tai nghe Sony của Em Nam");

            while (orderQueue.Count > 0)
            {
                string currentOrder = orderQueue.Dequeue(); // Lấy người đầu hàng ra
                Console.WriteLine($"-> Đang đóng gói và gửi đi: {currentOrder}");
            }



            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 3. THỬ NGHIỆM STACK (TÍNH NĂNG HOÀN TÁC CTRL + Z) ===");
            Console.ResetColor();

            Stack<string> historyActions = new Stack<string>();


            historyActions.Push("Bước 1: Mở ứng dụng");
            historyActions.Push("Bước 2: Gõ chữ 'Xin chào'");
            historyActions.Push("Bước 3: Lỡ tay bấm nhầm nút 'Xóa bài viết'"); // Hành động mới nhất nằm trên đỉnh ống!


            string undoneAction1 = historyActions.Pop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[CTRL + Z LẦN 1]: Đã hoàn tác -> '{undoneAction1}'");
            Console.ResetColor();

            // Bấm Ctrl + Z lần 2: Nhấc tiếp hành động trước đó ra:
            string undoneAction2 = historyActions.Pop();
            Console.WriteLine($"[CTRL + Z LẦN 2]: Đã hoàn tác -> '{undoneAction2}'");
        }

        public static async Task bai13()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== BẮT ĐẦU HỆ THỐNG TỰ ĐỘNG HÓA ĐƠN HÀNG (BẤM PHÍM BẤT KỲ ĐỂ DỪNG) ===");
            Console.ResetColor();

            Queue<string> orderQueue = new Queue<string>();
            bool isRunning = true;
            int orderId = 1;

            Task producer = Task.Run(async () =>
            {
                while (isRunning)
                {
                    await Task.Delay(1000);
                    string newOrder = $"Đơn hàng #{orderId++} lúc {DateTime.Now:HH:mm:ss}";


                    lock (orderQueue)
                    {
                        orderQueue.Enqueue(newOrder);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[+ KHÁCH ĐẶT]: {newOrder} (Hiện còn {orderQueue.Count} đơn chờ)");
                    Console.ResetColor();
                }
            });


            Task consumer = Task.Run(async () =>
            {
                while (isRunning)
                {
                    await Task.Delay(1500);

                    string processingOrder = null;
                    lock (orderQueue)
                    {
                        if (orderQueue.Count > 0)
                        {
                            processingOrder = orderQueue.Dequeue();
                        }
                    }

                    if (processingOrder != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"   [-> SHIPPER GIAO]: {processingOrder}");
                        Console.ResetColor();
                    }
                }
            });

            Console.ReadKey();
            isRunning = false;
            Console.WriteLine("\n[HỆ THỐNG ĐÃ DỪNG LẠI]");
        }

        public static void Tram1_Dictionary()
        {
            string text = "apple banana apple orange banana apple kiwi orange apple";

            string[] words = text.Split(' ');

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            Console.WriteLine("=== SỐ LẦN XUẤT HIỆN CỦA TỪ ===");
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            foreach (var kvp in wordCount)
            {
                Console.WriteLine($"{kvp.Key}    : xuất hiện {kvp.Value} lần.");
            }
        }


        public static void Tram2_HashSet()
        {
            int[] transactions = { 101, 105, 103, 102, 105, 108, 101 };

            HashSet<int> uniqueTransactions = new HashSet<int>();

            foreach (int id in transactions)
            {
                if (!uniqueTransactions.Add(id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[CẢNH BÁO]: Giao dịch trùng lặp ID = {id} đã bị bỏ qua!");
                    Console.ResetColor();
                    break;
                }
            }

            List<string> khachThang9 = new List<string>() { "0901", "0902", "0903", "0904" };
            List<string> khachThang10 = new List<string>() { "0903", "0905", "0901", "0906" };

            HashSet<string> khachThang9Set = new HashSet<string>(khachThang9);

            khachThang9Set.IntersectWith(khachThang10);

            foreach (string khach in khachThang9Set)
            {
                Console.WriteLine($"Khách hàng {khach} đã mua hàng cả tháng 9 và tháng 10.");
            }
        }

        public static void Tram3_Stack()
        {
            Console.WriteLine("Nhập một chuỗi chứa các dấu ngoặc: ");
            string input = Console.ReadLine();
            if (IsValid(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chuỗi hợp lệ: Các dấu ngoặc được đóng mở đúng cách.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chuỗi không hợp lệ: Các dấu ngoặc không được đóng mở đúng cách.");
                Console.ResetColor();
            }
        }

        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                        return false;
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        public static void Tram4_Queue()
        {
            int crurntTicketNumber = 1;
            int choice = 0;
            bool isRunning = true;

            Queue<int> ticketQueue = new Queue<int>();

            while (isRunning)
            {
                Console.WriteLine("=== HỆ THỐNG BỐC SỐ BỆNH VIỆN ===");
                Console.WriteLine("1. [Bệnh nhân] Bấm lấy số thứ tự");
                Console.WriteLine("2. [Bác sĩ] Bấm gọi bệnh nhân tiếp theo vào khám");
                Console.WriteLine("3. [Y tá] Xem số lượng người đang chờ & ai là người kế tiếp");
                Console.WriteLine("0. Kết thúc ca trực");
                Console.Write("Chọn chức năng:");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chọn sai vui lòng chọn chức năng từ số 0 - > 3");
                    Console.ResetColor();
                }
                switch (choice)
                {
                    case 1:
                        ticketQueue.Enqueue(crurntTicketNumber);
                        crurntTicketNumber++;
                        break;
                    case 2:
                        if (ticketQueue.Count <= 0)
                        {
                            Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                        }
                        else
                        {
                            Console.WriteLine($"Xin mời khách hàng tiếp theo là số: {ticketQueue.Dequeue()}");
                        }
                        break;
                    case 3:
                        if (ticketQueue.Count <= 0)
                        {
                            Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                        }
                        else
                        {
                            Console.WriteLine($"Khách hàng tiếp theo là số: {ticketQueue.Peek()}");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc ca trực.");
                        isRunning = false;
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại từ 0 -> 3.");
                        break;
                }
                Console.WriteLine($"\n\n\n\n");

            }

        }

        public static void OnTap_4CauTrucDuLieu()
        {
            bool isRunning = true;
            List<string> customersName = new List<string>() { "Anh Tuấn", "Chị Lan", "Em Nam", "Cô Mai" };
            List<string> Rank = new List<string>() { "VIP", "STANDARD", "ECONOMY", "COUPLE" };
            List<decimal> ticketPrices = new List<decimal>() { 500_000m, 150_000m, 200_000m, 350_000m };
            Queue<string> ticketQueue = new Queue<string>();
            Stack<string> paymentHistory = new Stack<string>();
            HashSet<string> scannedTickets = new HashSet<string>();
            List<string> ticketCode = new List<string> { "TICKET12345", "TICKET123456", "TICKET889", "TICKET555" };

            VanHanh vanHanh = new VanHanh();

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== HỆ THỐNG RẠP CHIẾU PHIM =====");
                Console.ResetColor();
                Console.WriteLine("1. Thêm khách hàng vào hàng đợi");
                Console.WriteLine("2. Gọi khách hàng tiếp theo");
                Console.WriteLine("3. Hiển thị danh sách khách hàng đang chờ");
                Console.WriteLine("4. Hiển thị số lượng khách hàng đang chờ");
                Console.WriteLine("5. Hiển thị khách hàng tiếp theo");
                Console.WriteLine("6. Hiển thị thông tin giá vé theo hạng");
                Console.WriteLine("7. Hoàn tiền cho khách hàng");
                Console.WriteLine("8. Soát vé cho khách hàng");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0. Thoát chương trình");
                Console.ResetColor();
                Console.Write("Chọn chức năng: ");
                int choice;

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chọn sai vui lòng chọn chức năng từ số 0 - > 8");
                    Console.ResetColor();
                }

                switch (choice)
                {
                    case 1:
                        vanHanh.ThemKhach(customersName, ticketQueue);
                        break;
                    case 2:
                        string nameCustomerNext = vanHanh.GoiKhach(ticketQueue);
                        if (nameCustomerNext != null)
                        {
                            vanHanh.HistoryActions(paymentHistory, nameCustomerNext);
                        }
                        break;
                    case 3:
                        vanHanh.HienThiDanhSachKhach(ticketQueue);
                        break;
                    case 4:
                        vanHanh.HienThiSoLuongKhach(ticketQueue);
                        break;
                    case 5:
                        vanHanh.HienThiKhachTiepTheo(ticketQueue);
                        break;
                    case 6:
                        vanHanh.DisplayTicketInfo(Rank, ticketPrices);
                        break;
                    case 7:
                        vanHanh.HoanTien(paymentHistory);
                        break;
                    case 8:
                        Console.Write("Nhập mã vé cần soát: ");
                        string inputTicketCode = Console.ReadLine();
                        if (vanHanh.XemVeCoTonTai(ticketCode, inputTicketCode))
                        {
                            vanHanh.SoatVe(scannedTickets, inputTicketCode);
                        }
                        else
                        {
                            Console.WriteLine($"Vé {inputTicketCode} không tồn tại trong danh sách.");
                        }    
                        break;
                    case 0:
                        Console.WriteLine("Thoát chương trình.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại từ 0 -> 8.");
                        break;
                }

                Console.WriteLine($"\n\n");
                Thread.Sleep(1000);
            }


        }
    }
    public class VanHanh
    {

        public void ThemKhach(List<string> customersName, Queue<string> ticketQueue)
        {

            foreach (string name in customersName)
            {
                ticketQueue.Enqueue(name);
            }

        }

        public string GoiKhach(Queue<string> ticketQueue)
        {
            if (ticketQueue.Count > 0)
            {
                string nextCustomer = ticketQueue.Dequeue();
                Console.WriteLine($"Xin mời khách hàng tiếp theo là: {nextCustomer}");
                return nextCustomer;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                Console.ResetColor();
                return null;
            }
        }

        public void HienThiDanhSachKhach(Queue<string> ticketQueue)
        {
            if (ticketQueue.Count > 0)
            {
                Console.WriteLine("=== DANH SÁCH KHÁCH HÀNG ĐANG CHỜ ===");
                foreach (string customer in ticketQueue)
                {
                    Console.WriteLine($"- {customer}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                Console.ResetColor();
            }
        }
        public void HienThiSoLuongKhach(Queue<string> ticketQueue)
        {
            Console.WriteLine($"Hiện tại có {ticketQueue.Count} khách hàng đang chờ.");
        }

        public void HienThiKhachTiepTheo(Queue<string> ticketQueue)
        {
            if (ticketQueue.Count > 0)
            {
                Console.WriteLine($"Khách hàng tiếp theo là: {ticketQueue.Peek()}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                Console.ResetColor();
            }
        }

        public void DisplayTicketInfo(List<string> Rank, List<decimal> ticketPrices)
        {
            Dictionary<string, decimal> boardticketPrice = new Dictionary<string, decimal>();

            for (int i = 0; i < Rank.Count; i++)
            {
                boardticketPrice[Rank[i]] = ticketPrices[i];
            }

            Console.WriteLine("=== DANH SÁCH GIÁ VÉ THEO HẠNG ===");
            foreach (var kvp in boardticketPrice)
            {
                Console.WriteLine($"Hạng: {kvp.Key} - Giá vé: {kvp.Value:N0} VNĐ");
            }
        }

        public void HistoryActions(Stack<string> paymentHistory, string nameCustomerNext)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            paymentHistory.Push($"Khách hàng {nameCustomerNext} đã mua vé");
            Console.ResetColor();
        }

        public void HoanTien(Stack<string> paymentHistory)
        {
            if (paymentHistory.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Không có giao dịch nào để hoàn tiền.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hoàn tiền thành công cho {paymentHistory.Pop()}.");
            Console.ResetColor();
        }

        public void SoatVe(HashSet<string> scannedTickets, string ticketCode)
        {
            if (scannedTickets.Contains(ticketCode))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vé {ticketCode} đã được quét trước đó. Không hợp lệ.");
                Console.ResetColor();
            }
            else
            {
                scannedTickets.Add(ticketCode);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vé {ticketCode} hợp lệ. Chúc quý khách xem phim vui vẻ!");
                Console.ResetColor();
            }
        }

        public bool XemVeCoTonTai(List<string> codeTicket, string scanCode)
        {
            return codeTicket.Contains(scanCode);
        }
    }
}
