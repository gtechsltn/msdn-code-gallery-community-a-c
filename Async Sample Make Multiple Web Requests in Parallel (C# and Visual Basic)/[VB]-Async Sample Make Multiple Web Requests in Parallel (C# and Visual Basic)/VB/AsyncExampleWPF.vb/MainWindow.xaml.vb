﻿

' Add the following Imports statements, and add a reference for System.Net.Http.
Imports System.Net.Http


Class MainWindow

    Async Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click

        resultsTextBox.Clear()
        Await CreateMultipleTasksAsync()
        resultsTextBox.Text &= vbCrLf & "Control returned to startButton_Click."
    End Sub


    Private Async Function CreateMultipleTasksAsync() As Task

        ' Declare an HttpClient object.
        Dim client As HttpClient = New HttpClient()

        ' Create and start the tasks. As each task finishes, DisplayResults 
        ' displays its length.
        Dim download1 As Task(Of Integer) =
            ProcessURL("http://msdn.microsoft.com", client)
        Dim download2 As Task(Of Integer) =
            ProcessURL("http://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx", client)
        Dim download3 As Task(Of Integer) =
            ProcessURL("http://msdn.microsoft.com/en-us/library/67w7t67f.aspx", client)

        ' Await each task.
        Dim length1 As Integer = Await download1
        Dim length2 As Integer = Await download2
        Dim length3 As Integer = Await download3

        Dim total As Integer = length1 + length2 + length3

        ' Display the total count for all of the websites.
        resultsTextBox.Text &= String.Format(vbCrLf & vbCrLf &
                                             "Total bytes returned:  {0}" & vbCrLf, total)
    End Function


    Private Async Function ProcessURL(url As String, client As HttpClient) As Task(Of Integer)

        Dim byteArray = Await client.GetByteArrayAsync(url)
        DisplayResults(url, byteArray)
        Return byteArray.Length
    End Function


    Private Sub DisplayResults(url As String, content As Byte())

        ' Display the length of each web site. The string format 
        ' is designed to be used with a monospaced font, such as
        ' Lucida Console or Global Monospace.
        Dim bytes = content.Length
        ' Strip off the "http://".
        Dim displayURL = url.Replace("http://", "")
        resultsTextBox.Text &= String.Format(vbCrLf & "{0,-58} {1,8}", displayURL, bytes)
    End Sub

End Class


