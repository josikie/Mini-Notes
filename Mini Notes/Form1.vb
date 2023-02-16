Imports System.IO
Imports System.Text

Public Class Form1
    Dim theFilePath As String = ""
    Private Function countingWords(theText As String)
        theText = " " + theText
        theText = Replace(theText, vbNewLine, " ")
        Dim numberOfWords As Integer = 0
        For i = 1 To Len(theText) - 1
            Dim firstSpace As String = Mid(theText, i, 1)
            Dim lastSpace As String = Mid(theText, i + 1, 1)
            If firstSpace = " " And lastSpace <> " " Then
                numberOfWords += 1
            End If
        Next
        Return numberOfWords
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim textTitle As String
        Dim path As String = "C:\Users\LENOVO\source\repos\Mini Notes\Mini Notes\Files\"
        textTitle = TextBox2.Text
        path += textTitle
        path += ".txt"

        Dim idx As Integer
        If ComboBox1.FindString(path) >= 0 Then
            MessageBox.Show("Duplicate File Name")
            idx = ComboBox1.FindString(path)
        Else
            idx = ComboBox1.Items.Add(path)
        End If

        ComboBox1.SelectedIndex = idx
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim text As New StringBuilder
        text.AppendLine(TextBox1.Text)
        Try
            If theFilePath IsNot "" Then
                System.IO.File.WriteAllText(theFilePath, text.ToString())
                MessageBox.Show("Written to the file.")
            End If
        Catch ex As Exception
            MessageBox.Show("Invalid File")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        theFilePath = ComboBox1.Text
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String = "C:\Users\LENOVO\source\repos\Mini Notes\Mini Notes\Files\"
        For Each file In My.Computer.FileSystem.GetFiles(path)
            ComboBox1.Items.Add(file)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If theFilePath IsNot "" Then
                Dim theText As String = My.Computer.FileSystem.ReadAllText(theFilePath)
                TextBox1.Text = theText
            End If
        Catch ex As Exception
            MessageBox.Show("Empty File")
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim numOfWords As Integer = countingWords(TextBox1.Text)
        TextBox3.Text = numOfWords
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        File.Delete(theFilePath)
        ComboBox1.Items.Remove(ComboBox1.SelectedItem)
        ComboBox1.SelectedIndex = -1
        MessageBox.Show("File Deleted.")
    End Sub
End Class