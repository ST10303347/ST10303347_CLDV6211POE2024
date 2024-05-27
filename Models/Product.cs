using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ST10303347_CLDV6211POE2024.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace ST10303347_CLDV6211POE2024.Models
{
    public class Product
    {

       

        [Key]
        public int productId { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public ProductCategory Category { get; set; }

        public string Availability { get; set; }

        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }


        public static string con_string = "Server=tcp:zayyyserver.database.windows.net,1433;Initial Catalog=ZAYYYDATA;Persist Security Info=False;User ID=loudeyes;Password=juiceWRLD999;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);

        public Product()
        {
        }

        public int insert_product(Product p)
        {

            try
            {
                string sql = "INSERT INTO Product (ProductName, ProductPrice, Category, Availability, Description, ImagePath ) VALUES (@Name, @Price, @Category, @Availability, @Description, @ImagePath)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@Imagepath", p.ImagePath);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                        



                throw ex;
            }


        }





    }
}
