<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbx_command = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_send = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbx_command
        '
        Me.cbx_command.FormattingEnabled = True
        Me.cbx_command.Location = New System.Drawing.Point(13, 29)
        Me.cbx_command.Name = "cbx_command"
        Me.cbx_command.Size = New System.Drawing.Size(259, 21)
        Me.cbx_command.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Command"
        '
        'btn_send
        '
        Me.btn_send.Location = New System.Drawing.Point(13, 57)
        Me.btn_send.Name = "btn_send"
        Me.btn_send.Size = New System.Drawing.Size(259, 23)
        Me.btn_send.TabIndex = 2
        Me.btn_send.Text = "Send"
        Me.btn_send.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 100)
        Me.Controls.Add(Me.btn_send)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbx_command)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbx_command As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_send As Button
End Class
