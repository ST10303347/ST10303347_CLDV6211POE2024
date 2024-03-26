using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10303347_CLDV6211POE2024.Models
{
    public class taybel : Controller
    {

        public static string con_string = "Server=tcp:zayyyserver.database.windows.net,1433;Initial Catalog=ZAYYYDATA;Persist Security Info=False;User ID=loudeyes;Password=juiceWRLD999;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        public IActionResult Index()
        {
            return View();
        }
    }
}
