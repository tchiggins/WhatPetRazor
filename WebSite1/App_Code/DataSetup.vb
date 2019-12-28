Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class DataSetup
    Inherits System.Web.UI.Page
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String
    Private Function SendSQLCommand(Command As String) As String
        'Create a Connection object.
#If DEBUG Then
        myConn = New SqlConnection("Initial Catalog=Pets;Data Source=tcp:mssqluk18.prosql.net;User ID=oliver;Password=Vintage12!$;")
#Else
        myConn = New SqlConnection("Initial Catalog=Pets;Data Source=tcp:mssqluk18.prosql.net;User ID=oliver;Password=Vintage12!$;")
#End If
        myCmd = myConn.CreateCommand
        myCmd.CommandText = Command
        'Open the connection.
        myConn.Open()
        'Execute the command.
        myReader = myCmd.ExecuteReader()
        'Concatenate the query result into a string.
        Do While myReader.Read()
            results = results & myReader.GetString(0) & vbTab & myReader.GetString(1) & vbLf
        Loop
        'Close the reader and the database connection.
        myReader.Close()
        myConn.Close()
        Return results
    End Function
    Private Function SendToDB(myConn As SqlConnection, Command As String) As Integer
        myCmd = myConn.CreateCommand
        myCmd.CommandText = Command
        'Execute the command.
        Dim count = myCmd.ExecuteNonQuery()
        Return count
    End Function
    Public Function PC_CSVImport(FileName As String) As Boolean
        'Connect to DB
        'Create a Connection object.
#If DEBUG Then
        myConn = New SqlConnection("Initial Catalog=Pets;Data Source=tcp:mssqluk18.prosql.net;User ID=oliver;Password=Vintage12!$;")
#Else
        myConn = New SqlConnection("Initial Catalog=Pets;Data Source=tcp:mssqluk18.prosql.net;User ID=oliver;Password=Vintage12!$;")
#End If
        myConn.Open()
        Dim Cmd As String
        'Upload and save the file  
        Dim CSVPath As String = Server.MapPath("~/Files/") + Path.GetFileName(FileName)
        'Read the contents of CSV file.  
        Dim csvData As String = File.ReadAllText(CSVPath)
        'Execute a loop over the rows.  
        For Each row As String In csvData.Split(ControlChars.Cr)
            If Not String.IsNullOrEmpty(row) Then
                Dim i As Integer = 0
                'Execute a loop over the columns.  
                For Each cell As String In row.Split(","c)
                    If cell.Length > 1 Then
                        Cmd = "INSERT INTO dbo.PetClass (PetClassID, ClassName) VALUES (NEWID(), '"
                        Cmd += cell
                        Cmd += "')"
                        SendToDB(myConn, Cmd)
                    End If
                    i += 1
                Next
            End If
        Next
        myConn.Close()
        Return True
    End Function
    Public Function S_CSVImport(FileName As String) As Boolean
        'Connect to DB
        'Create a Connection object.
        Dim temp As String
#If DEBUG Then
        myConn = New SqlConnection("Initial Catalog=Pets;Data Source=tcp:mssqluk18.prosql.net;User ID=oliver;Password=Vintage12!$;")
#Else
        myConn = New SqlConnection("Initial Catalog=Pets;Data Source=tcp:mssqluk18.prosql.net;User ID=oliver;Password=Vintage12!$;")
#End If
        myConn.Open()
        Dim Cmd As String
        'Upload and save the file  
        Dim CSVPath As String = Server.MapPath("~/Files/") + Path.GetFileName(FileName)
        'Read the contents of CSV file.  
        Dim csvData As String = File.ReadAllText(CSVPath)
        'Execute a loop over the rows.  
        For Each row As String In csvData.Split(ControlChars.Cr)
            If Not String.IsNullOrEmpty(row) Then
                Dim i As Integer = 0
                'Execute a loop over the columns.  
                For Each cell As String In row.Split(","c)
                    If cell.Length > 1 Then
                        Cmd = "SELECT FROM dbo.PetClass WHERE ClassName = '"
                        Cmd += cell
                        Cmd += "' ;"
                        SendToDB(myConn, Cmd)
                        Cmd = "INSERT INTO dbo.Species (SpeciesID, SpeciesName) VALUES (NEWID(), '"
                        Cmd += cell
                        Cmd += "', "
                        SendToDB(myConn, Cmd)
                    End If
                    i += 1
                Next
            End If
        Next
        myConn.Close()
        Return True
    End Function
End Class