<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="NutriaryWebForm.App.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>SB Admin 2 - Login</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="/Startbootstrap/css/sb-admin-2.min.css" rel="stylesheet">
</head>

<body class="bg-gradient-primary">

    <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-5 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body">
                        <!-- Nested Row within Card Body -->
                        <div class="text-center">
                            <h1 class="h4 text-gray-900 mb-4">Welcome to Nutriary!</h1>
                        </div>
                        <asp:Literal ID="ltLoginStatus" runat="server" />
                        <form class="user">
                            <div class="form-group">
                                <form runat="server" action="/" method="post">
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-user" placeholder="Enter Email Address..." />
                                    <br />
                                    <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control form-control-user form-hide" placeholder="Enter Password ..." />
                                    <br />
                                    <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-primary btn-user btn-block" OnClick="btnLogin_Click" />
                                </form>
                            </div>
                        </form>
                        <hr>
                        <div class="text-center">
                            <a class="small" href="forgot-password.html">Forgot Password?</a>
                        </div>
                        <div class="text-center">
                            <a class="small" href="Register.aspx">Create an Account!</a>
                        </div>

                        <%--<div class="p-0">
                        </div>--%>

                        <%--<div class="row">
                            <div class="col-lg-6">
                                
                            </div>
                        </div>--%>
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
