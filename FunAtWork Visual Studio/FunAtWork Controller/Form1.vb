Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim request As System.Net.WebRequest = System.Net.WebRequest.Create("http://192.168.35.2:8080/getCommands")
        Dim postData As String = ""
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

        Dim dt As New DataTable()
        dt.Columns.Add("CommandID")
        dt.Columns.Add("Command")
        Dim dr As DataRow
        Dim data As Array
        For Each r As String In responseFromServer.Split(";")
            data = r.Split(",")
            dr = dt.NewRow
            dr("CommandID") = data(0)
            dr("Command") = data(1)
            dt.Rows.Add(dr)
        Next

        cbx_command.DataSource = dt
        cbx_command.ValueMember = "CommandID"
        cbx_command.DisplayMember = "Command"

        reader.Close()
        dataStream.Close()
        response.Close()
    End Sub

    Private Sub btn_send_Click(sender As Object, e As EventArgs) Handles btn_send.Click
        Dim request As System.Net.WebRequest = System.Net.WebRequest.Create("http://192.168.35.2:8080/setCommand")
        Dim postData As String = "AppID=1;CommandID=" & cbx_command.SelectedValue
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
    End Sub
End Class
