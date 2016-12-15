<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebServices.aspx.cs" Inherits="AirlineApp.WebServices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<h2>Web Services</h2>
    <table>
        <tr>
            <td><asp:Label ID="lblGetAll" runat="server" Text="Get All Data"></asp:Label></td>
            <td><asp:Button ID="btnGetAll" runat="server" Text="Click Here" OnClick="btnGetAll_Click" /></td>
        </tr>
        <tr>
             <td><asp:Label ID="lblOrigin" runat="server" Text="Origin"></asp:Label></td>
             <td><asp:TextBox ID="txtOrigin" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
             <td><asp:Label ID="lblDestination" runat="server" Text="Destination"></asp:Label></td>
             <td><asp:TextBox ID="txtDestination" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <asp:GridView ID="gvWSAirlines" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                              <asp:Label ID="lblWSId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblWSName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Origin">
                        <ItemTemplate>
                            <asp:Label ID="lblWSOrigin" runat="server" Text='<%#Eval("origin") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Destination">
                        <ItemTemplate>
                            <asp:Label ID="lblWSDestination" runat="server" Text='<%#Eval("destination") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Class">
                        <ItemTemplate>
                            <asp:Label ID="lblWSClass" runat="server" Text='<%#Eval("class") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cost">
                        <ItemTemplate>
                            <asp:Label ID="lblWSCost" runat="server" Text='<%#Eval("cost") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </tr>

   </table>
</asp:Content>
