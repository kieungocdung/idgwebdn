﻿<%@ Control Language="C#" AutoEventWireup="true" Codebehind="View.ascx.cs" Inherits="IDG.Dnn.ModuleTrangChu.View" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<html lang="en">
<head>
    <title>Nivo Slider Demo</title>
    <link rel="stylesheet" href="/themes/default/default.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/themes/pascal/pascal.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/themes/orman/orman.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="style.css" type="text/css" media="screen" />
</head>
<body>
    <div id="wrapper">
    
        <a href="http://dev7studios.com" id="dev7link" title="Go to dev7studios">dev7studios</a>

        <div class="slider-wrapper theme-default">
            <div class="ribbon"></div>
            <div id="slider" class="nivoSlider">
                <img src="images/toystory.jpg" alt="" />
                <a href="http://dev7studios.com"><img src="images/up.jpg" alt="" title="This is an example of a caption" /></a>
                <img src="images/walle.jpg" alt="" />
                <img src="images/nemo.jpg" alt="" title="#htmlcaption" />
            </div>
            <div id="htmlcaption" class="nivo-html-caption">
                <strong>This</strong> is an example of a <em>HTML</em> caption with <a href="#">a link</a>.
            </div>
        </div>

    </div>
    <script type="text/javascript" src="scripts/jquery-1.6.1.min.js"></script>
    <script type="text/javascript" src="/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
    $(window).load(function() {
        $('#slider').nivoSlider();
    });
    </script>
</body>
</html>