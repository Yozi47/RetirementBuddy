<%@ Page Title="Comparisons And Graphs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComparisonsAndGraphs.aspx.cs" Inherits="RetirementBuddy.ComparisonsAndGraphs" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>This page shows the comparisons between the plans you entered.</h3>

    <div style="height: 300px; width: 1072px">
        <asp:Chart ID="RetirementSavingsChart" runat="server" Width="697px">
            <%--<Series>
                <asp:Series Name ="S1"></asp:Series>
            </Series>--%>
            <%--<ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>--%>
            <BorderSkin SkinStyle="Emboss" />
        </asp:Chart>
<%--        <asp:Chart ID="RetirementSavingsChart" runat="server" />--%>
    </div>
    <div style="height: 300px; width: 1072px">
        <asp:Chart ID="YearlyIncomeChart" runat="server" Width="697px">
            <%--<Series>
                <asp:Series Name ="S1"></asp:Series>
            </Series>--%>
            <%--<ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>--%>
            <BorderSkin SkinStyle="Emboss" />
        </asp:Chart>    </div>
    <div style="height: 300px; width: 1072px">
        <asp:Chart ID="SavingSizeBar" runat="server" Width="697px" Height="292px">
            <%--<Series>
                <asp:Series Name ="S1"></asp:Series>
            </Series>--%>
            <%--<<%--ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>--%>
            <BorderSkin SkinStyle="Emboss" />
        </asp:Chart>    
    </div>
    <div style="width: 707px">
        <div style="width: 288px; margin-left: 131px">
        <asp:Button ID="SeeRetirementTablesButton" runat="server" Text="See all Retirement Tables" OnClick="SeeRetirementTablesButton_Click" />
        </div>
    </div>

    <div style="margin-top: 10px;">
        <asp:Panel ID="GridViewPanel" runat="server"></asp:Panel>   
        </div>     
</asp:Content>
