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
        ViewSubmissions = New Button()
        CreateSubmission = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' ViewSubmissions
        ' 
        ViewSubmissions.Location = New Point(199, 159)
        ViewSubmissions.Name = "ViewSubmissions"
        ViewSubmissions.Size = New Size(366, 55)
        ViewSubmissions.TabIndex = 0
        ViewSubmissions.Text = "ViewSubmissions"
        ViewSubmissions.UseVisualStyleBackColor = True
        ' 
        ' CreateSubmission
        ' 
        CreateSubmission.Location = New Point(199, 235)
        CreateSubmission.Name = "CreateSubmission"
        CreateSubmission.Size = New Size(366, 50)
        CreateSubmission.TabIndex = 1
        CreateSubmission.Text = "CreateSubmission"
        CreateSubmission.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(199, 125)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 20)
        Label1.TabIndex = 2
        Label1.Text = "Label1"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(CreateSubmission)
        Controls.Add(ViewSubmissions)
        Name = "Form1"
        Text = "HomePage"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ViewSubmissions As Button
    Friend WithEvents CreateSubmission As Button
    Friend WithEvents Label1 As Label

End Class
