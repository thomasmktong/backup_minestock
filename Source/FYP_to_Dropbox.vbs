dim filesys
Set filesys = CreateObject("Scripting.FileSystemObject")

dim objZip
Set objZip = CreateObject("XStandard.Zip")

dim timeStr
timeStr = Day(Now) & MonthName(Month(Now),true) & Year(Now) & "-" & Timer

If filesys.FolderExists("C:\Documents and Settings\Thomas\My Documents\Visual Studio 2010\Projects") Then
   objZip.Pack "C:\Documents and Settings\Thomas\My Documents\Visual Studio 2010\Projects", "C:\Documents and Settings\Thomas\My Documents\My Dropbox\Study\COMP451\source\" & timeStr & ".zip"
End If