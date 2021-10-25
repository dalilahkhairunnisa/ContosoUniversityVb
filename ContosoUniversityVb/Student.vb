Imports System.Data.SqlClient
Public Class Student

    Dim Conn As SqlConnection
    Dim da As SqlDataAdapter
    Dim Cmd As SqlCommand
    Dim Rd As SqlDataReader
    Dim ds As DataSet
    Dim LokasiDB As String
    Sub Koneksi()
        LokasiDB = "data source=LAPTOP-SKOTDA7R;initial catalog=ContosoUniv;integrated security =true"
        Conn = New SqlConnection(LokasiDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

    Sub kondisiAwal()
        Call Koneksi()
        da = New SqlDataAdapter("Select * from Student", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "Student")
        DataGridView1.DataSource = (ds.Tables("Student"))
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiAwal()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Koneksi()
        Dim insert As String
        insert = "set identity_insert Student on; "
        insert &= "insert into Student (ID, LastName, FirstMidName, EnrollmentDate) values ('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & DateTimePicker1.Text & "'); "
        insert &= "set identity_insert Student off; "
        Cmd = New SqlCommand(insert, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Input success")
        Call kondisiAwal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Koneksi()
        Dim EditData As String = "update Student set LastName='" & TextBox2.Text & "', FirstMidName='" & TextBox3.Text & "', EnrollmentDate='" & DateTimePicker1.Text & "' where ID='" & TextBox1.Text & "'"
        Cmd = New SqlCommand(EditData, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Edit success")
        Call kondisiAwal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call Koneksi()
        Dim HapusData As String = "delete Student where ID='" & TextBox1.Text & "'"
        Cmd = New SqlCommand(HapusData, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Delete success")
        Call kondisiAwal()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            Cmd = New SqlCommand("select * from Student where ID='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TextBox2.Text = Rd.Item("LastName")
                TextBox3.Text = Rd.Item("FirstMidName")
                DateTimePicker1.Text = Rd.Item("EnrollmentDate")
            Else
                MsgBox("Data Not Found")
            End If
        End If
    End Sub
End Class