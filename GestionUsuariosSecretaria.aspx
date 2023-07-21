<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuariosSecretaria.aspx.cs" Inherits="App_TurnosMedicos_Linares.GestionUsuariosSecretaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row">
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <h5>PACIENTES</h5>
                        <br />
                        <br />
                        <div class="d-grid gap-2">
                            <a href="ListarPacientes.aspx" class="btn btn-primary">Listar</a>
                            <br />
                            <a href="BlanquearContraseñaPaciente.aspx" class="btn btn-warning">Blanquear Contraseñas</a>
                            <br />
                            <a href="AgregarPaciente.aspx" class="btn btn-success">Agregar</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <h5>MEDICOS</h5>
                        <br />
                        <br />
                        <div class="d-grid gap-2">
                            <a href="ListarDoctores.aspx" class="btn btn-primary">Listar</a>
                            <br />
                            <a href="BlanquearContraseñaDoctor.aspx" class="btn btn-warning">Blanquear Contraseñas</a>
                            <br />
                            <a href="GestionUsuarioDoctor.aspx" class="btn btn-success">Agregar</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <h5>TURNOS</h5>
                        <br />
                        <br />
                        <div class="d-grid gap-2">
                            <br />
                            <a href="AsistenteTurnosDoctor.aspx" class="btn btn-success">Agregar</a>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
