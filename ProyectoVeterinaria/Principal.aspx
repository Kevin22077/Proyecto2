<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="ProyectoVeterinaria.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/Estilos.css" rel="stylesheet" />
    <link href="CSS/EstilosBotton.css" rel="stylesheet" />
    <title>Inicio de sesion</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            Veterinaria UPI
            <br />
            <img src="Imagenes/animales2.png" alt="Fotografia de animales"/>
        </h1>
        
        <div>
            Ingrese sus datos para accesar al sistema.
            <br /><br />
            <b>Usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
            <asp:TextBox ID="tusuario" runat="server"></asp:TextBox>
            <br />
            <b>Contrasena:
            <asp:TextBox ID="tcontrasena" runat="server" OnTextChanged="tcontrasena_TextChanged" Visible="true" EnableTheming="True" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:Button Class="button" ID="bingresar" runat="server" Text="Ingresar" OnClick="bingresar_Click" />
            <asp:Button Class="button" ID="bborrar" runat="server" Text="Borrar" OnClick="bborrar_Click" />
        </div>
        
    </form>
</body>
</html>
