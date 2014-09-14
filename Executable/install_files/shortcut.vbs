Set VbsObj = CreateObject("WScript.Shell")

ShortCutPath = VbsObj.SpecialFolders("Desktop")
Set MyShortcut = VbsObj.CreateShortcut(ShortCutPath & "\MineStock Workbench.lnk")
MyShortcut.TargetPath = "C:\MineStock\Program\FYP_GUI_v1\bin\Release\FYP_GUI_v1.exe"
MyShortcut.IconLocation = "C:\MineStock\Program\FYP_GUI_v1\bin\Release\FYP_GUI_v1.exe"
MyShortcut.Save