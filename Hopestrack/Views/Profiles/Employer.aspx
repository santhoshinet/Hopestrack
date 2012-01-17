<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Hopestrack.Models.EmployerModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Employer
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="/Content/FormLayout.css" rel="stylesheet" type="text/css" />
 <div class="loginContent">
        <% using (Html.BeginForm("Employer", "Profiles", FormMethod.Post, new { enctype = "multipart/form-data" }))
           {%>
        <ul class="ul">
            <li>
                <h2>Employer</h2>
            </li>
            <li>
                <%=Html.ValidationSummary(true,"Unable to register. Please correct the errors and try again.")%>
            </li>
            <li>
                <label>Name of the company</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.NameOftheCompany, new Dictionary<string, object> { { "class", "txtNameOfTheCompany txtText" }, { "maxlength", 255 } })%>
                <%= Html.ValidationMessageFor(m => m.NameOftheCompany)%>
            </li>
            <li>
                <label>Address</label>
            </li>
            <li>
                <%= Html.TextAreaFor(m => m.AddressOftheCompany, new Dictionary<string, object> { { "class", "txtAddress txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.AddressOftheCompany)%>
            </li>
            <li>
                <label>
                    Nature of business</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.NatureOfBusiness, new Dictionary<string, object> { { "class", "txtNatureOfBusiness txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.EmailID)%>
            </li>
            <li>
                <label>
                    Total turn over</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.Totalturnover, new Dictionary<string, object> { { "class", "txtTotalturnover txtText" } , { "maxlength", 12 }})%>
                <%= Html.ValidationMessageFor(m => m.Totalturnover)%>
            </li>
            <li>
                <label>
                    Total regular manpower</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.Totalregularmanpower, new Dictionary<string, object> { { "class", "txtTotalregularmanpower txtText" }, { "maxlength", 3 } })%>
                <%= Html.ValidationMessageFor(m => m.Totalturnover)%>
            </li>
            <li>
                <label>
                    Contractbase labours
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.Contractbaselabours, new Dictionary<string, object> { { "class", "txtContractbaselabours txtText" }, { "maxlength", 3 } })%>
                <%= Html.ValidationMessageFor(m => m.Contractbaselabours)%>
            </li>
            <li>
                <label>
                    Contact person
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.ContactPerson, new Dictionary<string, object> { { "class", "txtContactPerson txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.ContactPerson)%>
            </li>
            <li>
                <h3>Contact details</h3>
            </li>
            <li>
                <label>Phone no(O)</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.PhoneNoOffice, new Dictionary<string, object> { { "class", "txtPhoneO txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.PhoneNoOffice )%>
            </li>
            <li>
                <label>
                    Phone no(R)
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.PhoneNoResident, new Dictionary<string, object> { { "class", "txtPhoneR txtText" }, { "maxlength", 14 } })%>
                <%= Html.ValidationMessageFor(m => m.PhoneNoResident )%>
            </li>
            <li>
                <label>Mobile</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.MobileNo, new Dictionary<string, object> { { "class", "txtMobile txtText" }, { "maxlength", 15 } })%>
                <%= Html.ValidationMessageFor(m => m.MobileNo )%>
            </li>
            <li>
                <label>
                    Fax
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.FaxNo, new Dictionary<string, object> { { "class", "txtFax txtText" }, { "maxlength", 15 } })%>
                <%= Html.ValidationMessageFor(m => m.FaxNo )%>
            </li>
            <li>
                <label>
                    Email
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.EmailID, new Dictionary<string, object> { { "class", "txtEmail txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.EmailID )%>
            </li>
            <li>
                <h3>Requirement Details</h3>
            </li>
            <li>
                <label>Position</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.Position, new Dictionary<string, object> { { "class", "txtPosition txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.Position )%>
            </li>
            <li>
                <label>
                No of candidates required
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.NoOfPositionsRequired, new Dictionary<string, object> { { "class", "txtNoOfCandidates txtText" }, { "maxlength", 3 } })%>
                <%= Html.ValidationMessageFor(m => m.NoOfPositionsRequired )%>
            </li>
            <li>
                <label>
                    Academic requirement
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.Academic, new Dictionary<string, object> { { "class", "txtAcademic txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.Academic)%>
            </li>
            <li>
                <label>
                    Technical / Professional
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.TechnicalOrProfessional, new Dictionary<string, object> { { "class", "txtTechnicalOfProfessional txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.TechnicalOrProfessional)%>
            </li>
            <li>
                <label>
                    Experience
                </label>
            </li>
            <li>
                <ul>
                    <li>
                        <label>From</label>
                    </li>
                    <li>
                        <%= Html.TextBoxFor(m => m.ExperienceFrom, new Dictionary<string, object> { { "class", "txtExpFrom txtText small" }, { "maxlength", 5 } })%>
                        <%= Html.ValidationMessageFor(m => m.ExperienceFrom)%>
                    </li>
                    <li>To</li>
                    <li>
                        <%= Html.TextBoxFor(m => m.ExperienceTo, new Dictionary<string, object> { { "class", "txtExpTo txtText small" }, { "maxlength", 5 } })%>
                        <%= Html.ValidationMessageFor(m => m.ExperienceTo)%>
                    </li>
                </ul>
            </li>
            <li>
                <label>Industry</label>
            </li>
            <li>
                <%= Html.TextAreaFor(m => m.Industry, new Dictionary<string, object> { { "class", "txtIndustry txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.Industry)%>
            </li>
            <li>
                <label>
                    Age
                </label>
            </li>
            <li>
                <ul>
                    <li>
                        <label>From</label>
                    </li>
                    <li>
                        <%= Html.TextBoxFor(m => m.AgeFrom, new Dictionary<string, object> { { "class", "txtAgeFrom txtText small" }, { "maxlength", 2 } })%>
                        <%= Html.ValidationMessageFor(m => m.AgeFrom)%>
                    </li>
                    <li>
                        <label>To</label>
                    </li>
                    <li>
                        <%= Html.TextBoxFor(m => m.AgeTo, new Dictionary<string, object> { { "class", "txtAgeTo txtText small" }, { "maxlength", 2 } })%>
                        <%= Html.ValidationMessageFor(m => m.AgeTo)%>
                    </li>
                </ul>
            </li>
            <li>
                <label>Place of work</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.PlaceOfWork, new Dictionary<string, object> { { "class", "txtPlaceofwork txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.PlaceOfWork)%>
            </li>
            <li>
                <label>
                    Job description/Nature of work/Job requirement
                </label>
            </li>
            <li>
                <%= Html.TextAreaFor(m => m.Jobdescription, new Dictionary<string, object> { { "class", "txtJobdescription txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.Jobdescription)%>
            </li>
            <li>
                <label>
                    Preference / any other requirement if any
                </label>
            </li>
            <li>
                <%= Html.TextAreaFor(m => m.Preferences, new Dictionary<string, object> { { "class", "txtPreferences txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.Preferences)%>
            </li>
            <li>
                <label>Gross salary range per month</label>
            </li>
            <li>
                <ul>
                    <li>
                        <label>From</label>
                    </li>
                    <li>
                        <%= Html.TextBoxFor(m => m.GrossSalaryFrom, new Dictionary<string, object> { { "class", "txtGrossSalFrom txtText small" }, { "maxlength", 9 } })%>
                        <%= Html.ValidationMessageFor(m => m.GrossSalaryFrom)%>
                    </li>
                    <li>
                        <label>To</label>
                     </li>
                     <li>
                        <%= Html.TextBoxFor(m => m.GrossSalaryTo, new Dictionary<string, object> { { "class", "txtGrossSalTo txtText small" }, { "maxlength", 9 } })%>
                        <%= Html.ValidationMessageFor(m => m.GrossSalaryTo)%>
                    </li>
                </ul>
            </li>
            <li>
                <label>
                    Additional benefits and housing facilities if any
                </label>
            </li>
            <li>
                <%= Html.TextAreaFor(m => m.AdditionalBenefits, new Dictionary<string, object> { { "class", "txtAdditionalBenefits txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.AdditionalBenefits)%>
            </li>
            <li>
                <label>
                    Probable date by which position is to be filled
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.ProbableDate, new Dictionary<string, object> { { "class", "txtProbabledate txtText" }, { "maxlength", 10 } })%>
                <%= Html.ValidationMessageFor(m => m.ProbableDate)%>
            </li>
            <li>
                <label>
                    Probable date of interview
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.ProbableDateOfInterview, new Dictionary<string, object> { { "class", "txtProbabledateOfInterview txtText" }, { "maxlength", 10 } })%>
                <%= Html.ValidationMessageFor(m => m.ProbableDateOfInterview)%>
            </li>
            <li>
                <label>
                    Interview location
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.InterviewLocation, new Dictionary<string, object> { { "class", "txtInterviewLocattion txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.InterviewLocation)%>
            </li>
            <li>
                <label>
                    Interviewer name
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.InterviewerName, new Dictionary<string, object> { { "class", "txtInterviewername txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.InterviewerName)%>
            </li>
            <li>
                <label>
                    Interviewer Position
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.InterviewerPosition, new Dictionary<string, object> { { "class", "txtInterviewerposition txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.InterviewerPosition)%>
            </li>
            <li>
                <input type="submit" value="Add requirement" />
                <input type="button" value="Cancel" onclick="window.location = '/';" />
            </li>
        </ul>
        <%
            }%>
    </div>
    <link href="/Content/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/JQValidation.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/Employer.js" type="text/javascript"></script>
</asp:Content>