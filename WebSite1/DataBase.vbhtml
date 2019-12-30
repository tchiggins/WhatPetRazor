<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    @Code
        Dim DB = Database.Open("DefaultConnection")
        Dim Cmd As String
        Cmd = "SELECT pt.TypeName, pt.PetSize, pt.PetSolitary, pt.PetIndoors, pt.PetOutdoors, pt.PetWalk, pt.PetDiet, pt.PetImage, s.SpeciesName FROM PetType pt JOIN Species s
	    ON (pt.SpeciesID = s.SpeciesID)
	    ORDER BY pt.TypeName"

        Dim rows = DB.Query(Cmd)
    End Code
    <table style ="border:1px solid black">
        @For Each row In rows
            @<tr style="border:1px solid black"><td>@row.TypeName</td><td>@row.PetSize</td><td>@row.PetDiet</td><td><img src="~/Images/pets/@row.PetImage" height="120" /></td></tr>
        Next
    </table>
</body>
</html>