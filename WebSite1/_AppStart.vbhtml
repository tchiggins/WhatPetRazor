@Functions
    Function InsertIntoDB()
        Dim DB = Database.Open("DefaultConnection")

        Dim Cmd = "DELETE FROM pets.dbo.PetClass"
        DB.Execute(Cmd)

        Cmd = "DELETE FROM pets.dbo.Species"
        DB.Execute(Cmd)

        Cmd = "DELETE FROM pets.dbo.PetType"
        DB.Execute(Cmd)

        Dim CSVImportVB As New DataSetup
        CSVImportVB.PC_CSVImport("PetClass.csv")
        CSVImportVB.S_CSVImport("Species.csv")
        CSVImportVB.PT_CSVImport("PetType.csv")

        Return True
    End Function

    Function CreateTables() As Boolean

        'Users table
        'UserID represents the DB's ID code for the user (user will never see)
        'RegisteredDate will track the date upon which that user registered
        'PassHash will store a hashed version of the user's password to add security in case of DB compromise
        Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Users')
        PRINT 'Table Exists'
        ELSE CREATE TABLE dbo.Users (UserID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
        FirstName varchar(128) NOT NULL, LastName varchar(128) NOT NULL, Gender varchar (128)
        NOT NULL, Email varchar(128) NOT NULL, RegisteredDate datetime NOT NULL,
        PassHash varchar(512) NOT NULL);"
        DB.Execute(Cmd)

        'Class table (mammal, bird, reptile etc.)
        Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PetClass')
        PRINT 'Table Exists'
        ELSE CREATE TABLE dbo.PetClass (PetClassID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
        ClassName varchar(128) NOT NULL);"
        DB.Execute(Cmd)

        'Species table (cat, dog etc.)
        Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Species')
        PRINT 'Table Exists'
        ELSE CREATE TABLE dbo.Species (SpeciesID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
        SpeciesName varchar(128) NOT NULL,
        PetClassID uniqueidentifier NOT NULL);"
        DB.Execute(Cmd)

        'PetType table (characteristics of specific breed)
        'PetSize will work on values of either Small, Average, or Large (as determined by the average for that particular species)
        Cmd = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PetType')
        PRINT 'Table Exists'
        ELSE CREATE TABLE dbo.PetType (TypeID uniqueidentifier ROWGUIDCOL NOT NULL PRIMARY KEY,
        SpeciesID uniqueidentifier NOT NULL, TypeName varchar(128) NOT NULL, PetSize varchar(128) NOT NULL,
        PetSolitary varchar(128) NOT NULL, PetIndoors varchar(128) NOT NULL, PetOutdoors varchar(128) NOT NULL,
        PetWalk varchar(128) NOT NULL, PetDiet varchar(128) NOT NULL, PetImage varchar(512) NOT NULL);"
        DB.Execute(Cmd)

        Return True
    End Function
End Functions
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

    CreateTables()
    InsertIntoDB()
End Code