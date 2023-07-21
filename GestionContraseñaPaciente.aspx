<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionContraseñaPaciente.aspx.cs" Inherits="App_TurnosMedicos_Linares.GestionContraseñaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col">
            </div>
            <div class="col-6">
                <div class="form-group">
                    <label for="TextContraVieja" class="text-info">Contraseña actual:</label><br />
                    <asp:TextBox ID="TextContraVieja" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="TextContraVieja"
                        ErrorMessage="Old Password is a required field."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="TextContraNueva" class="text-info">Contraseña nueva:</label><br />
                    <asp:TextBox ID="TextContraNueva" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                        ControlToValidate="TextContraNueva"
                        ErrorMessage="New Password is a required field."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="TextConfirmarContra" class="text-info">Por favor, ingrese otra vez la contraseña nueva:</label><br />
                    <asp:TextBox ID="TextConfirmarContra" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="TextConfirmarContra"
                        ErrorMessage="This is a required field."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>


                <asp:Label ID="LbError" runat="server" Text=" " class="btn btn-danger" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="LbError2" runat="server" Text=" " class="btn btn-danger" Visible="false"></asp:Label>
                <br />
                <br />
                <div class="form-group">
                    <asp:Button ID="BtnSalir" runat="server" class="btn btn-info btn-md" Text="Salir" OnClick="BtnSalir_Click" />
                    <asp:Button ID="BtnAceptar" runat="server" class="btn btn-info btn-md" Text="Aceptar!" OnClick="BtnAceptar_Click" />
                </div>
            </div>
            <div class="col">
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
