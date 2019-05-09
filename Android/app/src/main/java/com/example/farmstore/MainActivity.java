package com.example.farmstore;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;

import com.highsoft.highcharts.Common.HIChartsClasses.*;
import com.highsoft.highcharts.Core.HIChartView;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        HIChartView chartView = findViewById(R.id.hc);
        chartView.plugins = new ArrayList<>(Arrays.asList("variable-pie"));

        HIOptions options = new HIOptions();

        HITitle title = new HITitle();
        title.setText("Countries compared by population density and total area.");
        options.setTitle(title);

        HITooltip tooltip = new HITooltip();
        tooltip.setHeaderFormat("");
        tooltip.setPointFormat("<span style=\"color:{point.color}\"></span> <b> {point.name}</b><br/>Area (square km): <b>{point.y}</b><br/>Population density (people per square km): <b>{point.z}</b><br/>");
        options.setTooltip(tooltip);

        HIVariablepie series1 = new HIVariablepie();
        series1.setMinPointSize(10);
        series1.setInnerSize("20%");
        series1.setZMin(0);
        series1.setName("countries");

        HashMap<String, Object> map0 = new HashMap<>();
        map0.put("name", "Spain");
        map0.put("y", 505370);
        map0.put("z", 92.9);

        HashMap<String, Object> map1 = new HashMap<>();
        map1.put("name", "Spain");
        map1.put("y", 505370);
        map1.put("z", 92.9);

        HashMap<String, Object> map2 = new HashMap<>();
        map2.put("name", "France");
        map2.put("y", 551500);
        map2.put("z", 118.7);

        HashMap<String, Object> map3 = new HashMap<>();
        map3.put("name", "Poland");
        map3.put("y", 312685);
        map3.put("z", 124.6);

        HashMap<String, Object> map4 = new HashMap<>();
        map4.put("name", "Czech Republic");
        map4.put("y", 78867);
        map4.put("z", 137.5);

        HashMap<String, Object> map5 = new HashMap<>();
        map5.put("name", "Italy");
        map5.put("y", 301340);
        map5.put("z", 201.8);

        HashMap<String, Object> map6 = new HashMap<>();
        map6.put("name", "Switzerland");
        map6.put("y", 41277);
        map6.put("z", 214.5);

        HashMap<String, Object> map7 = new HashMap<>();
        map7.put("name", "Germany");
        map7.put("y", 357022);
        map7.put("z", 235.6);

        series1.setData(new ArrayList<>(Arrays.asList(map0, map1, map2, map3, map4, map5, map6, map7)));
        List list = new ArrayList<HISeries>();
        list.add(series1);
        options.setSeries((ArrayList<HISeries>) list);

        chartView.setOptions(options);
    }
}
