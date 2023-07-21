<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionTurnosPaciente.aspx.cs" Inherits="App_TurnosMedicos_Linares.GestionTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <%      if (!DarBajaT())
        { %>
     <div class="container-md">
    <asp:GridView ID="GvTurnosReservados" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
        OnSelectedIndexChanged="GvTurnosReservados_SelectedIndexChanged" DataKeyNames="IDTurno">
        <Columns>
            <asp:BoundField HeaderText="Fecha  " DataField="TurnoDisponible.FechaTurno" />
            <asp:BoundField HeaderText="Hora  " DataField="TurnoDisponible.HoraTurno" />
            <asp:BoundField HeaderText="Especialidad  " DataField="Especialidad" />
            <asp:CommandField HeaderText="Dar de baja turno" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
         </div>
    <%} %>
    <div class="container text-center">
        <div class="row">
            <div class="col-sm">
            </div>
            <div class="col-xxl">
                <% if (!Turnos())
                    { %>
                <h3>No tiene turnos agendados!</h3>
                <%} %>

                <% if (DarBajaT())
                    { %>
                <h3>¿Esta seguro que quiere cancelar este turno?</h3>
                <asp:Button ID="BtnConfirmar" runat="server" Text="Confirmar" class="btn btn-info btn-md" OnClick="BtnConfirmar_Click" />
                <asp:Button ID="BtnVolver" runat="server" Text="Volver" class="btn btn-info btn-md" OnClick="BtnVolver_Click" />
                <%} %>
            </div>
            <div class="col-sm">
            </div>
        </div>
    </div>

</asp:Content>
