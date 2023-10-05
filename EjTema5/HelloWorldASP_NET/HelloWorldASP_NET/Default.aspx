<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloWorldASP_NET._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
        

        <main>

            <p>
                <asp:Label ID="Label1" runat="server" Text="Introduzca su nombre "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </p>


            <p>
                 <asp:Button ID="Button1" runat="server" Text="Entrar" OnClick="Button1_Click" />

            </p>
       
            <p>

             <asp:Label ID="lblSaludo" runat="server" Text=""></asp:Label>

                <asp:Label ID="error" runat="server" Text=""></asp:Label>

            </p>
        </main>


</asp:Content>
