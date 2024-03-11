<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DailyReport.aspx.vb" Inherits="NutriaryWebForm.App.DailyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Daily Consumption Report</h1>
    </div>
    <div class="row">

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse"
                    role="button" aria-expanded="true" aria-controls="collapseCardExample">
                    <h6 class="m-0 font-weight-bold text-primary">Your Daily Food Consumption</h6>
                </a>
                <!-- Card Content - Collapse -->
                <div class="collapse show" id="collapseCardExample">
                    <div class="card-body">
                        <div class="form-group form-inline">
                            <asp:Label ID="lblDate" runat="server" Text="Choose the date" CssClass="col-sm-2 control-label" AssociatedControlID="txtDate"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtDate" TextMode="Date" runat="server" CssClass="form-control" placeholder="Enter Date" Width="300px"></asp:TextBox>
                            &nbsp;
    &nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>
                        <h6 class="m-0 font-weight-light text-primary">This is your foods consumption on <%= If(ViewState("LogDate") IsNot Nothing, DateTime.Parse(ViewState("LogDate").ToString()).ToString("d"), "") %></h6>
                        <br />
                        <table class="table table-hover table-responsive">
                            <asp:ListView ID="lvDailyReport" runat="server">
                                <LayoutTemplate>
                                    <thead>
                                        <tr>
                                            <th class="hidden">Log ID</th>
                                            <th>Food Name</th>
                                            <th>Quantity</th>
                                            <th>Log Date</th>
                                            <th>Energy (kcal)</th>
                                            <th>Protein (g)</th>
                                            <th>Fat (g)</th>
                                            <th>Carbohydrate (g)</th>
                                            <th>Fiber (g)</th>
                                            <th>Calcium (mg)</th>
                                            <th>Iron (mg)</th>
                                            <th>Natrium (mg)</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server"></tr>
                                    </tbody>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="hidden"><%# Eval("log_id") %></td>
                                        <td><%# Eval("food_name") %></td>
                                        <td><%# Eval("quantity") %></td>
                                        <td><%# Eval("log_date", "{0:d}") %></td>
                                        <td><%# Eval("energy_kal", "{0:0.00}") %></td>
                                        <td><%# Eval("protein_g", "{0:0.00}") %></td>
                                        <td><%# Eval("fat_g", "{0:0.00}") %></td>
                                        <td><%# Eval("carbs_g", "{0:0.00}") %></td>
                                        <td><%# Eval("fiber_g", "{0:0.00}") %></td>
                                        <td><%# Eval("calcium_mg", "{0:0.00}") %></td>
                                        <td><%# Eval("fe_mg", "{0:0.00}") %></td>
                                        <td><%# Eval("natrium_mg", "{0:0.00}") %></td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <tr>
                                        <td colspan="12">No data found on the chosen date</td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </table>
                    </div>
                </div>

            </div>
        </div>

        <div class="col-lg-12">
            <div class="card shadow mb-4">
                <!-- Card Header - Accordion -->
                <a href="#collapseCardSummary" class="d-block card-header py-3" data-toggle="collapse"
                    role="button" aria-expanded="true" aria-controls="collapseCardSummary">
                    <h6 class="m-0 font-weight-bold text-primary">Your Daily Consumption Summary</h6>
                </a>
                <!-- Card Content - Collapse -->
                <div class="collapse show" id="collapseCardSummary">
                    <div class="card-body">
                        <h6 class="m-0 font-weight-light text-primary">This is your foods consumption summary on <%= If(ViewState("LogDate") IsNot Nothing, DateTime.Parse(ViewState("LogDate").ToString()).ToString("d"), "") %></h6>
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
                                                        <div class="h6 mb-0 mr-3 font-weight-bold text-gray-800"><%= Convert.ToInt32(ViewState("TotalCalories")) %> kcal</div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="progress progress-sm mr-2">
                                                            <div class="progress-bar bg-primary" role="progressbar"
                                                                <%
                                                                Dim totalCalories = ViewState("TotalCalories")
                                                                Dim totalBMR = ViewState("TotalBMR")
                                                                Dim percentage
                                                                If totalBMR <> 0 Then
                                                                    percentage = (totalCalories / totalBMR) * 100
                                                                Else
                                                                    percentage = 0
                                                                End If
                                        %>
                                                                style="width: <%=percentage%>%" aria-valuenow="<%= ViewState("TotalCalories") %>" aria-valuemin="0"
                                                                aria-valuemax="<%= ViewState("TotalBMR") %>">
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
                                                <div class="h5 mb-0 font-weight-bold text-gray-800"><%= ViewState("TotalBMR") %> kcal</div>
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
                                                <div class="h5 mb-0 font-weight-bold text-gray-800"><%= ViewState("RemainingBMR") %> kcal</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
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

    </div>

</asp:Content>
