/*
 * Sử dụng Generic List để quản lý nhân sự với đầy đủ
 * Tính năng CRUD
 * C->CREATE --> Tạo mới dữ liệu
 * R->Read/Retrieve ->Xem, lọc, tìm kiếm, sắp xếp, thống kê...
 * U->Update --> sửa dữ liệu
 * D->DELETE--> xóa dữ liệu
 */
//Câu 1: Tạo 5 nhân viên, 3 nhân viên chính thức, 2 thời vụ
//lưu vào Generic List:
using OOP2;
using System.Text;

List<Employee> employees = new List<Employee>();
FulltimeEmployee fe1 = new FulltimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Name 1",
    Birthday = new DateTime(1990, 1, 1),
};
employees.Add(fe1);
FulltimeEmployee fe2 = new FulltimeEmployee()
{
    Id = 2,
    IdCard = "456",
    Name = "Name 2",
    Birthday = new DateTime(1992, 11, 12),
};
employees.Add(fe2);
FulltimeEmployee fe3 = new FulltimeEmployee()
 {
     Id = 3,
     IdCard = "789",
     Name = "Name 3",
     Birthday = new DateTime(1980, 12, 27),
 };
employees.Add(fe3);
ParttimeEmployee pe1 = new ParttimeEmployee()
{
    Id = 4,
    IdCard = "234",
    Name = "Name 4",
    Birthday = new DateTime(1973, 12, 15),
    WorkingHour=2
};
employees.Add(pe1);
ParttimeEmployee pe2 = new ParttimeEmployee()
{
    Id = 5,
    IdCard = "987",
    Name = "Name 5",
    Birthday = new DateTime(1974, 1, 16),
    WorkingHour=3
};
employees.Add(pe2);
Console.OutputEncoding=Encoding.UTF8;
//Câu 2: R->Xuất toàn bộ nhân sự:
Console.WriteLine("Câu 2: R->Xuất toàn bộ nhân sự:");
//cách 1:
employees.ForEach(e =>Console.WriteLine(e));

//Câu 3: R-> Lọc ra các nhân sự là chính thức
//cách 1: 
List<FulltimeEmployee> fe_list = 
                employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("Câu 3: R-> Lọc ra các nhân sự là chính thức:");
foreach(FulltimeEmployee fe in fe_list)
    Console.WriteLine(fe);

//Câu 4: Tổng lương nhân chính thức:
double fe_sum_salary = fe_list.Sum(e => e.calSalary());
Console.WriteLine("Câu 4: Tổng lương nhân chính thức:");
Console.WriteLine(fe_sum_salary);
//Câu 5: Tổng lương nhân viên thời vụ:
double pe_sum_salary=employees.OfType<ParttimeEmployee>()
                              .Sum(e => e.calSalary());
Console.WriteLine("Câu 5: Tổng lương nhân viên thời vụ:");
Console.WriteLine(pe_sum_salary);
//Câu 6: Sửa thông tin nhân viên:
Console.WriteLine("\nCâu 6: Sửa thông tin nhân viên:");
Console.Write("Nhập ID nhân viên cần sửa: ");
int updateId = int.Parse(Console.ReadLine());

Employee employeeToUpdate = employees.FirstOrDefault(e => e.Id == updateId);
if (employeeToUpdate != null)
{
    Console.WriteLine($"Thông tin hiện tại: {employeeToUpdate}");
    Console.WriteLine("Nhập thông tin mới:");

    Console.Write("Nhập IdCard mới: ");
    string newIdCard = Console.ReadLine();
    employeeToUpdate.IdCard = newIdCard;

    Console.Write("Nhập họ tên mới: ");
    string newName = Console.ReadLine();
    employeeToUpdate.Name = newName;

    Console.Write("Nhập ngày sinh mới (dd/MM/yyyy): ");
    DateTime newBirthday = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
    employeeToUpdate.Birthday = newBirthday;

    // Nếu là nhân viên thời vụ, cho phép sửa số giờ làm việc
    if (employeeToUpdate is ParttimeEmployee pe)
    {
        Console.Write("Nhập số giờ làm việc mới: ");
        int newWorkingHour = int.Parse(Console.ReadLine());
        pe.WorkingHour = newWorkingHour;
    }

    Console.WriteLine("Cập nhật thành công!");
    Console.WriteLine($"Thông tin sau khi cập nhật: {employeeToUpdate}");
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên với ID này!");
}

//Câu 7: Xóa thông tin nhân viên:
Console.WriteLine("\nCâu 7: Xóa thông tin nhân viên:");
Console.Write("Nhập ID nhân viên cần xóa: ");
int deleteId = int.Parse(Console.ReadLine());

Employee employeeToDelete = employees.FirstOrDefault(e => e.Id == deleteId);
if (employeeToDelete != null)
{
    Console.WriteLine($"Thông tin nhân viên sẽ bị xóa: {employeeToDelete}");
    Console.Write("Bạn có chắc chắn muốn xóa? (y/n): ");
    string confirm = Console.ReadLine();

    if (confirm?.ToLower() == "y" || confirm?.ToLower() == "yes")
    {
        employees.Remove(employeeToDelete);
        Console.WriteLine("Xóa nhân viên thành công!");
    }
    else
    {
        Console.WriteLine("Hủy thao tác xóa!");
    }
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên với ID này!");
}

// Hiển thị danh sách sau khi sửa/xóa
Console.WriteLine("\n=== DANH SÁCH NHÂN VIÊN SAU KHI CẬP NHẬT ===");
employees.ForEach(e => Console.WriteLine(e));

Console.WriteLine("\nNhấn Enter để thoát...");
Console.ReadLine();