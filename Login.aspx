<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="App_TurnosMedicos_Linares.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-form" class="form">
                        <br />
                        <h3 class="text-center text-info">Inicio De Sesion</h3>
                        <div class="form-group">
                            <label for="username" class="text-info">DNI:</label><br />
                            <asp:TextBox ID="TxDNI" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="TxDNI"
                                ErrorMessage="DNI is a required field."
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="password" class="text-info">Contraseña:</label><br />
                            <asp:TextBox ID="TxPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="TxPassword"
                                ErrorMessage="Password is a required field."
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <br />
                            <asp:Button ID="BotonLogin" runat="server" class="btn btn-info btn-md" Text="Ingresar" OnClick="BotonLogin_Click" />
                        </div>
                        <div class="form-group">
                            <br />
                            <p>¿No estas registrado aun? <a href="Registrarse.aspx" class="text-info">Regístrate!</a></p>
                        </div>
                        <br />
                        <br />
                         <asp:Label ID="LbError" runat="server" class="text-danger" Text="" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
