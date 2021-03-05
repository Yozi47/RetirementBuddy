using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace RetirementBuddy
{
    public partial class _Default : Page
    {
        readonly RetirementPlansSingleton ListOfPlans = RetirementPlansSingleton.Instance;
        string name;
        int age;
        decimal nestEgg;
        double rOR;
        decimal currentSalary;
        decimal yearlyContribution;
        bool percentageCheck;
        double salaryIncrementPrecentage;
        int retirementAge;
        decimal retirementSalary;
        bool dontSlowDownExpensesCheck;
        int lessActiveAge;
        decimal lessActiveStartingSalary;
        double inflationRate;
        double cOLA_InflationRate;
        decimal retirementBalance;
        decimal additionalPayment;
        int atYear;
        bool incrementEveryYearCheck;

        string scenario;
        RetirementPlan aPlan ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Validate();
            }
            else
            {
                if (Session["Name"] != null)
                {
                    name = Session["Name"].ToString();
                }
                if (Session["Age"] != null)
                {
                    age = int.Parse(Session["Age"].ToString());
                }

                if (Session["Scenario"] != null)
                {
                    scenario = Session["Scenario"].ToString();
                }

                if (Session["NestEgg"] != null)
                {
                    nestEgg = Decimal.Parse(Session["NestEgg"].ToString());
                }

                if (Session["RoR"] != null)
                {
                    rOR = double.Parse(Session["RoR"].ToString());
                }

                if (Session["CurrentSalary"] != null)
                {
                    currentSalary = Decimal.Parse(Session["CurrentSalary"].ToString());

                }
                if (Session["YearlyContribution"] != null)
                {
                    yearlyContribution = Decimal.Parse(Session["YearlyContribution"].ToString());

                }

                if (Session["PercentageCheck"] != null)
                {
                    percentageCheck = Convert.ToBoolean(Session["PercentageCheck"]);

                }

                if (Session["RetirementAge"] != null)
                {
                    retirementAge = int.Parse(Session["RetirementAge"].ToString());
                }

                if (Session["SalaryIncrement%"] != null)
                {
                    salaryIncrementPrecentage = double.Parse(Session["SalaryIncrement%"].ToString());

                }
                if (Session["RetirementSalary"] != null)
                {
                    retirementSalary = Decimal.Parse(Session["RetirementSalary"].ToString());

                }

                if (Session["DontSlowDownExpensesCheck"] != null)
                {
                    dontSlowDownExpensesCheck = Convert.ToBoolean(Session["DontSlowDownExpensesCheck"]);
                }

                if (Session["LessActiveAge"] != null)
                {
                    lessActiveAge = int.Parse(Session["LessActiveAge"].ToString());
                }
                if (Session["LessActiveStartingSalary"] != null)
                {
                    lessActiveStartingSalary = decimal.Parse(Session["LessActiveStartingSalary"].ToString());
                }

                if (Session["InflationRate"] != null)
                {
                    inflationRate = double.Parse(Session["InflationRate"].ToString());
                }

                if (Session["COLAInflationRate"] != null)
                {
                    cOLA_InflationRate = double.Parse(Session["COLAInflationRate"].ToString());
                }

                if (Session["RetirementBalance"] != null)
                {
                    retirementBalance = decimal.Parse(Session["RetirementBalance"].ToString());
                }

                if (Session["AdditionalPayment"] != null)
                {
                    additionalPayment = Decimal.Parse(Session["AdditionalPayment"].ToString());

                }
                if (Session["AtYear"] != null)
                {
                    atYear = int.Parse(Session["AtYear"].ToString());

                }

                if (Session["IncrementEveryYearCheck"] != null)
                {
                    incrementEveryYearCheck = Convert.ToBoolean(Session["IncrementEveryYearCheck"]);

                }
            }
            
            
        }
        protected void NameBox_TextChanged(object sender, EventArgs e)
        {
            // ***** Double check at some point *****

            Session["Name"] = NameBox.Text;
            name = Session["Name"].ToString();
        }

        protected void AgeBox_TextChanged(object sender, EventArgs e)
        {
            Session["Age"] = AgeBox.Text;
            if (!int.TryParse(Session["Age"].ToString(), out age))
            {
                //Default Values
                Session["Age"] = 0;
                age = 0;
            }
        }


        protected void ScenarioBox_TextChanged(object sender, EventArgs e)
        {
            Session["Scenario"] = ScenarioBox.Text;
            scenario = Session["Scenario"].ToString();
        }

        protected void NestEggBox_TextChanged(object sender, EventArgs e)
        {
            Session["NestEgg"] = NestEggBox.Text;
            if (!decimal.TryParse(Session["NestEgg"].ToString(), out nestEgg))
            {
                //Default Values
                Session["NestEgg"] = 0;
                nestEgg = 0;
            }
        }

        protected void RoRAvgBox_TextChanged(object sender, EventArgs e)
        {
            Session["RoR"] = RoRAvgBox.Text;
            if (!double.TryParse(Session["RoR"].ToString(), out rOR))
            {
                //Default Values
                Session["RoR"] = 0;
                rOR = 0;
            }
        }

        protected void CurrentSalaryBox_TextChanged(object sender, EventArgs e)
        {
            Session["CurrentSalary"] = CurrentSalaryBox.Text;
            if (!decimal.TryParse(Session["CurrentSalary"].ToString(), out currentSalary))
            {
                //Default Values
                Session["CurrentSalary"] = 0;
                currentSalary = 0;
            }
        }

        protected void YearlyContriBox_TextChanged(object sender, EventArgs e)
        {
            Session["YearlyContribution"] = YearlyContriBox.Text;
            if (!decimal.TryParse(Session["YearlyContribution"].ToString(), out yearlyContribution))
            {
                //Default Values
                Session["YearlyContribution"] = 0;
                yearlyContribution = 0;
            }
        }

        protected void PercentageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Session["PercentageCheck"] = PercentageCheckBox.Checked;
            percentageCheck = Convert.ToBoolean(Session["PercentageCheck"]);
            if (percentageCheck)
            {
                if(yearlyContribution > 100)
                {
                    YearlyContriBox.Text = "Put a valid Percentage";
                }
            }
            else
            {
                YearlyContriBox.Text = Session["YearlyContribution"].ToString();
            }

        }

        protected void SalaryIncrementPercentageBox_TextChanged(object sender, EventArgs e)
        {
            Session["SalaryIncrement%"] = SalaryIncrementPercentageBox.Text;
            if (!double.TryParse(Session["SalaryIncrement%"].ToString(), out salaryIncrementPrecentage))
            {
                //Default Values
                Session["SalaryIncrement%"] = 0;
                salaryIncrementPrecentage = 0;
            }
        }

        protected void RetirementAgeBox_TextChanged(object sender, EventArgs e)
        {
            Session["RetirementAge"] = RetirementAgeBox.Text;
            if (!int.TryParse(Session["RetirementAge"].ToString(), out retirementAge))
            {
                //Default Values
                Session["RetirementAge"] = 0;
                retirementAge = 0;
            }
        }

        protected void RetirementSalaryBox_TextChanged(object sender, EventArgs e)
        {
            Session["RetirementSalary"] = RetirementSalaryBox.Text;
            if (!decimal.TryParse(Session["RetirementSalary"].ToString(), out retirementSalary))
            {
                //Default Values
                Session["RetirementSalary"] = 0;
                retirementSalary = 0;
            }
        }

        protected void DontSlowDownExpensesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Session["DontSlowDownExpensesCheck"] = DontSlowDownExpensesCheckBox.Checked;
            dontSlowDownExpensesCheck = Convert.ToBoolean(Session["DontSlowDownExpensesCheck"]);
            if (dontSlowDownExpensesCheck)
            {
                LessActiveAgeBox.Visible = false;
                LessActiveAgeLabel.Visible = false;
                LessActiveAgeBox.Text = "";

                LessActiveStartingSalaryBox.Visible = false;
                LessActiveStartingSalaryLabel.Visible = false;
                LessActiveStartingSalaryBox.Text = "";
                //Session["Add at"] = 0;
                //addAt = 0;
            }
            else
            {
                LessActiveAgeBox.Visible = true;
                LessActiveAgeLabel.Visible = true;

                LessActiveStartingSalaryBox.Visible = true;
                LessActiveStartingSalaryLabel.Visible = true;
            }

        }

        protected void LessActiveAgeBox_TextChanged(object sender, EventArgs e)
        {
            Session["LessActiveAge"] = LessActiveAgeBox.Text;
            if (!int.TryParse(Session["LessActiveAge"].ToString(), out lessActiveAge))
            {
                //Default Values
                Session["LessActiveAge"] = 0;
                lessActiveAge = 0;
            }
        }

        protected void LessActiveStartingSalaryBox_TextChanged(object sender, EventArgs e)
        {
            Session["LessActiveStartingSalary"] = LessActiveStartingSalaryBox.Text;
            if (!decimal.TryParse(Session["LessActiveStartingSalary"].ToString(), out lessActiveStartingSalary))
            {
                //Default Values
                Session["LessActiveStartingSalary"] = 0;
                lessActiveStartingSalary = 0;
            }
        }

        protected void InflationRateBox_TextChanged(object sender, EventArgs e)
        {
            Session["InflationRate"] = InflationRateBox.Text;
            if (!double.TryParse(Session["InflationRate"].ToString(), out inflationRate))
            {
                //Default Values
                Session["InflationRate"] = 0;
                inflationRate = 0;
            }

        }

        protected void ColaInflRateBox_TextChanged(object sender, EventArgs e)
        {
            Session["COLAInflationRate"] = ColaInflRateBox.Text;
            if (!double.TryParse(Session["COLAInflationRate"].ToString(), out cOLA_InflationRate))
            {
                //Default Values
                Session["COLAInflationRate"] = 0;
                cOLA_InflationRate = 0;
            }

        }

        protected void TotalRetirementBalanceButton_Click(object sender, EventArgs e)
        {
            aPlan = new RetirementPlan(name, age, nestEgg, rOR, currentSalary, yearlyContribution, percentageCheck,
                                 salaryIncrementPrecentage, retirementAge, retirementSalary, dontSlowDownExpensesCheck, lessActiveAge,
                                     lessActiveStartingSalary, inflationRate, cOLA_InflationRate, retirementBalance, additionalPayment,
                                         atYear, incrementEveryYearCheck, scenario);
            RetirementBalanceBox.Text = Math.Round(aPlan.CalculateTotalRetirementBalance(),2).ToString();
            Session["RetirementBalance"] = RetirementBalanceBox.Text;
        }

        protected void AdditionalPaymentsBox_TextChanged(object sender, EventArgs e)
        {
            Session["AdditionalPayment"] = AdditionalPaymentsBox.Text;
            if (!decimal.TryParse(Session["AdditionalPayment"].ToString(), out additionalPayment))
            {
                //Default Values
                Session["AdditionalPayment"] = 0;
                additionalPayment = 0;
            }
        }

        protected void AtYearBox_TextChanged(object sender, EventArgs e)
        {
            Session["AtYear"] = AtYearBox.Text;
            if (!int.TryParse(Session["AtYear"].ToString(), out atYear))
            {
                //Default Values
                Session["AtYear"] = 0;
                atYear = 0;
            }
            
        }

        protected void IncEveryYearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Session["IncrementEveryYearCheck"] = IncEveryYearCheckBox.Checked;
            incrementEveryYearCheck = Convert.ToBoolean(Session["IncrementEveryYearCheck"]);
            if (incrementEveryYearCheck)
            {
                AtYearBox.Visible = false;
                AtYearLabel.Visible = false;
                AtYearBox.Text = "";
                //Session["Add at"] = 0;
                //addAt = 0;
            }
            else
            {
                AtYearBox.Visible = true;
                AtYearLabel.Visible = true;
            }

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            aPlan = new RetirementPlan(name, age, nestEgg, rOR, currentSalary, yearlyContribution, percentageCheck,
                                 salaryIncrementPrecentage, retirementAge, retirementSalary, dontSlowDownExpensesCheck, lessActiveAge,
                                     lessActiveStartingSalary, inflationRate, cOLA_InflationRate, retirementBalance, additionalPayment,
                                         atYear, incrementEveryYearCheck, scenario);
            
            if (aPlan.CalculateTotalRetirementBalance() > 0)
            {
                ListOfPlans.Save(aPlan);
                SeeComparisonsAndGraphsButton.Visible = true;
                P1.Visible = true;

                StringBuilder content = new StringBuilder();
                content.Append($"{aPlan.Scenario} saved.");

                P1.InnerText = content.ToString();
            }


        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            NameBox.Text = string.Empty;
            ScenarioBox.Text = string.Empty;
            NestEggBox.Text = string.Empty;
            RoRAvgBox.Text = string.Empty;
            CurrentSalaryBox.Text = string.Empty;
            YearlyContriBox.Text = string.Empty;
            PercentageCheckBox.Checked = false;

            SalaryIncrementPercentageBox.Text = string.Empty;
            RetirementAgeBox.Text = string.Empty;
            RetirementSalaryBox.Text = string.Empty;

            DontSlowDownExpensesCheckBox.Checked = false;
            LessActiveAgeBox.Text = string.Empty;
            LessActiveStartingSalaryBox.Text = string.Empty;
            InflationRateBox.Text = string.Empty;
            ColaInflRateBox.Text = string.Empty;
            RetirementBalanceBox.Text = string.Empty;
            AdditionalPaymentsBox.Text = string.Empty;
            AtYearBox.Text = string.Empty;

            IncEveryYearCheckBox.Checked = false;
            P1.Visible = false;
           

            Session.Clear();
        }

        protected void SeeComparisonsAndGraphsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComparisonsAndGraphs.aspx");
        }
    }
}

////Printing out some valueable information.
//P1.Visible = true;
//P2.Visible = true;
//P3.Visible = true;
//StringBuilder content1 = new StringBuilder();
//StringBuilder content2 = new StringBuilder();
//StringBuilder content3 = new StringBuilder();
//content1.AppendLine("Interest without additional payment = ");
//content1.Append(interestStraightWay);
//content2.AppendLine("Interest this way = ");
//content2.Append(totalInterestPaid);
//content3.AppendLine("Total saving in Interest = ");
//content3.Append(interestStraightWay - totalInterestPaid);

//P1.InnerText = content1.ToString();
//P2.InnerText = content2.ToString();
//P3.InnerText = content3.ToString();