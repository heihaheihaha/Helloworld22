Imports System.Data.SqlClient

Public Class Form2
    Dim _cmd As String
    Dim _cmm, _cmm2, _cmm3 As SqlCommand
    Dim adapter As New SqlDataAdapter
    Dim connection As New SqlConnection
    Dim sqlcmd As SqlCommand
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Drugmanagement.Show()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        connection = New SqlConnection()
        connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        connection.Open()
        _cmm = New SqlCommand("SELECT * FROM Patient WHERE P_ID = '" + TextBox1.Text + "'")
        _cmm.Connection = connection
        'when it's null ExecuteScalar() will return Nothing
        If _cmm.ExecuteScalar() = Nothing Then
            connection.Close()
            connection.Dispose()
        Else
            Dim dsDA As New SqlDataAdapter()
            dsDA.SelectCommand = New SqlCommand()
            dsDA.SelectCommand.Connection = connection
            dsDA.SelectCommand.CommandText = "SELECT * FROM Patient WHERE P_ID = '" + TextBox1.Text + "'"
            Dim dset As New DataSet()
            dsDA.Fill(dset, "helloworlddd")
            DataGridView1.DataSource = dset
            DataGridView1.DataMember = "helloworlddd"
            connection.Close()
            connection.Dispose()
            connection = Nothing
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        connection = New SqlConnection
        connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        connection.Open()
        _cmm = New SqlCommand("select Drug_name FROM Drug WHERE Drug_name  like'%" + TextBox2.Text + "%'")
        _cmm.Connection = connection
        If _cmm.ExecuteScalar() = Nothing Then
            Label5.Visible = 0
        Else
            Label5.Text = "您也许想输入：" + _cmm.ExecuteScalar()
            Label5.Visible = 1
            _cmm3 = New SqlCommand("select describe FROM Drug WHERE Drug_name ='" + TextBox2.Text + "'")
            _cmm3.Connection = connection
            If _cmm3.ExecuteScalar() = Nothing Then
                Return
            Else
                RichTextBox1.Text = _cmm3.ExecuteScalar()
            End If
        End If
        connection.Close()
        connection.Dispose()
        connection = Nothing
    End Sub
End Class