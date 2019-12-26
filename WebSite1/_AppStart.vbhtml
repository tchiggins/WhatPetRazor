@Code
    WebSecurity.InitializeDatabaseConnection("StarterSite", "UserProfile", "UserId", "Email", autoCreateTables:=True)

    ' To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
    ' you must update this site. For more information visit https://go.microsoft.com/fwlink/?LinkID=226949

    ' OAuthWebSecurity.RegisterMicrosoftClient(
    '     clientId:="",
    '     clientSecret:="")

    ' OAuthWebSecurity.RegisterTwitterClient(
    '     consumerKey:="",
    '     consumerSecret:="")

    ' OAuthWebSecurity.RegisterFacebookClient(
    '     appId:="",
    '     appSecret:="")

    ' OAuthWebSecurity.RegisterGoogleClient()

    ' WebMail.SmtpServer = "mailserver.example.com"
    ' WebMail.EnableSsl = True
    ' WebMail.UserName = "username@example.com"
    ' WebMail.Password = "your-password"
    ' WebMail.From = "your-name-here@example.com"

    ' To learn how to optimize scripts and stylesheets in your site go to  https://go.microsoft.com/fwlink/?LinkID=248974
    Dim DB = Database.Open("DefaultConnection")
    Dim Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'System') PRINT 'Table Exists'ELSE CREATE TABLE dbo.System (SystemID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY, ApplicationName varchar(128) NOT NULL, Image varbinary NULL)"
    DB.Execute(Cmd)

    End Code