<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="App_TurnosMedicos_Linares.AgregarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div id="register-row" class="row justify-content-center align-items-center">
        <div id="register-column" class="col-md-6">
            <br />
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="TextDNI" class="text-info">DNI:</label><br />
                        <asp:TextBox ID="TextDNI" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="TextDNI"
                            ErrorMessage="DNI is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextNombre" class="text-info">Nombre:</label><br />
                        <asp:TextBox ID="TextNombre" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="TextNombre"
                            ErrorMessage="Name is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextApellido" class="text-info">Apellido:</label><br />
                        <asp:TextBox ID="TextApellido" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="TextApellido"
                            ErrorMessage="Last name is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="DDCobertura" class="text-info">Cobertura:</label><br />
                        <asp:DropDownList ID="DDCobertura" CssClass="text-info" runat="server"></asp:DropDownList>
                    </div>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <label for="txtFechaNac" class="text-info">Fecha de Nacimiento</label>
                            <asp:TextBox runat="server" ID="txtFechaNac" TextMode="Date" CssClass="form-control" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtFechaNac"
                        ErrorMessage="Birth Date is a required field."
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="TextDomicilio"
                            ErrorMessage="Adress is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextTelefono" class="text-info">Telefono:</label><br />
                        <asp:TextBox ID="TextTelefono" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                            ControlToValidate="TextTelefono"
                            ErrorMessage="Phone is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="TextEmail" class="text-info">Email:</label><br />
                        <asp:TextBox ID="TextEmail" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                            ControlToValidate="TextEmail"
                            ErrorMessage="Email is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <%if (!Carga())
                        {  %>
                    <div class="form-group">
                        <label ID="lbcontra" for="TextContra" class="text-info">Contraseña:</label><br />
                        <asp:TextBox ID="TextContra" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                            ControlToValidate="TextContra"
                            ErrorMessage="Password is a required field."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <%} %>
                    <br />
                    <div class="form-group">
                        <asp:Button ID="BotonVolver" runat="server" class="btn btn-info btn-md" Text="Volver" CausesValidation="False" OnClick="BotonVolver_Click" />
                        <asp:Button ID="BotonRegister" runat="server" class="btn btn-info btn-md" Text="Modificar!" OnClick="BotonRegister_Click" />
                        <%if (PuedeEliminar())
                            {
                        %>
                        <asp:Button ID="BotonEliminar" CausesValidation="false" runat="server" class="btn btn-danger" OnClick="BotonEliminar_Click" Text="Eliminar" />
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
