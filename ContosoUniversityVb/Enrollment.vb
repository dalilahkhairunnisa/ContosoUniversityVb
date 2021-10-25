Imports System.Data.SqlClient
Public Class Enrollment
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
    Sub KondisiAwal()
        Call Koneksi()
        da = New SqlDataAdapter("Select * from Enrollment", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "Enrollment")
        DataGridView1.DataSource = (ds.Tables("Enrollment"))
        Call Kosong()
    End Sub
    Sub Kosong()
        TextBox2.Text = ""
        ComboC.Text = ""
        ComboS.Text = ""
        ComboG.Text = ""
    End Sub

    Private Sub FormEnrollment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Try
            Dim Cmd As New SqlCommand("Select * from Course", Conn)

            Dim Ad As New SqlDataAdapter(Cmd)

            Dim Table As New DataTable()

            Ad.Fill(Table)
            ComboC.DataSource = Table
            ComboC.DisplayMember = "Title"
            ComboC.ValueMember = "CourseID"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try

        Try
            Dim Cmd As New SqlCommand("Select * from Grade", Conn)

            Dim Ad As New SqlDataAdapter(Cmd)

            Dim Table As New DataTable()

            Ad.Fill(Table)
            ComboG.DataSource = Table
            ComboG.DisplayMember = "Grade"
            ComboG.ValueMember = "GradeID"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try

        Try
            Dim Cmd As New SqlCommand("Select * from Student", Conn)

            Dim Ad As New SqlDataAdapter(Cmd)

            Dim Table As New DataTable()
            Ad.Fill(Table)
            ComboS.DataSource = Table
            ComboS.DisplayMember = "LastName"
            ComboS.ValueMember = "ID"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try




    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboC.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call Koneksi()
        Dim HapusData As String = "delete Enrollment where EnrollmentID='" & TextBox2.Text & "'"
        Cmd = New SqlCommand(HapusData, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Delete success")
        Call KondisiAwal()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Koneksi()
        Dim insert As String
        insert = "set identity_insert Enrollment on; "
        insert &= "insert into Enrollment (EnrollmentID, CourseID, StudentID, Grade) values ('" & TextBox2.Text & "','" & ComboC.DropDownStyle & "', '" & ComboS.DropDownStyle & "', '" & ComboG.DropDownStyle & "'); "
        insert &= "set identity_insert Enrollment off; "
        Cmd = New SqlCommand(insert, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Input success")
        Call KondisiAwal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Koneksi()
        Dim EditData As String = "update Enrollment set CourseID='" & ComboC.SelectedIndex & "', StudentID='" & ComboS.SelectedIndex & "', Grade='" & ComboG.SelectedIndex & "' where EnrollmentID='" & TextBox2.Text & "'"
        Cmd = New SqlCommand(EditData, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Edit success")
        Call KondisiAwal()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox2.Text = DataGridView1.Item(0, i).Value
        ComboC.Text = DataGridView1.Item(1, i).Value
        ComboS.Text = DataGridView1.Item(2, i).Value
        ComboG.Text = DataGridView1.Item(3, i).Value
    End Sub

End Class