<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn2.aspx.cs" Inherits="SystemsOfSalesWeb.LogIn2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login V6</title>
	<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />

	<link rel="icon" type="image/png" href="/Content/Login/images/icons/favicon.ico"/>
    <link href="/Content/Login/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/Content/Login/fonts/iconic/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/animate/animate.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/animsition/css/animsition.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/daterangepicker/daterangepicker.css" rel="stylesheet" />	
    <link href="/Content/Login/css/util.css" rel="stylesheet" />
    <link href="/Content/Login/css/main.css" rel="stylesheet" />



</head>
<body>
   <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-t-85 p-b-20">
				<form class="login100-form validate-form">
					<span class="login100-form-title p-b-70">
						Welcome
					</span>
					<span class="login100-form-avatar">
						<img src="Content/Login/images/avatar-01.jpg" alt="AVATAR">
					</span>

					<div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate = "Enter username">
						<input class="input100" type="text" name="username">
						<span class="focus-input100" data-placeholder="Username"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-50" data-validate="Enter password">
						<input class="input100" type="password" name="pass">
						<span class="focus-input100" data-placeholder="Password"></span>
					</div>

					<div class="container-login100-form-btn">
						<button class="login100-form-btn">
							Login
						</button>
					</div>

					<ul class="login-more p-t-190">
						<li class="m-b-8">
							<span class="txt1">
								Forgot
							</span>

							<a href="#" class="txt2">
								Username / Password?
							</a>
						</li>

						<li>
							<span class="txt1">
								Don’t have an account?
							</span>

							<a href="#" class="txt2">
								Sign up
							</a>
						</li>
					</ul>
				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/bootstrap/js/popper.js"></script>
	<script src="/Content/Login/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/daterangepicker/moment.min.js"></script>
	<script src="/Content/Login/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/js/main.js"></script>

       
  
</body>
</html>
