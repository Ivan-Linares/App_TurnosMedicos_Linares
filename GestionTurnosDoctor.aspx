<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionTurnosDoctor.aspx.cs" Inherits="App_TurnosMedicos_Linares.GestionTurnosDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">

            <div class="col-6">
                <%if (!Reservados())
                    { %>
                <asp:Label ID="LbReservados" runat="server" Text=" " Visible="false" class="text-danger fs-4"></asp:Label>
                <br />
                <asp:GridView ID="GvTurnosReservados" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvTurnosReservados_SelectedIndexChanged" DataKeyNames="IDTurno">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha  " DataField="TurnoDisponible.FechaTurno" />
                        <asp:BoundField HeaderText="Hora  " DataField="TurnoDisponible.HoraTurno" />
                        <asp:BoundField HeaderText="Apellido Paciente  " DataField="ApePac" />
                        <asp:BoundField HeaderText="Nombre Paciente  " DataField="NombrePac" />
                        <asp:BoundField HeaderText="Especialidad  " DataField="Especialidad" />
                        <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍" />
                    </Columns>
                </asp:GridView>
                <%} %>
                <%if (Reservados())
                    { %>
                <asp:Button ID="BtnVolver" runat="server" class="btn btn-primary" Text="Volver" OnClick="BtnVolver_Click" />
                <asp:Button ID="BtnCancelarReser" runat="server" class="btn btn-danger" Text="Cancelar Turno" OnClick="BtnCancelarReser_Click" />
                <asp:Button ID="BtnRealizado" runat="server" class="btn btn-success" Text="Turno Realizado" OnClick="BtnRealizado_Click" />
                <%} %>
            </div>
            <div class="col-6">
                <%if (!Disponibles())
                    { %>
                <asp:Label ID="LbDisponible" runat="server" Text=" " Visible="false" class="text-primary fs-4"></asp:Label>
                <br />
                <asp:GridView ID="GvTurnosDisponibles" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="GvTurnosDisponibles_SelectedIndexChanged" DataKeyNames="IDTurno">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha  " DataField="FechaTurno" />
                        <asp:BoundField HeaderText="Hora  " DataField="HoraTurno" />
                        <asp:BoundField HeaderText="Especialidad  " DataField="EspecialidadDescrip" />
                    </Columns>
                </asp:GridView>
                <%} %>
            </div>
        </div>
    </div>

</asp:Content>



