using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
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
            bai10();
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

            var conHangProducts = products.Where(p => p.Quantity > 0 && p.Price >10000000m).ToList();

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
            var hetHangProducts = products.Where(p => p.Quantity == 0).ToList();
            var conHangProducts = products.Where(p => p.Quantity > 0 && p.Price >10000000m).ToList();
            var conhangxapxeptangdan = products.Where(p => p.Quantity > 0).OrderBy(p => p.Price).ToList();
            foreach (var product in conhangxapxeptangdan)
            {
                product.DisplayInfo();
            }
        }
    }
}
