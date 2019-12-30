﻿<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        Dim PT_rows = DB.Query(Cmd)

        Cmd = "SELECT pc.ClassName FROM PetClass pc
        ORDER BY pc.ClassName"
        Dim S_rows = DB.Query(Cmd)
    End Code
    <select>
        @For Each S_row In S_rows
            @<option value="@S_row.ClassName">@S_row.ClassName</option>
        Next
    </select>
    <table style = "border:1px solid black" >
            <tr style="border:1px solid black"><td>Name</td><td>Size</td><td>Diet</td><td>Image</td></tr>
        @For Each PT_row In PT_rows
            @<tr style="border:1px solid black">
                <td>@PT_row.TypeName</td>
                <td>@PT_row.PetSize</td>
                <td>@PT_row.PetDiet</td>
                <td><img src="~/Images/pets/@PT_row.PetImage" height="120" /></td></tr>
        Next
    </table>
</body>
</html>