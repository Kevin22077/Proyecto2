using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVeterinaria
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack) 
                {
                    LlenarGrid();
                }
            }
        }

        private void LlenarGrid()
        {
            string connectionString = "Data Source=KEVIN-DESKTOP\\SQLEXPRESS;Initial Catalog=Veterinaria;Integrated Security=True";
            string query = "SELECT * FROM usuarios";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();

                    GridView1.HeaderRow.Cells[0].Text = "ID usuario";
                    GridView1.HeaderRow.Cells[1].Text = "Clave";
                    GridView1.HeaderRow.Cells[2].Text = "Nombre";
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un error: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage}');", true);
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["VeterinariaConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Usuarios WHERE login_usuario = @LoginUsuario";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LoginUsuario", tid.Text);
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
            string id = tid.Text;
            string clave = tclave.Text;
            string nombre = tnombre.Text.ToUpper();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(clave) || string.IsNullOrEmpty(nombre))
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
                    string query = "INSERT INTO Usuarios (login_usuario, clave_usuario, nombre_usuario) VALUES (@IdUsuario, @Clave, @Nombre)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUsuario", id);
                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@Nombre", nombre);
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
            string id = tid.Text;
            string clave = tclave.Text;
            string nombre = tnombre.Text.ToUpper();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(clave) || string.IsNullOrEmpty(nombre))
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
                    string query = "UPDATE Usuarios SET clave_usuario=@Clave, nombre_usuario=@Nombre WHERE login_usuario=@IdUsuario";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdUsuario", id);
                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se realizó la inserción correctamente
                    if (rowsAffected > 0)
                    {
                        string Message = "Datos modificados correctamente";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{Message}');", true);
                    }
                    else
                    {
                        string errorMessage1 = "No se pudieron actualizar los datos. ";
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
            tid.Text = ""; tclave.Text = ""; tnombre.Text = "";
        }
    }
}
