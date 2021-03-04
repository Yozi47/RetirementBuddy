<%@ Page Title="ComparisonsAndGraphs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComparisonsAndGraphs.aspx.cs" Inherits="RetirementBuddy.ComparisonsAndGraphs" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <div style="height: 300px; width: 1072px">
        <asp:Chart ID="RetirementSavingsChart" runat="server">
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
<%--        <asp:Chart ID="RetirementSavingsChart" runat="server" />--%>
    </div>
    <div style="height: 300px; width: 1072px">
        <asp:Image ID="YearlyIncomeChart" runat="server" />
    </div>
    <div style="height: 300px; width: 1072px">
        <asp:Image ID="ColumnChartTotalRetirementAmount" runat="server" />
    </div>
</asp:Content>
