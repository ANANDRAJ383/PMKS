﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>MCCPG 2020 | Dashboard</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="vendor/bootstrap/css/bootstrap.min.css" />
    <!-- Custom styles for this template -->
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/base-responsive.css" />
    <link rel="stylesheet" href="css/animate.min.css" />
    <link rel="stylesheet" href="css/slicknav.min.css" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

    <script src="vendor/charts/Chart.js"></script>
    <script src="vendor/charts/moment.min.js"></script>
    <script src="vendor/charts/Chart.min.js"></script>
    <script src="vendor/charts/utils.js"></script>
    <style>
        body {
            background-color: #fff;
        }

        .b-leftmenu ul {
            list-style: none;
            margin: 0;
            padding: 0;
        }

            .b-leftmenu ul li {
                /* Sub Menu */
            }

                .b-leftmenu ul li a {
                    display: block;
                    background: #ebebeb;
                    padding: 10px 15px;
                    color: #333;
                    text-decoration: none;
                    -webkit-transition: 0.2s linear;
                    -moz-transition: 0.2s linear;
                    -ms-transition: 0.2s linear;
                    -o-transition: 0.2s linear;
                    transition: 0.2s linear;
                }

                    .b-leftmenu ul li a:hover {
                        background: #f8f8f8;
                        color: #515151;
                    }

                    .b-leftmenu ul li a .fa {
                        width: 16px;
                        text-align: center;
                        margin-right: 5px;
                        float: right;
                    }

            .b-leftmenu ul ul {
                background-color: #ebebeb;
            }

        .b-leftmenu .sub-menu ul li a {
            background: #f8f8f8;
            border-left: 4px solid transparent;
            padding: 10px 25px;
        }

        .b-leftmenu .sub-sub-menu ul li a {
            padding: 10px 20px 10px 40px;
        }

        .b-leftmenu a.b-newpage:hover {
            background: #ebebeb;
            border-left: 4px solid #3498db;
        }
    </style>
