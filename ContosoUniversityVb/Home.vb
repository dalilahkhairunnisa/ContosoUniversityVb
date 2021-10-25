Public Class Home
    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        sembunyi()
        Student.TopLevel = False
        Panel1.Controls.Add(Student)
        Student.Show()
    End Sub

    Private Sub CourseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CourseToolStripMenuItem.Click
        sembunyi()
        Course.TopLevel = False
        Panel1.Controls.Add(Course)
        Course.Show()
    End Sub

    Private Sub EnrollmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnrollmentToolStripMenuItem.Click
        sembunyi()
        Enrollment.TopLevel = False
        Panel1.Controls.Add(Enrollment)
        Enrollment.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Sub sembunyi()
        PictureBox1.Hide()
        Student.Hide()
        Course.Hide()
        Enrollment.Hide()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class