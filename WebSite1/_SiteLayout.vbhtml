<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>@PageData("Title") - My ASP.NET Web Page</title>
        <link href="~/Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
        <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
        <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <script src="~/Scripts/jquery-3.4.1.min.js"></script>
        <script src="~/Scripts/jquery-ui-1.12.1.js"></script>
        <script src="~/Scripts/modernizr-2.8.3.js"></script>
        <meta name="viewport" content="width=device-width" />
    </head>
    <body></body>
    @Code
        Dim SystemResult = Database.Open("DefaultConnection").Query("SELECT * from dbo.System")
        Dim Count = SystemResult.Count
    End Code
        <header>
              <div class="content-wrapper">
                  <table>
                      <tr>
                          <td>
                              <div class="float-left">
                                  <img src="~/Images/logo.jpeg" alt="WhatPet Logo" style="width:30px" />
                              </div>
                          </td>
                          <td>
                              <h1>WhatPet</h1>
                          </td>
                      </tr>
                  </table>
                <div Class="float-right">
                    <section id = "login" >
    @If WebSecurity.IsAuthenticated Then
    @<text>
        Hello, <a class="email" href="~/Account/Manage" title="Manage">@WebSecurity.CurrentUserName</a>!
        <form id="logoutForm" action="~/Account/Logout" method="post">
            @AntiForgery.GetHtml()
            <a href="javascript:document.getElementById('logoutForm').submit()">Log out</a>
        </form>
    </text>
    Else
                            @<ul>
                                <li><a href="~/Account/Register">Register</a></li>
                                <li><a href="~/Account/Login">Log in</a></li>
                            </ul>
    End If
                        </section>
                        <nav>
                            <ul id = "menu" >
                                <li><a href="Default.vbhtml">Home</a></li>
                            <li> <a href = "About.vbhtml" > About</a></li>
                                <li> <a href = "Contact.vbhtml" > Contact</a></li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </header>
            <div id = "body" >
    @RenderSection("featured", required:=false)
                <section class="content-wrapper main-content clear-fix">
    @RenderBody()
                </section>
            </div>
            <footer>
                                <div class="content-wrapper">
                    <div class="float-left">
                        <p>&copy; @DateTime.Now.Year - My ASP.NET Web Page</p>
                                        </div>
                                    </div>
                                </footer>
                        @RenderSection("Scripts", required:=False)
                            </body>
</html>