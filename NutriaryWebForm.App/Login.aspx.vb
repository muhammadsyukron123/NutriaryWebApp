Imports NutriaryWebApp.BLL.BLL

Public Class Login
    Inherits System.Web.UI.Page
    Dim _authenticationBLL As New AuthenticationBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserID") IsNot Nothing Then
            Response.Redirect("DailyConsumption.aspx")
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim userId As Integer
            Dim result = _authenticationBLL.UserLogin(txtEmail.Text, txtPassword.Text, userId)
            If result = 1 Then
                Session("UserID") = userId
                Response.Redirect("DailyConsumption.aspx")

                'set the session 
                ltLoginStatus.Text = "<span class='alert alert-success'>Login Successful </span><br/><br/>"
            Else
                ltLoginStatus.Text = "<span class='alert alert-danger'>Invalid Email or Password </span><br/><br/>"
            End If
        Catch ex As Exception
            ltLoginStatus.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class