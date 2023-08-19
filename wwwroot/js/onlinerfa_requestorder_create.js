/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />

$(function(){
    'use strict'
    var requestOrderViewModel;

    function Header(){}
    function Detail(){}

    function RequestOrderViewModel(){}

    requestOrderViewModel = new RequestOrderViewModel();
    ko.applyBindings(requestOrderViewModel, document.getElementById('requestorder'));
})