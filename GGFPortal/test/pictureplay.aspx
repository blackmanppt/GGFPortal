<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pictureplay.aspx.cs" Inherits="GGFPortal.test.pictureplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<!-- 上述3個meta標簽*必須*放在最前面，任何其他內容都*必須*跟隨其後！ -->
<title>圖片輪播_01</title>
<!-- Bootstrap -->
<link href="../Content/bootstrap.min.css" rel="stylesheet"/>
<script src="../scripts/jquery-3.1.1.min.js"></script>
<script src="../scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<!--
作者：凱爾
時間：2016-02-20
描述：
carousel
date-interval="4000"停留時間/幅圖
支持鍵盤左右方向鍵對圖片進行輪播方向選擇
-->
<div class="container">
<div style="width:960px;height: 400px;margin: auto;padding: auto;">
<div id="carousel-example-generic" class="carousel slide">
<ol class="carousel-indicators">
<li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
<li data-target="#carousel-example-generic" data-slide-to="1" class=""></li>
<li data-target="#carousel-example-generic" data-slide-to="2" class=""></li>
<li data-target="#carousel-example-generic" data-slide-to="3" class=""></li>
</ol>
<div class="carousel-inner">
<div class="item active">
<img src="../IMG/Cancelimages.png" />
</div>
<div class="item">
<img src="../IMG/images.png" />
<!--
圖片上要顯示的文字
-->
<div class="carousel-caption">
<h3>聯想校園大使</h3></div>
</div>
<div class="item">
<img src="../img/圖片輪播/pic03.jpg" />
</div>
<div class="item">
<img src="../img/圖片輪播/pic04.jpg" />
</div>
</div>
<!-- Controls -->
<a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
<span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
<span class="sr-only">Previous</span>
</a>
<a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
<span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
<span class="sr-only">Next</span>
</a>
</div>
</div>
</div>
<!--設定時間間隔，通過JavaScript，這樣做相對於css屬性設定而言，可以自啟動，無需人為進行幹預-->
<script>
$(".carousel").carousel({
interval: 4000
})
</script>
    </form>
</body>
</html>
