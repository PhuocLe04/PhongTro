// AccountController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phong_Tro.Models;
using System.Linq;

public class AccountController : Controller
{
    private readonly DatabaseAccount _context;

    public AccountController(DatabaseAccount context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View("~/Views/Home/Login.cshtml");
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Accounts.SingleOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            // Kiểm tra vai trò của người dùng
            if (user.Role == 3)
            {
                // Nếu là Admin, chuyển hướng đến trang quản trị
                return RedirectToAction("Index", "Admin");
            }
            else if (user.Role == 1 || user.Role == 2)
            {
                // Nếu là User, chuyển hướng đến trang người dùng
                return RedirectToAction("Index", "User");
            }
            else
            {
                // Vai trò không hợp lệ, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Invalid role";
                return View();
            }
        }
        else
        {
            // Đăng nhập thất bại, hiển thị lại trang đăng nhập với thông báo lỗi
            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }
    }
}
