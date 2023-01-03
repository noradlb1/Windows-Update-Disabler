Imports System.ServiceProcess
Public Class Form1

    'Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As System.Windows.Forms.Keys) As Short //for hotkey
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim WindowsUpdateService As New System.ServiceProcess.ServiceController("wuauserv")
            Dim ST As String = WindowsUpdateService.StartType
            Label2.Text = "Disabled"
            Label2.ForeColor = Color.ForestGreen
            Label3.Text = WindowsUpdateService.Status
            If ST IsNot "4" Or WindowsUpdateService.Status = System.ServiceProcess.ServiceControllerStatus.Running Then
                Shell("sc stop wuauserv", AppWinStyle.Hide)
                Shell("sc config wuauserv start= disabled", AppWinStyle.Hide)
            End If
        Catch ex As Exception
            MsgBox("Attempt to disable Update Failed", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer1.Enabled = False
        Label2.Text = "Unblocked"
        Label2.ForeColor = Color.Orange
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer1.Enabled = False
        Label2.Text = "Running"
        Label2.ForeColor = Color.Red
        Shell("sc config wuauserv start=demand", AppWinStyle.Hide)
        Shell("sc start wuauserv", AppWinStyle.Hide)
    End Sub
End Class
