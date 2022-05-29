Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim sqlcn As New SqlConnection
    Dim sqlcmd As SqlCommand
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
        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        sqlcn.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = sqlcn
        dsDA.SelectCommand.CommandText = $"SELECT PASSWORD FROM Patient WHERE P_ID = " + TextBox1.Text
        Dim dset As New DataSet()
        dsDA.Fill(dset, "helloworld")


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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class
