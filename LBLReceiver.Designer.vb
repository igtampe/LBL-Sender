<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LBLReceiver
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LBLBackgroundSender = New System.ComponentModel.BackgroundWorker()
        Me.Header = New System.Windows.Forms.Label()
        Me.Footer = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLBackgroundSender
        '
        Me.LBLBackgroundSender.WorkerReportsProgress = True
        Me.LBLBackgroundSender.WorkerSupportsCancellation = True
        '
        'Header
        '
        Me.Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header.Location = New System.Drawing.Point(118, 20)
        Me.Header.Name = "Header"
        Me.Header.Size = New System.Drawing.Size(503, 25)
        Me.Header.TabIndex = 3
        Me.Header.Text = "Downloading A:\Downloads\TTS.CSV"
        '
        'Footer
        '
        Me.Footer.Location = New System.Drawing.Point(118, 45)
        Me.Footer.Name = "Footer"
        Me.Footer.Size = New System.Drawing.Size(501, 13)
        Me.Footer.TabIndex = 4
        Me.Footer.Text = "Waiting For server"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(118, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(500, 25)
        Me.Label1.TabIndex = 4
        '
        'ProgressBar
        '
        Me.ProgressBar.BackColor = System.Drawing.Color.MediumBlue
        Me.ProgressBar.Location = New System.Drawing.Point(118, 72)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(30, 25)
        Me.ProgressBar.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LBL_Sender.My.Resources.Resources.FileIn
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 96)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'LBLReceiver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(633, 119)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Footer)
        Me.Controls.Add(Me.Header)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "LBLReceiver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LBL Receiver"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LBLBackgroundSender As System.ComponentModel.BackgroundWorker
    Friend WithEvents Header As Label
    Friend WithEvents Footer As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar As Label
End Class
