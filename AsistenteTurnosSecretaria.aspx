<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AsistenteTurnosSecretaria.aspx.cs" Inherits="App_TurnosMedicos_Linares.AsistenteTurnosSecretaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col">
            </div>
            <div class="col-6">
                <br />
                <br />
                <%if (!IsPostBack)
                    { %>
                <h3>Seleccione una opción para buscar: </h3>
                <br />
                <asp:RadioButtonList ID="RadioBL" runat="server">
                    <asp:ListItem Selected="True">Busqueda por Especialidad</asp:ListItem>
                    <asp:ListItem>Busqueda por Médico</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="Btnsiguiente" runat="server" Text="Siguiente" OnClick="Btnsiguiente_Click" />
                <%} %>
                <br />
                <br />
            </div>
            <div class="col">
            </div>
        </div>
    </div>


    <div class="container text-center">
        <div class="row">
            <div class="col-sm">
            </div>
            <div class="col-xxl">
                <%if (MostrarMedicos())
                    {  %>
                <h3>Seleccione el médico con quien te quieras atender: </h3>
                <asp:GridView ID="GvMedicos" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvMedicos_SelectedIndexChanged" DataKeyNames="IdMedico">
                    <columns>
                        <asp:BoundField HeaderText="Nombre  " DataField="Usuario.Nombre" />
                        <asp:BoundField HeaderText="Apellido  " DataField="Usuario.Apellido" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </columns>
                </asp:GridView>
                <% }%>

                <% if (MostrarEpecialidades())
                    { %>
                <h3>Seleccione una especialidad para reservar un turno: </h3>
                <asp:GridView ID="GvEspecialidades" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvEspecialidades_SelectedIndexChanged" DataKeyNames="IdEspecialidad">
                    <columns>
                        <asp:BoundField HeaderText="Descripcion  " DataField="Descripcion" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </columns>
                </asp:GridView>
                <% }%>

                <%if (MostrarMedicoEspe())
                    {  %>
                <h3>Seleccione el médico con quien te quieras atender: </h3>
                <asp:GridView ID="GvMedicoEspec" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvMedicoEspec_SelectedIndexChanged" DataKeyNames="IdMedico">
                    <columns>
                        <asp:BoundField HeaderText="Nombre  " DataField="Usuario.Nombre" />
                        <asp:BoundField HeaderText="Apellido  " DataField="Usuario.Apellido" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </columns>
                </asp:GridView>
                <% }%>

                <%if (MostrarTurnos())
                    {  %>
                <h3>Seleccione un turno: </h3>
                <asp:GridView ID="GvTurnos" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvTurnos_SelectedIndexChanged" DataKeyNames="IDTurno">
                    <columns>
                        <asp:BoundField HeaderText="Fecha  " DataField="FechaTurno" />
                        <asp:BoundField HeaderText="Hora  " DataField="HoraTurno" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </columns>
                </asp:GridView>
                <% }%>
                <%if (Confirmarturno())
                    { %>
                <h3>Ingrese el DNI del paciente: </h3>
                <asp:TextBox ID="TxtDNIPac" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="TxtDNIPac"
                    ErrorMessage="DNI is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <br />
                <h3>¿Confirma la reserva del turno?</h3>
                <asp:Button ID="BtnConfirmar" runat="server" class="btn btn-info btn-md" Text="Confirmar" OnClick="BtnConfirmar_Click" />
                <asp:Button ID="BtnCancelar" runat="server" class="btn btn-info btn-md" Text="Cancelar" OnClick="BtnCancelar_Click" CausesValidation="false" />
                <%} %>
            </div>
            <div class="col-sm">
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
