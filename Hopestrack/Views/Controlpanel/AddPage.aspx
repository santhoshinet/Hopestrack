﻿<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<Hopestrack.Models.PageModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add Content Page</title>
    <link href="/Content/FormLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="loginContent">
        <% using (Html.BeginForm("AddPage", "Controlpanel", FormMethod.Post, new { enctype = "multipart/form-data" }))
           {%>
        <ul class="ul">
            <li>
                <h2>
                    Add Page</h2>
            </li>
            <li>
                <%=Html.ValidationSummary(true,"Unable to add page. Please correct the errors and try again.")%>
            </li>
            <li>
                <label>
                    Title</label>
            </li>
            <li>
                <%=Html.TextBoxFor(m => m.PageTitle)%>
                <%=Html.ValidationMessageFor(m => m.PageTitle)%>
            </li>
            <li>
                <label>
                    Content</label>
            </li>
            <li>
                <%=Html.TextAreaFor(m => m.Content, new { @class = "textarea" })%>
                <%=Html.ValidationMessageFor(m => m.Content)%>
            </li>
            <li>
                <input type="submit" value="Save page" />
                <input type="button" value="Cancel" onclick="window.location = '/controlpanel/Pages';" />
                <input type="button" value="Add Image" id="Btnaddimage" />
            </li>
        </ul>
        <%}%>
    </div>

    <script src="/Scripts/jquery-1.6.1.min.js" type="text/javascript" charset="utf-8"></script>

    <script src="/Scripts/jquery-fieldselection.js" type="text/javascript"></script>

    <script src="/Scripts/jquery.mousewheel-3.0.4.pack.js" type="text/javascript"></script>

    <script src="/Scripts/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>

    <script src="/Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript" charset="utf-8"></script>

    <script src="/Scripts/elrte.min.js" type="text/javascript" charset="utf-8"></script>

    <link rel="stylesheet" href="/Content/smoothness/jquery-ui-1.8.13.custom.css" type="text/css"
        media="screen" charset="utf-8" />
    <link rel="stylesheet" href="/Content/elrte.min.css" type="text/css" media="screen"
        charset="utf-8" />
    <link href="/Content/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />

    <script src="/Scripts/elrte.en.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript" charset="utf-8">
        $().ready(function() {
            var opts = {
                cssClass: 'el-rte',
                lang: 'en',
                height: 420,
                toolbar: 'maxi',
                cssfiles: ['/Content/elrte-inner.css']
            }
            $('.textarea').elrte(opts);
            $('.el-rte .toolbar UL LI.image').attr('href', '/controlpanel/InsertImage');
            $('.el-rte .toolbar UL LI.image').click(function() {
                try {
                    $('.ui-widget').remove();
                } catch (e) { }
                try {
                    $('.ui-widget-overlay').remove();
                } catch (e) { }
                //var range = $($('iframe')[0].contentDocument.body).getSelection();
            });
            $('.el-rte .toolbar UL LI.image').fancybox({
                'type': 'ajax',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'height': '620',
                'width': '620',
                'autoDimensions': false,
                'onClosed': function() {
                },
                'onStart': function() {
                }
            });
            $('#Btnaddimage').fancybox({
                'href': "/controlpanel/Ajaxaddimage",
                'type': 'iframe',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'autoScale': true,
                'autoDimensions': true,
                'onClosed': function() {
                },
                'onStart': function() {
                }
            });
        })
    </script>

</body>
</html>