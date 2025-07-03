using F4_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Web_DATN.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly string _apiBase = "https://localhost:7183/";

        public async Task<IActionResult> Index()
        {
            List<NhanVien> list = new List<NhanVien>();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(_apiBase);
                var response = await http.GetAsync("api/NhanViens");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<NhanVien>>(data);
                }
            }
            return View(list);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            NhanVien nv = new();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(_apiBase);
                var response = await http.GetAsync($"api/NhanViens/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    nv = JsonConvert.DeserializeObject<NhanVien>(data);
                }
            }
            return View(nv);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, NhanVien nv)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(_apiBase);
                var content = new StringContent(JsonConvert.SerializeObject(nv), Encoding.UTF8, "application/json");
                var response = await http.PutAsync($"api/NhanViens/{id}", content);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhanVien nv)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(_apiBase);
                var content = new StringContent(JsonConvert.SerializeObject(nv), Encoding.UTF8, "application/json");
                var response = await http.PostAsync("api/NhanViens", content);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(_apiBase);
                var response = await http.DeleteAsync($"api/NhanViens/{id}");
            }
            return RedirectToAction("Index");
        }
    }
}
