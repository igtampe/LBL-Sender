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
End Class
