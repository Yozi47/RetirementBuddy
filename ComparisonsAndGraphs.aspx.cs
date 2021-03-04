using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;

namespace RetirementBuddy
{
    public partial class ComparisonsAndGraphs : Page
    {
        RetirementPlansSingleton listOfPlans = RetirementPlansSingleton.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Chart aChart = new Chart(300, 300);
            foreach (RetirementPlan plan in listOfPlans.Plans)
            {
                plan.FillChartData();
                int[] age = listOfPlans.Plans[0].retirementSavings.Keys.ToArray();
                decimal[] savings = listOfPlans.Plans[0].retirementSavings.Values.ToArray();
                aChart.AddSeries(chartType: "line",
                xField: "Age", yFields: "Savings",
                xValue: age, yValues: savings
                );
            }
            
            aChart.Write();
        }
    }
}