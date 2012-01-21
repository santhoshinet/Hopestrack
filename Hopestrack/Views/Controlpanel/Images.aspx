<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="HopestrackDL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Images</title>
    <link href="/Content/FormLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="loginContent">
        <%
            var fileList = (List<File>)ViewData["fileList"];
            int index = 1; %>
        <% if (fileList.Count > 0)
           {
        %>
        <form method="post" action="Checkout">
        <ul class="ul">
            <li>
                <h2>
                    List of images.</h2>
            </li>
            <li>
                <table id="Cart_Table" class="Cart_Table">
                    <thead>
                        <tr>
                            <th style="width: 20px;">
                                Sno
                            </th>
                            <th style="width: 200px;">
                                Picture
                            </th>
                            <th style="width: 465px;">
                                Url
                            </th>
                            <th style="width: 100px;">
                                Actions
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            foreach (var file in fileList)
                            {%>
                        <tr id='<%= file.Filename %>'>
                            <td>
                                <%= index++%>
                            </td>
                            <td>
                                <img alt="" class="product_image" src="/Photo/<%=file.Id%>" title="<%= file.Filename %>" />
                            </td>
                            <td>
                                <a href="/Photo/<%=file.Id%>" target="_blank">/Photo/<%=file.Id%></a>
                            </td>
                            <td>
                                <span class="delete_button">
                                    <img src="/Images/ico-delete.gif" />
                                    <a href="/DeleteImage/<%= file.Id %>" class="ViewProfile">Delete</a> </span>
                            </td>
                        </tr>
                        <%
                            }%>
                    </tbody>
                </table>
            </li>
            <li>
                <input type="button" value="Add new image" onclick="window.location = '/controlpanel/addimage';" />
                <input type="button" value="Home" onclick="window.location = '/controlpanel';" />
            </li>
        </ul>
        </form>
        <%
            }
           else
           {%>
        <form method="post" action="">
        <ul class="ul">
            <li>
                <h2>
                    There is no images uploaded yet.</h2>
            </li>
            <li>
                <input type="button" value="Add new image" onclick="window.location = '/controlpanel/addimage';" />
                <input type="button" value="Home" onclick="window.location = '/controlpanel';" />
            </li>
        </ul>
        </form>
        <%}%>
    </div>
</body>
</html>