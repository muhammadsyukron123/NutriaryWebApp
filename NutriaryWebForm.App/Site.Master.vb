Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("UserID") Is Nothing Then
            ' Redirect pengguna ke halaman login jika belum login
            Response.Redirect("Login.aspx")
        End If

        lblUser.Text = Session("FirstName") & " " & Session("LastName")
    End Sub
End Class