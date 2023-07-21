<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarPacientes.aspx.cs" Inherits="App_TurnosMedicos_Linares.ListarPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GvPacientes" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
        OnSelectedIndexChanged="GvPacientes_SelectedIndexChanged" DataKeyNames="IdPaciente">
        <Columns>
            <asp:BoundField HeaderText="ID  " DataField="IdPaciente" />
            <asp:BoundField HeaderText="DNI  " DataField="Usuario.DNI" />
            <asp:BoundField HeaderText="Nombre  " DataField="Usuario.Nombre" />
            <asp:BoundField HeaderText="Apellido  " DataField="Usuario.Apellido" />
            <asp:BoundField HeaderText="Cobertura  " DataField="Cobertura.Descripcion" />
            <asp:BoundField HeaderText="Mail  " DataField="Usuario.Email" />
            <asp:BoundField HeaderText="Telefono  " DataField="Usuario.Telefono" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>

</asp:Content>
