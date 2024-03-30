using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace ProyectoVeterinaria
{
    public partial class Mascotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        private void LlenarGrid()
        {
            string connectionString = "Data Source=KEVIN-DESKTOP\\SQLEXPRESS;Initial Catalog=Veterinaria;Integrated Security=True";
            string query = "SELECT nombre_mascota, tipo_mascota, comida_favorita FROM Mascotas";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();

                    GridView1.HeaderRow.Cells[0].Text = "Nombre";
                    GridView1.HeaderRow.Cells[1].Text = "Tipo";
                    GridView1.HeaderRow.Cells[2].Text = "Comida favorita";
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un error: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage}');", true);
            }
        }
    

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            string nombre = tnombre.Text.ToUpper();
            string tipo = ttipo.Text.ToUpper();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, completa todos los campos.');", true);
                return;
            }
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["VeterinariaConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Mascotas WHERE nombre_mascota = @Nombre AND tipo_mascota=@Tipo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", tnombre.Text);
                    command.Parameters.AddWithValue("@Tipo", ttipo.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string Message = "Datos eliminados correctamente";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{Message}');", true);
                    }
                    else
                    {
                        string errorMessage1 = "No se encontraron datos segun el ID digitado ";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage1}');", true);
                    }
                    LlenarGrid();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un error: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage}');", true);
            }
        }

        protected void bagregar_Click1(object sender, EventArgs e)
        {
            string nombre = tnombre.Text.ToUpper();
            string tipo = ttipo.Text.ToUpper();
            string comida = tcomida.Text.ToUpper();


            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(comida))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, completa todos los campos.');", true);
                return;
            }

            if (nombre.Any(char.IsDigit))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('El nombre no puede contener números.');", true);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["VeterinariaConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Mascotas (nombre_mascota, tipo_mascota, comida_favorita) VALUES (@Nombre, @Tipo, @Comida)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Tipo", tipo);
                    command.Parameters.AddWithValue("@Comida", comida);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se realizó la inserción correctamente
                    if (rowsAffected > 0)
                    {
                        string Message = "Datos ingresados correctamente";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{Message}');", true);
                    }
                    else
                    {
                        string errorMessage1 = "No se pudieron ingresar los datos. ";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage1}');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un error: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage}');", true);
            }
            LlenarGrid();

        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            string nombre = tnombre.Text.ToUpper();
            string tipo = ttipo.Text.ToUpper();
            string comida = tcomida.Text.ToUpper();


            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(comida))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, completa todos los campos.');", true);
                return;
            }

            if (nombre.Any(char.IsDigit))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('El nombre no puede contener números.');", true);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["VeterinariaConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Mascotas set tipo_mascota=@Tipo, comida_favorita=@Comida WHERE nombre_mascota = @Nombre";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Tipo", tipo);
                    command.Parameters.AddWithValue("@Comida", comida);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se realizó la inserción correctamente
                    if (rowsAffected > 0)
                    {
                        string Message = "Datos ingresados correctamente";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{Message}');", true);
                    }
                    else
                    {
                        string errorMessage1 = "No se pudieron ingresar los datos. ";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage1}');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un error: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage}');", true);
            }
            LlenarGrid();
        }

        protected void blimpiar_Click(object sender, EventArgs e)
        {
            tnombre.Text = ""; ttipo.Text = ""; tcomida.Text = "";
        }
    }
}