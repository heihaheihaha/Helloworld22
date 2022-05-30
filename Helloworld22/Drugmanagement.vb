Imports System.Data.SqlClient
Public Class Drugmanagement
    Dim _connection As New SqlConnection
    Dim _cmd As String
    Dim _cmm, _cmm2, _cmm3 As SqlCommand
    Dim adapter As New SqlDataAdapter
    Private Sub Drugmamagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        _connection = New SqlConnection()
        _connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        _connection.Open()
        Dim dsDa As New SqlDataAdapter()
        dsDa.SelectCommand = New SqlCommand()
        dsDa.SelectCommand.Connection = _connection
        dsDa.SelectCommand.CommandText = $"SELECT * FROM Drug"
        Dim dset As New DataSet()
        dsDa.Fill(dset, "helloworld")
        DataGridView1.DataSource = dset
        DataGridView1.DataMember = "helloworld"
        _connection.Close()
        _connection.Dispose()
        _connection = Nothing
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim intValue As Integer
        If Integer.TryParse(TextBox2.Text, intValue) Then
            Dim dalg As DialogResult = MessageBox.Show("确认提交？", "提交", MessageBoxButtons.OKCancel,
                                                       MessageBoxIcon.Exclamation)
            If dalg = DialogResult.OK Then
                _connection = New SqlConnection()
                _connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
                _connection.Open()
                _cmd = "INSERT INTO Drug VALUES ( '" + Trim(TextBox1.Text) + "','" + RichTextBox1.Text + "'," & TextBox2.Text & ")"
                adapter.SelectCommand = New SqlCommand(_cmd, _connection)
                adapter.SelectCommand.ExecuteNonQuery()
                _connection.Close()
                _connection.Dispose()
                _connection = Nothing
                '清空输入框
                TextBox1.Text = ""
                TextBox2.Text = ""
                RichTextBox1.Text = ""
                '刷新DataGridView1
                _connection = New SqlConnection()
                _connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
                _connection.Open()
                Dim dsDa As New SqlDataAdapter()
                dsDa.SelectCommand = New SqlCommand()
                dsDa.SelectCommand.Connection = _connection
                dsDa.SelectCommand.CommandText = $"SELECT * FROM Drug"
                Dim dset As New DataSet()
                dsDa.Fill(dset, "helloworld")
                DataGridView1.DataSource = dset
                DataGridView1.DataMember = "helloworld"
                _connection.Close()
                _connection.Dispose()
                _connection = Nothing
            End If
        Else
            MessageBox.Show("请键入有效的数字")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        _connection = New SqlConnection
        _connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        _connection.Open()
        _cmm = New SqlCommand("SELECT Drug_name FROM drug WHERE Drug_name = '" + TextBox1.Text + "'")
        _cmm.Connection = _connection
        'when it's null ExecuteScalar() will return Nothing
        If _cmm.ExecuteScalar() = Nothing Then
            Dim adlg As DialogResult = MessageBox.Show("该药品不在库中", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _connection.Close()
            _connection.Dispose()
        Else
            Dim dalg2 As DialogResult = MessageBox.Show("请确认将要删除的药品名：" + TextBox1.Text, "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If dalg2 = DialogResult.OK Then
                _connection = New SqlConnection()
                _connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
                _connection.Open()
                _cmd = "DELETE FROM Drug WHERE Drug_name = '" + TextBox1.Text + "'"
                adapter.SelectCommand = New SqlCommand(_cmd, _connection)
                adapter.SelectCommand.ExecuteNonQuery()
                _connection.Close()
                _connection.Dispose()
                _connection = Nothing
            End If
            If dalg2 = DialogResult.Cancel Then
                Return
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        _connection = New SqlConnection
        _connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        _connection.Open()
        If RichTextBox1.Text = "" Then
            Dim intValue As Integer
            If Integer.TryParse(TextBox2.Text, intValue) Then
                _cmd = "UPDATE Drug SET price=" + TextBox2.Text + "WHERE Drug_name = '" + TextBox1.Text + "'"
                adapter.SelectCommand = New SqlCommand(_cmd, _connection)
                adapter.SelectCommand.ExecuteNonQuery()
            Else
                MessageBox.Show("请键入有效的单价")
                Return
            End If
        Else
            _cmd = "UPDATE Drug SET describe=" + RichTextBox1.Text + "WHERE Drug_name = '" + TextBox1.Text + "'"
            adapter.SelectCommand = New SqlCommand(_cmd, _connection)
            adapter.SelectCommand.ExecuteNonQuery()
            RichTextBox1.Text = ""
            MessageBox.Show("已修改描述，但未对单价做出修改，如需修改单价，请在描述栏为空时重新提交修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '刷新DataGridView1
        _connection = New SqlConnection()
        _connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
        _connection.Open()
        Dim dsDA As New SqlDataAdapter()
        dsDA.SelectCommand = New SqlCommand()
        dsDA.SelectCommand.Connection = _connection
        dsDA.SelectCommand.CommandText = $"SELECT * FROM Drug"
        Dim dset As New DataSet()
        dsDA.Fill(dset, "helloworld")
        DataGridView1.DataSource = dset
        DataGridView1.DataMember = "helloworld"
        _connection.Close()
        _connection.Dispose()
        _connection = Nothing
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Visible = 1
        Button3.Visible = 0
        _connection = New SqlConnection
        _connection.ConnectionString = "server=(local);database=helloworld;integrated security = true"
        _connection.Open()
        _cmm = New SqlCommand("select Drug_name FROM Drug WHERE Drug_name  like'%" + TextBox1.Text + "%'")
        _cmm.Connection = _connection
        If _cmm.ExecuteScalar() = Nothing Then
            Label4.Visible = 0
        Else
            Label4.Text = "您也许想输入：" + _cmm.ExecuteScalar()
            Label4.Visible = 1
            _cmm2 = New SqlCommand("select price FROM Drug WHERE Drug_name ='" + TextBox1.Text + "'")
            _cmm3 = New SqlCommand("select describe FROM Drug WHERE Drug_name ='" + TextBox1.Text + "'")
            _cmm2.Connection = _connection
            _cmm3.Connection = _connection
            If _cmm2.ExecuteScalar() = Nothing Then
                Return
            Else
                TextBox2.Text = _cmm2.ExecuteScalar()
                RichTextBox1.Text = _cmm3.ExecuteScalar()
                Button1.Visible = 0
                Button3.Visible = 1
            End If
        End If
        _connection.Close()
        _connection.Dispose()
        _connection = Nothing
    End Sub
End Class