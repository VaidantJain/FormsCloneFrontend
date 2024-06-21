Public Class ViewSubmissionsForm
    Private submissions As List(Of Submission)
    Private currentIndex As Integer = 0
    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Label1.Text = "Vaidant Jain, Slidely Task 2 - Slidely Form App"
        Label2.Text = "Name"
        Label3.Text = "Email"
        Label4.Text = "Phone Num"
        Label5.Text = "Github Link" & Environment.NewLine & " for Task 2"
        TextBox1.BackColor = Color.LightGray
        TextBox2.BackColor = Color.LightGray
        TextBox3.BackColor = Color.LightGray
        TextBox4.BackColor = Color.LightGray
        TextBox5.BackColor = Color.LightGray
        Button1.Text = "PREVIOUS (CTRL + P)"
        Button1.BackColor = Color.Yellow
        Button2.Text = "NEXT (CTRL + N)"
        Button2.BackColor = Color.LightBlue
        Label6.Text = "Stopwatch" & Environment.NewLine & "Time"
        FetchSubmissions()
        DisplaySubmission()
    End Sub

    Private Sub FetchSubmissions()
        Dim client As New System.Net.WebClient()
        Dim jsonResponse As String = client.DownloadString("http://localhost:3000/read")
        submissions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Submission))(jsonResponse)
    End Sub

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            Button1.PerformClick()
        End If
        If e.Control AndAlso e.KeyCode = Keys.N Then
            Button2.PerformClick()
        End If
    End Sub
    Private Sub DisplaySubmission()
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            Dim submission As Submission = submissions(currentIndex)
            TextBox1.Text = submission.Name
            TextBox2.Text = submission.Email
            TextBox3.Text = submission.PhoneNumber
            TextBox4.Text = submission.GitHubRepo
            TextBox5.Text = submission.ElapsedTime
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission()
        End If
    End Sub


End Class