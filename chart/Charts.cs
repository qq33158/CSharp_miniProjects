using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Charts 的摘要描述
/// 適用圖表類型 Pie/Bar/Stack/Line
/// -------------------------
/// |         lebel         |
/// -------------------------
/// |      |                |
/// |legend|      data      |
/// |      |                |
/// -------------------------
/// </summary>
public class Charts {
    public Charts() {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public string Seq {
        set { seq = value; }
        get { return seq; }
    }
    string seq = "";
    public string Title {
        set { title = value; }
        get { return title; }
    }
    string title = "";
    public string Label {
        set { label = value; }
        get { return label; }
    }
    string label = "";
    public string Legend {
        set { legend = value; }
        get { return legend; }
    }
    string legend = "";
    public string Data {
        set { data = value; }
        get { return data; }
    }
    string data = "";
    public string[] BackgroundColor{
        set { backgroundColor = value; }
        get { return backgroundColor; }
    }
    string[] backgroundColor = { "#FF6666", "#FF9966", "#FFCD56", "#99CC99", "#99CCFF", "#336699", "#FF9999", "#9966CC", "#FF99CC", "#CCCCCC" };
    public string ChartScript{
        set { chartScript = value; }
        get { return chartScript; }
    }
    string chartScript = "";

    // 適用於長條/堆疊/折線圖資料型態
    public virtual void GetData(DataTable dt) {
        if (dt.Rows.Count > 0) {
            string label = "";
            string legend = "";
            string data = "";
            for (int i = 1; i < dt.Columns.Count; i++) {
                label += "'" + dt.Columns[i].ColumnName + "',";
            }
            for (int i = 0; i < dt.Rows.Count; i++) {
                legend += dt.Rows[i][0] + ",";
                for (int j = 1; j < dt.Columns.Count; j++) {
                    data += dt.Rows[i][j] + ",";
                }
                data = data.TrimEnd(',');
                data += "_";
            }
            label = label.TrimEnd(',');
            data = data.TrimEnd('_');
            legend = legend.TrimEnd(',');

            Label = label;
            Data = data;
            Legend = legend;
        } else {
            Label = "";
            Data = "";
            Legend = "";
        }
    }
    public virtual void GetScript() {
        StringBuilder cstext = new StringBuilder();

        cstext.Append("<script type=\"text/javascript\"> ");
        cstext.Append("$(document).ready(function() { chart" + Seq + "(); });");
        cstext.Append("function chart" + Seq + "() { const data = {labels:[" + Label + "],datasets: [");
        string[] datas = Data.Split('_');
        string[] legends = Legend.Split(',');
        for (int i = 0; i < datas.Length; i++) {
            cstext.Append("{label:'" + legends[i] + "',data:[" + datas[i] + "],backgroundColor: ['" + BackgroundColor[i] + "'],},");

        }
        cstext.Append("]};");

        cstext.Append("const config = {type: 'bar',data: data,options: {plugins: {legend: {position: 'bottom',labels: {color: '#000000',font: {size: 15}},onClick: null},title: {display: true,text:'" + Title + "',color: '#000000',font: {size: 20}},");
        cstext.Append("datalabels: {color:'#fff',labels: {title: {font: {weight: 'bold'}}}},},responsive: true}};");
        cstext.Append("$('#chart').append(\"<canvas id='myChart" + Seq + "'></canvas>\");");
        cstext.Append("Chart.register(ChartDataLabels);const myChart = new Chart(document.getElementById('myChart" + Seq + "'),config);");
        cstext.Append("} </script>");

        ChartScript = cstext.ToString();
    }
}

public class Pie : Charts {
    public Pie(DataTable dt) {
        GetData(dt);
    }
    // Pie
    public override void GetData(DataTable dt) {
        if (dt.Rows.Count > 0) {
            string label = "";
            string legend = "";
            string data = "";
            for (int i = 1; i < dt.Columns.Count; i++) {
                label += "'"+dt.Columns[i].ColumnName + "',";
                for (int j = 0; j < dt.Rows.Count; j++) {
                    data += dt.Rows[j][i] + ",";
                }
                data = data.TrimEnd(',');
                data += "_";
            }
            for (int i = 0; i < dt.Rows.Count; i++) {
                legend += "'"+ dt.Rows[i][0] + "',";

            }
            label = label.TrimEnd(',');
            data = data.TrimEnd('_');
            legend = legend.TrimEnd(',');

            Label = label;
            Data = data;
            Legend = legend;
            GetScript();
        } else {
            Label = "";
            Data = "";
            Legend = "";
        }
    }
    public override void GetScript() {
        StringBuilder cstext = new StringBuilder();

        cstext.Append("<script type=\"text/javascript\"> ");
        cstext.Append("$(document).ready(function() { chart"+Seq+"(); });");
        string[] datas = Data.Split(',');
        string backgroundcolors = "";
        for (int i = 0; i < datas.Length; i++) {
            backgroundcolors += "'" + BackgroundColor[i] + "',";
        }
        backgroundcolors = backgroundcolors.TrimEnd(',');
        cstext.Append("function chart" + Seq + "() { const data = {labels:[" + Legend + "],datasets: [{data:["+ Data + "],backgroundColor: ["+ backgroundcolors + "],}]};");
        cstext.Append("const config = {type: 'pie',data: data,options: {responsive: true,plugins: {legend: {position: 'bottom',labels: {color: '#000000',font:{size: 15}},onClick: null},title: {display: true,color: '#000000',font: {size: 20},text: '"+Title+"'},");
        cstext.Append("datalabels: {formatter: (value, ctx) => {let sum = 0;let dataArr = ctx.chart.data.datasets[0].data;dataArr.map(data => {sum += Number(data);});let percentage = (value * 100 / sum).toFixed(1) + \"%\";return percentage;},color: '#fff',font:{size: 20}}}},};");
        cstext.Append("$('#chart').append(\"<canvas id='myChart"+Seq+"'></canvas>\");");
        cstext.Append("Chart.register(ChartDataLabels);const myChart = new Chart(document.getElementById('myChart" + Seq + "'),config);");
        cstext.Append("} </script>");

        base.ChartScript = cstext.ToString();
    }
}

public class Stack : Charts {
    public Stack(DataTable dt) {
        GetData(dt);
    }
    public override void GetScript() {
        StringBuilder cstext = new StringBuilder();

        cstext.Append("<script type=\"text/javascript\"> ");
        cstext.Append("$(document).ready(function() { chart" + Seq + "(); });");
        cstext.Append("function chart" + Seq + "() { const data = {labels:[" + Label + "],datasets: [");
        string[] datas = Data.Split('_');
        string[] legends = Legend.Split(',');
        for (int i =0; i < datas.Length;i++) {
            cstext.Append("{label:'"+ legends[i]+"',data:["+datas[i]+"],backgroundColor: ['"+BackgroundColor[i]+"'],},");

        }
        cstext.Append("]};");
        cstext.Append("const config = {type: 'bar',data: data,options: {plugins: {legend: {position: 'bottom',labels: {color: '#000000',font: {size: 15}},onClick: null},title: {display: true,text:'"+Title+"',color: '#000000',font: {size: 20}},");
        cstext.Append("datalabels: {color:'#fff',labels: {title: {font: {weight: 'bold'}}}},},responsive: true,scales: {x: {stacked: true,},y: {stacked: true}}}};");
        cstext.Append("$('#chart').append(\"<canvas id='myChart" + Seq + "'></canvas>\");");
        cstext.Append("Chart.register(ChartDataLabels);const myChart = new Chart(document.getElementById('myChart" + Seq + "'),config);");
        cstext.Append("} </script>");

        base.ChartScript = cstext.ToString();
    }
}

public class Bar : Charts{
    public Bar(DataTable dt) {
        GetData(dt);
    }
    public override void GetScript() {
        StringBuilder cstext = new StringBuilder();

        cstext.Append("<script type=\"text/javascript\"> ");
        cstext.Append("$(document).ready(function() { chart" + Seq + "(); });");
        cstext.Append("function chart" + Seq + "() { const data = {labels:[" + Label + "],datasets: [");
        string[] datas = Data.Split('_');
        string[] legends = Legend.Split(',');
        for (int i = 0; i < datas.Length; i++) {
            cstext.Append("{label:'" + legends[i] + "',data:[" + datas[i] + "],backgroundColor: ['" + BackgroundColor[i] + "'],},");

        }
        cstext.Append("]};");
        cstext.Append("const config = {type: 'bar',data: data,options: {plugins: {legend: {position: 'bottom',labels: {color: '#000000',font: {size: 15}},onClick: null},title: {display: true,text:'" + Title + "',color: '#000000',font: {size: 20}},");
        cstext.Append("datalabels: {color:'#fff',labels: {title: {font: {weight: 'bold'}}}},},responsive: true}};");
        cstext.Append("$('#chart').append(\"<canvas id='myChart" + Seq + "'></canvas>\");");
        cstext.Append("Chart.register(ChartDataLabels);const myChart = new Chart(document.getElementById('myChart" + Seq + "'),config);");
        cstext.Append("} </script>");

        base.ChartScript = cstext.ToString();
    }
}

public class Line : Charts {
    public Line(DataTable dt) {
        GetData(dt);
    }

