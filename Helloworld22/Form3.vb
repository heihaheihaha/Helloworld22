Imports System.Data.SqlClient

Public Class Form3
    Dim connection As SqlConnection
    Dim cmd As SqlCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
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
        cmd = New SqlCommand("SELECT password FROM Docter WHERE D_ID = " + "'" + Trim(TextBox1.Text) + "'")
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
                Form2.Show()
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

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim dalg As DialogResult = MessageBox.Show("请联系管理员解决", "忘记密码？", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If dalg = DialogResult.Yes Then
            MessageBox.Show("3520225523@qq.com", "请发送邮件至", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class