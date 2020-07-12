var placeHolderStyle = {
        normal: {
            label: {
                show: false
            },
            labelLine: {
                show: false
            },
            color: "rgba(0,0,0,0)",
            borderWidth: 0
        },
        emphasis: {
            color: "rgba(0,0,0,0)",
            borderWidth: 0
        }
    };

var defaultStyle = {
    normal: {
        formatter: '空闲',
        position: 'center',
        show: true,
        textStyle: {
            fontSize: '26',
            fontWeight: 'normal',
            color: '#34374E'
        }
    }
};
var dataStyle = {
    normal: {
        formatter: '{c}%',
        position: 'center',
        show: true,
        textStyle: {
            fontSize: '26',
            fontWeight: 'normal',
            color: '#34374E'
        }
    }
};

// 基于准备好的dom，初始化echarts实例
var docObject = document.getElementsByClassName('pie');
var myChart = [];
var titleArr = [];
var seriesArr = [];
var optionArr = [];
for (var i = 0; i < docObject.length; i++) {
    var chart = echarts.init(docObject[i]);
    myChart.push(chart);
    var titleIndex = [{
        text: '采集站' + (i + 1),
        left: '49%',
        top: '80%',
        textAlign: 'center',
        textStyle: {
            fontWeight: 'normal',
            fontSize: '14',
            color: '#AAAFC8',
            textAlign: 'center',
        },
    }];
    titleArr.push(titleIndex);
    //第一个图表
    var seriesIndex = [{
        type: 'pie',
        hoverAnimation: false, //鼠标经过的特效
        radius: ['83%', '100%'],
        center: ['50%', '60%'],
        startAngle: 225,
        labelLine: {
            normal: {
                show: false
            }
        },
        label: {
            normal: {
                position: 'center'
            }
        },
        data: [{
            value: 100,
            itemStyle: {
                normal: {
                    color: '#E1E8EE'
                }
            },
        }, {
            value: 35,
            itemStyle: placeHolderStyle,
        }]
    },
    //上层环形配置
    {
        type: 'pie',
        hoverAnimation: false, //鼠标经过的特效
        radius: ['83%', '100%'],
        center: ['50%', '60%'],
        startAngle: 225,
        labelLine: {
            normal: {
                show: false
            }
        },
        label: {
            normal: {
                position: 'center'
            }
        },
        data: [{
            value: 0,
            itemStyle: {
                normal: {
                    color: '#4897f6'
                }
            },
            label: defaultStyle,
        }, {
            value: 35,
            itemStyle: placeHolderStyle,
        }]
    }];
    seriesArr.push(seriesIndex);
    var option = {
        backgroundColor: '#fff',
        title: titleIndex,
        series: seriesIndex
    };
    optionArr.push(option);
    // 使用刚指定的配置项和数据显示图表。
    chart.setOption(option);
}
//动态刷新资源采集进度
function refreshProgess(deviceInfo, percent) {
    var liObj = $('.par-pie');
    $.each(liObj, function (i, v) {
        var dataInfo = $(v).attr('data-info');
        if (dataInfo != '' && dataInfo == deviceInfo) {
            var series = seriesArr[i];
            series[1].data[0].value = percent;
            series[1].data[0].label = dataStyle;
            series[1].data[1].value = 35 + (100 - percent);
            myChart[i].setOption(optionArr[i]);
            return false;
        }
        else if (dataInfo == '') {
            $(v).attr('data-info', deviceInfo);
            $(v).find('.icon').addClass('block');
            $(v).find('span').text(deviceInfo);
            var series = seriesArr[i];
            series[1].data[0].value = percent;
            series[1].data[0].label = dataStyle;
            series[1].data[1].value = 35 + (100 - percent);
            myChart[i].setOption(optionArr[i]);
            return false;
        }
    });
}
//移除U盘刷新采集站状态
function removeDevice(deviceInfo) {
    var liObj = $('.par-pie');
    $.each(liObj, function (i, v) {
        var dataInfo = $(v).attr('data-info');
        if (dataInfo != '' && dataInfo == deviceInfo) {
            var series = seriesArr[i];
            series[1].data[0].value = 0;
            series[1].data[0].label = defaultStyle;
            series[1].data[1].value = 35;
            myChart[i].setOption(optionArr[i]);
            $(v).attr('data-info', '');
            $(v).find('.icon').removeClass('block').addClass('none');
            $(v).find('span').text('');
            return false;
        }
    });
}