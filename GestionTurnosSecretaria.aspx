<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionTurnosSecretaria.aspx.cs" Inherits="App_TurnosMedicos_Linares.GestionTurnosSecretaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <div class="row">
            <div class="col-sm">
            
            </div>
            
            <div class="col-xxl">
                <%if (!DniPaciente())
                    { %>
                <h3>Ingrese el DNI del paciente: </h3>
                <asp:TextBox ID="TxtDNIPac" runat="server" class="form-control"></asp:TextBox>
                <br />
                <asp:Button ID="BtnIngresar" runat="server" class="btn btn-info btn-md" Text="Ingresar Dni" OnClick="BtnIngresar_Click" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="TxtDNIPac"
                    ErrorMessage="DNI is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <%} %>
            </div>
            
            <div class="col-sm">
            
            </div>
        </div>
    </div>

    <%if (DniPaciente())
        { %>
     <%      if (!DarBajaT())
        { %>
    <asp:GridView ID="GvTurnosReservados" class="table table-striped-columns" runat="server" AutoGenerateColumns="false"
        OnSelectedIndexChanged="GvTurnosReservados_SelectedIndexChanged" DataKeyNames="IDTurno">
        <Columns>
            <asp:BoundField HeaderText="Fecha  " DataField="TurnoDisponible.FechaTurno" />
            <asp:BoundField HeaderText="Hora  " DataField="TurnoDisponible.HoraTurno" />
            <asp:BoundField HeaderText="Apellido Medico " DataField="Apemed" />
            <asp:BoundField HeaderText="Nombre Medico " DataField="NombreMed" />
            <asp:BoundField HeaderText="Especialidad  " DataField="Especialidad" />
            <asp:CommandField HeaderText="Dar de baja turno" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
    <%} %>
    <div class="container text-center">
        <div class="row">
            <div class="col-sm">
            </div>
            <div class="col-xxl">
                <% if (!Turnos())
                    { %>
                <h3>Este paciente no tiene turnos agendados!</h3>
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
    <%} %>
</asp:Content>

