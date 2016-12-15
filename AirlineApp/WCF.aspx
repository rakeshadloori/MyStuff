<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WCF.aspx.cs" Inherits="AirlineApp.WCF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2>WCF</h2>
    <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
    <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
    <asp:Button ID="btnGetWeather" runat="server" Text="Get Data" OnClick="btnGetWeather_Click" /><br />
    <h5><asp:Label ID="lblResult" runat="server" Text=""></asp:Label></h5>
</asp:Content>
