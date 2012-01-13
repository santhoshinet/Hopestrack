<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title>Menus</title>
    <link href="/Content/stylesheet_default.css" rel="stylesheet" type="text/css" />
    <link href="/Content/FormLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="loginContent">
        <%
            var menus = (List<HopestrackDL.Menu>)ViewData["menus"];
            int index = 1; %>
        <% if (menus.Count > 0)
           {
        %>
        <form method="post" action="#">
        <ul class="ul">
            <li>
                <h2>
                    List of menu.</h2>
            </li>
            <li>
                <table id="Cart_Table">
                    <thead>
                        <tr>
                            <th>
                                Sno
                            </th>
                            <th style="width: 40%">
                                Name
                            </th>
                            <th style="width: 40%">
                                Page name
                            </th>
                            <th style="width: 160px" colspan="2">
                                Actions
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            foreach (var menu in menus)
                            {%>
                        <tr id='<%= menu.Id %>'>
                            <td>
                                <%=index++%>
                            </td>
                            <td>
                                <%=menu.Name%>
                            </td>
                            <td>
                                <%=menu.Page.Name%>
                            </td>
                            <td>
                                <span class="delete_button">
                                    <img src="/Images/ico-delete.gif" />
                                    <a href="/deletemenu/<%= menu.Id %>" class="ViewProfile">delete</a></span>
                            </td>
                            <td>
                                <span class="edit_button">
                                    <img src="/Images/edit.gif" />
                                    <a href="/editmenu/<%= menu.Id %>" class="ViewProfile">edit</a> </span>
                            </td>
                        </tr>
                        <%
                            }%>
                    </tbody>
                </table>
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
                    There is no menu added yet.</h2>
            </li>
            <li>
                <input type="button" value="Add new menu" onclick="window.location = '/controlpanel/addmenu';" />
                <input type="button" value="Home" onclick="window.location = '/controlpanel';" />
            </li>
        </ul>
        </form>
        <%}%>
    </div>
</body>
</html>