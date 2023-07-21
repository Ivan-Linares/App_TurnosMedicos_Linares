<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionDatosSecretaria.aspx.cs" Inherits="App_TurnosMedicos_Linares.GestionDatosSecretaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div id="register-row" class="row justify-content-center align-items-center">
        <div id="register-column" class="col-md-6">
            <br />
            <h3 class="text-center text-info">Administra tus datos!</h3>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="TextDNI" class="text-info">DNI:</label><br />
                        <asp:TextBox ID="TextDNI" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="TextNombre" class="text-info">Nombre:</label><br />
                        <asp:TextBox ID="TextNombre" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="TextNombre"
                            ErrorMessage="Nombre is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextApellido" class="text-info">Apellido:</label><br />
                        <asp:TextBox ID="TextApellido" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="TextApellido"
                            ErrorMessage="Apellido is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <label for="txtFechaNac" class="text-info">Fecha de Nacimiento</label>
                            <asp:TextBox runat="server" ID="txtFechaNac" TextMode="Date" CssClass="form-control" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtFechaNac"
                        ErrorMessage="Fecha Nacimiento is a required field."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvFecha" runat="server"
                        ControlToValidate="txtFechaNac"
                        ErrorMessage="Debes tener al menos 18 años!"
                        ForeColor="Red"
                        OnServerValidate="cvFecha_ServerValidate" />
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="TextDomicilio" class="text-info">Domicilio:</label><br />
                        <asp:TextBox ID="TextDomicilio" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="TextDomicilio"
                            ErrorMessage="Adress is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextTelefono" class="text-info">Telefono:</label><br />
                        <asp:TextBox ID="TextTelefono" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="TextTelefono"
                            ErrorMessage="Phone is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextEmail" class="text-info">Email:</label><br />
                        <asp:TextBox ID="TextEmail" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                            ControlToValidate="TextEmail"
                            ErrorMessage="Email is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <br />
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnSalir" runat="server" class="btn btn-info btn-md" Text="Salir" OnClick="BtnSalir_Click" />
                    <asp:Button ID="BtnAceptar" runat="server" class="btn btn-info btn-md" Text="Aceptar!" OnClick="BtnAceptar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
