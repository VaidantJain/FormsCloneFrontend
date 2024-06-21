Public Class Form1
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Label1.Text = "Vaidant Jain, Slidely Task 2 - Slidely Form App"
        ViewSubmissions.Text = "VIEW SUBMISSIONS(CTRL + V)"
        CreateSubmission.Text = "CREATE SUBMISSION(CTRL + N)"
        ViewSubmissions.BackColor = Color.Yellow
        CreateSubmission.BackColor = Color.LightBlue

    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            ViewSubmissions_Click(ViewSubmissions, EventArgs.Empty)
        End If
        If e.Control AndAlso e.KeyCode = Keys.N Then
            CreateSubmission_Click(CreateSubmission, EventArgs.Empty)
        End If
    End Sub
    Private Sub ViewSubmissions_Click(sender As Object, e As EventArgs) Handles ViewSubmissions.Click

        Dim viewForm As New ViewSubmissionsForm()
        viewForm.ShowDialog()
    End Sub

    Private Sub CreateSubmission_Click(sender As Object, e As EventArgs) Handles CreateSubmission.Click
        Dim createForm As New CreateSubmissionForm()
        createForm.ShowDialog()
    End Sub

End Class
