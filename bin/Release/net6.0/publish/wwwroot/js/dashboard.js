/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />
/// <reference path="../lib/chart/chart.js" />



$(function () {
  'use Strict'
  var viewModelDashboard;

  function ViewModelDashboard() {
    var self;
    self = this;




    self.generateChart = function () {
      var ctx, chartSummary;

      ctx = $("#DeptSummary");
      chartSummary = new Chart(ctx,
        {
          type: 'doughnut',
          data: {
            labels: [
              'IT',
              'CC',
              'QC',
              'VPC',
              'In Land',
              'CKD',
              'HR/BS',
              'FA'
            ],
            datasets: [{
              label: 'My First Dataset',
              data: [10, 34, 5, 30, 15, 20, 50, 11],
              backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(54, 162, 235)',
                'rgb(255, 205, 86)',
                'rgb(252, 188, 38)',
                'rgb(38, 252, 245)',
                'rgb(69, 162, 255)',
                'rgb(165, 86, 245)',
                'rgb(250, 10, 210)',
              ],
              hoverOffset: 4
            }]
          }
        });

      chartSummary.update();


    }

    self.gnerateSummaryAll = function () {
      var ctx, chartSummaryAll, labels;
     

      ctx = $("#SummaryAll");
      chartSummaryAll = new Chart(ctx,
        {
          type: 'bar',
          data: {
            labels: ['JAN','FEB','MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC'],
            datasets: [{
              label: 'Total Request per Month',
              data: [10, 34, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0],
              backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
              ],
              borderColor: [
                'rgb(54, 162, 235)'
              ],
              borderWidth: 1
            }]
          }
        });

      chartSummaryAll.update();
    }

    self.gnerateSummaryAll();
    self.generateChart();
  }

  viewModelDashboard = new ViewModelDashboard();
  ko.applyBindings(viewModelDashboard, document.getElementById('dashboard'))

})