<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="ProyectoVeterinaria.Citas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CITAS VETERINARIA</title>
    <link href="CSS/Estilos.css" rel="stylesheet" />
    <link href="CSS/EstilosBotton.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            REPORTE DE CITAS
            <br />
            <nav>
                <ul>
                    <li><a href="Menu.aspx">Inicio</a></li>
                    <li><a href="Reportes.aspx">Reportes</a></li>
                    <li><a href="Principal.aspx">Salir</a></li>
                </ul>
                <br />
            </nav>
        </div>

        <div>
            <h2>Citas por atender:</h2>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

            <h2>Citas vencidas:<br />
            </h2>
            <h2>
                <asp:Label ID="lblMensaje" runat="server" Visible="false" ForeColor="Red"></asp:Label></h2>

            <asp:GridView ID="GridView2" runat="server"></asp:GridView>

            ID mascota:    
            <asp:TextBox ID="tid" runat="server"></asp:TextBox>
            Proxima fecha: 
            <asp:TextBox ID="tpfecha" runat="server" OnTextChanged="tpfecha_TextChanged" TextMode="Date"></asp:TextBox>
            Medico asignado:
            <asp:TextBox ID="tmedico" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button Class="button" ID="bagregar" runat="server" Text="AGREGAR" OnClick="bagregar_Click1" />
            <asp:Button Class="button" ID="bborrar" runat="server" Text="BORRAR" OnClick="bborrar_Click" />
            <asp:Button Class="button" ID="bmodificar" runat="server" Text="MODIFICAR" OnClick="bmodificar_Click" />
            <asp:Button Class="button" ID="blimpiar" runat="server" Text="LIMPIAR CELDAS" OnClick="blimpiar_Click" />
            <br />
            <br />
            <div>
                Instrucciones de uso:
    <br />
                Para INGRESAR un dato, complete todos los campos segun se le solicita.
    <br />
                Para BORRAR un dato, digite el id de la mascota y la fecha que desea eliminar.
    <br />
                Para MODIFICAR un dato, digite el Id de la mascota que desea modificar y seguidamente los datos nuevos.
            </div>
        </div>
    </form>
</body>
</html>
