// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var xValuesPieM = window.Chart1Valuesy;
var yValuesPieM = window.Chart1Valuesx;
console.log(window.Chart1Valuesx);
console.log(window.Chart1Valuesy);
var barColors = [
    "#E14423",
    "#221B10",
    "brown",
];

new Chart("chart1", {
    type: "pie",
    data: {
        labels: window.Chart1Valuesy,
        datasets: [{
            backgroundColor: barColors,
            data: window.Chart1Valuesx
        }]
    },
    options: {
        title: {
            display: true,
            text: "Payment Method"
        }
    }
});
//==========================================chart2==========================


new Chart("chart2", {
    type: "bar",
    data: {
        labels: window.Chart2Valuesy,
        datasets: [{
            backgroundColor: barColors,
            data: window.Chart2Valuesx
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
//=======================================chart3====================
var color = "blue"
new Chart("chart3", {
    type: "horizontalBar",
    data: {
        labels: window.Chart3Valuesy,
        datasets: [{
            backgroundColor: color,
            data: window.Chart3Valuesx
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
//==============================================

var barColors = [
    "#E14423",
    "#221B10",
];

new Chart("chart4", {
    type: "pie",
    data: {
        labels: window.Chart4Valuesy,
        datasets: [{
            backgroundColor: barColors,
            data: window.Chart4Valuesx
        }]
    },
    options: {
        title: {
            display: true,
            text: "Festival attendence"
        }
    }
});
//=======================================
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
        labels: window.Chart5Valuesy,
        datasets: [{
            backgroundColor: barColors,
            data: window.Chart5Valuesx
        }]
    },
    options: {
        title: {
            display: true,
            text: "How Did You Know About Our Festival"
        }
    }
});
//=============================chart 6
var color = "blue"
new Chart("chart6", {
    type: "horizontalBar",
    data: {
        labels: window.Chart6Valuesy,
        datasets: [{
            backgroundColor: color,
            data: window.Chart6Valuesx
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