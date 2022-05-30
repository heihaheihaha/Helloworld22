Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim connection As New SqlConnection
    Dim cmd As SqlCommand

    Private Sub Form1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        '另一种实现窗体居中的方法
        'Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        '' Note: call this from frm's Load event!
        '    Dim r As Rectangle
        '    If parent IsNot Nothing Then
        '        r = parent.RectangleToScreen(parent.ClientRectangle)
        '    Else
        '        r = Screen.FromPoint(frm.Location).WorkingArea
        '    End If

        '    Dim x = r.Left + (r.Width - frm.Width) \ 2
        '    Dim y = r.Top + (r.Height - frm.Height) \ 2
        '    frm.Location = New Point(x, y)
        'End Sub

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Label4.Visible = 1
            Return
        End If

        If TextBox2.Text = "" Then
            Label5.Visible = 1
            Return
        End If
        connection = New SqlConnection
        connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        connection.Open()
        cmd = New SqlCommand("SELECT password FROM Patient WHERE P_ID = " + "'" + Trim(TextBox1.Text) + "'")
        cmd.Connection = connection
        'when it's null ExecuteScalar() will return Nothing
        If cmd.ExecuteScalar() = Nothing Then
            Dim dalg As DialogResult = MessageBox.Show("请检查用户名", "用户名异常", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
            If dalg = Windows.Forms.DialogResult.Retry Then
                TextBox1.Text = ""
            End If
        Else
            If Str(cmd.ExecuteScalar()) = Str(TextBox2.Text) Then
                MessageBox.Show("登录成功", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                Form4.Show()
                connection.Close()
                connection.Dispose()
            Else
                Dim adlg As DialogResult = MessageBox.Show("密码错误", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                If adlg = DialogResult.Retry Then
                    TextBox2.Text = ""
                End If
            End If
        End If
    End Sub

    Public Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'Label4 的可见性
        Dim str As String
        str = TextBox1.Text
        If str.Length() > 6 Then Label4.Visible = 1 Else Label4.Visible = 0
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        'Label5 的可见性
        Label5.Visible = 0
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim dalg As DialogResult = MessageBox.Show("请联系管理员解决", "忘记密码？", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If dalg = DialogResult.Yes Then
            MessageBox.Show("3520225523@qq.com", "请发送邮件至", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Form3.Show()
        Me.Hide()
    End Sub
End Class
