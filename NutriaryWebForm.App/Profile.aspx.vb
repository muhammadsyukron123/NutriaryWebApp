Imports NutriaryWebApp.BLL.BLL
Imports NutriaryWebApp.BLL.DTOs

Public Class Profile
    Inherits System.Web.UI.Page
    Dim _userProfileBLL As New UserProfileBLL

    Sub LoadUserModalInfo()
        Dim _viewUserProfileDTOList As List(Of ViewUserProfileDTO)
        Dim userID = Session("UserID")
        _viewUserProfileDTOList = _userProfileBLL.GetUserProfile(userID)

        ' Check if the list is not empty before accessing its elements
        If _viewUserProfileDTOList IsNot Nothing AndAlso _viewUserProfileDTOList.Count > 0 Then
            ' For demonstration purposes, assuming you only take the first user profile
            Dim _viewUserProfileDTO As ViewUserProfileDTO = _viewUserProfileDTOList(0)

            ' Populate your text boxes with the data from the first user profile
            tbModalFirstName.Text = _viewUserProfileDTO.firstname
            tbModalLastName.Text = _viewUserProfileDTO.lastname
            tbModalUsername.Text = _viewUserProfileDTO.username
            tbModalEmail.Text = _viewUserProfileDTO.email
            ddlGender.SelectedValue = _viewUserProfileDTO.gender
            tbModalAge.Text = _viewUserProfileDTO.age
            tbModalHeight.Text = _viewUserProfileDTO.height
            tbModalWeight.Text = _viewUserProfileDTO.weight
            ddlActivityLevel.SelectedValue = _viewUserProfileDTO.ActivityLevel
            ddlTargetGoal.SelectedValue = _viewUserProfileDTO.TargetGoal
        Else
            ltUserProfileUpdateModal.Text = "<span class='alert alert-danger'>Error: User profile not found</span><br/><br/>"
        End If
    End Sub

    Sub LoadUserInfo()
        Dim _viewUserProfileDTOList As List(Of ViewUserProfileDTO) ' Declare a list of ViewUserProfileDTO
        Dim userID = Session("UserID")

        ' Assuming GetUserProfile(userID) returns a list of ViewUserProfileDTO objects
        _viewUserProfileDTOList = _userProfileBLL.GetUserProfile(userID)

        ' Check if the list is not empty before accessing its elements
        If _viewUserProfileDTOList IsNot Nothing AndAlso _viewUserProfileDTOList.Count > 0 Then
            ' For demonstration purposes, assuming you only take the first user profile
            Dim _viewUserProfileDTO As ViewUserProfileDTO = _viewUserProfileDTOList(0)

            ' Populate your text boxes with the data from the first user profile
            lblEmail.Text = _viewUserProfileDTO.email
            lblUsername.Text = _viewUserProfileDTO.username
            lblFirstName.Text = _viewUserProfileDTO.firstname
            lblLastName.Text = _viewUserProfileDTO.lastname
            lblGender.Text = _viewUserProfileDTO.gender
            lblAge.Text = _viewUserProfileDTO.age
            lblHeight.Text = _viewUserProfileDTO.height
            lblWeight.Text = _viewUserProfileDTO.weight
            lblActivityLevel.Text = _viewUserProfileDTO.ActivityLevel
            lblTarget.Text = _viewUserProfileDTO.TargetGoal
        Else
            ltUpdateProfileStatus.Text = "<span class='alert alert-danger'>Error: User profile not found</span><br/><br/>"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadUserInfo()
        End If
    End Sub

    Protected Sub btnUpdateProfile_Click(sender As Object, e As EventArgs)
        LoadUserModalInfo()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#editProfileModal').modal('show');})", True)
    End Sub

    Protected Sub btnSaveProfile_Click(sender As Object, e As EventArgs)
        Dim _updateUserProfileDTO As New UpdateUserProfileDTO


    End Sub

    Protected Sub btUpdateAccount_Click(sender As Object, e As EventArgs)
        LoadUserModalInfo()


        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#editAccountModal').modal('show');})", True)
    End Sub

    Protected Sub btnSaveAccountInfo_Click(sender As Object, e As EventArgs)
        Dim updateUserAccountDTO As New UpdateUserAccountDTO
        updateUserAccountDTO.user_id = Session("UserID")
        updateUserAccountDTO.username = tbModalUsername.Text
        updateUserAccountDTO.email = tbModalEmail.Text
        updateUserAccountDTO.firstname = tbModalFirstName.Text
        updateUserAccountDTO.lastname = tbModalLastName.Text

        Try
            _userProfileBLL.UpdateUserAccount(updateUserAccountDTO)
            ltUserAccountUpdateModal.Text = "<span class='alert alert-success'>Account Updated Successfully</span><br/><br/>"
            LoadUserInfo()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#editAccountModal').modal('hide');", True)
        Catch ex As Exception
            ltUserAccountUpdateModal.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try


    End Sub
End Class