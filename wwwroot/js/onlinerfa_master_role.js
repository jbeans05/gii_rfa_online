/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />

$(function(){
    'use strict'
    var roleViewModel;

    function Role(roleCode, roleName, description, createdBy, createdTime){
        var self;
        self = this;
        self.roleCode = ko.observable(roleCode || null);
        self.roleName = ko.observable(roleName || null);
        self.description = ko.observable(description || null);
        self.createdBy = ko.observable(createdBy || null);
        self.createdTime = ko.observable(createdTime || null);
        self.isNew = ko.observable(false);
    }

    function RoleViewModel(){
        var self;
        self = this;
        
        self.roles = ko.observableArray([]);
        self.keyword = ko.observable(null);
        self.isAdd = ko.observable(false);

        self.getRoles = function(){
            self.roles.push(new Role('SA','Super Administrator','this role own should be IT and GA','1234567','14-Apr-2023'));
            self.roles.push(new Role('A','Administrator','this role belong to one person of each departement as representative','1234567','14-Apr-2023'));
            self.roles.push(new Role('UHR','User HR','this role is assign to user that resposible to make purchase request or RFA for HR departement','1234567','14-Apr-2023'));
            self.roles.push(new Role('UCC','User CC','this role is assign to user that resposible to make purchase request or RFA for CC departement','1234567','14-Apr-2023'));
            self.roles.push(new Role('UVPC','User VPC','this role is assign to user that resposible to make purchase request or RFA for VPC departement','1234567','14-Apr-2023'));
            self.roles.push(new Role('UKD','User KD','this role is assign to user that resposible to make purchase request or RFA for KD departement','1234567','14-Apr-2023'));
            self.roles.push(new Role('UQC','User QC','this role is assign to user that resposible to make purchase request or RFA for QC departement','1234567','14-Apr-2023'));
            self.roles.push(new Role('UIT','User IT','this role is assign to user that resposible to make purchase request or RFA for IT departement','1234567','14-Apr-2023'));
            self.roles.push(new Role('UIL','User In Land','this role is assign to user that resposible to make purchase request or RFA for KD departement','1234567','14-Apr-2023'));
            self.roles.push(new Role('UTO','	User Transport Patner','this role is assign to user that resposible to make purchase request or RFA for TP departement','1234567','14-Apr-2023'));
            
        };
        self.Search = function(){
            alert(self.keyword());
        };
        self.Add = function(){
            var newRole, isPending;
            isPending = false;
            

            $.each(self.roles(), function(index, item){
                if(item.isNew()){
                    isPending = true;
                };
            });

            if(!!!isPending)
            {
                newRole = new Role();
                newRole.isNew(true);
                self.roles.push(newRole);
                self.isAdd(true);
            }

            
        };
        self.Save = function(e){
            e.isNew(false);
        };
        self.Cancel = function(e){
            self.roles.remove(e);

        };

        
        self.getRoles();
    }

    roleViewModel = new RoleViewModel();
    ko.applyBindings(roleViewModel, document.getElementById('role'))

});