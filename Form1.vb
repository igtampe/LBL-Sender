Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Text = "Press me again! An LBL Server should be able to handle more than one LBL transfer at a time"
        OpenFileDialog1.Multiselect = True
        Dim result As Boolean = OpenFileDialog1.ShowDialog()
        If result Then
            For Each Filename As String In OpenFileDialog1.FileNames
                Dim LBLER As LBLSender = New LBLSender With {.FileToSend = Filename}
                LBLER.Show()
            Next
        End If
    End Sub

    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        Button1.Text = "now let me go!"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim AllFiles As String() = ServerCommand.RawCommand("LBL:DIR:").Split(",")

        ListView1.Items.Clear()

        For Each File As String In AllFiles
            ListView1.Items.Add(File)
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If Not IsNothing(ListView1.SelectedItems) Then
            Dim Downloader As New LBLReceiver With {.FileToReceive = ListView1.SelectedItems.Item(0).Text}
            Downloader.Show()
        End If
    End Sub
End Class
