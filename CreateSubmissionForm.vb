Imports System.Diagnostics
Imports System.Net

Public Class CreateSubmissionForm
    Private Stopwatch As Stopwatch

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Stopwatch = New Stopwatch()
        Timer1.Interval = 1000 ' Update every second
        Timer1.Start()

        Label1.Text = "Vaidant Jain, Slidely Task 2 - Slidely Form App"
        Label2.Text = "Name"
        Label3.Text = "Email"
        Label4.Text = "Phone Num"
        Label5.Text = "Github Link" & Environment.NewLine & " for Task 2"
        Button1.Text = "SUBMIT (CTRL + S)"
        Button1.BackColor = Color.LightBlue
        Button2.Text = "TOGGLE STOPWATCH (CTRL + T)"
        Button2.BackColor = Color.Yellow
        Label6.Text = "00:00:00"
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            Button1.PerformClick()
        End If
        If e.Control AndAlso e.KeyCode = Keys.T Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim submission As New Submission With {
            .Name = TextBox1.Text,
            .Email = TextBox2.Text,
            .PhoneNumber = TextBox3.Text,
            .GitHubRepo = TextBox4.Text,
            .ElapsedTime = String.Format("{0:hh\:mm\:ss}", Stopwatch.Elapsed)
        }

        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(submission)
        Try
            Using client As New WebClient()
                client.Headers(HttpRequestHeader.ContentType) = "application/json"
                client.UploadString("http://localhost:3000/submit", json)
            End Using
            MessageBox.Show("Submission successful!")
            ResetForm()

        Catch ex As Exception
            MessageBox.Show("Submission failed: " & ex.Message)
        End Try
    End Sub

    Private Sub ResetForm()
        ' Stop and reset the stopwatch
        Stopwatch.Stop()
        Stopwatch.Reset()
        Label6.Text = "00:00:00"
        Button2.Text = "Start"

        ' Clear the text boxes
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Stopwatch.IsRunning Then
            Stopwatch.Stop()
            Button2.Text = "Resume"
        Else
            Stopwatch.Start()
            Button2.Text = "Pause"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = String.Format("{0:hh\:mm\:ss}", Stopwatch.Elapsed)
    End Sub
End Class

Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property PhoneNumber As String
    Public Property GitHubRepo As String
    Public Property ElapsedTime As String
End Class
