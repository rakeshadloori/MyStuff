<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="AirlineApp.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        th, td{
            padding: 8px;
        }
    </style>
    <br /> 
    <table>
        <tr>
            <td>Name</td>
            <td>
                <input type="text" id="txtName"/>
        </tr>
        <tr>
            <td>Origin</td>
            <td>
                <input type="text" id="txtOrigin"/>
        </tr>
        <tr>
            <td>Destination</td>
            <td>
                <input type="text" id="txtDestination"/> 
            </td>       
        </tr>
        <tr>
            <td>Cost</td>
            <td>
                <input type="text" id="txtCost"/>       
            </td>
        </tr>

    </table> 
     <div>
        <button id="btnGet" />Save
    </div><br />
    <div id="Result1">

    </div>
    <script>
        $("#btnGet").click(function (e) {
            e.preventDefault();
            $("#Result1").empty();
            var table = "<table><th>Name</th><th>Origin</th><th>Destination</th><th>Cost</th><th>Class</th>";


            var name1 = $("#txtName").val();
            var origin1 = $("#txtOrigin").val();
            var destination1 = $("#txtDestination").val();
            var cost1 = $("#txtCost").val();
            //alert(name1 + origin1 + destination1 + cost1);
            if (name1 == "" || origin1 == "" || destination1 == "" || cost1 == "") {
                alert("Please enter details");
            }
            else{
                var airlineData = { "id": 1, "name": name1, "origin": origin1, "destination": destination1, "cost": cost1, "classid": 1 };
                //alert(airlineData);
                $.ajax({
                    type: "POST",
                    data: JSON.stringify(airlineData),
                    url: "http://localhost:60381/api/airline/postDetails",
                    contentType: "application/json"
                
                })
                .done(function (res) {
                    var obj = jQuery.parseJSON(res);
                    var len = Object.keys(obj).length;
                   console.log(obj.length);

                    for (var i = 0; i < len; i++) {
                        table += "<tr><td>" + obj[i].name + "</td><td>" + obj[i].origin + "</td><td>" + obj[i].destination + "</td><td>" + obj[i].cost + "</td><td>" + obj[i].class + "</td></tr>";
                    }
                    table += "</table>";
                    $("#Result1").append(table);


                });


            }
       })
    </script>
</asp:Content>
