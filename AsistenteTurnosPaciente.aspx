<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AsistenteTurnosPaciente.aspx.cs" Inherits="App_TurnosMedicos_Linares.AsistenteTurnos" %>

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
                    <asp:ListItem Selected="True"> Busqueda por Especialidad</asp:ListItem>
                    <asp:ListItem> Busqueda por Médico</asp:ListItem>
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
                    <Columns>
                        <asp:BoundField HeaderText="Nombre  " DataField="Usuario.Nombre" />
                        <asp:BoundField HeaderText="Apellido  " DataField="Usuario.Apellido" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </Columns>
                </asp:GridView>
                <% }%>

                <% if (MostrarEpecialidades())
                    { %>
                <h3>Seleccione una especialidad para reservar un turno: </h3>
                <asp:GridView ID="GvEspecialidades" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvEspecialidades_SelectedIndexChanged" DataKeyNames="IdEspecialidad">
                    <Columns>
                        <asp:BoundField HeaderText="Descripcion  " DataField="Descripcion" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </Columns>
                </asp:GridView>
                <% }%>

                <%if (MostrarMedicoEspe())
                    {  %>
                <h3>Seleccione el médico con quien te quieras atender: </h3>
                <asp:GridView ID="GvMedicoEspec" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvMedicoEspec_SelectedIndexChanged" DataKeyNames="IdMedico">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre  " DataField="Usuario.Nombre" />
                        <asp:BoundField HeaderText="Apellido  " DataField="Usuario.Apellido" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </Columns>
                </asp:GridView>
                <% }%>

                 <%if (MostrarTurnos())
                    {  %>
                <h3>Seleccione un turno: </h3>
                <asp:GridView ID="GvTurnos" class="table table-striped-columns" runat="server" AutoGenerateColumns="false" 
                    OnSelectedIndexChanged="GvTurnos_SelectedIndexChanged" DataKeyNames="IDTurno">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha  " DataField="FechaTurno" />
                        <asp:BoundField HeaderText="Hora  " DataField="HoraTurno" />
                        <asp:BoundField HeaderText="Especialidad  " DataField="EspecialidadDescrip" />
                        <asp:CommandField HeaderText="" ShowSelectButton="true" SelectText="✍" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="LbError" runat="server" Text=" " Visible="false"></asp:Label>
                <% }%>
                <%if (Confirmarturno())
                    { %>
                <h3>¿Confirma la reserva del turno?</h3>
                <asp:Button ID="BtnConfirmar" runat="server" class="btn btn-info btn-md" Text="Confirmar" OnClick="BtnConfirmar_Click"/>
                <asp:Button ID="BtnCancelar" runat="server" class="btn btn-info btn-md" Text="Cancelar" OnClick="BtnCancelar_Click"/>
                <%} %>

            </div>
            <div class="col-sm">
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
