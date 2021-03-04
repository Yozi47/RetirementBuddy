using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetirementBuddy
{
    public sealed class RetirementPlansSingleton
    {
        public List<RetirementPlan> Plans = new List<RetirementPlan>();
        private static RetirementPlansSingleton instance;

        private RetirementPlansSingleton() { }
        static RetirementPlansSingleton()
        {
            RetirementPlansSingleton.instance = new RetirementPlansSingleton();
        }

        public static RetirementPlansSingleton Instance
        {
            get
            {
                return RetirementPlansSingleton.instance;
            }
        }

        public void Save(RetirementPlan aPlan)
        {
            Plans.Add(aPlan);
        }
    }
}