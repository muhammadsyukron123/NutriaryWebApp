Imports NutriaryWebApp.BLL.BLL
Imports NutriaryWebApp.BLL.DTOs
Imports NutriaryWebApp.BLL.Interfaces

Public Class Dashboard
    Inherits System.Web.UI.Page

    Dim _consumedFoodsBLL As New ConsumedFoodsBLL
    Sub PreventBackLogin()
        If Session("UserID") Is Nothing Then
            ' Redirect pengguna ke halaman login jika belum login
            Response.Redirect("Login.aspx")
        End If
    End Sub


    Sub LoadNutritionInfo()
        Dim result = _consumedFoodsBLL.GetDailyTotalNutrition(Session("UserID"))
        Dim summary = _consumedFoodsBLL.GetCalorieSummaryToday(Session("UserID"))
        Session("TotalCalories") = summary.consumed_calories
        ViewState("TotalProtein") = result.total_protein_g
        ViewState("TotalCarbs") = result.total_carbs_g
        ViewState("TotalFat") = result.total_fat_g
        ViewState("TotalFiber") = result.total_fiber_g
        ViewState("TotalCalcium") = result.total_calcium_mg
        ViewState("TotalIron") = result.total_fe_mg
        ViewState("TotalNatrium") = result.total_natrium_mg
        Session("TotalBMR") = summary.BMR
        Session("RemainingBMR") = summary.remaining_calories
    End Sub

    Sub AssignPieChartData()
        ' Assign values to the NutritionChart
        NutritionChart.PieChartValues.Clear()
        NutritionChart.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
        .Category = "Protein",
        .Data = Convert.ToDouble(ViewState("TotalProtein"))
    })
        NutritionChart.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
        .Category = "Carbohydrates",
        .Data = Convert.ToDouble(ViewState("TotalCarbs"))
    })
        NutritionChart.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
        .Category = "Fat",
        .Data = Convert.ToDouble(ViewState("TotalFat"))
    })
        NutritionChart.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
        .Category = "Fiber",
        .Data = Convert.ToDouble(ViewState("TotalFiber"))
    })

        ' Assign values to the PieChart1
        PieChart1.PieChartValues.Clear()
        PieChart1.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
        .Category = "Calcium",
        .Data = Convert.ToDouble(ViewState("TotalCalcium"))
    })
        PieChart1.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
        .Category = "Iron",
        .Data = Convert.ToDouble(ViewState("TotalIron"))
    })
        PieChart1.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
        .Category = "Natrium",
        .Data = Convert.ToDouble(ViewState("TotalNatrium"))
    })
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PreventBackLogin()
            LoadNutritionInfo()
            ltTitle.Text = "Welcome to Nutriary, " & Session("FirstName") & " " & Session("LastName")

            ' Assign pie chart data based on session variables
            AssignPieChartData()
        End If
    End Sub


End Class