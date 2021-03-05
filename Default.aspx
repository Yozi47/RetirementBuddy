<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RetirementBuddy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 971px; width: 810px; margin-left: 15%; margin-top: 20px; margin-right: 15%;">
      
        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label1" runat="server" Text="Your Name"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="NameBox" runat="server" Height="20px" Width="176px" OnTextChanged="NameBox_TextChanged" ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label4" runat="server" Text="Your Age"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="AgeBox" runat="server" Height="20px" Width="176px" OnTextChanged="AgeBox_TextChanged" ></asp:TextBox>
        </div>
        </div>


        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label8" runat="server" Text="Scenario Name/No."></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="ScenarioBox" runat="server" Height="20px" Width="176px" TextMode="SingleLine" OnTextChanged="ScenarioBox_TextChanged" ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label10" runat="server" Text="Your Nest Egg"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="NestEggBox" runat="server" Height="20px" Width="176px" OnTextChanged="NestEggBox_TextChanged" ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label11" runat="server" Text="Rate of Return(avg. %)"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="RoRAvgBox" runat="server" Height="20px" Width="176px" OnTextChanged="RoRAvgBox_TextChanged"  ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label12" runat="server" Text="Current Salary"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="CurrentSalaryBox" runat="server" Height="20px" Width="176px" OnTextChanged="CurrentSalaryBox_TextChanged" ></asp:TextBox>
        </div>
        </div>

        <div style="height: 88px; width: 443px; margin-top: 0px;">
        <div style="height: 19px; width: 160px; margin-left: 9px; margin-top: 15px;">
            <asp:Label ID="Label13" runat="server" Text="Yearly Contribution"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="YearlyContriBox" runat="server" Height="20px" Width="176px" OnTextChanged="YearlyContriBox_TextChanged" ></asp:TextBox>
        </div>
        <div style="height: 25px; margin-top: 25px; width: 176px; margin-left: 83px;">          
            <asp:CheckBox ID="PercentageCheckBox" runat="server" Text=" Apply as percentage? " AutoPostBack="True" TextAlign="Left" OnCheckedChanged="PercentageCheckBox_CheckedChanged" />
        </div>

        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label9" runat="server" Text="Every Year Salary Inc. by(%)"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="SalaryIncrementPercentageBox" runat="server" Height="20px" Width="176px" OnTextChanged="SalaryIncrementPercentageBox_TextChanged"  ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
             <asp:Label ID="Label2" runat="server" Text="Planned Retirement Age"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="RetirementAgeBox" runat="server" Height="20px" Width="176px" OnTextChanged="RetirementAgeBox_TextChanged"   ></asp:TextBox>
        </div>
        </div>


        <div style="height: 50px; margin-top: 0px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label3" runat="server" Text="Retirement Salary"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="RetirementSalaryBox" runat="server" Height="20px" Width="176px" OnTextChanged="RetirementSalaryBox_TextChanged"   ></asp:TextBox>
        </div>
        </div>


        <div style="height: 80px; width: 443px;">
        <div style="height: 25px; margin-top: 9px; width: 345px; margin-left: 40px;">          
            <asp:CheckBox ID="DontSlowDownExpensesCheckBox" runat="server" Text=" Don't Slow down expenses after Active ages? " AutoPostBack="True" TextAlign="Left" OnCheckedChanged="DontSlowDownExpensesCheckBox_CheckedChanged" />
        </div>
        <div style="height: 20px; width: 160px; margin-left: 9px; margin-top: 14px;">
            <asp:Label ID="LessActiveAgeLabel" runat="server" Text="Less active at age:"></asp:Label>           
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="LessActiveAgeBox" runat="server" Height="20px" Width="176px" OnTextChanged="LessActiveAgeBox_TextChanged"  ></asp:TextBox>
            
        </div>
        </div>


         <div style="height: 60px; width: 443px;">
        <div style="height: 23px; width: 160px; margin-left: 9px; margin-top: 19px;">
                <asp:Label ID="LessActiveStartingSalaryLabel" runat="server" Text="Starting Salary after Less active age"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="LessActiveStartingSalaryBox" runat="server" Height="20px" Width="176px" OnTextChanged="LessActiveStartingSalaryBox_TextChanged"  ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
                <asp:Label ID="Label14" runat="server" Text="Inflation Rate(%)"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="InflationRateBox" runat="server" Height="20px" Width="176px" OnTextChanged="InflationRateBox_TextChanged"  ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
                <asp:Label ID="Label15" runat="server" Text="SSA COLA Infl. Rate(%)"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="ColaInflRateBox" runat="server" Height="20px" Width="176px" OnTextChanged="ColaInflRateBox_TextChanged"  ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px; width: 443px;">
        <div style="height: 29px; width: 160px; margin-left: 9px; margin-top: 19px;">
                <asp:Button ID="TotalRetirementBalanceButton" runat="server" Text="Show Ret. Balance" Height="27px" Width="146px" OnClick="TotalRetirementBalanceButton_Click" />
        </div>
        <div style="height: 0px; margin-top: -28px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="RetirementBalanceBox" runat="server" Height="20px" Width="176px"></asp:TextBox>
        </div>
        </div>

        <div style="margin-left: 440px; margin-top: -700px; height: 703px;">
            <div style="height: 227px; width: 342px; margin-left: 16px; margin-top: 40px;">
              
                <p id ="P1" runat="server" style="background-color:aliceblue; height: 54px;" visible ="false"></p>
                
                <div style="width: 327px; margin-top: 66px; height: 499px; margin-left: 7px;">
                    <asp:Button ID="SeeComparisonsAndGraphsButton" runat="server" Text="See Comparisons and Graph" Height="38px" Width="314px" OnClick="SeeComparisonsAndGraphsButton_Click" visible ="false"/>
                </div>
            

            </div>
        </div>


        <div style="height: 50px">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 10px;">
                <asp:Label ID="Label6" runat="server" Text="Additional Payments"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="AdditionalPaymentsBox" runat="server" Height="20px" Width="176px" OnTextChanged="AdditionalPaymentsBox_TextChanged" ></asp:TextBox>
        </div>
        <div style="height: 21px; width: 96px; margin-left: 443px; margin-top: -20px;">
            <asp:Label ID="AtYearLabel" runat="server" Text="At Year : "></asp:Label>
            </div>
        <div style="height: 0px; margin-top: -22px; width: 101px; margin-left: 550px;">          
            <asp:TextBox ID="AtYearBox" runat="server" Height="20px" Width="83px" OnTextChanged="AtYearBox_TextChanged"  ></asp:TextBox>
        </div>
        </div>


        <div style="height: 35px">
            <div style="height: 30px; margin-top: 4px; width: 223px; margin-left: 200px;">          
                <asp:CheckBox ID="IncEveryYearCheckBox" runat="server" Text=" Increment Every Year" AutoPostBack="True" OnCheckedChanged="IncEveryYearCheckBox_CheckedChanged" />
            </div>
        </div>


        <div style=" height: 35px;">
            <div style="width: 184px; margin-top: 8px; height: 25px; margin-left: 7px;">
                <asp:Button ID="SaveButton" runat="server" Text="Save Scenario" Height="27px" Width="164px" OnClick="SaveButton_Click" />
            </div>
            <div style="width: 184px; margin-top: -24px; height: 25px; margin-left: 228px;">
                <asp:Button ID="ResetButton" runat="server" Text="Reset" Height="27px" Width="164px" OnClick="ResetButton_Click"/>
            </div>
        </div>        

         

    </div>
</asp:Content>
