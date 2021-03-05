using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization;
using System.Web.Helpers;
using System.Web.UI.WebControls;

namespace RetirementBuddy
{
    public partial class ComparisonsAndGraphs : Page
    {
        RetirementPlansSingleton listOfPlans = RetirementPlansSingleton.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            RetirementSavingsChart.Titles.Add("Retirement Savings Chart");
            RetirementSavingsChart.Titles[0].Text = "Retirement Savings Chart";
            RetirementSavingsChart.ChartAreas.Add("Retirement Savings Chart");
            RetirementSavingsChart.ChartAreas["Retirement Savings Chart"].AxisX.Title = "Age";
            RetirementSavingsChart.ChartAreas["Retirement Savings Chart"].AxisY.Title = "Amount in $";
            RetirementSavingsChart.ChartAreas[0].AxisX.Interval = 10;

            YearlyIncomeChart.Titles.Add("Yearly Income Chart");
            YearlyIncomeChart.Titles[0].Text = "Retirement Yearly Income Chart";
            YearlyIncomeChart.ChartAreas.Add("Yearly Income Chart");
            YearlyIncomeChart.ChartAreas["Yearly Income Chart"].AxisX.Title = "Age";
            YearlyIncomeChart.ChartAreas["Yearly Income Chart"].AxisY.Title = "Amount in $";
            YearlyIncomeChart.ChartAreas[0].AxisX.Interval = 10;

            SavingSizeBar.Titles.Add("Total Retirement Savings Bars");
            SavingSizeBar.Titles[0].Text = "Total Retirement Savings Bars";
            SavingSizeBar.ChartAreas.Add("Total Retirement Savings Bars");
            SavingSizeBar.ChartAreas["Total Retirement Savings Bars"].AxisX.Title = "Plans";
            SavingSizeBar.ChartAreas["Total Retirement Savings Bars"].AxisY.Title = "Amount in $";
            SavingSizeBar.ChartAreas[0].AxisY.Interval = 100000;

            int i = 0;
            foreach (RetirementPlan plan in listOfPlans.Plans)
            {
                if (!(plan.retirementSavings.Count > 0))
                {
                    plan.FillChartData();
                }
                RetirementSavingsChart.Series.Add(plan.Scenario);
                RetirementSavingsChart.Series[i].BorderWidth = 4;
                RetirementSavingsChart.Legends.Add(plan.Scenario);
                int[] age = listOfPlans.Plans[i].retirementSavings.Keys.ToArray();
                decimal[] savings = listOfPlans.Plans[i].retirementSavings.Values.ToArray();
                RetirementSavingsChart.Series[i].Points.DataBindXY(age, savings);
                RetirementSavingsChart.Series[i].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                RetirementSavingsChart.Legends.ToString();
                RetirementSavingsChart.Legends[i].Enabled = true;

                YearlyIncomeChart.Series.Add(plan.Scenario);
                YearlyIncomeChart.Series[i].BorderWidth = 4;
                YearlyIncomeChart.Legends.Add(plan.Scenario);
                int[] age1 = listOfPlans.Plans[i].retirementYearlyIncome.Keys.ToArray();
                decimal[] savings1 = listOfPlans.Plans[i].retirementYearlyIncome.Values.ToArray();
                YearlyIncomeChart.Series[i].Points.DataBindXY(age1, savings1);
                YearlyIncomeChart.Series[i].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                YearlyIncomeChart.Legends.ToString();
                YearlyIncomeChart.Legends[i].Enabled = true;

                SavingSizeBar.Series.Add(plan.Scenario);
                SavingSizeBar.Legends.Add(plan.Scenario);
                decimal savings2 = listOfPlans.Plans[i].CalculateTotalRetirementBalance();
                SavingSizeBar.Series[i].Points.AddY(savings2);
                SavingSizeBar.Series[i].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                SavingSizeBar.Legends.ToString();
                SavingSizeBar.Legends[i].Enabled = true;
                i++;

                //retirementSavingChart.AddSeries(chartType: "line",
                //xField: "Age", yFields: "Savings",
                //xValue: age, yValues: savings
                //);
            }
        }

        protected void SeeRetirementTablesButton_Click(object sender, EventArgs e)
        {
            if(GridViewPanel.Controls.Count == 0)
            {
                foreach (RetirementPlan plan in listOfPlans.Plans)
                {
                    Literal label = new Literal
                    {
                        ID = plan.Scenario,
                        Text = plan.Scenario
                    };
                    GridView view = new GridView
                    {
                        ID = plan.Scenario,
                        DataSource = plan.GenerateTable()
                    };
                    view.DataBind();

                    GridViewPanel.Controls.Add(label);
                    GridViewPanel.Controls.Add(view);
                }
            }
            
        }
    }
}