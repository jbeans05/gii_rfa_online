/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />


$(function(){
    'use strict'
    var userRoleModelView;
    function UserRole(employeeId, roleCode, status, createdBy, createdTime) {
        var self;
        self = this;

        self.employeeId = ko.observable(employeeId || null); 
        self.roleCode = ko.observable(roleCode || null);
        self.status = ko.observable(status || null);
        self.createdBy = ko.observable(createdBy || null);
        self.createdTime = ko.observable(createdTime || null);
        self.isNew = ko.observable();
        

    }
    function UserRoleViewModel(){
        var self;
        self = this;

        self.keyword = ko.observable();
        self.userRoles = ko.observableArray([])

        self.getUserRoles = () => {
            self.userRoles.push(new UserRole('12121222','UCC','Active','12030922','06 June 2023'))
            self.userRoles.push(new UserRole('34345555','UIT','Active','12030922','06 June 2023'))
            self.userRoles.push(new UserRole('78677865','UIT','Active','12030922','06 June 2023'))
            self.userRoles.push(new UserRole('33345556','UVPC','Active','12030922','06 June 2023'))
            self.userRoles.push(new UserRole('88866555','UVPC','Active','12030922','06 June 2023'))
            self.userRoles.push(new UserRole('55445655','UKD','Active','12030922','06 June 2023'))
            self.userRoles.push(new UserRole('11223333','UTP','Active','12030922','06 June 2023'))
        }
        self.Search = () => {}
        self.Add = () => {}
        self.Save =() => {}
        self.Cancel = () => {}
        self.SaveDraft =(e) => {}
        self.DeleteDraft =(e) => {}

        self.getUserRoles();
    }

    userRoleModelView = new UserRoleViewModel();
    ko.applyBindings(userRoleModelView, document.getElementById('userrole'))
});