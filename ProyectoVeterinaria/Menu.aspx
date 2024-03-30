<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ProyectoVeterinaria.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/Estilos.css" rel="stylesheet" />
    <title>Menu Veterinaria</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Menu Veterinaria UPI</h1>
        <br />
        <img src="Imagenes/animales2.png" alt="Fotografia de animales" style="height: 215px; width: 552px" />
        <nav>
            <ul>
                <li><a href="Menu.aspx">Inicio</a></li>
                <li><a href="Reportes.aspx">Reportes</a></li>
                <li><a href="Principal.aspx">Salir</a></li>
            </ul>
        </nav>
    </form>
</body>
</html>
