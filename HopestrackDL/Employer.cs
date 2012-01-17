using Telerik.OpenAccess;

namespace HopestrackDL
{
    [Persistent]
    public class Employer
    {
        public string NameOftheCompany { get; set; }

        public string AddressOftheCompany { get; set; }

        public string NatureOfBusiness { get; set; }

        public string Totalturnover { get; set; }

        public string Totalregularmanpower { get; set; }

        public string Contractbaselabours { get; set; }

        public string ContactPerson { get; set; }

        public string PhoneNoOffice { get; set; }

        public string PhoneNoResident { get; set; }

        public string MobileNo { get; set; }

        public string FaxNo { get; set; }

        public string EmailID { get; set; }

        public string Position { get; set; }

        public string NoOfPositionsRequired { get; set; }

        public string Academic { get; set; }

        public string TechnicalOrProfessional { get; set; }

        public string ExperienceFrom { get; set; }

        public string ExperienceTo { get; set; }

        public string Industry { get; set; }

        public string AgeFrom { get; set; }

        public string AgeTo { get; set; }

        public string PlaceOfWork { get; set; }

        public string Jobdescription { get; set; }

        public string Preferences { get; set; }

        public string GrossSalaryFrom { get; set; }

        public string GrossSalaryTo { get; set; }

        public string AdditionalBenefits { get; set; }

        public string ProbableDate { get; set; }

        public string ProbableDateOfInterview { get; set; }

        public string InterviewLocation { get; set; }

        public string InterviewerName { get; set; }

        public string InterviewerPosition { get; set; }
    }
}