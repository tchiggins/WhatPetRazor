Imports System.Data
Imports System.Data.SqlClient

Partial Class GetEmployeeDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim con As SqlConnection = New SqlConnection("Data Source=localhost;Initial Catalog=master;User ID=sa;Password=Vintage12")
                Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM employee", con)
                cmd.Connection.Open()

                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim ds As New DataSet("DataSet")
                adapter.Fill(ds, "Table")

                If (ds.Tables(0).Rows.Count <= 0) Then
                    Response.Write("Empty")
                Else
                    Dim i As Integer
                    Dim empID As String = ""
                    Dim empName As String = ""

                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        empID += ds.Tables(0).Rows(i)(0).ToString() + ","
                        empName += ds.Tables(0).Rows(i)(1).ToString() + ","
                    Next

                    empID = empID.Substring(0, empID.Length - 1)
                    empName = empName.Substring(0, empName.Length - 1)

                    Response.Write(empID + "~" + empName)
                End If
            Catch ex As Exception
                Response.Write("Error")
            End Try
        End If
    End Sub
End Class
