using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restest.Models
{
    public class General
    {
        public class RunTimeItems : TestingUtilities.Models.General.RunTimeItems
        {
            public string Release { get; set; }
            public string Build { get; set; }
            public string OrgsEnvShortName { get; set; }
            public string Org_Name { get; set; }

            public TestingUtilities.Models.TestingObjects.RunItems RI { get; set; }

            public RunTimeItems(TestingUtilities.Models.TestingObjects.RunItems run)
            {
                this.LWBuild_IDNumber = run.LWBuild_IDNUM;
                this.LWVersion_IDNumber = run.LWVersion_IDNUM;
                this.Release = run.Release;
                this.Build = run.Build;
                this.OrgsEnvShortName = run.OrgsEnvShortName;
                this.Org_Name = run.Org_Name;
                this.RI = run;
            }
        }
    }
}
