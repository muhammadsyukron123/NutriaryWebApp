Imports NutriaryWebApp.BLL.BLL
Imports NutriaryWebApp.BLL.DTOs

Public Class Login
    Inherits System.Web.UI.Page
    Dim _authenticationBLL As New AuthenticationBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID") IsNot Nothing Then
            Response.Redirect("Dashboard.aspx")
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim _authenticationDTO As New UserLoginDTO
            Dim result = _authenticationBLL.LoginUser(txtEmail.Text, txtPassword.Text)
            If result IsNot Nothing Then
                Session("LoginResult") = result.LoginResult
                Session("UserID") = result.user_id
                Session("Username") = result.username
                Session("FirstName") = result.firstname
                Session("LastName") = result.lastname
                Response.Redirect("Dashboard.aspx")
                ltLoginStatus.Text = "<span class='alert alert-success'>Login Successful</span><br/><br/>"
            Else
                ltLoginStatus.Text = "<span class='alert alert-danger'>Invalid Email or Password</span><br/><br/>"
            End If
        Catch ex As Exception
            ltLoginStatus.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class