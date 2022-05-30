Imports System.Data.SqlClient
Public Class Drugmanagement
    Dim connection As New SqlConnection
    Dim cmd As String
    Dim adapter As New SqlDataAdapter
    Private Sub Drugmamagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        connection = New SqlConnection()
        connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        connection.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = connection
        dsDA.SelectCommand.CommandText = $"SELECT * FROM Drug"
        Dim dset As New DataSet()
        dsDA.Fill(dset, "helloworld")
        DataGridView1.DataSource = dset
        DataGridView1.DataMember = "helloworld"
        connection.Close()
        connection.Dispose()
        connection = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dalg As DialogResult = MessageBox.Show("确认提交？", "提交", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
        If dalg = DialogResult.OK Then
            DataGridView1.Visible = 0
            connection = New SqlConnection()
            connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
            connection.Open()
            cmd = "INSERT INTO Drug VALUES ( ' " + Trim(TextBox1.Text) + "','" + RichTextBox1.Text + "'," & TextBox2.Text & ")"
            adapter.SelectCommand = New SqlCommand(cmd, connection)
            adapter.SelectCommand.ExecuteNonQuery()
            connection.Close()
            connection.Dispose()
            connection = Nothing
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim intValue As Integer
        If Integer.TryParse(TextBox2.Text, intValue) Then
            Return
        Else
            MessageBox.Show("请键入有效的数字")
        End If
    End Sub
End Class