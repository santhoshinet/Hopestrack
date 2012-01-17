using System;
using Telerik.OpenAccess;

namespace HopestrackDL
{
    [Persistent]
    public  class JobSeeker
    {
        public JobSeeker()
        {
            ResumeAttachment = new Attachment();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailID { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string OptionalEmailID { get; set; }

        public string PhoneNo { get; set; }

        public string MobileNo { get; set; }

        public string UgQualification { get; set; }

        public string UgOthers { get; set; }

        public string PgQualification { get; set; }

        public string PgOthers { get; set; }

        public string Industry { get; set; }

        public string IndustryOthers { get; set; }

        public string Functional { get; set; }

        public string FunctionalOthers { get; set; }

        public string PrimarySkillSet { get; set; }

        public string SecondarySkillSet { get; set; }

        public Double RelaventExperience { get; set; }

        public Double TotalExperience { get; set; }

        public Double NoticePeriod { get; set; }

        public Double CurrentCtc { get; set; }

        public Double ExpectedCtc { get; set; }

        public Attachment ResumeAttachment { get; set; }
    }
}