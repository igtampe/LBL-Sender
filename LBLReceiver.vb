Public Class LBLReceiver

    Public FileToReceive As String
    Private CurrentPercentage As Double = 0
    Private CurrentHeader As String = "Initializing File Transfer"
    Private CurrentFooter As String = "Reading File "
    Private WebLocation As String = ""

    Private Sub LBLSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setprogress(0)
        Text = "Getting file " & FileToReceive
        Header.Text = "Initializing File Transfer"
        Footer.Text = "Waiting for Server"
        LBLBackgroundSender.RunWorkerAsync()
    End Sub

    Private Sub LBLActualSender() Handles LBLBackgroundSender.DoWork

        FileOpen(1, FileToReceive, OpenMode.Output)

        'Initialize the transfer
        CurrentFooter = "Initializing LBL Transfer"
        LBLBackgroundSender.ReportProgress(0)
        Dim Receiver As LBLClientDownload = New LBLClientDownload(FileToReceive)
        Dim X As Double = 0
        Dim MeasuringTimeCoso As Stopwatch = New Stopwatch()
        Dim TimeLeft As String = ""
        Dim ServerMSG As String = ""

        Dim alllines As Integer = Receiver.RemainingLines

        'Send the coito
        CurrentHeader = "Downloading File"
        For X = 0 To alllines
            CurrentPercentage = X / alllines
            CurrentFooter = "Receiving line " & X & " of " & alllines & ", " & Math.Floor(CurrentPercentage * 100) & "%" & TimeLeft

            LBLBackgroundSender.ReportProgress(X)

            MeasuringTimeCoso.Start()
            ServerMSG = Receiver.GetLine()
            MeasuringTimeCoso.Stop()

            If ServerMSG = "CLOSED" Or ServerMSG = "LBL.PLSCLOSE" Then
                Exit For
            End If

            PrintLine(1, ServerMSG)

            TimeLeft = ", about " & CInt((MeasuringTimeCoso.ElapsedMilliseconds / 1000.0) * (alllines - X - 1)) & "s to go."
            MeasuringTimeCoso.Reset()
            X += 1
        Next

        'Close the cosito
        CurrentHeader = "Finalizing transfer"
        CurrentFooter = "Please wait..."
        CurrentPercentage = 1
        LBLBackgroundSender.ReportProgress(100)
        WebLocation = Receiver.Close()
        FileClose(1)
    End Sub

    Private Sub LBLReportProgress() Handles LBLBackgroundSender.ProgressChanged
        Header.Text = CurrentHeader
        Footer.Text = CurrentFooter
        setprogress(CurrentPercentage)
    End Sub

    Private Sub LBLDone() Handles LBLBackgroundSender.RunWorkerCompleted
        Header.Text = "File Transfer Complete!"
        Footer.Text = "You can close this window now."
        PictureBox1.Image = My.Resources.CertificationCheck
    End Sub

    Private Sub setprogress(progress As Double)
        ProgressBar.Width = 500 * progress
    End Sub
End Class