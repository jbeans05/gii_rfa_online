/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />

$(function(){
    'use strict'
    var userRoleViewModel;

    function UserRole(roleCode, roleName, decription, createdBy, createdTime){
        var self;
        self=this;
        roleCode = ko.observable(roleCode || null);
        roleName = ko.observable(roleName || null);
        decription = ko.observable(decription || null);
        createdBy = ko.observable(createdBy || null);
        createdTime = ko.observable(createdTime || null);
    }

    function UserRoleViewModel(){
        var self;
        self = this;
        
        self.keyword = ko.observable(null);

        self.getRoles = function(){};
        self.Search = function(){
            alert(self.keyword());
        };
        self.Add = function(){};
        self.Save = function(){};
        self.Cancel = function(){};
    }

    userRoleViewModel = new UserRoleViewModel();
    ko.applyBindings(userRoleViewModel, document.getElementById('userrole'))

})