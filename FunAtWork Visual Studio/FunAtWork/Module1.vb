Imports System.Threading
Imports System.Net.WebRequest
Imports System.Windows.forms
Module Module1
    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Private Const KEYEVENTF_KEYUP As Long = &H2
    Private Const VK_LWIN As Long = &H5B

    Sub Main()
        Thread.Sleep(1000)
        While True
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create("http://192.168.35.2:8080/getCommand")
            Dim postData As String = "AppID=1"
            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(postData)
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length

            Dim dataStream As System.IO.Stream = request.GetRequestStream
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()

            Dim response As System.Net.WebResponse = request.GetResponse
            dataStream = response.GetResponseStream

            Dim reader As New System.IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd

            reader.Close()
            dataStream.Close()
            response.Close()

            Select Case responseFromServer
                Case "1"
                    keybd_event(VK_LWIN, 0&, 0&, 0&)
                    keybd_event(VK_LWIN, 0&, KEYEVENTF_KEYUP, 0&)
                Case "2"
                    Process.Start("shutdown", "-s")
                Case "3"
                    Process.Start("shutdown", "-l")
                Case "4"
                    Process.Start("shutdown", "-h")
                Case "5"
                    SendKeys.SendWait("Hello! I'm your computer.")
                Case "6"
                    SendKeys.SendWait("{Enter}")
                Case "7"
                    Process.Start("mspaint")
                Case "8"
                    MsgBox("Never", MsgBoxStyle.Critical, "Rick Rolled")
                    MsgBox("Gonna", MsgBoxStyle.Exclamation, "Rick Rolled")
                    MsgBox("Give", MsgBoxStyle.Information, "Rick Rolled")
                    MsgBox("You", MsgBoxStyle.Critical, "Rick Rolled")
                    MsgBox("Up", MsgBoxStyle.Exclamation, "Rick Rolled")
                    Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ")
            End Select

            Thread.Sleep(1000)
        End While
    End Sub

End Module
