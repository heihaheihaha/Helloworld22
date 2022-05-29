Imports System.Data.SqlClient

Public Class Form3
    Dim connection As SqlConnection
    Dim cmd As SqlCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection = New SqlConnection
        connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        connection.Open()
        cmd = New SqlCommand("SELECT password FROM Docter WHERE D_ID = " + Trim(TextBox1.Text))
        cmd.Connection = connection
        Dim pass = Str(cmd.ExecuteScalar())
        If pass.Equals(Str(TextBox2.Text)) Then
            MessageBox.Show("登录成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            connection.Close()
            connection.Dispose()
            Form2.Show()
            Me.Close()
        Else
            MessageBox.Show("密码错误!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class