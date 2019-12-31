<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Ajax_VB.aspx.vb" Inherits="Ajax_VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ajax_VB</title>
    
<script type="text/javascript" language="javascript">
var xmlHttp
function GetData()
{

    xmlHttp=GetXmlHttpObject()
 
    if (xmlHttp==null)
    {
        alert ("Browser does not support HTTP Request")
        return;
    } 
    var url="GetEmployeeDetails.aspx"
    xmlHttp.onreadystatechange=stateChanged
    xmlHttp.open("GET",url,true)
    xmlHttp.send(null)
} 

function stateChanged() 
{ 
    if (xmlHttp.readyState==4 || xmlHttp.readyState=="complete")
    { 
        var response=xmlHttp.responseText;
        
        response=response.substring(0,response.indexOf("<!DOCTYPE")-4);
        
        if(response=="Empty")
        {
            alert("No Record Found !!!");
        }
        else if(response=='Error')
        {
            alert("An Error occured in accessing the DataBase !!!");
        }
        else
        {
            var arr=response.split("~");
            var empID=arr[0].split(",");
            var empName=arr[1].split(",");
        
            document.getElementById('dlistEmployee').length=0;
            for(var i=0;i<empID.length;i++)
            {
                var o = document.createElement("option");
                o.value = empID[i];
                o.text = empName[i];
                document.getElementById('dlistEmployee').add(o);
            }
        }
   } 
} 

function GetXmlHttpObject()
{ 
    var objXMLHttp=null
    if (window.XMLHttpRequest)
    {
        objXMLHttp=new XMLHttpRequest()
    }
    else if (window.ActiveXObject)
    {
        objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP")
    }
    return objXMLHttp
} 

function display()
{
    var selIndex=document.getElementById("dlistEmployee").selectedIndex;
    var empName=document.getElementById("dlistEmployee").options(selIndex).text;
    var empID=document.getElementById("dlistEmployee").options(selIndex).value;
    
    document.getElementById("lblResult").innerHTML="You have selected " + empName + " ( ID : " + empID + " )";
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <input id="btnGetData" type="button" value="I am Html Button To Get Employee Data From DB" onclick="GetData();"/>
        <asp:DropDownList ID="dlistEmployee" runat="server" onchange="display();">
        </asp:DropDownList>
        <asp:Label ID="lblResult" runat="server" Text="No Record Selected"></asp:Label></div>
    </form>
</body>
</html>
