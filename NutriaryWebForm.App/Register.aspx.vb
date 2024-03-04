Imports NutriaryWebApp.BLL.BLL
Imports NutriaryWebApp.BLL.DTOs

Public Class Register
    Inherits System.Web.UI.Page
    Dim _createUserBll As New CreateUserBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs)
        Dim _createUserDTO As New CreateUserDTO
        _createUserDTO.email = txtEmail.Text
        _createUserDTO.password = txtPassword.Text
        _createUserDTO.username = txtUsername.Text
        _createUserDTO.firstname = txtFirstName.Text
        _createUserDTO.lastname = txtLastName.Text

        Try
            If (txtPassword.Text = txtConfirmPassword.Text) Then
                ' Lakukan proses registrasi
                _createUserBll.CreateUser(_createUserDTO)
                ltRegisterStatus.Text = "<span class='alert alert-success'>Registration Successful </span><br/><br/>"

                ' Cek apakah proses registrasi berhasil sebelum melakukan login
                Dim _authentication As New AuthenticationBLL
                Dim result = _authentication.LoginUser(txtUsername.Text, txtPassword.Text)

                ' Pastikan login berhasil sebelum redirect
                If result IsNot Nothing AndAlso result.LoginResult = 1 Then
                    ' Simpan informasi user dalam session
                    Session("LoginResult") = result.LoginResult
                    Session("UserID") = result.user_id
                    Session("Username") = result.username
                    Session("FirstName") = result.firstname
                    Session("LastName") = result.lastname

                    ' Redirect ke halaman user profile setelah login berhasil
                    Response.Redirect("InsertUserProfile.aspx")
                Else
                    ' Tampilkan pesan jika login gagal
                    ltRegisterStatus.Text = "<span class='alert alert-danger'>Login failed: Invalid username or password</span><br/><br/>"
                End If
            Else
                ltRegisterStatus.Text = "<span class='alert alert-danger'>Password and Confirm Password do not match </span><br/><br/>"
            End If
        Catch ex As Exception
            ltRegisterStatus.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class