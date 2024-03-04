Imports NutriaryWebApp.BLL.BLL
Imports NutriaryWebApp.BLL.DTOs

Public Class InsertUserProfile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmitProfile_Click(sender As Object, e As EventArgs)
        Dim _addUserProfile As New AddUserBLL
        Dim _userProfile As New AddUserProfileDTO
        _userProfile.user_id = Session("UserID")
        _userProfile.gender = ddlGender.SelectedValue
        _userProfile.age = txtAge.Text
        _userProfile.height = txtHeight.Text
        _userProfile.weight = txtWeight.Text
        _userProfile.activity_level_id = ddlActivityLevel.SelectedValue
        _userProfile.target_goal_id = ddlTargetGoal.SelectedValue

        Try
            _addUserProfile.AddUserProfile(_userProfile)
            ltInputUserProfileStatus.Text = "<span class='alert alert-success'>Profile Added Successfully</span><br/><br/>"
            Response.Redirect("DailyConsumption.aspx")
        Catch ex As Exception
            ltInputUserProfileStatus.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try

    End Sub
End Class