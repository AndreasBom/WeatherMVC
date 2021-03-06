﻿google.load('visualization', '1', { packages: ['corechart', 'line'] });


$(document).ready(function () {
    //For TESTING
    var urlToData = function () {
        console.log(document.location.href);
        if (document.location.hostname === "localhost") {
            if (document.location.toString().indexOf("Weather") > -1) {
                return "GetTempData";
            } else {
                return "Weather/GetTempData";
            }
        } else {
            if (document.location.toString().indexOf("Weather") > -1) {
                return "/GetTempData";
            } else {
                return "/ab22cw/Weather/GetTempData";
            }
        }
        

    }

    //Fetch temperature data from server
    $(function () {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: 'http://172.16.214.1/1dv409/ab22cw/Weather/GetTempData',
            data: '{}',
            success: function (response) {
                console.log("Temperature data successfully loaded");
                drawTemperature(response); // calling method                      
            },
            error: function () {
                $("#graph").html("Ett fel inträffade när data skulle hämtas");
            }
        });

        //Arrange data and render chart
        function drawTemperature(jsonData) {
            var data = new google.visualization.DataTable(jsonData);

            //Add Columns
            data.addColumn('string', 'Day');
            data.addColumn('number', '\xB0C');

            //Add data to rows
            for (var i = 0; i < jsonData.length; i++) {
                data.addRow([jsonData[i].day, jsonData[i].temp]);
            }

            // Render chart
            var chart = new google.visualization.LineChart(document.getElementById('graph'));
            chart.draw(data,
            {
                title: "Temperatur",
                position: "top",
                fontsize: "14px",
                chartArea: { width: '60%' }
            });
        }
    });
});
