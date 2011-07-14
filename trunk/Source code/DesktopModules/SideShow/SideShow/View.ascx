<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="IDG.Dnn.SideShow.View" %>
<link href="/DesktopModules/SideShow/images/DanhMucDonVi.css" rel="stylesheet" type="text/css" />
<script src="js/mootools-1.3.1-core.js"></script>

    <script src="js/mootools-1.3.1.1-more.js"></script>

    <script src="js/slideshow.js"></script>

    <script src="js/slideshow.flash.js"></script>

    <script src="js/slideshow.fold.js"></script>

    <script src="js/slideshow.kenburns.js"></script>

    <script src="js/slideshow.push.js"></script>
<script>
    window.addEvent('domready', function() {
        var data = { '1.jpg': { caption: '1' }, '2.jpg': { caption: '2' }, '3.jpg': { caption: '3' }, '4.jpg': { caption: '4'} };

        new Slideshow('overlap', data, { captions: { delay: 1000 }, delay: 3000, height: 300, hu: '/Portals/0/', width: 400 });
        new Slideshow('noOverlap', data, { height: 300, hu: '/Portals/0/', overlap: false, resize: 'fit', width: 400 });
        new Slideshow.Flash('flash', data, { color: ['tomato', 'palegreen', 'orangered', 'aquamarine'], height: 300, hu: '/Portals/0/', width: 400 });
        new Slideshow.Fold('fold', data, { height: 300, hu: 'images/', width: 400 });
        new Slideshow.KenBurns('kenburns', data, { duration: 1500, height: 300, hu: 'images/', width: 400 });
        new Slideshow.Push('push', data, { height: 300, hu: 'images/', transition: 'back:in:out', width: 400 });
    });
	</script>

<div id="noOverlap" style="float: left; margin: 50px;">
    <img src="/Portals/0/1.jpg" alt="1">
</div>
