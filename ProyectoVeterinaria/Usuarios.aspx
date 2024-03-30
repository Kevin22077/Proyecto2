<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ProyectoVeterinaria.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/Estilos.css" rel="stylesheet" />
    <link href="CSS/EstilosBotton.css" rel="stylesheet" />
    <title>USUARIOS VETERINARIA</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Mantenimiento de usuarios</h1>
        <nav>
            <ul>
                <li><a href="Menu.aspx">Inicio</a></li>
                <li><a href="Reportes.aspx">Reportes</a></li>
                <li><a href="Principal.aspx">Salir</a></li>
            </ul>
        </nav>
        <div>
            Lista de usuarios
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>

        <div>
            Ingresar, actualizar o eliminar
            <br />
            Id:    
            <asp:TextBox ID="tid" runat="server" TextMode="Number"></asp:TextBox>
            Clave: 
            <asp:TextBox ID="tclave" runat="server"></asp:TextBox>
            Nombre:
            <asp:TextBox ID="tnombre" runat="server"></asp:TextBox>
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
            Para INGRESAR un dato, complete los campos segun se le solicita.
        <br />
            Para BORRAR un dato, digite el ID del usuario que desea eliminar.
        <br />
            Para MODIFICAR un dato, digite el ID del usuario que desea modificar y seguidamente los datos nuevos.
        </div>

    </form>
</body>
</html>
