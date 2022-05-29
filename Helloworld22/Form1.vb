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
        connection = New SqlConnection
        connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        connection.Open()
        cmd = New SqlCommand("SELECT password FROM Patient WHERE P_ID = " + Trim(TextBox1.Text))
        cmd.Connection = connection
        Dim pass = Str(cmd.ExecuteScalar())
        If pass.Equals(Str(TextBox2.Text)) Then
            MessageBox.Show("登录成功", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Form4.Show()
            connection.Close()
            connection.Dispose()
        Else
            MessageBox.Show("密码错误", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Form3.Show()
        Me.Hide()
    End Sub
End Class
