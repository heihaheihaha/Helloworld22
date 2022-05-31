Imports System.Data.SqlClient

Public Class Form4
    Dim connection As SqlConnection
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = 1
        MessageBox.Show("为了保护您的隐私，窗口会在60秒后关闭！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.CenterToScreen()
        connection = New SqlConnection()
        connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        connection.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = connection
        dsDA.SelectCommand.CommandText = "SELECT * FROM Drug_use WHERE P_ID ='" + Form1.TextBox1.Text + "'"
        Dim dset As New DataSet()
        dsDA.Fill(dset, "helloworld")
        DataGridView1.DataSource = dset
        DataGridView1.DataMember = "helloworld"
        connection.Close()
        connection.Dispose()
        connection = Nothing
    End Sub
    '刷新
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection = New SqlConnection()
        connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        connection.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = connection
        dsDA.SelectCommand.CommandText = "SELECT * FROM Drug_use WHERE P_ID = '" + Form1.TextBox1.Text + "'"
        Dim dset As New DataSet()
        dsDA.Fill(dset, "helloworld")
        DataGridView1.DataSource = dset
        DataGridView1.DataMember = "helloworld"
        connection.Close()
        connection.Dispose()
        connection = Nothing
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Close()
    End Sub
End Class