Public Class Form1

    Dim randomnumber As New Random

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = Nothing

        Dim beginningtext As String = TextBox1.Text

        Dim textarray() As String = beginningtext.Split(" ")

        Dim vowels As Integer
        Dim vowelloc() As Integer
        Dim charcounter As Integer = 0
        Dim vowelarraycounter As Integer = 0
        Dim chosennum As Integer
        Dim whichvoweltoremove As Integer = 0

        For Each item In textarray
            vowels = 0
            charcounter = 0
            vowelarraycounter = 0

            For Each character As Char In item

                If character = "a" Or character = "e" Or character = "i" Or character = "o" Or character = "u" Then

                    vowels += 1

                End If

            Next

            ReDim vowelloc(vowels)

            For Each character As Char In item

                If character = "a" Or character = "e" Or character = "i" Or character = "o" Or character = "u" Then

                    vowelloc(vowelarraycounter) = charcounter
                    vowelarraycounter += 1
                End If

                charcounter += 1
            Next

            'MAX NUM TO REMOVE

            If vowels <> 0 Then

                If vowels = 1 Then
                    chosennum = 1
                Else
                    Do Until chosennum <> 0
                        chosennum = randomnumber.Next(vowels + 1)
                        If chosennum = vowels + 1 Then
                            chosennum = vowels - 1
                        End If
                    Loop

                End If

                Else
                chosennum = randomnumber.Next(vowels)
            End If

           




            'GETS STRING
            Dim newtext As String = item
            Dim removecounter As Integer = 0
            Dim counter As Integer = 0

            Do Until counter >= chosennum

                Try
                    newtext = newtext.Replace(newtext.Substring(vowelloc(counter) - removecounter, 1), "")
                Catch ex As Exception
                    newtext = newtext.Substring(0, newtext.Length - 1)
                End Try


                counter += 1
                removecounter += 1
            Loop

            TextBox2.Text = TextBox2.Text & " " & newtext






            'LAST NEXT
        Next

        If TextBox2.Text.Substring(0, 1) = " " Then
            TextBox2.Text = TextBox2.Text.Remove(0, 1)
        End If

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SplashScreen.Close()
    End Sub
End Class
