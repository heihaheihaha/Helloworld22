<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(224, 298)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 34)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "提交"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(144, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "用户名："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(162, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "密码："
        '
        'TextBox1
        '
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Location = New System.Drawing.Point(232, 159)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(390, 30)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "请输入账号"
        '
        'TextBox2
        '
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox2.Location = New System.Drawing.Point(232, 205)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(390, 30)
        Me.TextBox2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(458, 308)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "忘记密码？"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(406, 346)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 32
        Me.DataGridView1.Size = New System.Drawing.Size(393, 103)
        Me.DataGridView1.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "登录"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Public WithEvents Label3 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
