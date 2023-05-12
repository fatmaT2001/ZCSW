$(function () {
	"use strict";

	// chart 1
    // ===========================Chart1 =====================================================
    // =======================================================================================
    var xValuesPieM = ["Vodafobe Cash", "mypay", "else"];
    var yValuesPieM = [55, 49, 100];
    var barColors = [
        "#E14423",
        "#221B10",
        "brown",
    ];

    new Chart("chart1", {
        type: "pie",
        data: {
            labels: xValuesPieM,
            datasets: [{
                backgroundColor: barColors,
                data: yValuesPieM
            }]
        },
        options: {
            title: {
                display: true,
                text: "Payment Method"
            }
        }
    });

	// chart 1
    // ===========================Chart2 =====================================================
    // =======================================================================================
    var xValuesbarP = ["Vodafobe Cash", "mypay", "else"];
    var yValuesbarP = [55, 49, 100];
    var barColors = ["green", "orange", "brown"];

    new Chart("chart2", {
        type: "bar",
        data: {
            labels: xValuesbarP,
            datasets: [{
                backgroundColor: barColors,
                data: yValuesbarP
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                text: "Payment Money Per Method"
            }
        }
    });

	// chart 1
    // ===========================Chart3 =====================================================
    // =======================================================================================
    var xValuesHbarP = ["Day1", "Day2", "Day3", "Day4", "Day5", "Day6","Day7"];
    var yValuesHbarP = [55, 49, 100,200,300,400,500];
    var color="blue"
    new Chart("chart3", {
        type: "horizontalBar",
        data: {
            labels: xValuesHbarP,
            datasets: [{
                backgroundColor: color,
                data: yValuesHbarP
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                text: "festival payments for each day of the week"
            }
        }
    });
   // ===========================Chart4 =====================================================
    // =======================================================================================
    var xValuesPieV = ["Male", "Female"];
    var yValuesPieV = [55, 45];
    var barColors = [
        "#E14423",
        "#221B10",
    ];

    new Chart("chart4", {
        type: "pie",
        data: {
            labels: xValuesPieV,
            datasets: [{
                backgroundColor: barColors,
                data: yValuesPieV
            }]
        },
        options: {
            title: {
                display: true,
                text: "Festival attendence"
            }
        }
    });
   // ===========================Chart5 =====================================================
   // =======================================================================================
        var xValuesPieV = ["Facebook", "Twitter", "Instgram","Website","Other"];
        var yValuesPieV = [55, 49, 100,200,300,400];
        var barColors = [
            "#E14423",
            "#221B10",
            "brown",
            "#671C09",
            "#AA2C0B",
            "#81071A"
        ];

        new Chart("chart5", {
            type: "pie",
            data: {
                labels: xValuesPieV,
                datasets: [{
                    backgroundColor: barColors,
                    data: yValuesPieV
                }]
            },
            options: {
                title: {
                    display: true,
                    text: "How Did You Know About Our Featival"
                }
            }
        });

    // ===========================Chart6 =====================================================
    // =======================================================================================
    var xValuesHbarV = ["Day1", "Day2", "Day3", "Day4", "Day5", "Day6", "Day7"];
    var yValuesHbarV = [55, 49, 100, 200, 300, 400, 500];
    var color = "blue"
    new Chart("chart6", {
        type: "horizontalBar",
        data: {
            labels: xValuesHbarV,
            datasets: [{
                backgroundColor: color,
                data: yValuesHbarV
            }]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                text: "festival attendance for each day of the week"
            }
        }
    });
    // ===========================Chart7 =====================================================
    // =======================================================================================
    var xyValuesSV = [
        { x: 50, y: 7 },
        { x: 60, y: 20 },
        { x: 70, y: 8 },
        { x: 80, y: 25 },
        { x: 90, y: 30 },
        { x: 100, y: 2 },
        { x: 110, y: 10 },
        { x: 120, y: 100 },
        { x: 130, y: 14 },
        { x: 140, y: 50 },
        { x: 150, y: 15 }
    ];

    new Chart("chart7", {
        type: "scatter",
        data: {
            datasets: [{
                pointRadius: 4,
                pointBackgroundColor: "rgb(0,0,255)",
                data: xyValuesSV
            }]
        },
        options: {
            legend: { display: false },
            scales: {
                xAxes: [{ ticks: { min: 40, max: 160 } }],
                yAxes: [{ ticks: { min: 6, max: 100 } }],
            },
            title: {
            display: true,
            text: "festival visitiors Ages"
        }
        }
    });
});
