/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />


$(function(){
    'use strict'
    var userViewModel;
    
    function User(employeeId, userName, pass, role, isLock, status, createdBy, createdTime){
        var self;
        self = this;

        self.employeeId = ko.observable(employeeId || null);
        self.userName = ko.observable(userName || null);
        self.pass= ko.observable(pass || null);
        self.role= ko.observable(role || null);
        self.isLock= ko.observable(isLock || null);
        self.status= ko.observable(status || null);
        self.createdBy= ko.observable(createdBy || null);
        self.createdTime= ko.observable(createdTime || null);
        self.isNew = ko.observable(false);
        self.isDraft = ko.observable(false);
        self.isEdit = ko.observable(false);
    }

    function UserViewModel(){
        var self;
        self = this;

        self.isAdd = ko.observable(false);
        self.userName = ko.observable(null);
        self.users = ko.observableArray([]);



        self.GetUsers = function(){
            // normally get data from database
            self.users.push(new User('2000119211','Dimas Tri','***************','UCC',0,1,'2000119203','11-Apr-2023'));
            self.users.push(new User('2000119214','Darmanto','***************','UKD',0,1,'2000119203','11-Apr-2023'));
            self.users.push(new User('2000119300','Farid','***************','UQA',0,1,'2000119203','11-Apr-2023'));
            self.users.push(new User('2000119400','Lisnawati','***************','UVPC',0,1,'2000119203','11-Apr-2023'));
        };
        self.GetUser = function(){};
        self.AddUser = function(){
            var isPending, newUser;
            isPending = false;

            $.each(self.users(), function(index,item){
                if(item.isNew()){
                    isPending=true;
                }
            });

            if(!!!isPending){
                newUser = new User();
                newUser.isNew(true);
                self.users.push(newUser);
                self.isAdd(true);
            }
        };
        self.Search = function(){
            alert(self.userName());
        };
        self.Download = function(){};
        self.SaveUser = function(){};
        self.Cancel = function(){
            var slf ;
            slf = this;

            slf.deleteData = ko.observableArray([]);
            $.each(self.users(), function(index, item){
                if(item.isNew() || item.isDraft()){
                    slf.deleteData.push(item);
                }
            })

            self.users.removeAll(slf.deleteData());
            self.isAdd(false);
        };
        self.EditRow = function(e){
            console.log(e);
            e.isEdit(true);
        }


        self.GetUsers();
    }

    userViewModel = new UserViewModel();
    ko.applyBindings(userViewModel, document.getElementById('user'));

})