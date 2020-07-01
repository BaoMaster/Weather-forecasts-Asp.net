<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Weather1._0._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="jumbotron">




        <h1>Weather forecasts</h1>
             <p class="lead">Select the city name to know the weather at that location</p>
        <p><asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="65px">
            <asp:ListItem>City</asp:ListItem>
            <asp:ListItem>ZIP</asp:ListItem>
            <asp:ListItem>ID</asp:ListItem>
            
            

        </asp:DropDownList>
           <%-- <input id="bao" type="text" runat="server" style="height:30px;width:200px"/></p>--%>
        <asp:TextBox ID="bao" runat="server" ></asp:TextBox>
       <p><button id="btnLogin" type="submit" value="sign" runat="server" onserverclick="login_click" class="btn btn-primary btn-lg">Search &raquo;</button></p>
    </div>

    <div class="row" style="border:solid 1px;background-color:#ff6a00">
        <div class="col-md-4" style="border:solid 1px">
            
            
                <span style="font-size:large">Location: </span>
                 <span ID="txtCity" runat="server" style="font-size:medium"></span>
        <span ID="txtCountry" runat="server" style="font-size:medium"></span><br />
                
            
            
                 <span style="font-size:large">TimeZone: </span>
                <span ID="txtTimeZone" runat="server" style="font-size:medium"></span>
            
            <p>
                <span style="font-size:large">Latitude: </span>
                <span ID="txtLat" runat="server" style="font-size:medium"></span><br />
                <span style="font-size:large">Longitude: </span>
                <span ID="txtLong" runat="server" style="font-size:medium"></span><br />
                <span style="font-size:large">ID: </span>
                 <span ID="txtId" runat="server" style="font-size:medium"></span><br />
             
              
            </p>
      
     
            </div>
       
        
        <div class="col-md-4" style="border:solid 1px">
             <div style="height:50px; width:50px; margin-left:auto;margin-right:auto;background: url( '<%=vari  %>');background-size: cover;"></div>
            <p>
                <span ID="cloud" runat="server" style="font-size:large"></span>
                <span ID="ValCloud" runat="server" style="font-size:medium"></span><br />
                <span style="font-size:large">Humidity: </span>
                 <span ID="hum" runat="server" style="font-size:medium"></span><br />
                   <span style="font-size:large">Time Update: </span>
                 <span id="timee" runat="server" style="font-size:medium"></span>
            </p>
           
           
        </div>
       <div class="col-md-4" style="border:solid 1px">
            <span style="font-size:large">Wind Direction: </span>
            <span ID="windDe" runat="server" style="font-size:medium"></span>
            <span ID="windS" runat="server" style="font-size:medium"></span><br />
            <span style="font-size:large">Wind Speed: </span>
        <span ID="windspeed" runat="server" style="font-size:medium"></span><br />
           <p>
                <span style="font-size:large">Temperature: </span>
            <span ID="temp" runat="server" style="font-size:medium"></span><br />
           <span style="font-size:large">Feel like: </span>
            <span ID="feel" runat="server" style="font-size:medium"></span><br />
           <span style="font-size:large">Pressure: </span>
            <span ID="press" runat="server" style="font-size:medium"></span>
           
            </p>
             
       </div>
        
       
    </div>



 

</asp:Content>