</head>
<body>
    <div class="d-flex" id="wrapper">

        <!-- Sidebar -->
        <div class="dashboard-bgcolor border-right" id="sidebar-wrapper">
            <div class="sidebar-heading text-center b-db-color" style="font-size: 24px">
                <span class="fas fa-tachometer-alt"></span>&nbsp;<span class="text-uppercase">Admin</span>
            </div>
            <div class="list-group list-group-flush b-leftmenu">

                <ul id="sortable-menu">
                    <li><a href='dashboard.html' class="dashboard-bgcolor b-db-color border-bottom b-newpage">Dashboard</a></li>

                    <li class='sub-menu'><a href='javascript:void(0)' class="dashboard-bgcolor border-bottom b-db-color b-newpage">XML Create<div class='fa fa-caret-down right'></div>
                    </a>
                        <ul>
                            <li><a class="b-newpage" href='barchart.html'>Fresh Farmer</a></li>
                            <li><a class="b-newpage" href='linechart.html'>Ist Level Rejection</a></li>
                            <li><a class="b-newpage" href='areachart.html'>PFMS Rejected</a></li>
                            <li><a class="b-newpage" href='areachart.html'>Aadhar Not Verified</a></li>
                            <li class='sub-sub-menu'>
                                <a href='javascript:void(0)' class="b-newpage">Physical Verification<div class='fa fa-caret-down right'></div>
                                </a>
                                <ul>
                                    <li><a class="b-newpage" href='scatterchart.html'>5% (Percent)</a></li>
                                    <li><a class="b-newpage" href='doughnut-piechart.html'>10% (Percent)</a></li>
                                    <%--<li><a class="b-newpage" href='polarareachart.html'>Polar Area Chart</a></li>--%>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <%--			<li><a href='table.html' class="dashboard-bgcolor border-bottom b-newpage b-db-color">Reports</a></li>
			<li><a href='forms.html' class="dashboard-bgcolor border-bottom b-newpage b-db-color">Forms</a></li>--%>
                    <li class='sub-menu'><a href='javascript:void(0)' class="dashboard-bgcolor border-bottom b-db-color b-newpage">Report<div class='fa fa-caret-down right'></div>
                    </a>
                        <ul>
                            <li><a href='typography.html' class="b-newpage">Monthly Report</a></li>
                            <li><a href='buttons.html' class="b-newpage">Commulative Report</a></li>
                            <li><a href='cards.html' class="b-newpage">Block Wise</a></li>
                            <li><a href='icons.html' class="b-newpage">Panchayat Wise</a></li>
                        </ul>
                    </li>
                    <li class='sub-menu'><a href='javascript:void(0)' class="dashboard-bgcolor border-bottom b-db-color b-newpage">Upload Data<div class='fa fa-caret-down right'></div>
                    </a>
                        <ul>
                            <li><a href='javascript:void(0);' class="b-newpage">Ist level</a></li>
                            <li><a href='javascript:void(0)' class="b-newpage">PFMS Rejected</a></li>
                            <li><a href='javascript:void(0)' class="b-newpage">Aadhaar Falture</a></li>
                            <li class='sub-sub-menu'><a href='javascript:void(0);' class="b-newpage">Physical Verification<div class='fa fa-caret-down right'></div>
                            </a>
                                <ul>
                                    <li><a href='javascript:void(0)' class="b-newpage">5% (Percent)</a></li>
                                    <li><a href='javascript:void(0);' class="b-newpage">10% (Percent)</a></li>
                                    <%--<li><a href='javascript:void(0)' class="b-newpage">Third Level Item</a></li>--%>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
        <!-- /#sidebar-wrapper -->

        <!-- Page Content -->
        <div id="page-content-wrapper">

            <nav class="navbar navbar-expand-lg navbar-light dashboard-bgcolor border-bottom">
                <button class="btn b-db-color" id="menu-toggle">
                    <span style="display: none;">Menu</span>
                    <span class="fas fa-bars" style="font-size: 1.4rem"></span>
                </button>

                <!-- Online users -->
                <div class="d-inline-block px-4 py-2 dropdown">
                    <div class="dropdown-toggle" data-toggle="dropdown" style="cursor: pointer;">
                        <span class="fas fa-users" style="font-size: 20px;"></span>
                    </div>
                    <div class="dropdown-menu b-dropmenu-db">
                        <a class="dropdown-item" href="#">User action</a>
                        <a class="dropdown-item" href="#">Another user action</a>
                        <a class="dropdown-item" href="#">Another user action</a>
                        <a class="dropdown-item" href="#">Another user action</a>
                    </div>
                </div>






                <button class="navbar-toggler b-dropmenubtn" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="far fa-caret-square-down" style="font-size: 30px; color: #FFF"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto mt-2 mt-lg-0">
                        <li class="nav-item">
                            <a class="nav-link b-db-color" href="#">Notification</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link b-db-color" href="#">Inbox</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle b-db-color" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Profile
                            </a>
                            <div class="dropdown-menu dropdown-menu-right text-center b-dropmenu-db" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="javascript:void(0);" data-toggle="modal" data-target="#signout-modal">Sign Out</a>

                            </div>
                        </li>
                    </ul>
                </div>
            </nav>

            <div class="container-fluid">
                <div class="d-flex clearfix mt-4">
                    <h3 class="d-inline-block" style="font-size: 32px;">Dashboard</h3>
                    <span class="ml-auto d-inline-block align-self-center">
                        <button type="button" class="btn btn-primary b-btn"><span class="fas fa-download fa-sm"></span>Statistic</button></span>
                </div>


                <!-- Content Row -->

                <div class="my-5" id="b-homedb">

                    <div class="container">
                        <h4 class="text-center mb-3 b-latest-data">Latest Data</h4>
                        <div class="pl-4 text-right" style="font-size: 24px">
                            <span class="mr-2" id="one-item-row" style="cursor: pointer;">
                                <i class="fas fa-bars"></i>
                            </span>
                            <span class="mr-2" id="two-item-row" style="cursor: pointer;">
                                <i class="fas fa-th-large"></i>
                            </span>
                            <span class="mr-2" id="three-item-row" style="cursor: pointer;">
                                <i class="fas fa-th"></i>
                            </span>
                        </div>

                        <div class="">
                            <div class="row text-center pl-4" id="sortable-cards">
                                <div class="col-lg-6 col-sm-12 p-3 b-customize">
                                    <div class="bg-light p-4 b-dbcard">
                                        <i class="fa fa-wheat position-absolute" style="font-size: 35px; right: 40px; top: 40px;"></i>
                                        <div class="">
                                            <p class="text-left font-weight-bold" style="font-size: 14px;">Total Applied Farmers'</p>
                                            <h3 class="text-left font-weight-bold" style="margin-top: -5px">
                                                <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>
                                            </h3>
                                            <div class="text-left" style="margin: 10px 0px 5px;">
                                                <span class="badge badge-success">+4%</span>
                                                <span style="font-size: 13px;">From previous period</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-6 col-sm-12 p-3 b-customize">
                                    <div class="bg-light p-4 b-dbcard">
                                        <i class="fas fa-vial position-absolute" style="font-size: 35px; right: 40px; top: 40px;"></i>
                                        <div class="">
                                            <p class="text-left font-weight-bold" style="font-size: 14px;">Send to Delhi</p>
                                            <h3 class="text-left font-weight-bold" style="margin-top: -5px">
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>
                                            <div class="text-left" style="margin: 10px 0px 5px;">
                                                <span class="badge badge-success">2%</span>
                                                <span style="font-size: 13px;">From previous period</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-6 col-sm-12 p-3 b-customize">
                                    <div class="bg-light p-4 b-dbcard">
                                        <i class="fas fa-tractor position-absolute" style="font-size: 35px; right: 40px; top: 40px;"></i>
                                        <div class="">
                                            <p class="text-left font-weight-bold" style="font-size: 14px;">New Approved Data</p>
                                            <h3 class="text-left font-weight-bold" style="margin-top: -5px">
                                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></h3>
                                            <div class="text-left" style="margin: 10px 0px 5px;">
                                                <span class="badge badge-success">12%</span>
                                                <span style="font-size: 13px;">From previous period</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-6 col-sm-12 p-3 b-customize">
                                    <div class="bg-light p-4 b-dbcard">
                                        <i class="fas fa-rupee-sign position-absolute" style="font-size: 35px; right: 40px; top: 40px;"></i>
                                        <div class="">
                                            <p class="text-left font-weight-bold" style="font-size: 14px;">Total Pendng Data (5%-10%)</p>
                                            <h3 class="text-left font-weight-bold" style="margin-top: -5px">
                                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h3>
                                            <div class="text-left" style="margin: 10px 0px 5px;">
                                                <span class="badge badge-success">+28%</span>
                                                <span style="font-size: 13px;">From previous period</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>

                </div>




                <%--     <div class="row my-5 mx-sm-5">
        	<div class="col-md-6">
        		<h4 class="text-center">Send to Delhi Data Graph</h4>
        		<canvas id="basicLineChart2" width="400" height="400"></canvas>
        	</div>
        	<div class="col-md-6">
        		<h4 class="text-center">Payment (in percent)</h4>
        		<canvas id="doughnutChart2" width="400" height="400"></canvas>
        	</div>
        </div>
                --%>
            </div>
            <!-- /#page-content-wrapper -->

        </div>
        <!-- /#wrapper -->



        <!-- Bootstrap core JavaScript -->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
        <script src="js/jquery.slicknav.min.js"></script>
        <script src="js/dashboard.js"></script>

        <!-- Menu Toggle Script -->
        <script>
            $("#menu-toggle").click(function (e) {
                e.preventDefault();
                $("#wrapper").toggleClass("toggled");
            });
        </script>


        <script>
            $(document).ready(function () {
                $('#backtotop').click(function () {
                    $("html, body").animate({ scrollTop: 0 }, 600);
                    return false;
                });
            });
        </script>


        <script>
            $('.sub-menu ul').hide();
            $('.sub-sub-menu ul').hide();
            $(".sub-menu a").click(function () {
                $(this).parent(".sub-menu").children("ul").slideToggle("100");
                $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
            });

            $(".sub-sub-menu a").click(function () {
                $(this).parent(".sub-sub-menu").children("ul").slideToggle("100");
                $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
            });
        </script>



        <!-- Signup Modal -->
        <div class="modal fade" id="signout-modal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header text-center d-block p-5 border-bottom-0">
                        <h3 class="modal-title">Sign Out?</h3>
                        <button type="button" class="close position-absolute" style="right: 15px; top: 8px;" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <p class="text-center">Are you sure you want to Sign Out?</p>
                        <div class="text-center py-4">
                            <form action="index.html">
                                <button type="submit" class="btn btn-primary b-btn mx-1">Sign Out</button>
                                <button class="btn btn-secondary mx-3" data-dismiss="modal">Cancel</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <script src="vendor/jquery-ui/jquery-ui.js"></script>
        <script>
            $(function () {
                $("#sortable-menu").sortable();
                $("#sortable-menu").disableSelection();

                $("#sortable-cards").sortable();
                $("#sortable-cards").disableSelection();
            });
        </script>


        <script>
            $(function () {
                $("#one-item-row").on("click", function () {
                    $(".b-customize").addClass("col-lg-12", 300);
                    $(".b-customize").removeClass("col-lg-4", 300);
                    $(".b-customize").removeClass("col-lg-6", 300);

                });

                $("#two-item-row").on("click", function () {
                    $(".b-customize").addClass("col-lg-6", 300);
                    $(".b-customize").removeClass("col-lg-4", 300);
                    $(".b-customize").removeClass("col-lg-12", 300);

                });

                $("#three-item-row").on("click", function () {
                    $(".b-customize").addClass("col-lg-4", 300);
                    $(".b-customize").removeClass("col-lg-6", 300);
                    $(".b-customize").removeClass("col-lg-12", 300);

                });

            });
        </script>




        <form id="form1" runat="server">
            <div>
            </div>
        </form>
</body>
</html>