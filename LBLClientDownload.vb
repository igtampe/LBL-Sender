Imports LBL_Sender.ServerCommand
Public Class LBLClientDownload
    Private ID As Integer
    Public RemainingLines As Integer

    ''' <summary>
    ''' Creates and starts an LBL Transfer with the specified filename
    ''' </summary>
    ''' <param name="Filename"></param>
    Public Sub New(Filename As String)
        Dim ServerMSG As String() = RawCommand("LBL:OPENGET:" & Filename).Split(":")
        Dim IDHolder As String = ServerMSG(0)
        If IDHolder = "E" Then
            Throw New LBLOpenError
        ElseIf IDHolder = "NE" Then
            Throw New LBLFileNotFoundException
        ElseIf IDHolder = "invalid Packet Sent" Then
            Throw New LBLNotSupportedException()
        End If
        ID = IDHolder
        RemainingLines = ServerMSG(1)
    End Sub

    Public Function GetLine()
        Dim response As String = RawCommand("LBL:TRANSFER:" & ID & ":")
        If response = "E" Or response = "CRASH" Or response = "NOCONNECT" Then
            Do
                Dim QuestionReply As MsgBoxResult = MsgBox("I couldn't send the current line. Would you like me to try again?" & vbNewLine & vbNewLine & "Response from the server: " & response, MsgBoxStyle.AbortRetryIgnore + MsgBoxStyle.Question, "LBL Transfer")
                Select Case QuestionReply
                    Case MsgBoxResult.Abort
                        Close()
                        Return "CLOSED"
                    Case MsgBoxResult.Ignore
                        Return "OK"
                    Case MsgBoxResult.Retry
                        response = RawCommand("LBL:TRANSFER:" & ID & ":")
                End Select
            Loop While response = "E" Or response = "CRASH" Or response = "NOCONNECT"
        ElseIf response = "invalid Packet Sent" Then
            'OpenGet already checks if LBL is supported. This may occur during transfer and it simply indicates a blank line.
            'Perhaps by LBL2.1 we can replace this with LBL.EMPTYLINE
            Return ""
        End If
        Return response
    End Function

    Public Function Close() As String
        Dim response As String = RawCommand("LBL:CLOSE:" & ID)
        If response = "E" Then
            Throw New LBLCloseError()
        End If
        ID = Nothing
        Return response
    End Function



    'Internal exceptions:
    Public Class LBLNotSupportedException
        Inherits Exception
        Public Sub New()
            MyBase.New("LBL is not supported by the server")
        End Sub
    End Class
    Public Class LBLOpenError
        Inherits Exception
        Public Sub New()
            MyBase.New("LBL Could not open a file transfer now.")
        End Sub
    End Class
    Public Class LBLFileNotFoundException
        Inherits Exception
        Public Sub New()
            MyBase.New("LBL Could not find the file")
        End Sub
    End Class
    Public Class LBLCloseError
        Inherits Exception
        Public Sub New()
            MyBase.New("LBL Could not close this file transfer. Perhaps something else already closed it?")
        End Sub
    End Class

End Class
