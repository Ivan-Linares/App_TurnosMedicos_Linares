<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarDoctores.aspx.cs" Inherits="App_TurnosMedicos_Linares.ListarDoctores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

</asp:Content>
