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
        Dim dsDa As New SqlDataAdapter()
        dsDa.SelectCommand = New SqlCommand()
        dsDa.SelectCommand.Connection = connection
        dsDa.SelectCommand.CommandText = $"SELECT * FROM Drug"
        Dim dset As New DataSet()
        dsDa.Fill(dset, "helloworld")
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
            Dim dalg2 As DialogResult = MessageBox.Show("请确认将要删除的药品名：" + TextBox1.Text, "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If dalg2 = DialogResult.OK Then
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
            If dalg2 = DialogResult.Cancel Then
                Return
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        connection = New SqlConnection()
        connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        connection.Open()
        cmd = "DELETE FROM Drug WHERE Drug_name = like'%" + TextBox1.Text + "%'"
        adapter.SelectCommand = New SqlCommand(cmd, connection)
        If adapter.SelectCommand.ExecuteScalar() = Nothing Then
            Label4.Visible = 0
        Else
            Label4.Text = adapter.SelectCommand.ExecuteScalar()
            Label4.Visible = 1
        End If
        connection.Close()
        connection.Dispose()
        connection = Nothing
    End Sub
End Class