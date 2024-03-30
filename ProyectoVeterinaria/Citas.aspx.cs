using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ProyectoVeterinaria
{
    public partial class Citas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                citas_vencidas();
            }
        }

        private void LlenarGrid()
        {
            string connectionString = "Data Source=KEVIN-DESKTOP\\SQLEXPRESS;Initial Catalog=Veterinaria;Integrated Security=True";
            string query = "SELECT M.id_mascota, M.nombre_mascota, C.proxima_fecha, C.medico_asignado FROM Mascotas M INNER JOIN citas C ON M.id_mascota=C.id_mascota WHERE C.proxima_fecha>=GETDATE() ORDER BY C.proxima_fecha";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    GridView1.HeaderRow.Cells[0].Text = " Id mascota";
                    GridView1.HeaderRow.Cells[1].Text = " Nombre Mascota";
                    GridView1.HeaderRow.Cells[2].Text = " Proxima Fecha";
                    GridView1.HeaderRow.Cells[3].Text = " Medico asignado";
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un error: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{errorMessage}');", true);
            }
        }

        private void citas_vencidas ()
        {
            string connectionString = "Data Source=KEVIN-DESKTOP\\SQLEXPRESS;Initial Catalog=Veterinaria;Integrated Security=True";
            string query = "SELECT M.id_mascota, M.nombre_mascota, C.proxima_fecha, C.medico_asignado FROM Mascotas M INNER JOIN citas C ON M.id_mascota=C.id_mascota WHERE C.proxima_fecha<GETDATE() ORDER BY C.proxima_fecha";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        GridView2.DataSource = reader;
                        GridView2.DataBind();
                        GridView2.HeaderRow.Cells[0].Text = "Id mascota";
                        GridView2.HeaderRow.Cells[1].Text = "Nombre Mascota";
                        GridView2.HeaderRow.Cells[2].Text = "Proxima Fecha";
                        GridView2.HeaderRow.Cells[3].Text = "Medico asignado";
                    }
                    else
                    {
                        lblMensaje.Text = "No hay citas vencidas.";
                        lblMensaje.Visible = true;
                    }
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

        protected void bagregar_Click1(object sender, EventArgs e)
        {
            string id = tid.Text.ToUpper();
            string fecha = tpfecha.Text.ToUpper();
            string medico = tmedico.Text.ToUpper();


            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fecha) || string.IsNullOrEmpty(medico))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, completa todos los campos.');", true);
                return;
            }

            if (medico.Any(char.IsDigit))
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
                    string query = "INSERT INTO Citas (id_mascota, proxima_fecha, medico_asignado) VALUES (@Id, @Fecha, @Medico)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.Parameters.AddWithValue("@Medico", medico);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se realizó la inserción correctamente
                    if (rowsAffected > 0)
                    {
                        string Message = "Datos registrados correctamente";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{Message}');", true);
                    }
                    else
                    {
                        string errorMessage1 = "No se pudieron registrar los datos. ";
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
            citas_vencidas();
        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            string id = tid.Text.ToUpper();
            string fecha = tpfecha.Text.ToUpper();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fecha))
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
                    string query = "DELETE FROM Citas WHERE id_mascota = @Id AND proxima_fecha=@Fecha";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se realizó la inserción correctamente
                    if (rowsAffected > 0)
                    {
                        string Message = "Datos eliminados correctamente";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorPopup", $"alert('{Message}');", true);
                    }
                    else
                    {
                        string errorMessage1 = "No se encontraron datos segun el ID digitado";
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
            citas_vencidas();
        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            string id = tid.Text.ToUpper();
            string fecha = tpfecha.Text.ToUpper();
            string medico = tmedico.Text.ToUpper();


            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fecha) || string.IsNullOrEmpty(medico))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Por favor, completa todos los campos.');", true);
                return;
            }

            if (medico.Any(char.IsDigit))
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
                    string query = "UPDATE Citas set proxima_fecha=@Fecha, medico_asignado=@Medico WHERE id_mascota = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.Parameters.AddWithValue("@Medico", medico);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se realizó la inserción correctamente
                    if (rowsAffected > 0)
                    {
                        string Message = "Datos actualizados correctamente";
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
            citas_vencidas();
        }
    

        protected void blimpiar_Click(object sender, EventArgs e)
        {
            tid.Text = ""; tpfecha.Text = ""; tmedico.Text = "";
        }

        protected void tpfecha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}