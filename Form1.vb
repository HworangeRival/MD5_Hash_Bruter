Public Class Form1

    Dim done As Boolean

    Public Shared Function getMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
    
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim password As String
        password = TextBox4.Text
        If TextBox4.Text = "" Then
            MsgBox("Please Enter a Password or Hash")
        Else
            Dim test() As String = {"", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
                                    "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S",
                                    "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "~", "!", "@", "#", "$", "%", "^",
                                    "&", "*", "(", ")", "_", "-", "+", "="}
            For x As Integer = 0 To test.Length - 1
                Me.Button2.Enabled = True
                Console.WriteLine(test(x))
                For y As Integer = 0 To test.Length - 1
                    Console.WriteLine(test(x) & test(y))
                    For z As Integer = 0 To test.Length - 1
                        Console.WriteLine(test(x) & test(y) & test(z))
                        For q As Integer = 0 To test.Length - 1
                            Console.WriteLine(test(x) & test(y) & test(z) & test(q))
                            For j As Integer = 0 To test.Length - 1
                                Console.WriteLine(test(x) & test(y) & test(z) & test(q) & test(j))
                                TextBox3.Text = test(x) & test(y) & test(z) & test(q) & test(j)
                                TextBox3.Refresh()
                                Me.Refresh()
                                If getMD5Hash(test(x) & test(y) & test(z) & test(q) & test(j)) = password Then
                                    MsgBox("Password is:" & test(x) & test(y) & test(z) & test(q) & test(j))
                                    done = True
                                    TextBox4.Text = ""
                                    TextBox3.Text = ""
                                End If
                            Next
                            If done = True Then Exit Sub
                        Next
                        If done = True Then Exit Sub
                    Next
                    If done = True Then Exit Sub
                Next
                If done = True Then Exit Sub
            Next
        End If

        If done = True Then
            done = False
        End If
        TextBox3.Enabled = True
        TextBox4.Enabled = True

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Button3.Select()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        done = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        'This button sets done to true and this stops the loop
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        done = False
        If done = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        'This button starts the loop by running backgroundWorker and disables the textboxes
    End Sub

    Private Sub TextBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.DoubleClick
        Clipboard.SetText(TextBox3.Text) : MsgBox("Copied in Clipoard!")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        done = True : Application.Exit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class

