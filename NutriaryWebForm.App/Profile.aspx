<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.vb" Inherits="NutriaryWebForm.App.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Profile Page</h1>
        </div>

        <div class="d-flex justify-content-between align-items-center mb-4">
            <asp:Button ID="btUpdateAccount" runat="server" Text="Update Account" CssClass="btn btn-primary btn-user btn-block btn-sm" OnClick="btUpdateAccount_Click" />
            <asp:Button ID="btUpdateUserProfile" runat="server" Text="Update Profile" CssClass="btn btn-primary btn-user btn-block btn-sm" OnClick="btnUpdateProfile_Click" />
        </div>

        <asp:Literal ID="ltUpdateProfileStatus" runat="server" />

        <div class="col-xl-6 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center mb-4">
                        <div class="text-lg font-weight-bold text-primary text-uppercase mb-1">
                            Account Information
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                First Name
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblFirstName" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-user fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Last Name
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblLastName" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-user fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Username
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblUsername" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-at fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Email
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblEmail" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-envelope fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- card user profile information --%>
        <div class="col-xl-6 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center mb-4">
                        <div class="text-lg font-weight-bold text-primary text-uppercase mb-1">
                            User Profile Information
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Gender
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblGender" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-venus-mars fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Age
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblAge" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-baby fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Height (cm)
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblHeight" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-ruler fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Weight (kg)
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblWeight" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-weight fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Activity Level
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblActivityLevel" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dumbbell fa-2x text-gray-300"></i>
                        </div>
                    </div>

                    <div class="row no-gutters align-items-center mb-4">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Target
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblTarget" runat="server" />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-weight fa-2x text-gray-300"></i>
                        </div>
                    </div>

                </div>
            </div>
        </div>




        <div class="modal" id="editProfileModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Edit User Profile Information</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>


                    <!-- Modal body -->
                    <div class="modal-body">
                        <div class="p-lg-3">
                            <form class="user">
                                <asp:Literal ID="ltUserProfileUpdateModal" runat="server" />
                                <div class="form-group row-cols-1">
                                    <asp:Label CssClass="p-3" Text="Choose your gender" Font-Size="Small" runat="server" />
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control dropdown rounded-pill" Font-Size="Small" Height="50px" placeholder="Choose your gender">
                                        <asp:ListItem Text="Male" Value="Male" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group row-cols-1">
                                    <asp:Label CssClass="p-3" Text="Age" Font-Size="Small" runat="server" />
                                    <asp:TextBox ID="tbModalAge" TextMode="Number" runat="server" CssClass="form-control form-control-user" placeholder="Age" />
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:Label CssClass="p-3" Text="Weight (kg)" Font-Size="Small" runat="server" />
                                        <asp:TextBox ID="tbModalWeight" runat="server" CssClass="form-control form-control-user" placeholder="Weight" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label CssClass="p-3" Text="Height (cm)" Font-Size="Small" runat="server" />
                                        <asp:TextBox ID="tbModalHeight" runat="server" CssClass="form-control form-control-user" placeholder="Height" />
                                    </div>
                                </div>
                                <div class="form-group row-cols-1">
                                    <asp:Label CssClass="p-3" Text="Choose your activity level" Font-Size="Small" runat="server" />
                                    <asp:DropDownList ID="ddlActivityLevel" CssClass="form-control rounded-pill dropdown" Font-Size="Small" Height="50px" runat="server" placeholder="Choose your activity level">
                                        <asp:ListItem Text="Sedentary" Value="1" />
                                        <asp:ListItem Text="Lightly Active" Value="2" />
                                        <asp:ListItem Text="Moderately Active" Value="3" />
                                        <asp:ListItem Text="Very Active" Value="4" />
                                        <asp:ListItem Text="Extra Active" Value="5" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group row-cols-1">
                                    <asp:Label CssClass="p-3" Text="Choose your goal" Font-Size="Small" runat="server" />
                                    <asp:DropDownList ID="ddlTargetGoal" CssClass="form-control rounded-pill dropdown" Font-Size="Small" Height="50px" runat="server" placeholder="Choose your target goal">
                                        <asp:ListItem Text="Weight gain" Value="1" />
                                        <asp:ListItem Text="Maintain weight" Value="2" />
                                        <asp:ListItem Text="Weight loss" Value="3" />
                                    </asp:DropDownList>
                                </div>
                            </form>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button Text="Save Profile" ID="btnSaveProfile" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnSaveProfile_Click" />
                    </div>
                </div>
            </div>
        </div>



        <div class="modal" id="editAccountModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Edit User Account Information</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>


                    <!-- Modal body -->
                    <div class="modal-body">
                        <div class="p-lg-3">
                            <form class="user">
                                <asp:Literal ID="ltUserAccountUpdateModal" runat="server" />

                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:Label CssClass="p-3" Text="First Name" Font-Size="Small" runat="server" />
                                        <asp:TextBox ID="tbModalFirstName" runat="server" CssClass="form-control form-control-user" placeholder="First Name" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label CssClass="p-3" Text="Last Name" Font-Size="Small" runat="server" />
                                        <asp:TextBox ID="tbModalLastName" runat="server" CssClass="form-control form-control-user" placeholder="Last Name" />
                                    </div>
                                </div>
                                <div class="form-group row-cols-1">
                                    <asp:Label CssClass="p-3" Text="Username" Font-Size="Small" runat="server" />
                                    <asp:TextBox ID="tbModalUsername" runat="server" CssClass="form-control form-control-user" placeholder="Username" />
                                </div>
                                <div class="form-group row-cols-1">
                                    <asp:Label CssClass="p-3" Text="Email" Font-Size="Small" runat="server" />
                                    <asp:TextBox ID="tbModalEmail" runat="server" CssClass="form-control form-control-user" placeholder="Email Address" />
                                </div>
                            </form>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button Text="Save Account Info" ID="btnSaveAccountInfo" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnSaveAccountInfo_Click" />
                    </div>
                </div>
            </div>
        </div>














    </div>
</asp:Content>
