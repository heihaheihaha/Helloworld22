Imports System.Data.SqlClient
Public Class Drugmanagement
    Dim connection As New SqlConnection
    Dim cmd As String
    Dim cmm As SqlCommand
    Dim adapter As New SqlDataAdapter
    Private Sub Drugmamagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
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
        Dim intValue As Integer
        If Integer.TryParse(TextBox2.Text, intValue) Then
            Dim dalg As DialogResult = MessageBox.Show("确认提交？", "提交", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            If dalg = DialogResult.OK Then
                connection = New SqlConnection()
                connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
                connection.Open()
                cmd = "INSERT INTO Drug VALUES ( '" + Trim(TextBox1.Text) + "','" + RichTextBox1.Text + "'," & TextBox2.Text & ")"
                adapter.SelectCommand = New SqlCommand(cmd, connection)
                adapter.SelectCommand.ExecuteNonQuery()
                connection.Close()
                connection.Dispose()
                connection = Nothing
                '清空输入框
                TextBox1.Text = ""
                TextBox2.Text = ""
                RichTextBox1.Text = ""
                '刷新DataGridView1
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
            End If
        Else
            MessageBox.Show("请键入有效的数字")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connection = New SqlConnection
        connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        connection.Open()
        cmm = New SqlCommand("SELECT Drug_name FROM drug WHERE Drug_name = '" + TextBox1.Text + "'")
        cmm.Connection = connection
        'when it's null ExecuteScalar() will return Nothing
        If cmm.ExecuteScalar() = Nothing Then
            Dim adlg As DialogResult = MessageBox.Show("该药品不在库中", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connection.Close()
            connection.Dispose()
        Else
            connection = New SqlConnection()
            connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
            connection.Open()
            cmd = "DELETE FROM Drug WHERE Drug_name = '" + TextBox1.Text + "'"
            adapter.SelectCommand = New SqlCommand(cmd, connection)
            adapter.SelectCommand.ExecuteNonQuery()
            connection.Close()
            connection.Dispose()
            connection = Nothing
        End If
    End Sub
End Class