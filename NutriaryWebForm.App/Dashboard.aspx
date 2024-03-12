<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.vb" Inherits="NutriaryWebForm.App.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="h3 mb-0 text-gray-800">
        <asp:Literal ID="ltTitle" runat="server" />
    </h1>
    <div class="m-0 font-weight-bold text-primary">
        This is your today's dashboard. You can see your daily progress here.
    </div>
    <br />

    <div class="row">
        <div class="col-xl-4 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Total Consumed Calories
                            </div>
                            <div class="row no-gutters align-items-center">
                                <div class="col-auto">
                                    <div class="h6 mb-0 mr-3 font-weight-bold text-gray-800"><%= Convert.ToInt32(Session("TotalCalories")) %> kcal</div>
                                </div>
                                <div class="col">
                                    <div class="progress progress-sm mr-2">
                                        <div class="progress-bar bg-primary" role="progressbar"
                                            <%
                                            Dim totalCalories = Session("TotalCalories")
                                            Dim totalBMR = Session("TotalBMR")
                                            Dim percentage = If(totalBMR <> 0, (totalCalories / totalBMR) * 100, 0)
                                    %>
                                            style="width: <%=percentage%>%" aria-valuenow="<%= Session("TotalCalories") %>" aria-valuemin="0"
                                            aria-valuemax="<%= Session("TotalBMR") %>">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-4 col-md-6 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                BMR (Calorie limit)
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800"><%= Session("TotalBMR") %> kcal</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-4 col-md-6 mb-4">
            <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                Remaining calorie limit
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800"><%= Session("RemainingBMR") %> kcal</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div class="row">
        <div class="col-xl">
            <div class="card shadow mb-4">
                <div
                    class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">Nutrition Information</h6>

                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <h6 class="m-0 font-weight-light text-primary">Macronutrients in grams</h6>
                            <div class="align-content-center">
                                <ajaxToolkit:PieChart ForeColor="Transparent" BackColor="White" BorderStyle="None" BorderWidth="0px" BorderColor="Transparent" CssClass="chart-pie" ID="NutritionChart" runat="server">
                                    <PieChartValues>
                                        <ajaxToolkit:PieChartValue Category="Protein" />
                                        <ajaxToolkit:PieChartValue Category="Carbohydrates" />
                                        <ajaxToolkit:PieChartValue Category="Fat" />
                                        <ajaxToolkit:PieChartValue Category="Fiber" />
                                    </PieChartValues>
                                </ajaxToolkit:PieChart>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <h6 class="m-0 font-weight-light text-primary">Micronutrients in miligrams</h6>
                            <div class="align-content-center">
                                <ajaxToolkit:PieChart ForeColor="Transparent" BackColor="White" BorderStyle="None" BorderWidth="0px" BorderColor="Transparent" CssClass="chart-pie" ID="PieChart1" runat="server">
                                    <PieChartValues>
                                        <ajaxToolkit:PieChartValue Category="Calcium" />
                                        <ajaxToolkit:PieChartValue Category="Iron" />
                                        <ajaxToolkit:PieChartValue Category="Natrium" />
                                    </PieChartValues>
                                </ajaxToolkit:PieChart>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
