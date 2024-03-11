Imports NutriaryWebApp.BLL.BLL
Imports NutriaryWebApp.BLL.DTOs

Public Class DailyConsumption
    Inherits System.Web.UI.Page
    Dim _consumedFoodsBLL As New ConsumedFoodsBLL


    Sub ClearModal()
        ddFoodName.SelectedIndex = 0
        txtFoodQuantity.Text = ""
    End Sub

    Sub PreventBackLogin()
        If Session("UserID") Is Nothing Then
            ' Redirect pengguna ke halaman login jika belum login
            Response.Redirect("Login.aspx")
        End If
    End Sub
    Sub LoadFoodList()

        lvConsumedFood.DataSource = GetFoodNutritionByID()
        lvConsumedFood.DataBind()

        Dim result = _consumedFoodsBLL.foodNameLists()
        ddFoodName.DataSource = result
        ddFoodName.DataTextField = "food_name"
        ddFoodName.DataValueField = "food_name"
        ddFoodName.DataBind()


    End Sub



    Sub LoadFoodEditModalForm(logID As Integer)
        Dim result = _consumedFoodsBLL.GetFoodInformationByLogID(logID)

        Try
            If result IsNot Nothing Then
                tbLogID.Text = result(0).log_id
                tbFoodName.Text = result(0).food_name
                tbEditQuantity.Text = result(0).quantity
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Error: Article not found</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try

    End Sub

    Public Function GetFoodNutritionByID() As List(Of ConsumedFoodsDTO)
        Dim userId = Session("UserID")
        Return _consumedFoodsBLL.GetFoodNutritionByID(userId)
    End Function

    Public Function GetFoodDetailsByLogID(logID As Integer) As List(Of FoodDetailsDTO)
        Return _consumedFoodsBLL.GetFoodDetailsByLogId(logID)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadFoodList()
            ClearModal()
            PreventBackLogin()
        End If
    End Sub

    Protected Sub btnAddFoodConsumption_Click(sender As Object, e As EventArgs)

        Try
            Dim userId As Integer = Session("UserID")
            _consumedFoodsBLL.AddFoodConsumption(userId, ddFoodName.SelectedValue, txtFoodQuantity.Text)
            LoadFoodList()
            ltMessage.Text = "<span class='alert alert-success'>Food Consumption Added</span><br/><br/>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub lvConsumedFood_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadFoodEditModalForm(CInt(lvConsumedFood.SelectedDataKey.Value))

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#editModal').modal('show');})", True)

    End Sub


    Protected Sub lvConsumedFood_ItemDeleting(sender As Object, e As ListViewDeleteEventArgs)
        Dim logId As Integer = Convert.ToInt32(lvConsumedFood.DataKeys(e.ItemIndex).Value)
        Try
            'add javascript browser confirmation dialog here
            _consumedFoodsBLL.DeleteFoodLog(logId)
            LoadFoodList()
            ltMessage.Text = "<span class='alert alert-success'>Food Consumption Deleted</span><br/><br/>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btEditFoodInfo_Click(sender As Object, e As EventArgs)
        Try
            Dim logId As Integer = Convert.ToInt32(tbLogID.Text)
            Dim quantity As Decimal = Convert.ToDecimal(tbEditQuantity.Text)
            _consumedFoodsBLL.UpdateFoodQuantity(logId, quantity)
            LoadFoodList()
            ltMessage.Text = "<span class='alert alert-success'>Food Consumption Updated</span><br/><br/>"

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#editModal').modal('hide');", True)
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub lnkDetails_Click(sender As Object, e As EventArgs)
        Dim lnkDetails As LinkButton = CType(sender, LinkButton)
        Dim logId As String = lnkDetails.CommandArgument
        lvFoodDetails.DataSource = GetFoodDetailsByLogID(logId)
        lvFoodDetails.DataBind()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#viewModal').modal('show');})", True)
    End Sub

    Protected Sub btCloseViewModal_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#viewModal').modal('hide');", True)
    End Sub

    Protected Sub lvConsumedFood_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)

    End Sub
End Class