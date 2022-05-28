Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim sqlcn As New SqlConnection
    Dim sqlcmd As SqlCommand
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlcn = New SqlConnection()
        sqlcn.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        sqlcn.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = sqlcn
        dsDA.SelectCommand.CommandText = "SELECT * FROM DOCTER"
        Dim dset As New DataSet()
        dsDA.Fill(dset, "helloworld")
        DataGridView1.DataSource = dset
        DataGridView1.DataMember = "helloworld"

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
