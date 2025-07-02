using Microsoft.AspNetCore.Mvc;

namespace Web_DATN.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Admin")
                return RedirectToAction("AccessDenied", "TaiKhoan");

            return View(); // Trang quản trị
        }
    }
}
