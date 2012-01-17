using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Hopestrack.Models
{
    public class JobSeekerModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email ID")]
        public string EmailID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime  DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Alternative Email Id")]
        public string OptionalEmailID { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone No")]
        public string PhoneNo { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("UG Qualification")]
        public string UgQualification { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("UG Others")]
        public string UgOthers { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("PG Qualification")]
        public string PgQualification { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("PG Others")]
        public string PgOthers { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Industry")]
        public string Industry { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Industry Others")]
        public string IndustryOthers { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Functional")]
        public string Functional { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Functional Others")]
        public string FunctionalOthers { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Primary Skill Set")]
        public string PrimarySkillSet { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Secondary Skill Set")]
        public string SecondarySkillSet { get; set; }

        [DataType(DataType.Duration)]
        [DisplayName("Relavant Experience")]
        public Double RelaventExperience { get; set; }

        [DataType(DataType.Duration)]
        [DisplayName("Total Experience")]
        public Double TotalExperience { get; set; }

        [DataType(DataType.Duration)]
        [DisplayName("Notice Period")]
        public Double NoticePeriod { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Current CTC")]
        public Double CurrentCtc { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Expected CTC")]
        public Double ExpectedCtc { get; set; }

        [Required]
        [DisplayName("Resume Attachment")]
        public HttpPostedFileBase ResumeAttachment { get; set; }
    }

   public class EmployerModel
    {
       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Name of the company")]
       public string NameOftheCompany { get; set; }

       [Required]
       [DataType(DataType.MultilineText)]
       [DisplayName("Address of the company")]
       public string AddressOftheCompany { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Nature of business")]
       public string NatureOfBusiness { get; set; }

       [Required]
       [DataType(DataType.Currency)]
       [DisplayName("Total turn over")]
       public string Totalturnover { get; set; }

       [Required]
       [DisplayName("Total regular manpower")]
       public string Totalregularmanpower { get; set; }

       [Required]
       [DisplayName("Contractbase labours")]
       public string Contractbaselabours { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Contact person")]
       public string ContactPerson { get; set; }

       [Required]
       [DataType(DataType.PhoneNumber)]
       [DisplayName("Phone no (O)")]
       public string PhoneNoOffice { get; set; }

       [Required]
       [DataType(DataType.PhoneNumber)]
       [DisplayName("Phone no (R)")]
       public string PhoneNoResident { get; set; }

       [Required]
       [DataType(DataType.PhoneNumber)]
       [DisplayName("Mobile no")]
       public string MobileNo { get; set; }

       [Required]
       [DataType(DataType.PhoneNumber)]
       [DisplayName("Fax no")]
       public string FaxNo { get; set; }

       [Required]
       [DataType(DataType.EmailAddress)]
       [DisplayName("Email")]
       public string EmailID { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Position")]
       public string Position { get; set; }

       [Required]
       [DisplayName("No of positions required")]
       public string NoOfPositionsRequired { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Academic")]
       public string Academic { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Technical/Professional")]
       public string TechnicalOrProfessional { get; set; }

       [Required]
       [DisplayName("ExperienceFrom")]
       public string ExperienceFrom { get; set; }

       [Required]
       [DisplayName("ExperienceTo")]
       public string ExperienceTo { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Industry")]
       public string Industry { get; set; }

       [Required]
       [DisplayName("AgeFrom")]
       public string AgeFrom { get; set; }

       [Required]
       [DisplayName("AgeTo")]
       public string AgeTo { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Place of work")]
       public string PlaceOfWork { get; set; }

       [Required]
       [DataType(DataType.MultilineText)]
       [DisplayName("Job description/Nature of work/Job requirement")]
       public string Jobdescription { get; set; }

       [Required]
       [DataType(DataType.MultilineText)]
       [DisplayName("Preference/any other requirement if any?")]
       public string Preferences { get; set; }

       [Required]
       [DataType(DataType.Currency)]
       [DisplayName("GrossSalaryFrom")]
       public string GrossSalaryFrom { get; set; }

       [Required]
       [DataType(DataType.Currency)]
       [DisplayName("GrossSalaryTo")]
       public string GrossSalaryTo { get; set; }

       [Required]
       [DataType(DataType.MultilineText)]
       [DisplayName("Additional benefits and housing facilities if any?")]
       public string AdditionalBenefits { get; set; }

       [Required]
       [DataType(DataType.Date)]
       [DisplayName("Probabale date by which position is to be filled")]
       public string ProbableDate { get; set; }

       [Required]
       [DataType(DataType.Date)]
       [DisplayName("Probabale date of interview")]
       public string ProbableDateOfInterview { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Interview location")]
       public string InterviewLocation { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Interviewer name")]
       public string InterviewerName { get; set; }

       [Required]
       [DataType(DataType.Text)]
       [DisplayName("Interviewer position")]
       public string InterviewerPosition { get; set; }
    }
}