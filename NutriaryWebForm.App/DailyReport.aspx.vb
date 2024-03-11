Imports NutriaryWebApp.BLL.BLL

Public Class DailyReport
    Inherits System.Web.UI.Page
    Dim _consumedFoodsBLL As New ConsumedFoodsBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PreventBackLogin()
            LoadDailyFoodMenu()
            AssignPieChartData()
        End If
    End Sub

    Sub PreventBackLogin()
        If Session("UserID") Is Nothing Then
            ' Redirect pengguna ke halaman login jika belum login
            Response.Redirect("Login.aspx")
        End If
    End Sub
    Sub LoadDailyFoodMenu()
        Dim dateSelected = Date.Today
        Dim userId As Integer = Session("UserID")
        Dim result = _consumedFoodsBLL.GetDailyFoodMenuOnDate(userId, dateSelected)
        Dim summary = _consumedFoodsBLL.GetDailyTotalNutritionByDate(userId, dateSelected)

        ViewState("LogDate") = dateSelected
        ViewState("TotalCalories") = summary.total_energy_kal
        ViewState("TotalProtein") = summary.total_protein_g
        ViewState("TotalCarbs") = summary.total_carbs_g
        ViewState("TotalFat") = summary.total_fat_g
        ViewState("TotalFiber") = summary.total_fiber_g
        ViewState("TotalCalcium") = summary.total_calcium_mg
        ViewState("TotalIron") = summary.total_fe_mg
        ViewState("TotalNatrium") = summary.total_natrium_mg
        ViewState("TotalBMR") = summary.total_bmr
        ViewState("RemainingBMR") = summary.remaining_bmr


        lvDailyReport.DataSource = result
        lvDailyReport.DataBind()
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim dateSelected As Date = Convert.ToDateTime(txtDate.Text)
        Dim userId As Integer = Session("UserID")
        Dim result = _consumedFoodsBLL.GetDailyFoodMenuOnDate(userId, dateSelected)
        Dim summary = _consumedFoodsBLL.GetDailyTotalNutritionByDate(userId, dateSelected)
        lvDailyReport.DataSource = result
        lvDailyReport.DataBind()

        ViewState("LogDate") = dateSelected
        ViewState("TotalCalories") = summary.total_energy_kal
        ViewState("TotalProtein") = summary.total_protein_g
        ViewState("TotalCarbs") = summary.total_carbs_g
        ViewState("TotalFat") = summary.total_fat_g
        ViewState("TotalFiber") = summary.total_fiber_g
        ViewState("TotalCalcium") = summary.total_calcium_mg
        ViewState("TotalIron") = summary.total_fe_mg
        ViewState("TotalNatrium") = summary.total_natrium_mg
        ViewState("TotalBMR") = summary.total_bmr
        ViewState("RemainingBMR") = summary.remaining_bmr

        AssignPieChartData()
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
End Class