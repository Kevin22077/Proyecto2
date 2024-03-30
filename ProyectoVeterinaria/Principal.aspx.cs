using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVeterinaria
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bingresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = tusuario.Text;
                string contrasena = tcontrasena.Text;

                //if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, completa todos los campos.');", true);
                //    return;
                //}

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, completa todos los campos.');", true);
                    return;
                }
                else if (!Regex.IsMatch(usuario, @"^\d+$") || !Regex.IsMatch(contrasena, @"^\d+$"))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, ingresa únicamente números en los campos de usuario y contraseña.');", true);
                    return;
                }

                string constr = ConfigurationManager.ConnectionStrings["VeterinariaConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE login_usuario = @username AND clave_usuario = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros a la consulta
                        command.Parameters.AddWithValue("@username", usuario);
                        command.Parameters.AddWithValue("@password", contrasena);

                        // Ejecutar la consulta y obtener el resultado
                        int count = (int)command.ExecuteScalar();

                        // Verificar si se encontró un usuario con las credenciales proporcionadas
                        if (count > 0)
                        {
                            // Credenciales válidas, redireccionar a la página principal o realizar alguna acción
                            Response.Redirect("Menu.aspx");
                        }
                        else
                        {
                            // Credenciales inválidas, mostrar un mensaje de error
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Usuario o contraseña incorrectos. Intentelo nuevamente');", true);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Se produjo un error durante el proceso de inicio de sesión: " + ex.Message);
            }
        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            tusuario.Text = ""; tcontrasena.Text = "";
        }

        protected void tcontrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}