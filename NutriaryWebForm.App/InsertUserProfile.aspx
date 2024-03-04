<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertUserProfile.aspx.vb" Inherits="NutriaryWebForm.App.InsertUserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Insert Profile</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="/StartBootstrap/css/sb-admin-2.min.css" rel="stylesheet">
</head>

<body class="bg-gradient-primary">

    <div class="container">
        <div class="row justify-content-center">
            <div class="col-xl-5 col-lg-12 col-md-9">
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-5">
                        <asp:Literal ID="ltInsertUserProfileStatus" Text="" runat="server" />
                        <div class="text-center">
                            <h1 class="h4 text-gray-900 mb-4">Insert your personal information</h1>
                        </div>
                        <form class="user" runat="server">
                            <asp:Literal ID="ltInputUserProfileStatus" runat="server" />
                            <asp:Label for="ddlGender" CssClass="p-3" Text="Choose your gender" Font-Size="Small" runat="server"/> 
                            <div class="form-group my-2" runat="server" >
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control rounded-pill dropdown" Font-Size="Small" Height="50px" placeholder="Choose your gender">
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                </asp:DropDownList>
                            </div>
                            <asp:Label for="txtAge" CssClass="p-3" Text="Insert your age" runat="server" Font-Size="Small"/>
                            <div class="form-group my-2">
                                <asp:TextBox ID="txtAge" runat="server" TextMode="Number" CssClass="form-control form-control-user" placeholder="Insert your age" />
                            </div>
                            <asp:Label for="txtHeight" CssClass="p-3" Text="Insert your height" runat="server" Font-Size="Small"/>
                            <div class="form-group my-2">
                                <asp:TextBox ID="txtHeight" TextMode="Number" runat="server" CssClass="form-control form-control-user" placeholder="Insert your height" />
                            </div>
                            <asp:Label for="txtWeight" CssClass="p-3" Text="Insert your weight" runat="server" Font-Size="Small"/>
                            <div class="form-group my-2">
                                <asp:TextBox ID="txtWeight" TextMode="Number" runat="server" CssClass="form-control form-control-user"  placeholder="Insert your weight" />
                            </div>
                            <asp:Label for="ddlActivityLevel" CssClass="p-3" Text="Choose your activity level" runat="server" Font-Size="Small"/>
                            <div class="form-group my-2" runat="server">
                                <asp:DropDownList ID="ddlActivityLevel" CssClass="form-control rounded-pill dropdown" Font-Size="Small" Height="50px" runat="server" placeholder="Choose your activity level">
                                    <asp:ListItem Text="Sedentary" Value="1" />
                                    <asp:ListItem Text="Lightly Active" Value="2" />
                                    <asp:ListItem Text="Moderately Active" Value="3" />
                                    <asp:ListItem Text="Very Active" Value="4" />
                                    <asp:ListItem Text="Extra Active" Value="5" />
                                </asp:DropDownList>
                            </div>
                            <asp:Label for="ddlTargetGoal" CssClass="p-3" Text="Choose your target goal" runat="server" Font-Size="Small"/>
                            <div class="form-group my-2 mb-5" runat="server">
                                <asp:DropDownList ID="ddlTargetGoal" CssClass="form-control rounded-pill dropdown" Font-Size="Small" Height="50px" runat="server"  placeholder="Choose your target goal">
                                    <asp:ListItem Text="Weight gain" Value="1" />
                                    <asp:ListItem Text="Maintain weight" Value="2" />
                                    <asp:ListItem Text="Weight loss" Value="3" />
                                </asp:DropDownList>
                            </div>
                            <asp:Button ID="btnSubmitProfile" runat="server" Text="Add Profile" CssClass="btn btn-primary btn-user btn-block my-2" OnClick="btnSubmitProfile_Click" />
                        </form>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

</body>
</html>
