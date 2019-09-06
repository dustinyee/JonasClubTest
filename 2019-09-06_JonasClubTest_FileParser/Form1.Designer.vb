<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.DirTextBox1 = New System.Windows.Forms.TextBox()
        Me.ParseButton1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DirTextBox1
        '
        Me.DirTextBox1.Location = New System.Drawing.Point(70, 16)
        Me.DirTextBox1.Name = "DirTextBox1"
        Me.DirTextBox1.Size = New System.Drawing.Size(472, 20)
        Me.DirTextBox1.TabIndex = 0
        '
        'ParseButton1
        '
        Me.ParseButton1.Location = New System.Drawing.Point(236, 55)
        Me.ParseButton1.Name = "ParseButton1"
        Me.ParseButton1.Size = New System.Drawing.Size(75, 23)
        Me.ParseButton1.TabIndex = 1
        Me.ParseButton1.Text = "Parse"
        Me.ParseButton1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Directory:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 90)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ParseButton1)
        Me.Controls.Add(Me.DirTextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DirTextBox1 As TextBox
    Friend WithEvents ParseButton1 As Button
    Friend WithEvents Label1 As Label
End Class
