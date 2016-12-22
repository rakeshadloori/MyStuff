<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WcfwsHttpBinding.aspx.cs" Inherits="AirlineApp.WcfwsHttpBinding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <br />
    <h2>Airlines</h2>
     <table>
        <tr>
            <td>Airline</td>
            <td>
                <asp:TextBox ID="txtAirline" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Origin</td>
            <td>
                <asp:TextBox ID="txtOrigin" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Desination</td>
            <td>
                <asp:TextBox ID="txtDestination" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Class</td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>Cost</td>
            <td>
                <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="108px" OnClick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Reset" Width="129px" />
            </td>
        </tr>
       <tr>
           <td>
               <asp:HiddenField ID="hdnAid" runat="server"/>
               <asp:HiddenField ID="hdnIsSave" Value="0" runat="server" />

           </td>
       </tr>
         <tr>
             <asp:GridView ID="gvWCFAirlines" runat="server" AutoGenerateColumns="false">
                 <Columns>
                                         <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbAid" runat="server" Text='<%#Eval("id") %>'
                                Aid ='<%#Eval("id") %>' Name ='<%#Eval("name") %>' Origin ='<%#Eval("origin") %>'
                                Destination ='<%#Eval("destination") %>' Cost ='<%#Eval("cost") %>' Class ='<%#Eval("class") %>'
                                OnCommand="lbAid_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Origin">
                        <ItemTemplate>
                            <asp:Label ID="lblOrigin" runat="server" Text='<%#Eval("origin") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Destination">
                        <ItemTemplate>
                            <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("destination") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Class">
                        <ItemTemplate>
                            <asp:Label ID="lblClass" runat="server" Text='<%#Eval("class") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cost">
                        <ItemTemplate>
                            <asp:Label ID="lblCost" runat="server" Text='<%#Eval("cost") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="Content/delete.png" OnCommand="ibDelete_Command" ID="ibDelete" runat="server" Aid='<%#Eval("id") %>' Height="30px" Width="32px" ></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                 </Columns>

             </asp:GridView>
         </tr>
    </table>

</asp:Content>
