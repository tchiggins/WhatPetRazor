@Code
    WebSecurity.InitializeDatabaseConnection("StarterSite", "UserProfile", "UserId", "Email", autoCreateTables:=False)
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

    'System table

    Dim DB = Database.Open("DefaultConnection")
    Dim Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'System')
    PRINT 'Table Exists'ELSE CREATE TABLE dbo.System (SystemID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
    ApplicationName varchar(128) NOT NULL, Image varbinary NULL);"
    DB.Execute(Cmd)

    'Users table
    Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Users')
    PRINT 'Table Exists'
    ELSE CREATE TABLE dbo.Users (UserID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
    FirstName varchar(128) NOT NULL, LastName varchar(128) NOT NULL, Gender varchar (128)
    NOT NULL, Email varchar(128) NOT NULL, RegisteredDate datetime NOT NULL);"
    DB.Execute(Cmd)

    'Ordo table
    Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Ordo')
    PRINT 'Table Exists'
    ELSE CREATE TABLE dbo.Ordo (OrdoID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
    OrdoName varchar(128) NOT NULL);"
    DB.Execute(Cmd)

    'Species table
    Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Species')
    PRINT 'Table Exists'
    ELSE CREATE TABLE dbo.Species (SpeciesID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
    SpeciesName varchar(128) NOT NULL, OrdoID uniqueidentifier FOREIGN KEY REFERENCES Ordo(OrdoID));"
    DB.Execute(Cmd)
    End Code