<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AsistenteTurnosDoctor.aspx.cs" Inherits="App_TurnosMedicos_Linares.AsistenteTurnosDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div id="register-row" class="row justify-content-center align-items-center">
        <div id="register-column" class="col-md-6">
            <div class="form" method="post">
                <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <label for="txtFecha" class="text-info">Fecha del turno</label>
                            <asp:TextBox runat="server" ID="txtFechaTurno" TextMode="Date" CssClass="form-control" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:CustomValidator ID="CustomValidator1" runat="server"
                    ControlToValidate="txtFechaTurno"
                    ErrorMessage="La fecha no puede ser anterior a la actual!"
                    ForeColor="Red"
                    OnServerValidate="cvFecha_ServerValidate" />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtFechaTurno"
                    ErrorMessage="Fecha is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <br />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <label for="TxtHora" class="text-info">Hora del turno</label>
                        <asp:TextBox runat="server" ID="TxtHora" TextMode="Time" CssClass="form-control" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:CustomValidator ID="CustomValidator2" runat="server"
                    ControlToValidate="TxtHora"
                    ErrorMessage="Seleccionar una hora entre las 8:00 y las 20:00"
                    ForeColor="Red"
                    OnServerValidate="CustomValidator2_ServerValidate" />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="TxtHora"
                    ErrorMessage="Hora is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>
            <br />

            <div class="form-group">
                <label for="DDEspecialidades" class="text-info">Especialidad Medica: </label>
                <asp:DropDownList ID="DDEspecialidades" class="text-info" runat="server" OnSelectedIndexChanged="DDEspecialidades_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <br />
            <br />
            <div class="form-group">
                <label for="DDMedicos" class="text-info">Medico: </label>
                <asp:DropDownList ID="DDMedicos" class="text-info" runat="server"></asp:DropDownList>
            </div>
            <br />
            <asp:Button ID="BtnConfirmar" runat="server" Text="Confirmar" class="btn btn-info btn-md" OnClick="BtnConfirmar_Click" />
        </div>
    </div>

</asp:Content>
