/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />


$(function(){
    'use strict'
    var userViewModel;
    
    function User(employeeId, userName, pass, role, isLock, status, createdBy, createdTime){
        var self;
        self = this;

        employeeId = ko.observable(employeeId || null);
        userName = ko.observable(userName || null);
        pass= ko.observable(pass || null);
        role= ko.observable(role || null);
        isLock= ko.observable(isLock || null);
        status= ko.observable(status || null);
        createdBy= ko.observable(createdBy || null);
        createdTime= ko.observable(createdTime || null);
    }

    function UserViewModel(){
        var self;
        self = this;
        self.userName = ko.observable(null);



        self.GetUsers = function(){};
        self.GetUser = function(){};
        self.AddUser = function(){};
        self.Search = function(){
            alert(self.userName());
        };
        self.Download = function(){};
        self.SaveUser = function(){};
        self.Cancel = function(){};
    }

    userViewModel = new UserViewModel();
    ko.applyBindings(userViewModel, document.getElementById('user'));

})