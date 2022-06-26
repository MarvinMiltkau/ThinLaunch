﻿Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Process.Start("cmd", "/c taskkill /f /im explorer.exe && C:\ThinLaunch\Connect.rdp")
    End Sub

    Private Sub btnshutdown_Click(sender As Object, e As EventArgs) Handles btnshutdown.Click
        Select Case MessageBox.Show("Möchten Sie den Computer wirklich Herunterfahren?", "ThinLaunch", MessageBoxButtons.YesNo)
            Case Windows.Forms.DialogResult.Yes
                Process.Start("cmd", "/c shutdown.exe /s /t 0 /f")
            Case Windows.Forms.DialogResult.No

        End Select
    End Sub

    Private Sub btnreboot_Click(sender As Object, e As EventArgs) Handles btnreboot.Click
        Select Case MessageBox.Show("Möchten Sie den Computer wirklich Neu starten?", "ThinLaunch", MessageBoxButtons.YesNo)
            Case Windows.Forms.DialogResult.Yes
                Process.Start("cmd", "/c shutdown.exe /r /t 0 /f")
            Case Windows.Forms.DialogResult.No

        End Select
    End Sub

    Private Sub btnconnect_Click(sender As Object, e As EventArgs) Handles btnconnect.Click
        Process.Start("C:\ThinLaunch\Connect.rdp")
    End Sub

    Private Sub btnemergency_Click(sender As Object, e As EventArgs) Handles btnemergency.Click
        Dim emergency As New ProcessStartInfo()
        emergency.Verb = "runas"
        emergency.FileName = "cmd.exe"
        emergency.Arguments = "/c net user EmergencyUser /active:yes && net user ThinUser /active:no && shutdown.exe /r /t 0 /f"

        Try
            Process.Start(emergency)
        Catch

        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub
End Class
