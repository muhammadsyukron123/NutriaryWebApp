<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DailyConsumption.aspx.vb" Inherits="NutriaryWebForm.App.DailyConsumption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Food Consumption Today</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Your food consumption today</h6>
                </div>
                <div class="card-body">
                    <button type="button" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#myModal">
                        Add Food Consumption
                    </button>
                    <asp:Label ID="lblSelectedIndex" runat="server" />
                    <br />
                    <table class="table table-hover" id="dailyConsumptionTable">
                        <asp:ListView ID="lvConsumedFood" runat="server" DataKeyNames="log_id" OnSelectedIndexChanged="lvConsumedFood_SelectedIndexChanged" OnSelectedIndexChanging="lvConsumedFood_SelectedIndexChanging" OnItemDeleting="lvConsumedFood_ItemDeleting">
                            <LayoutTemplate>
                                <thead>
                                    <tr>
                                        <th class="text-hide" >Log ID</th>
                                        <th>Food Name</th>
                                        <th>Quantity</th>
                                        <th>Calories</th>
                                        <th>Log Date</th>
                                        <th></th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server"></tr>
                                </tbody>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="text-hide"><%# Eval("log_id") %></td>
                                    <td><%# Eval("food_name") %></td>
                                    <td><%# Eval("quantity") %></td>
                                    <td><%# Eval("total_energy_kcal", "{0:0.00}") %></td>
                                    <td><%# Eval("log_date", "{0:d}") %></td>
                                    <td>
                                        <asp:LinkButton ID="lnkDetails" CommandArgument='<%# Eval("log_id") %>' Text="Details" CssClass="btn btn-outline-info btn-sm" CommandName="View" runat="server" OnClick="lnkDetails_Click" />
                                        &nbsp;
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" CssClass="btn btn-outline-warning btn-sm"
                                            CommandName="Select" runat="server" />
                                        &nbsp;
                                    <asp:LinkButton ID="lnkDelete" Text="Delete" CssClass="btn btn-outline-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this food consumption log?');"
                                        CommandName="Delete" runat="server" />
                                    </td>

                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="6">There's no food consumption today</td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <br />

                    </table>
                    <br />
                    <asp:Literal ID="ltMessage" runat="server" />
                </div>

                <div class="modal" id="myModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">Add Food Consumption</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="ddFoodName">Food Name :</label>
                                    <asp:DropDownList ID="ddFoodName" CssClass="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtQuantity">Food Quantity :</label>
                                    <asp:TextBox ID="txtFoodQuantity" runat="server" CssClass="form-control" placeholder="Enter Food Quantity (gram)" />
                                </div>
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">
                                <asp:Button Text="Submit" ID="btnAddFoodConsumption" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnAddFoodConsumption_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal" id="viewModal">
                    <div class="modal-dialog modal-xl">
                        <div class="modal-content">
                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">Food Details</h4>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body">
                                <div class="table table-hover table-responsive">
                                    <asp:ListView ID="lvFoodDetails" runat="server">
                                        <LayoutTemplate>
                                            <table class="table table-borderless">
                                                <thead>
                                                    <tr>
                                                        <th>Quantity</th>
                                                        <th>Log Date</th>
                                                        <th>Food Name</th>
                                                        <th>Total Energy (kcal)</th>
                                                        <th>Total Protein (g)</th>
                                                        <th>Total Fat (g)</th>
                                                        <th>Total Carbs (g)</th>
                                                        <th>Total Fiber (g)</th>
                                                        <th>Total Calcium (mg)</th>
                                                        <th>Total Iron (mg)</th>
                                                        <th>Total Natrium (mg)</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("quantity") %></td>
                                                <td><%# Eval("log_date", "{0:yyyy-MM-dd}") %></td>
                                                <td><%# Eval("food_name") %></td>
                                                <td><%# Eval("total_energy_kcal") %></td>
                                                <td><%# Eval("total_protein_g") %></td>
                                                <td><%# Eval("total_fat_g") %></td>
                                                <td><%# Eval("total_carbs_g") %></td>
                                                <td><%# Eval("total_fiber_g") %></td>
                                                <td><%# Eval("total_calcium_mg") %></td>
                                                <td><%# Eval("total_iron_mg") %></td>
                                                <td><%# Eval("total_natrium_mg") %></td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            Data tidak tersedia.
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </div>


                            </div>
                            <div class="modal-footer">
                                <asp:Button Text="Close" ID="btCloseViewModal" CssClass="btn btn-danger btn-sm" runat="server" OnClick="btCloseViewModal_Click" />
                            </div>

                        </div>
                    </div>
                </div>

                <div class="modal" id="editModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">Edit Food Consumption Information</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="tbLogID">Food Log ID :</label>
                                    <asp:TextBox ID="tbLogID" runat="server" CssClass="form-control" ReadOnly="true" />
                                </div>
                                <div class="form-group">
                                    <label for="tbFoodName">Food Name :</label>
                                    <asp:TextBox ID="tbFoodName" runat="server" CssClass="form-control" ReadOnly="true" />
                                </div>
                                <div class="form-group">
                                    <label for="tbEditQuantity">Food Quantity :</label>
                                    <asp:TextBox ID="tbEditQuantity" runat="server" CssClass="form-control" placeholder="Enter Food Quantity (gram)" />
                                </div>
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">
                                <asp:Button Text="Submit" ID="btEditFoodInfo" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btEditFoodInfo_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