    public override void GetScript() {
        StringBuilder cstext = new StringBuilder();

        cstext.Append("<script type=\"text/javascript\"> ");
        cstext.Append("$(document).ready(function() { chart" + Seq + "(); });");
        cstext.Append("function chart" + Seq + "() { const data = {labels:[" + Label + "],datasets: [");
        string[] datas = Data.Split('_');
        string[] legends = Legend.Split(',');
        for (int i = 0; i < datas.Length; i++) {
            cstext.Append("{label:'" + legends[i] + "',data:[" + datas[i] + "],borderColor: ['" + BackgroundColor[i] + "'],backgroundColor: ['" + BackgroundColor[i] + "'],},");

        }
        cstext.Append("]};");
        cstext.Append("const config = {type: 'line',data: data,options: {plugins: {legend: {position: 'bottom',labels: {color: '#000000',font: {size: 15}},onClick: null},title: {display: true,text:'" + Title + "',color: '#000000',font: {size: 20}},");
        cstext.Append("datalabels: {color:'#000000',labels: {title: {font: {weight: 'bold',size: 18}}}},},responsive: true}};");
        cstext.Append("$('#chart').append(\"<canvas id='myChart" + Seq + "'></canvas>\");");
        cstext.Append("Chart.register(ChartDataLabels);const myChart = new Chart(document.getElementById('myChart" + Seq + "'),config);");
        cstext.Append("} </script>");

        base.ChartScript = cstext.ToString();
    }
}

