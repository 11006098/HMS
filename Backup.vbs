Dim Input
set fso = createObject("Scripting.FileSystemObject")
str = "BackUp"&"_"&Date&"_"&Time
str = Replace(str,"/","")
str = Replace(str,":","")
str = Replace(str,".","")
str = "G:\SAD\HMS\Project\Backup\" &str

call fso.CreateFolder(str)
if(fso.FolderExists(str)) then
	fso.CopyFolder  "G:\SAD\HMS\Project\HMS", str
	msgbox "Copied"
Else
	Msgbox "Not copied"
End if
