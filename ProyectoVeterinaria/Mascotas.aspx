<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mascotas.aspx.cs" Inherits="ProyectoVeterinaria.Mascotas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MASCOTAS VETERINARIA</title>
    <link href="CSS/Estilos.css" rel="stylesheet" />
    <link href="CSS/EstilosBotton.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            REPORTE DE MASCOTAS
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
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            Nombre:    
            <asp:TextBox ID="tnombre" runat="server"></asp:TextBox>
            Tipo mascota: 
            <asp:TextBox ID="ttipo" runat="server"></asp:TextBox>
            Comida favorita:
            <asp:TextBox ID="tcomida" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button Class="button" ID="bagregar" runat="server" Text="AGREGAR" OnClick="bagregar_Click1" />
            <asp:Button Class="button" ID="bborrar" runat="server" Text="BORRAR" OnClick="bborrar_Click" />
            <asp:Button Class="button" ID="bmodificar" runat="server" Text="MODIFICAR" OnClick="bmodificar_Click" />
            <asp:Button Class="button" ID="blimpiar" runat="server" Text="LIMPIAR CELDAS" OnClick="blimpiar_Click" />
            <br />
            <br />
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>

        <div>
            Instrucciones de uso:
            <br />
            Para INGRESAR un dato, complete todos los campos segun se le solicita.
            <br />
            Para BORRAR un dato, digite el nombre de la mascota y el tipo que desea eliminar.
            <br />
            Para MODIFICAR un dato, digite el nombre de la mascota que desea modificar y seguidamente los datos nuevos.
        </div>
    </form>
</body>
</html>
