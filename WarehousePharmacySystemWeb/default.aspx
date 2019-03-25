<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WarehousePharmacySystemWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="../../js/jquery-3.3.1.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="Scripts/toastr.js"></script>
    <script src="Scripts/toastr.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="row" style="margin-top: 120px; box-shadow: -1px 1px 50px 10px black;">
                        <div class="col-md-6">
                            <ul>
                                <a href="#" style="border-bottom: 2px solid #d32e2e; padding: 10px;">Sign In </a>
                                <a href="pages/SignUp/rUsuarios.aspx">/ Sign Up</a>
                            </ul>
                            <label class="label control-label" for="TextBoxUsername">Username</label>
                            <asp:TextBox class="form-control" ID="TextBoxUsername" runat="server" placeholder="Username" autocomplete="off"> </asp:TextBox>

                            <label class="label control-label" for="TextBoxPassword">Password</label>
                            <asp:TextBox class="form-control" TextMode="Password" ID="TextBoxPassword" runat="server" placeholder="Password" autocomplete="off"> </asp:TextBox>

                            <asp:Button class="btn btn-info" ID="ButtonSingIn" runat="server" Text="SING IN" OnClick="ButtonSingIn_Click" />
                        </div>
                        <div class="col-md-6">
                            <img src="images/bg.png" />
                        </div>
                    </div>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
    </form>
</body>
</html>
