Imports System.Text

Public Class Main

    Private Declare Function GetSystemMetrics Lib "user32" (ByVal nIndex As Long) As Long
    Private Const SM_CLEANBOOT = 67

    Const ApplicationTitle = "Windows Terminal Remover"

    Function GetBootMode() As String
        Select Case GetSystemMetrics(SM_CLEANBOOT)
            Case 1 : Return "SafeMode"
            Case 2 : Return "SafeModeWithNetworking"
            Case Else : Return "Normal"
        End Select
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Step1.Click
        Step1.Enabled = False
        Step1.Text = "Running..."

        RunPowerShellEncodedCommand(My.Resources.Step1)

        Step1.Text = "Rebooting..."
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Step2.Click
        Step2.Enabled = False
        Step2.Text = "Running..."

        RunPowerShellEncodedCommand(My.Resources.Step2)

        Step2.Text = "Rebooting..."
    End Sub

    Sub RunPowerShellEncodedCommand(command)
        'Using to avoid escape problems with quotes

        Dim CommandBytes As Byte() = Encoding.Unicode.GetBytes(command)
        Dim CommandEncoded As String = Convert.ToBase64String(CommandBytes)

        Dim x As New Process
        x.StartInfo.FileName = "powershell"
        x.StartInfo.CreateNoWindow = True
        x.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        x.StartInfo.Arguments = "-EncodedCommand " & CommandEncoded
        x.Start()
        x.WaitForExit()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GetBootMode() = "Normal" Then
            Step1.Enabled = True
            Step2.Enabled = False
        Else
            Step1.Enabled = False
            Step2.Enabled = True
        End If

        MsgBox("Greetings!" & vbNewLine & vbNewLine & "It is VERY important that you read the information on Step 1 and Step 2 before you begin.", vbInformation, ApplicationTitle)
    End Sub

End Class