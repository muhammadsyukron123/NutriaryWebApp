<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="NutriaryWebForm.App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
                    <table class="table table-hover">
                        <asp:ListView ID="lvConsumedFood" runat="server" DataKeyNames="log_id" OnSelectedIndexChanged="lvConsumedFood_SelectedIndexChanged" OnSelectedIndexChanging="lvConsumedFood_SelectedIndexChanging" OnItemDeleting="lvConsumedFood_ItemDeleting">
                            <LayoutTemplate>
                                <thead>
                                    <tr>
                                        <th>Log ID</th>
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
                                    <td><%# Eval("log_id") %></td>
                                    <td><%# Eval("food_name") %></td>
                                    <td><%# Eval("quantity") %></td>
                                    <td><%# Eval("total_energy_kcal", "{0:0.00}") %></td>
                                    <td><%# Eval("log_date", "{0:d}") %></td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" CssClass="btn btn-outline-warning btn-sm"
                                            CommandName="Select" runat="server" />
                                        &nbsp;
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" CssClass="btn btn-outline-danger btn-sm"
                                            CommandName="Delete" runat="server" />
                                    </td>

                                </tr>
                            </ItemTemplate>
                            <EmptyItemTemplate>
                                <tr>
                                    <td colspan="7">No records found</td>
                                </tr>
                            </EmptyItemTemplate>
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
