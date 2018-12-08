<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapSelectPoint.aspx.cs" Inherits="Admin_lbs_MapSelectPoint" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
        body, html, #allmap
        {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
        }

        #l-map
        {
            height: 100%;
            width: 78%;
            float: left;
            border-right: 2px solid #bcbcbc;
        }

        #r-result
        {
            height: 100%;
            width: 20%;
            float: left;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=52f17b0f696d2e60e6058a659f3e1c26"></script>
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/jquery.query.js"></script>
    <title>鼠标点击拾取坐标 
    </title>
</head>
<body>
    <div id="l-map"></div>
    <div id="r-result" style="font-size: 12px;">
        鼠标点击拾取坐标<br />
        鼠标点击地图图区位置，右侧显示点击处经纬度坐标<br />
        纬度（x）:<span id="latXSpan"></span>
        <br />
        经度（y）：<span id="LngYspan"></span>


    </div>
</body>
</html>
<script type="text/javascript">
    var y_jindu = $.query.get("yjindu");
    var x_weidu = $.query.get("xweidu");

//    if ($.trim(y_jindu) == "true") {
//        y_jindu = 116.404;
//    }
//    if ($.trim(x_weidu) == "true") {
//        x_weidu = 39.915;
//    }

    // 百度地图API功能
    var map = new BMap.Map("l-map");
    map.centerAndZoom(new BMap.Point(y_jindu, x_weidu), 12);                   // 初始化地图,设置城市和地图级别。
    var marker1 = new BMap.Marker(new BMap.Point(y_jindu, x_weidu));  // 创建标注
    map.addOverlay(marker1);              // 将标注添加到地图中
    map.enableScrollWheelZoom();                            //启用滚轮放大缩小

    //添加右击菜单----start-----
    var contextMenu = new BMap.ContextMenu();
    var txtMenuItem = [
      {
          text: '放大',
          callback: function () { map.zoomIn() }
      },
      {
          text: '缩小',
          callback: function () { map.zoomOut() }
      },
      {
          text: '放置到最大级',
          callback: function () { map.setZoom(18) }
      },
      {
          text: '查看全国',
          callback: function () { map.setZoom(4) }
      },
      {
          text: '在此添加标注',
          callback: function (p) {
              var marker = new BMap.Marker(p), px = map.pointToPixel(p);
              map.addOverlay(marker);
          }
      }
    ];


    for (var i = 0; i < txtMenuItem.length; i++) {
        contextMenu.addItem(new BMap.MenuItem(txtMenuItem[i].text, txtMenuItem[i].callback, 100));
        if (i == 1 || i == 3) {
            contextMenu.addSeparator();
        }
    }
    map.addContextMenu(contextMenu);

    //添加右击菜单----end-----

    map.addEventListener("click", function (e) {
        // document.getElementById("r-result").innerHTML = e.point.lng + ", " + e.point.lat;
        document.getElementById("LngYspan").innerText = e.point.lng;
        document.getElementById("latXSpan").innerText = e.point.lat;

        window.parent.document.getElementById("tblongitude").value = e.point.lng;
        window.parent.document.getElementById("tblatitude").value = e.point.lat;

    });

</script>
