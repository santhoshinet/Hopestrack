<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Hopestrack.Models.JobSeekerModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Job Seekers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="/Content/FormLayout.css" rel="stylesheet" type="text/css" />
 <div class="loginContent">
        <% using (Html.BeginForm("JobSeekers", "Profiles", FormMethod.Post, new { enctype = "multipart/form-data" }))
           {%>
        <ul class="ul">
            <li>
                <h2>
                    Job Seekers Registration</h2>
            </li>
            <li>
                <%=Html.ValidationSummary(true,"Unable to register. Please correct the errors and try again.")%>
            </li>
            <li>
                <h3>
                    Personal Information
                </h3>
            </li>
            <li>
                <label>
                    First Name</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.FirstName,new Dictionary<string, object> { {"class","txtFirstname txtText"}} )%>
                <%= Html.ValidationMessageFor(m => m.FirstName)%>
            </li>
            <li>
                <label>Last Name</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.LastName, new Dictionary<string, object> { { "class", "txtLastname txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.LastName)%>
            </li>
            <li>
                <label>
                    Email</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.EmailID, new Dictionary<string, object> { { "class", "txtEmail txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.EmailID)%>
            </li>
            <li>
                <label>
                    Date Of Birth</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.DateOfBirth, new Dictionary<string, object> { { "class", "txtDOB txtText" }, { "maxlength", 10 } })%>
                <%= Html.ValidationMessageFor(m => m.DateOfBirth)%>
            </li>
            <li>
                <label>
                    Gender</label>
            </li>
            <li>
                <select id="Select1" name="Gender" class="CmbGender">
                    <%
               var gender = ViewData["Selectedgender"];
               if (gender == null)
               {%>
                    <option value="" title="Select receiver" selected="selected" >--Select gender--</option>
                    <option value="Male" title="Male">Male</option>
                    <option value="Female" title="Female">Female</option>
                    <%
                        }
               else
               {
                   if (gender.ToString().ToLower() == "male")
                   {
%>                  <option value="" title="Select receiver" >--Select gender--</option>
                    <option value="Male" title="Male" selected="selected" >Male</option>
                    <option value="Female" title="Female">Female</option>
                    <%
                   }
                   else
                   {%>
                   <option value="" title="Select receiver" >--Select gender--</option>
                    <option value="Male" title="Male"  >Male</option>
                    <option value="Female" title="Female" selected="selected">Female</option>
                   <%
                   }%>
               <%
               }%>
                </select>
                <%= Html.ValidationMessageFor(m => m.Gender)%>
            </li>
            <li>
                <label>
                    Alternative Email ID
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.OptionalEmailID, new Dictionary<string, object> { { "class", "txtOptionalEmail txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.OptionalEmailID)%>
            </li>
            <li>
                <label>
                    Phone No
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.PhoneNo, new Dictionary<string, object> { { "class", "txtPhoneNo txtText" }, { "maxlength", 15 } })%>
                <%= Html.ValidationMessageFor(m => m.PhoneNo)%>
            </li>
            <li>
                <label>
                    Mobile No
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.MobileNo, new Dictionary<string, object> { { "class", "txtMobileNo txtText" }, { "maxlength", 15 } })%>
                <%= Html.ValidationMessageFor(m => m.MobileNo )%>
            </li>
            <li>
                <h3>Education Details</h3>
            </li>
            <li>
                <label>UG Qualification</label>
            </li>
            <li>
                <select id="Select2" name="UGQualification" class="CmbUGQualification">
                    <option value="" title="Select receiver">--Select your UG qualification--</option>
                    <%
                        var quList = (List<string>)ViewData["UGQualifications"];%>
                    <%
                        var selectedUgQualification = ViewData["SelectedUgQualification"].ToString();
                foreach (string qualification in quList)
{
                        if (selectedUgQualification == qualification)
                        {
%>
                    <option title="<%=qualification%>" value="<%=qualification%>" selected ="selected">
                    <%
                        }
                        else
                        {%>
                        <option title="<%=qualification%>" value="<%=qualification%>" >
                           <%
                        }%>
                        <%= qualification%>
                    </option>
                    <% } %>
                </select>
                <%= Html.ValidationMessageFor(m => m.UgQualification)%>
            </li>
            <li>
                <label>
                    If others
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.UgOthers, new Dictionary<string, object> { { "class", "txtUgOthers txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.UgOthers )%>
            </li>
            <li>
                <label>PG Qualification</label>
            </li>
            <li>
                <select id="Select3" name="PGQualification" class="CmbPgQualification">
                    <option value="" title="Select receiver">--Select your PG qualification--</option>
                    <%
                        var pgList = (List<string>)ViewData["PGQualifications"];
                        var selectedPgQualification = ViewData["SelectedPgQualification"].ToString();
                foreach (string qualification in pgList)
                       {

                         if (selectedPgQualification == qualification)
                         {
%>
                     <option title="<%=qualification%>" value="<%=qualification%>" selected="selected">
                           <%
                        }
                         else
                         {%>
                        <option title="<%=qualification%>" value="<%=qualification%>">
                        <%
                         }%>
                        <%= qualification%>
                    </option>
                    <% } %>
                </select>
                <%= Html.ValidationMessageFor(m => m.PgQualification)%>
            </li>
            <li>
                <label>
                    If others
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.PgOthers, new Dictionary<string, object> { { "class", "txtPgOthers txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.PgOthers )%>
            </li>
            <li>
                <h3>Techinical Details</h3>
            </li>
            <li>
                <label>Industry</label>
            </li>
            <li>
                <select id="Select4" name="Industry" class="CmbIndustry">
                    <option value="" title="Select receiver">--Select Industry--</option>
                    <%
                        var industries = (List<string>)ViewData["Industries"];
                        var selectedIndustry = ViewData["SelectedIndustry"].ToString();
               foreach (string industry in industries)
                       {
                            if (selectedIndustry == industry)
                            {
%>
                    <option title="<%=industry%>" value="<%=industry%>" selected ="selected">
                    <%
                        }
                            else
                            {%>
                            <option title="<%=industry%>" value="<%=industry%>">
                         <%
                            }%>
                        <%= industry%>
                    </option>
                    <% } %>
                </select>
                <%= Html.ValidationMessageFor(m => m.Industry)%>
            </li>
            <li>
                If others
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.IndustryOthers, new Dictionary<string, object> { { "class", "txtIndustryOthers txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.IndustryOthers )%>
            </li>
            <li>
                <label>
                    Function Area
                </label>
            </li>
            <li>
                <select id="Select5" name="Functional" class="CmbFunctionalArea" >
                    <option value="" title="Select receiver">--Select your functional area--</option>
                    <%
                        var selectedFunctionalArea = ViewData["SelectedFunctionalArea"].ToString();
                        var functionalareas = (List<string>)ViewData["FunctionalArea"];
                foreach (string functional in functionalareas)
                       {
                           if (selectedFunctionalArea == functional)
                           {
%>
                    <option title="<%=functional%>" value="<%=functional%>" selected="selected">
                    <%
                           }else
                           {%>
                           <option title="<%=functional%>" value="<%=functional%>" >
                           <%
                           }%>
                        <%= functional %>
                    </option>
                    <% } %>
                </select>
                <%= Html.ValidationMessageFor(m => m.Functional)%>
            </li>
            <li>
                <label>
                    If others
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.FunctionalOthers, new Dictionary<string, object> { { "class", "txtFunctionalOthers txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.FunctionalOthers)%>
            </li>
            <li>
                <label>
                    Primary skill set
                </label>
            </li>
            <li>
                <%= Html.TextAreaFor(m => m.PrimarySkillSet, new Dictionary<string, object> { { "class", "txtPrimarySkillSet txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.PrimarySkillSet)%>
            </li>
            <li>
                <label>Secondary skill set</label>
            </li>
            <li>
                <%= Html.TextAreaFor(m => m.SecondarySkillSet, new Dictionary<string, object> { { "class", "txtSecondarySkillSet txtText" } })%>
                <%= Html.ValidationMessageFor(m => m.SecondarySkillSet)%>
            </li>
            <li>
                <h3>Experience Details</h3>
            </li>
            <li>
                <label>
                    Relevant experience
                </label>
                <p>
                    Please specify the no of years of your experienced.
                </p>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.RelaventExperience, new Dictionary<string, object> { { "class", "txtRelaventExp txtText" }, { "maxlength", 5 } })%>
                <%= Html.ValidationMessageFor(m => m.RelaventExperience)%>
            </li>
            <li>
                <label>Total experience</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.TotalExperience, new Dictionary<string, object> { { "class", "txtTotalExp txtText" }  , { "maxlength", 5 } } )%>
                <%= Html.ValidationMessageFor(m => m.TotalExperience)%>
            </li>
            <li>
                <label>
                    Current CTC
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.CurrentCtc, new Dictionary<string, object> { { "class", "txtCurrentCTC txtText" }, { "maxlength", 10 } })%>
                <%= Html.ValidationMessageFor(m => m.CurrentCtc)%>
            </li>
            <li>
                <label>
                    Expected CTC
                </label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.ExpectedCtc, new Dictionary<string, object> { { "class", "txtExpectedCTC txtText" }, { "maxlength", 10 } })%>
                <%= Html.ValidationMessageFor(m => m.ExpectedCtc)%>
            </li>
            <li>
                <label>Resume</label>
                <p>Attach your latest resume</p>
            </li>
            <li>
                <input type="file" name="ResumeAttachment" class="ResumeAttachment" />
                <%= Html.ValidationMessageFor(m => m.ResumeAttachment)%>
            </li>
            <li>
                <input type="submit" value="Upload my info" />
                <input type="button" value="Cancel" onclick="window.location = '/';" />
            </li>
        </ul>
        <%
            }%>
    </div>
    <link href="/Content/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/JQValidation.js" type="text/javascript"></script>
    <script src="/Scripts/JobSeeker.js" type="text/javascript"></script>
</asp:Content>