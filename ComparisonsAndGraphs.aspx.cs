using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization;
using System.Web.Helpers;

namespace RetirementBuddy
{
    public partial class ComparisonsAndGraphs : Page
    {
        RetirementPlansSingleton listOfPlans = RetirementPlansSingleton.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (RetirementPlan plan in listOfPlans.Plans)
            {
                plan.FillChartData();
                RetirementSavingsChart.Series.Add(plan.Scenario);
                RetirementSavingsChart.Legends.Add(plan.Scenario);
                int[] age = listOfPlans.Plans[i].retirementSavings.Keys.ToArray();
                decimal[] savings = listOfPlans.Plans[i].retirementSavings.Values.ToArray();
                RetirementSavingsChart.Series[i].Points.DataBindXY(age, savings);
                RetirementSavingsChart.Series[i].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                RetirementSavingsChart.Legends.ToString();
                RetirementSavingsChart.Legends[i].Enabled = true;
                i++;

                //retirementSavingChart.AddSeries(chartType: "line",
                //xField: "Age", yFields: "Savings",
                //xValue: age, yValues: savings
                //);
            }
        }
    }
}