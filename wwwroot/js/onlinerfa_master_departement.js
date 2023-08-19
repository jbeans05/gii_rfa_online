/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />

$(function () {
    'use strict'
    var departementViewModel;

    function Departement(id,deptCode, deptName, description,  isActive, createdBy, createdDate) {
        var self;
        self = this;

        self.id = ko.observable(id||null);
        self.deptCode = ko.observable(deptCode || null);
        self.deptName = ko.observable(deptName || null);
        self.description = ko.observable(description || null);       
        self.createdBy = ko.observable(createdBy || null);
        self.createdDate = ko.observable(createdDate || null);
        self.isActive = ko.observable(isActive || false);  
        self.isNew = ko.observable(false);
        self.isDraft = ko.observable(false);
        self.isEdit = ko.observable(false);

    }

    function DepartementViewModel() {
        var self;
        self = this;

        self.keyword = ko.observable(null);      
        self.isAdd = ko.observable(false);     
        self.departements = ko.observableArray([]);
     

        self.keyword.subscribe((e) => {          
            if (!!e ) {
                self.Search();
            }else
            {
                self.GetDepartement();
            }           
        });     
        
     
        self.GetDepartement = () => {           
            $.ajax({
                url: "/api/Departement",
                type: 'GET',
                success: function (result) {                  
                    var result = ko.utils.arrayMap(result, function (item) {
                        return new Departement(
                            item.id,
                            item.deptCode,
                            item.deptName,
                            item.description,                           
                            item.isActive,
                            item.createdBy,
                            item.createdDate
                        )
                    });
                    self.departements(result);
                   
                }
            });       
        }

        self.Add = () => {
            var newData, isPending, dtNow, dtMoment;
            dtNow = new Date();
            dtMoment = moment(dtNow);
            isPending = false;         

            $.each(self.departements(), function (index, item) {
                if (item.isNew()) {
                    isPending = true;
                }
            });

            if (!!!isPending) {
                newData = new Departement();
                newData.id(0);
                newData.isNew(true);
                newData.isActive(true);               
                newData.createdBy('202210110001');
                newData.createdDate(dtMoment.format());        
                self.departements.push(newData)
                self.isAdd(true);
            };
        }

        self.Edit = (e) => {
            e.isEdit(true);
            self.isAdd(true);
        }
        

        /*there is two different mean of delete
            1. if data is not yet used then data will be delete permanently 
            2. if data already in used , data will be set as in active 
        */
        self.Delete = (e) => {
            $.ajax({
                url:"/api/Departement/"+e.id(),
                type:"DELETE",
                success: function(data){
                    switch (data) {                     
                        case -1:
                            toastr.error("Delete Failed, the subject not found");
                            break;
                        case -2:
                            toastr.error("Delete Failed, the data already set in active state");
                            break;                   
                        default:
                            toastr.success("Delete Success");
                            self.GetDepartement();
                            break;
                    }                   
                }
            })
        } 

        self.Cancel = () => {
            var slf;
            slf = this;

            slf.deleteData = ko.observableArray([]);
            $.each(self.departements(), function (index, item) {                
                if(item.id() <= 0){
                    // this is new record 
                    self.deleteData.push(item);
                }else{
                    item.isDraft(false);
                    item.isNew(false);
                    item.isEdit(false);
                }             
            })

            self.departements.removeAll(slf.deleteData());
            self.isAdd(false);
        }

        self.Save = () => { 
            var self;
            self = this;
            self.getDraft = ko.observableArray([]);
          
            $.each(self.departements(), function(Index, item){
                if (item.isDraft() || item.isNew() || item.isEdit()) {
                    if (!!!self.validationNewdata(item)) {
                        toastr.info("please correct the data at fist");
                        return;
                    }
                    self.getDraft.push(item);
                }
            });

            if (self.getDraft().length > 0) {
               $.ajax({
                    url:"/api/Departement",
                    type:"POST",
                    contentType:"application/json",
                    data:ko.toJSON(self.getDraft()),
                    success: function(data){
                        if (data === 0) {
                            self.isAdd(false);
                            self.GetDepartement();                          
                            toastr.success("save successed");
                        }else{
                            toastr.error("save failed")          
                        }
                    },
                    error : function(xhr){
                        console.log(xhr);
                    }                  
               })
            }

        }

        /*
            savedraft will be store in browser memory  and the data will be disapear when the browser is refresed
            by this condition you can save multiple data at one time process
        */
        self.SaveDraft = () => {
            var isValid;
            isValid = true;
            $.each(self.departements(), function (index, item) {
                if (item.isNew() || item.isEdit()) {
                    if (self.validationNewdata(item)) {
                        item.isDraft(true);
                        item.isNew(false);
                        item.isEdit(false);
                    } else {
                        isValid = false;
                    }
                }
            });
            if (isValid === false) {
                toastr.info("please check your data");
            }
        }

        self.Search = () => {
            // remove all departement and clear for grid
            self.departements.removeAll();

            $.ajax({
                url: "/api/Departement/Search/"+self.keyword(),
                type: 'GET',
                success: function (data) {                                         
                    var result = ko.utils.arrayMap(data, function (item) {
                        return new Departement(
                            item.id,
                            item.deptCode,
                            item.deptName,
                            item.description,                           
                            item.isActive,
                            item.createdBy,
                            item.createdDate
                            
                        )
                    });                        
                    self.departements(result);
                   
                }
            }); 
            
        }

        /*
            for lock data is use to lock departement list . after lock action , user can't be modified 
            teh data . 
        */
       /* self.LockData = () => {
           var ids = [];

            $.each(self.departements(), function(index , item){
                if(item.isCheck()){
                   ids.push(item.id);
                }
            })
           
            
            $.ajax({
                url:"/api/Departement/Lock",
                type:"PUT",
                data:ko.toJSON(ids),
                contentType: "Application/json",
                success: function(data){
                     switch (data) {
                        case -1:
                            toastr.error("Lock Failed, contact you administrator")
                            break;
                     
                        default:
                            toastr.success("Lock Success");
                            self.refresh();
                            break;

                     }           
                }
            })

         }*/

        /*
            Duplicating data especially for every year changing as long as the departement code and name are same with last year
        */
       /* self.Duplicate = () => {     
          
            if (self.selectedYear() === "Select Year") {
                $("#dpConfirm").modal("hide"); 
                toastr.info("Year must be selected");
                return;
            }
           
            $.ajax({
                url:"/api/Departement/Duplicate/"+self.selectedYear(),
                type:"POST",              
                contentType: "Application/json",
                success: function(data){
                     switch (data) {
                        case -1:                           
                            toastr.error("Duplicate Failed, contact you administrator");                             
                            break;
                        case -2 :
                            toastr.error("Data already exist"); 
                            break;                     
                        default:                           
                            toastr.success("Duplicate Success");
                            self.refresh()
                            break;

                     }    
                     $("#dpConfirm").modal("hide");  
                         
                }
            })

        }
        self.YearSelect = (e) => {
            self.selectedYear(e.item);
            self.Search();
        }*/

        /*
        this function is used to check input value when insert new data
        dept code = mandatory
        dept name = mandatory
        year = mandatory
        */
        self.validationNewdata = (item) => {
            if (!!!item.deptCode() || !!!item.deptName() ) {
                return false;
            } else {
                return true;
            }
        }

       // self.GetYears();
        self.GetDepartement();
    };

    departementViewModel = new DepartementViewModel();
    ko.applyBindings(departementViewModel, document.getElementById('departement'));
})