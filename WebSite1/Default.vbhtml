﻿@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Home Page"

    Dim SystemResult = Database.Open("DefaultConnection").Query("SELECT * from dbo.System")
    Dim Count = SystemResult.Count

End Code

@Section featured
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                @If Count > 0 Then
                    @<h1>@SystemResult.ElementAt(0).ApplicationName</h1>
                Else
                    @<h1>No Name Set</h1>
                End If
                <h2>Modify this template To jump-start your ASP.NET Web Pages application.</h2>
                </hgroup>
                <p>
                    To learn more about ASP.NET Web Pages, visit
                    <a href = "https://asp.net/webpages" title="ASP.NET Web Pages Website">https://asp.net/webpages</a>.
                    The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET Web Pages.
                    If you have any questions about ASP.NET Web Pages, visit
                    <a href = "https://forums.iis.net/1166.aspx" title="ASP.NET Web Pages Forum">our forums</a>.
                </p>
            </div>
        </section>
End Section

<h3>We suggest the following:</h3>

<ol class="round">
                        <li class="one">
                            <h5> Getting Started</h5>
                            ASP.NET Web Pages and the new Razor syntax provide a fast, approachable, and lightweight way to combine server code with HTML
                            to create dynamic web content. Connect to databases, add video, link to social networking sites, and include many more features
                            that let you create beautiful sites using the latest web standards.
                            <a href = "https://go.microsoft.com/fwlink/?LinkId=245139" > Learn more…</a>
                        </li>

                        <li class="two">
                            <h5> Add NuGet packages and jump start your coding</h5>
                            NuGet makes it easy to install and update free libraries and tools.
                            <a href = "https://go.microsoft.com/fwlink/?LinkId=245140" > Learn more…</a>
                        </li>

                        <li class="three">
                            <h5> Find Web Hosting</h5>
                            You can easily find a web hosting company that offers the right mix of features and price for your applications.
                            <a href = "https://go.microsoft.com/fwlink/?LinkId=245143" > Learn more…</a>
                        </li>
</ol>