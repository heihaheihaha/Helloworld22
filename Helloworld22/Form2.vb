Imports System.Data.SqlClient

Public Class Form2
    Dim _cmd As String
    Dim _cmm, _cmm2, _cmm3 As SqlCommand
    Dim adapter As New SqlDataAdapter
    Dim connection As New SqlConnection
    Dim _connection As New SqlConnection
    Dim sqlcmd As SqlCommand
    Dim d_id As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Drugmanagement.Show()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim intValue As Integer
        If Integer.TryParse(TextBox3.Text, intValue) Then
            Return
        Else
            MessageBox.Show("请输入正确的数字", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim intValue As Integer
        If Integer.TryParse(TextBox3.Text, intValue) Then
            Dim dalg = MessageBox.Show("确认提交？", "提交", MessageBoxButtons.OKCancel,
                                       MessageBoxIcon.Exclamation)
            If dalg = DialogResult.OK Then
                _connection = New SqlConnection()
                _connection.ConnectionString = "server=(local);database=Helloworld;Integrated Security=True"
                _connection.Open()
                _cmd = "INSERT INTO Drug_use VALUES ( '" + TextBox1.Text + "','" + d_id + "','" + Form3.TextBox1.Text + "'," + DateAndTime.DateString + "," + TextBox3.Text + ")"
                adapter.SelectCommand = New SqlCommand(_cmd, _connection)
                adapter.SelectCommand.ExecuteNonQuery()
                _connection.Close()
                _connection.Dispose()
                _connection = Nothing
                '清空输入框
                TextBox2.Text = ""
                TextBox3.Text = "0"
                RichTextBox1.Text = ""
            End If
        End If
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
        _cmm2 = New SqlCommand("select ID FROM Drug WHERE Drug_name  like'%" + TextBox2.Text + "%'")
        _cmm.Connection = connection
        _cmm2.Connection = connection
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
                d_id = _cmm2.ExecuteScalar()
            End If
        End If
        connection.Close()
        connection.Dispose()
        connection = Nothing
    End Sub
End Class