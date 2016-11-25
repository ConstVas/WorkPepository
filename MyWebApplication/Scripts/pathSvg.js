var height = 100;
    width = 1100;
    var data = [];
    for (i = 0; i < 1000; i++) {
        var rnd = Math.floor(Math.random()*100)
        data.push({ x: i, y: rnd })
    }

var line = d3.svg.line()
            .x(function (d) { return d.x; })
            .y(function (d) { return d.y; });
var svg = d3.select("#path").append('svg');
svg.attr("height", height)
    .attr("width", width);
svg.append("path").attr("d", line(data));