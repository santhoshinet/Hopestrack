using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Hopestrack.Models;
using HopestrackDL;

namespace Hopestrack.Controllers
{
    public class ProfilesController : Controller
    {
        [HttpGet]
        public ActionResult JobSeekers()
        {
            ViewData["Selectedgender"] = null;
            var result = GetUgQualifications();
            result.Sort();
            ViewData["UGQualifications"] = result;
            result = GetPgQualifications();
            result.Sort();
            ViewData["PGQualifications"] = result;
            result = GetIndustries();
            result.Sort();
            ViewData["Industries"] = result;
            result = GetFunctionalAreas();
            result.Sort();
            ViewData["FunctionalArea"] = result;
            ViewData["SelectedFunctionalArea"] = string.Empty;
            ViewData["SelectedIndustry"] = string.Empty;
            ViewData["SelectedPgQualification"] = string.Empty;
            ViewData["SelectedUgQualification"] = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult JobSeekers(JobSeekerModel jobSeekerModel, HttpPostedFileBase resumeAttachment)
        {
            var result = GetUgQualifications();
            result.Sort();
            ViewData["UGQualifications"] = result;
            result = GetPgQualifications();
            result.Sort();
            ViewData["PGQualifications"] = result;
            result = GetIndustries();
            result.Sort();
            ViewData["Industries"] = result;
            result = GetFunctionalAreas();
            result.Sort();
            ViewData["FunctionalArea"] = result;
            string selectedGender = string.Empty;
            if (Request.Form["Gender"] != null)
                selectedGender = Request.Form["Gender"];
            string selectedUgQualification = string.Empty;
            if (Request.Form["UGQualification"] != null)
                selectedUgQualification = Request.Form["UGQualification"];
            string selectedPgQualification = string.Empty;
            if (Request.Form["PGQualification"] != null)
                selectedPgQualification = Request.Form["PGQualification"];
            string selectedIndustry = string.Empty;
            if (Request.Form["Industry"] != null)
                selectedIndustry = Request.Form["Industry"];
            string selectedFunctionalArea = string.Empty;
            if (Request.Form["Functional"] != null)
                selectedFunctionalArea = Request.Form["Functional"];
            if (string.IsNullOrEmpty(selectedGender))
                ModelState.AddModelError("Gender", "Please select gender.");
            if (string.IsNullOrEmpty(selectedUgQualification))
                ModelState.AddModelError("UgQualification", "Please select your ug qualification.");
            else if (selectedUgQualification.ToLower().Trim() == "others" && string.IsNullOrEmpty(jobSeekerModel.UgOthers))
                {
                    ModelState.AddModelError("UgOthers", "Please input your ug qualification - others");
                }
            if (string.IsNullOrEmpty(selectedPgQualification))
                ModelState.AddModelError("PgQualification", "Please select your pg qualification.");
            else if (selectedPgQualification.ToLower().Trim() == "others" && string.IsNullOrEmpty(jobSeekerModel.PgOthers))
            {
                ModelState.AddModelError("PgOthers", "Please input your pg qualification - others");
            }
            if (string.IsNullOrEmpty(selectedIndustry))
                ModelState.AddModelError("Industry", "Please select industry.");
            else if (selectedIndustry.ToLower().Trim() == "others" && string.IsNullOrEmpty(jobSeekerModel.IndustryOthers))
            {
                ModelState.AddModelError("IndustryOthers", "Please input your industry - others");
            }
            if (string.IsNullOrEmpty(selectedFunctionalArea))
                ModelState.AddModelError("Functional", "Please select your functional area.");
            else if (selectedFunctionalArea.ToLower().Trim() == "others" && string.IsNullOrEmpty(jobSeekerModel.FunctionalOthers))
            {
                ModelState.AddModelError("FunctionalOthers", "Please input your functiona area - others");
            }
            if (ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                scope.Transaction.Begin();
                var jobSeeker = new JobSeeker
                                    {
                                        CurrentCtc = jobSeekerModel.CurrentCtc,
                                        DateOfBirth = jobSeekerModel.DateOfBirth,
                                        EmailID = jobSeekerModel.EmailID,
                                        ExpectedCtc = jobSeekerModel.ExpectedCtc,
                                        FirstName = jobSeekerModel.FirstName,
                                        Functional = jobSeekerModel.Functional,
                                        FunctionalOthers = jobSeekerModel.FunctionalOthers,
                                        Gender = jobSeekerModel.Gender,
                                        Industry = jobSeekerModel.Industry,
                                        IndustryOthers = jobSeekerModel.IndustryOthers,
                                        LastName = jobSeekerModel.LastName,
                                        MobileNo = jobSeekerModel.MobileNo,
                                        NoticePeriod = jobSeekerModel.NoticePeriod,
                                        OptionalEmailID = jobSeekerModel.OptionalEmailID,
                                        PgOthers = jobSeekerModel.PgOthers,
                                        PgQualification = jobSeekerModel.PgQualification,
                                        PhoneNo = jobSeekerModel.PhoneNo,
                                        PrimarySkillSet = jobSeekerModel.PrimarySkillSet,
                                        RelaventExperience = jobSeekerModel.RelaventExperience,
                                        SecondarySkillSet = jobSeekerModel.SecondarySkillSet,
                                        TotalExperience = jobSeekerModel.TotalExperience,
                                        UgOthers = jobSeekerModel.UgOthers,
                                        UgQualification = jobSeekerModel.UgQualification
                                    };
                Stream fileStream = resumeAttachment.InputStream;
                int fileLength = resumeAttachment.ContentLength;
                var attachment = new Attachment
                                     {
                                         Filedata = new byte[fileLength],
                                         MimeType = resumeAttachment.ContentType,
                                         Id = DateTime.Now.Ticks.ToString()
                                     };
                fileStream.Read(attachment.Filedata, 0, fileLength);
                jobSeeker.ResumeAttachment = attachment;
                scope.Add((jobSeeker));
                scope.Transaction.Commit();
                ViewData["Status"] = "Thank you for uploading your profile, we will get back to you soon.";
                return View("Status");
            }
            ViewData["Selectedgender"] = selectedGender;
            ViewData["SelectedUgQualification"] = selectedUgQualification;
            ViewData["SelectedPgQualification"] = selectedPgQualification;
            ViewData["SelectedIndustry"] = selectedIndustry;
            ViewData["SelectedFunctionalArea"] = selectedFunctionalArea;
            return View();
        }

        private static List<string> GetFunctionalAreas()
        {
            return new List<string> { "Sales/Marketing/Business Development",
            "Service",
            "Material Management",
            "Legal",
            "BPO-QA-Six Signal/COPC/BS7799",
            "Manufacturing",
            "Finance/Accounts",
            "Customer Service",
            "Corp Planning/Strategy/Consulting",
            "Civil Project Management",
            "Back End Operations",
            "Editor/Journaliser/Anchors",
            "Teaching/Educations",
            "Doctors/Nurses",
            "Freshers",
            "IT-Mainframes",
            "IT-Mid Range-AS400",
            "IT-Client Server",
            "IT-Internet Technologies",
            "IT-QA",
            "IT-CAD/CAM/CAE",
            "IT-Tandem",
            "IT-Latex",
            "IT-Telecom Software",
            "IT-Embedded Systems",
            "IT-DBA",
            "IT-Datawarehousing",
            "IT-Network Admin",
            "IT-System Admin",
            "IT-Systems Programming",
            "IT-ERP",
            "IT-PLM/PDM",
            "IT-HP-Series",
            "IT-MIS/EDP",
            "IT-Technical Writers",
            "IT-Language Specialists",
            "IT-Business Process Management/Content Management/KM",
            "IT-Business Analysits/Functional Consultant",
            "IT-Presales/Sales Support",
            "IT-Marketing",
            "IT-EDI",
            "IT-LotusNotes",
            "IT-Senior",
            "BPO-Associate",
            "BPO-Team Leader",
            "BPO-Team Manager",
            "BPO-Program Manager",
            "BPO-Training",
            "BPO-Networking/Infrastructure",
            "BPO-Clinical",
            "BPO-Senior",
            "Specialty/Biotech Research",
            "Others",
            "Research&Product Development",
            "IT-EAI",
            "Designing and Merchandising",
            "Profit Center Head",
            "IT-Others",
            "Creative Directors/Visualizer/Web Graphic Designer",
            "IT-Hardware Design",
            "IT-PLM/PDM",
            "Human Resources",
            "Health/Safety/Environment",
            "BPO-CA",
            "Others"
            };
        }

        private static List<string> GetIndustries()
        {
            return new List<string> { "Govt/Public Service",
            "ExService Man",
            "Others",
            "FMCG",
            "Consumer Durables",
            "Banking",
            "Financial Service",
            "Insurance",
            "Pharma/Speciality Chemical/Fine Chemicals",
            "Cement/Building Materials/Ceramics",
            "Sugar",
            "Engineering(Light/Heavy)",
            "Auto(2/3/4 wheelers",
            "Auto Ancillary",
            "Telecom",
            "Office Automation",
            "Media & Entertainment",
            "Advertising/Event Mgmt/Market Research",
            "Travels&Tourism/Hotels&Hospitality/RealEst/Resorts",
            "Airlines",
            "Logistics/Shipping/Courier",
            "Retail",
            "Trading",
            "Software Services",
            "BPO/ITES",
            "Construction/Infrastucture",
            "Oil&Gas/Power/Energy",
            "Consulting",
            "Hardware/Networking",
            "Texttile/Textile Inputs",
            "Chemical&Fertilizers",
            "Education/Training",
            "Agriculture/Farming/Horiculture",
            "Bio-Technology",
            "Frehers",
            "Corp Comm/PR",
            "Printing/Packaging",
            "Apparel/Footwear/Jewellery",
            "Petrochemical/Lubricants/LPG",
            "Telecom Equipments",
            "Professionals",
            "Utilities/Service/Security Service",
            "Paints",
            "Glass",
            "Breweris/Distelleries",
            "Tyres/Auto Batteries/Accessories",
            "Steel/Metal/Minings",
            "Plastics",
            "Leather",
            "Others"};
        }

        private static List<string> GetUgQualifications()
        {
            return new List<string>{"B.Ed",
                "B.Pharma",
            "Diploma - Computers",
            "Bachelors - Veterinary Science",
            "BCA",
            "BSC - Computer Science",
            "Engineering - Mechanical",
            "Commerce",
            "Diploma - Civil",
            "Diploma - Computers",
            "Diploma - Electrical",
            "Diploma - Electronics / Telecomm",
            "Diploma - Engineering",
            "Diploma - Mechanical",
            "Economics",
            "Engineering - Bio-Chem/Bio-Tech",
            "Engineering - Chemical",
            "Engineering - Civil",
            "Engineering - Computer Science",
            "Engineering - Electrical",
            "Engineering - Electronics/Telecom",
            "Engineering - Instrumentation",
            "Engineering - Mechanical",
            "Engineering - Metallurgy",
            "Engineering - Mining",
            "Engineering - Others",
            "Engineering - Production/Industrial",
            "Engineering - Textile",
            "Fashion/Design",
            "Hotel Management",
            "Humanities",
            "Inter ICWA/CA/CS",
            "Journalism/Mass Communication",
            "Law / LLB",
            "Management",
            "Medical",
            "PR/Advertising",
            "Sciences",
            "Sciences / Maths",
            "Tourism",
            "Vocational Training",
            "Others"};
        }

        private static List<string> GetPgQualifications()
        {
            return new List<string> { "Architecture",
            "CA",
            "CA - Inter",
            "Commerce",
            "Computer Science/Information Technology",
            "CS",
            "Economics",
            "Engineering - Chemical",
            "Engineering - Civil",
            "Engineering - Computer Science",
            "Engineering - Electrical",
            "Engineering - Electronics/Telecom",
            "Engineering - Instrumentation",
            "Engineering - Mechanical",
            "Engineering - Metallurgy",
            "Engineering - Mining",
            "Engineering - Production/Industrial",
            "Engineering Bio - Chem/Bio-Tech",
            "Engineering - Textile",
            "Fashion/Design",
            "Hotel Management",
            "Humanities",
            "Inter ICWA/CA/CS",
            "Journalism/MAss Communication",
            "Law / LLB",
            "Management",
            "M Pharma",
            "M. Phil",
            "PG - Diploma",
            "Ph.D",
            "Medical",
            "PR/Advertising",
            "Sciences",
            "Tourism",
            "Vocational Training",
            "Others"};
        }

        [HttpGet]
        public ActionResult Employer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Employer(EmployerModel model)
        {
            if(ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                scope.Transaction.Begin();
                var employer = new Employer
                                   {
                                       Academic = model.Academic,
                                       AdditionalBenefits = model.AdditionalBenefits,
                                       AddressOftheCompany = model.AddressOftheCompany,
                                       AgeFrom = model.AgeFrom,
                                       AgeTo = model.AgeTo,
                                       ContactPerson = model.ContactPerson,
                                       Contractbaselabours = model.Contractbaselabours,
                                       EmailID = model.EmailID,
                                       ExperienceFrom = model.ExperienceFrom,
                                       ExperienceTo = model.ExperienceTo,
                                       FaxNo = model.FaxNo,
                                       GrossSalaryFrom = model.GrossSalaryFrom,
                                       GrossSalaryTo = model.GrossSalaryTo,
                                       Industry = model.Industry,
                                       InterviewerName = model.InterviewerName,
                                       InterviewerPosition = model.InterviewerPosition,
                                       InterviewLocation = model.InterviewLocation,
                                       Jobdescription = model.Jobdescription,
                                       MobileNo = model.MobileNo,
                                       NameOftheCompany = model.NameOftheCompany,
                                       NatureOfBusiness = model.NatureOfBusiness,
                                       NoOfPositionsRequired = model.NoOfPositionsRequired,
                                       PhoneNoOffice = model.PhoneNoOffice,
                                       PhoneNoResident = model.PhoneNoResident,
                                       PlaceOfWork = model.PlaceOfWork,
                                       Position = model.Position,
                                       Preferences = model.Preferences,
                                       ProbableDate = model.ProbableDate,
                                       ProbableDateOfInterview = model.ProbableDateOfInterview,
                                       TechnicalOrProfessional = model.TechnicalOrProfessional,
                                       Totalregularmanpower = model.Totalregularmanpower,
                                       Totalturnover = model.Totalturnover
                                   };
                scope.Add(employer);
                scope.Transaction.Commit();
                ViewData["Status"] = "Thank you for posting your requirement with us, we will get back to you soon.";
                return View("Status");
            }
            return View();
        }
    }
}