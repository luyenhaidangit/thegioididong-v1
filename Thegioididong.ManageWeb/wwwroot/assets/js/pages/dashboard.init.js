var options = {
    series: [{
        name: "2020", 
        type: "column", 
        data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
    }, 
    {
        name: "2019"
        , type: "line"
        , data: [23, 32, 27, 38, 27, 32, 27, 38, 22, 31, 21, 16]
    }], 
    chart: {
        height: 280,
        type: "line", 
        toolbar: {
            show: !1
        }
    }, 
    stroke: {
        width: [0, 3], 
        curve: "smooth"
    }, 
    plotOptions: {
        bar: {
            horizontal: !1
            , columnWidth: "20%"
        }
    }, 
    dataLabels: {
        enabled: !1
    }, 
    legend: {
        show: !1
    }, 
    colors: ["#5664d2", "#1cbb8c"], 
    labels: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"]
}

var chart = new ApexCharts(document.querySelector("#line-column-chart"), options);
chart.render();


options = {
    series: [42, 26, 15], 
    chart: {
        height: 230, 
        type: "donut"
    },
    labels: ["Product A", "Product B", "Product C"],
    plotOptions: {
    pie: {
        donut: {
            size: "75%"
        }
    }
}
, dataLabels: {
    enabled: !1
}
, legend: {
    show: !1
}
, colors: ["#5664d2", "#1cbb8c", "#eeb902"]
};
var chart = new ApexCharts(document.querySelector("#donut-chart"), options)
chart.render();



var radialoptions = {
    series: [72]
    , chart: {
        type: "radialBar"
        , wight: 60
        , height: 60
        , sparkline: {
            enabled: !0
        }
    }
    , dataLabels: {
        enabled: !1
    }
    , colors: ["#5664d2"]
    , stroke: {
        lineCap: "round"
    }
    , plotOptions: {
        radialBar: {
            hollow: {
                margin: 0
                , size: "70%"
            }
            , track: {
                margin: 0
            }
            , dataLabels: {
                show: !1
            }
        }
    }
}
var radialchart = new ApexCharts(document.querySelector("#radialchart-1"), radialoptions);
radialchart.render();




var radialoptions = {
series: [65]
, chart: {
    type: "radialBar"
    , wight: 60
    , height: 60
    , sparkline: {
        enabled: !0
    }
}
, dataLabels: {
    enabled: !1
}
, colors: ["#1cbb8c"]
, stroke: {
    lineCap: "round"
}
, plotOptions: {
    radialBar: {
        hollow: {
            margin: 0
            , size: "70%"
        }
        , track: {
            margin: 0
        }
        , dataLabels: {
            show: !1
        }
    }
}
};
var radialchart = new ApexCharts(document.querySelector("#radialchart-2"), radialoptions)
radialchart.render();




// var options = {
// series: [{
//     data: [23, 32, 27, 38, 27, 32, 27, 34, 26, 31, 28]
// }]
// , chart: {
//     type: "line"
//     , width: 80
//     , height: 35
//     , sparkline: {
//         enabled: !0
//     }
// }
// , stroke: {
//     width: [3]
//     , curve: "smooth"
// }
// , colors: ["#5664d2"]
// , tooltip: {
//     fixed: {
//         enabled: !1
//     }
//     , x: {
//         show: !1
//     }
//     , y: {
//         title: {
//             formatter: function (e) {
//                 return ""
//             }
//         }
//     }
//     , marker: {
//         show: !1
//     }
// }
// };
// var chart = new ApexCharts(document.querySelector("#spak-chart1"), options)
// chart.render();




var options = {
series: [{
    data: [24, 62, 42, 84, 63, 25, 44, 46, 54, 28, 54]
}]
, chart: {
    type: "line"
    , width: 80
    , height: 35
    , sparkline: {
        enabled: !0
    }
}
, stroke: {
    width: [3]
    , curve: "smooth"
}
, colors: ["#5664d2"]
, tooltip: {
    fixed: {
        enabled: !1
    }
    , x: {
        show: !1
    }
    , y: {
        title: {
            formatter: function (e) {
                return ""
            }
        }
    }
    , marker: {
        show: !1
    }
}
};


