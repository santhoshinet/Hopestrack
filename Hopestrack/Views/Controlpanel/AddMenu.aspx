<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Hopestrack.Models.MenuModel>" %>

<%@ Import Namespace="HopestrackDL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Menu</title>
    <link href="/Content/stylesheet_default.css" rel="stylesheet" type="text/css" />
    <link href="/Content/FormLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="loginContent">
        <% using (Html.BeginForm("AddMenu", "Controlpanel", FormMethod.Post, new { enctype = "multipart/form-data" }))
           {%>
        <ul class="ul">
            <li>
                <h2>
                    Add Menu</h2>
            </li>
            <li>
                <%=Html.ValidationSummary(true,"Unable to add menu. Please correct the errors and try again.")%>
            </li>
            <li>
                <label>
                    Name</label>
            </li>
            <li>
                <%= Html.TextBoxFor(m => m.MenuName)%>
                <%= Html.ValidationMessageFor(m => m.MenuName)%>
            </li>
            <li>
                <label>
                    Page</label>
            </li>
            <li>
                <select id="CmbPages" name="CmbPages">
                    <option value="Select receiver" title="Select receiver">--Select page--</option>
                    <%
                        var contentPages = (List<ContentPage>)ViewData["ContentPages"];%>
                    <% foreach (var contentPage in contentPages)
                       { %>
                    <option value="<%= contentPage.Id %>" title="<%= contentPage.Name %>">
                        <%= contentPage.Name %>
                    </option>
                    <% } %>
                </select>
            </li>
            <li>
                <input type="submit" value="Add menu" />
                <input type="button" value="Cancel" onclick="window.location = '/controlpanel/menus';" />
            </li>
        </ul>
        <%
            }%>
    </div>
</body>
</html>