Imports System.Data.SqlClient

Public Class Form2
    Dim connection As New SqlConnection
    Dim sqlcmd As SqlCommand

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        connection = New SqlConnection()
        connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        connection.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = connection
        dsDA.SelectCommand.CommandText = $"SELECT Drug AS 药品名称,describe as 描述,price AS 定价,id FROM Drug"
        Dim dset As New DataSet()
        dsDA.Fill(dset, "helloworld")
        connection.Close()
        connection.Dispose()
        connection = Nothing
    End Sub
End Class