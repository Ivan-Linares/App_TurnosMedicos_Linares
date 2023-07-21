<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="App_TurnosMedicos_Linares.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row">
            <div class="col-md-auto">
                <div>
                    <asp:Label runat="server" Text="Hola "></asp:Label>
                    <asp:Label ID="ApeNom" runat="server" Text=""></asp:Label>
                    <asp:Label runat="server" Text="  | DNI: "></asp:Label>
                    <asp:Label ID="LbDni" runat="server" Text="Label"></asp:Label>
                    <asp:Label runat="server" Text="  | Email: "></asp:Label>
                    <asp:Label ID="LbEmail" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Lbcob" runat="server" Text="  | Cobertura: " Visible="false"></asp:Label>
                    <asp:Label ID="LbCobertura" runat="server" Text="Label" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="container-lg">
        <div id="carouselExample" class="carousel slide">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="Images/TurnoOnline.PNG" class="d-block w-100" style="height: 500px;" />
                </div>
                <div class="carousel-item active">
                    <img src="Images/Bienvenida.PNG" class="d-block w-100" style="height: 500px;" />
                </div>
            </div>

            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>

        </div>
    </div>
    <br />
    <br />
    <div class="container text-center">
        <div class="row justify-content-md-center">
            <div class="col col-lg-2">
                <div>
                    <asp:Button ID="BtnAgendar" class="btn btn-primary" runat="server" Text="Agendar turnos!" OnClick="BtnAgendar_Click" />
                </div>
            </div>

            <div class="col col-lg-2">
                <div>
                    <asp:Button ID="BtnGestionar" class="btn btn-primary" runat="server" Text="Gestionar mis turnos!" OnClick="BtnGestionar_Click" />
                </div>
            </div>
        </div>
    </div>
    <%--    <div class="container text-center">
        <div class="row">
            <div class="col-md-auto">
                <div>
                    <asp:Label runat="server" Text="Nro Usuario: "></asp:Label>
                    <asp:Label ID="LbIDUsuario" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="row justify-content-md-center">
        <div class="col-md-auto">
           
            <div>
                <asp:Label runat="server" Text="DNI: "></asp:Label>
                <asp:Label ID="LbDni" runat="server" Text="Label"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Nombre: "></asp:Label>
                <asp:Label ID="LbNombre" runat="server" Text="Label"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Apellido: "></asp:Label>
                <asp:Label ID="LbApellido" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <div class="col-md-auto">
            <div>
                <asp:Label runat="server" Text="Email: "></asp:Label>
                <asp:Label ID="LbEmail" runat="server" Text="Label"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Domicilio: "></asp:Label>
                <asp:Label ID="LbDomicilio" runat="server" Text="Label"></asp:Label>
            </div>
            <div>
                <asp:Label runat="server" Text="Telefono: "></asp:Label>
                <asp:Label ID="LbTelefono" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="col-md-auto">
            <div>
                <asp:Label runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                <asp:Label ID="LbFechaNac" runat="server" Text="Label"></asp:Label>
            </div>
            <div>
                <asp:Label ID="Lbcob" runat="server" Text="Cobertura: " Visible="false"></asp:Label>
                <asp:Label ID="LbCobertura" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
        </div>
    </div>--%>
</asp:Content>
