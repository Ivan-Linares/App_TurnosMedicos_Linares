<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BlanquearContraseñaDoctor.aspx.cs" Inherits="App_TurnosMedicos_Linares.BlanquearContraseñaDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Selecciona el paciente que quieras blanquear la contraseña!</h3>

    <asp:GridView ID="GvDoctores" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
        OnSelectedIndexChanged="GvPacientes_SelectedIndexChanged" DataKeyNames="IdMedico">
        <Columns>
            <asp:BoundField HeaderText="ID  " DataField="IdMedico" />
            <asp:BoundField HeaderText="DNI  " DataField="Usuario.DNI" />
            <asp:BoundField HeaderText="Nombre  " DataField="Usuario.Nombre" />
            <asp:BoundField HeaderText="Apellido  " DataField="Usuario.Apellido" />
            <asp:BoundField HeaderText="Mail  " DataField="Usuario.Email" />
            <asp:BoundField HeaderText="Telefono  " DataField="Usuario.Telefono" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>

      <asp:Label ID="LbConfirmacion" runat="server" Text=" " Visible="false" class="text-primary fs-4"></asp:Label>

</asp:Content>
