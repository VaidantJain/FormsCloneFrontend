Imports System.Net

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
        Button3.Text = "UPDATE (CTRL + U)"
        Button3.BackColor = Color.LightGreen
        Button4.Text = "DELETE (CTRL + D)"
        Button4.BackColor = Color.Red
        Label6.Text = "Stopwatch" & Environment.NewLine & "Time"
        FetchSubmissions()
        DisplaySubmission()
    End Sub

    Private Sub FetchSubmissions()
        Dim client As New WebClient()
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
        If e.Control AndAlso e.KeyCode = Keys.U Then
            Button3.PerformClick()
        End If
        If e.Control AndAlso e.KeyCode = Keys.D Then
            Button4.PerformClick()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        UpdateSubmission()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DeleteSubmission()
    End Sub
    Private Sub UpdateSubmission()
        Dim updatedSubmission As New Submission With {
            .Name = TextBox1.Text,
            .Email = TextBox2.Text,
            .PhoneNumber = TextBox3.Text,
            .GitHubRepo = TextBox4.Text,
            .ElapsedTime = TextBox5.Text
        }

        Dim client As New WebClient()
        Dim submissionData As New With {
            .index = currentIndex,
            .submission = updatedSubmission
        }
        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(submissionData)

        Try
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim response As String = client.UploadString("http://localhost:3000/update", "PUT", json)
            MessageBox.Show("Update successful: " & response)
            submissions(currentIndex) = updatedSubmission
        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message)
        End Try
    End Sub
    Private Sub DeleteSubmission()
        Dim client As New WebClient()
        Dim deleteData As New With {
            .index = currentIndex
        }
        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(deleteData)

        Try
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim response As String = client.UploadString("http://localhost:3000/delete", "DELETE", json)
            MessageBox.Show("Delete successful: " & response)
            submissions.RemoveAt(currentIndex)
            If currentIndex >= submissions.Count Then
                currentIndex = submissions.Count - 1
            End If
            DisplaySubmission()
        Catch ex As Exception
            MessageBox.Show("Delete failed: " & ex.Message)
        End Try
    End Sub
End Class


