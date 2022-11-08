// 1.使用元件charts.cs
// 後端
Pie pie = new Pie(ds.Tables[2]);
pie.Title = "顧客滿意度問卷回覆統計";
pie.Seq = "3";
pie.GetScript();

Stack stack = new Stack(ds.Tables[1]);
stack.Title = "顧客滿意度問卷回覆統計";
stack.BackgroundColor = new string[] {"#AE57A4", "#8080C0", "#5CADAD"};
stack.Seq = "2";
stack.GetScript();

Line bar= new Line(ds.Tables[1]);
bar.Title = "顧客滿意度問卷回覆統計";
bar.BackgroundColor = new string[] { "#AE57A4", "#8080C0", "#5CADAD" };
bar.Seq = "2";
bar.GetScript();
Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", pie.ChartScript+ stack.ChartScript + bar.ChartScript);

// 前端
<div id="chart" style="width: 75%; margin: auto">
	<%--<canvas id="myChart"></canvas>--%>
</div>