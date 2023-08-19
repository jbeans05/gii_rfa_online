/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />



$(function () {
    'use strict'
    var employeeModelView;
    
    function Employee(id,employeeId, employeeName, isActive, departement, action, createdBy, createdDate){
        var self;
        self = this;

        self.id = ko.observable(id || null);
        self.employeeId = ko.observable(employeeId || null);
        self.employeeName = ko.observable(employeeName || null);
        self.departement = ko.observable(departement || null);
        self.isActive = ko.observable(isActive || false);
        self.action = ko.observable(action || null);
        self.createdBy = ko.observable(createdBy || null);
        self.createdDate = ko.observable(createdDate || null);
        self.isNew = ko.observable(false);
        self.isEdit = ko.observable(false);
        self.isDraft = ko.observable(false);
    }
    function Departement(id, deptCode, deptName, description, year) {
        var self;
        self = this;

        self.id = ko.observable(id||null);
        self.deptCode = ko.observable(deptCode || null);
        self.deptName = ko.observable(deptName || null);
        self.description = ko.observable(description || null);
        self.year = ko.observable(year || null);
    }

    function EmployeeModelView(){
        var self;
        self = this;

        /*this is use for search text box*/
        self.keyword = ko.observable();
        /*this array is used for  */
        self.employees = ko.observableArray([]);
        /*this array is use to display dpartement data */           
        self.departements = ko.observableArray([]);
        /*this is use for storing selcted departement*/
        self.selectedDept = ko.observable();
        /*this is is use for show hide button save and cancel*/
        self.editable = ko.observable(false);

        self.keyword.subscribe(function(e){  
            self.GetPaggingEmployee();                     
        });

        /*paging data */
        self.pageSize = ko.observable(10);
        self.pageIndex = ko.observable(1);
        self.totalPage = ko.observable(0);   

        self.firstPage = () => {           
            self.pageIndex(1);
            self.GetPaggingEmployee();
        };
        self.nextPge =()=> {                     
            if (parseInt(parseInt(self.pageIndex())+1) <= parseInt (self.totalPage())) {                
                self.pageIndex(parseInt(self.pageIndex())+1);
                self.GetPaggingEmployee();
            }
        };
        self.previousePage =()=>{                  
            if (parseInt(self.pageIndex() -1 ) >= 1) {                
                self.pageIndex(self.pageIndex() -1 );
                self.GetPaggingEmployee();
            }
        };
        self.lastPage=()=>{          
            self.pageIndex(self.totalPage());
            self.GetPaggingEmployee();
        };
       

        self.GetTotalRecord = () => {
            var url;   
            if (!!!self.keyword()) {
                url  ="/api/Employee/TotalRecord";              
            }else{
                url ="/api/Employee/TotalRecord/"+self.keyword();              
            }           
            $.ajax({
                url: url,
                type: 'GET',
                success: function (data) {                    
                    if (data > 0) {      
                        self.totalPage( Math.ceil(parseInt(data)/parseInt(self.pageSize())));
                    }      
                }
            });
        }

        self.GetPaggingEmployee = () => {
            var url;
            self.GetTotalRecord();
            self.editable(false);

            if (!!!self.keyword()) {
                url  = "/api/Employee/Paging/"+self.pageIndex()+"/"+self.pageSize();               
            }else
            {
                url  = "/api/Employee/Paging/"+self.pageIndex()+"/"+self.pageSize()+"/"+self.keyword();               
            }            
            $.ajax({
                url: url,
                type: 'GET',
                success: function (data) {                  
                    var result = ko.utils.arrayMap(data, function (item) {
                        return new Employee(
                            item.id,
                            item.employeeId, 
                            item.employeeName, 
                            item.isActive,                            
                            item.departement, 
                            item.action,
                            item.createdBy, 
                            item.createdDate
                        )
                    });
                    if (result != null && result != undefined) {
                        self.employees.removeAll();
                        self.employees(result);  
                    }
                }
            }); 
        }

        /* end paging data */

        self.AddEmployee = () => {
            var self, isPending, dtNow, dtMoment;
            self = this;   
            dtNow = new Date();
            dtMoment = moment(dtNow); 
            isPending = false;       
            $.each(self.employees(), function(index, item){
                if (item.isNew() && !!!item.departement()) {
                   toastr.info("departement must be selected");
                   isPending = true;
                   return;
                }                
            })   
            if (!!!isPending) {
                var empData = new Employee();
                empData.isNew(true);
                empData.isActive(true);
                empData.id(0);
                empData.createdBy('202210110001') 
                empData.createdDate(dtMoment.format());
                empData.action = 'insert';
                self.employees.push(empData);
                self.editable(true);
            }              
        }

        self.SaveEmployee = () => {
            var self;
            self = this;

            self.saveData = ko.observableArray();
            $.each(self.employees(), function(index, item){
                if (item.isEdit() || item.isNew() || item.isDraft()) {
                    self.saveData.push(item);
                }
            });           

            if (self.saveData().length > 0) {
                $.ajax({
                    url:"/api/Employee",
                    type:"POST",
                    contentType:"application/json",
                    data:ko.toJSON(self.saveData()),
                    success: function(data){
                        if (data === 0) {
                            self.editable(false);       
                            self.GetPaggingEmployee();                    
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

        self.cancelEdit =(e)=>{
            e.isEdit(false);
            e.action('')
            self.editable(false);
        }
        self.Edit =(e) => {
            e.isEdit(true);
            e.action('edit')
            self.editable(true);
        }

        self.Delete = (e) => {
        
            if (e.id() <= 0) {
                self.employees.remove(e);
            }else
            {
                $.ajax({
                    url:"/api/employee/"+e.employeeId(),
                    type:"DELETE",
                    success: function(data){
                        switch (data) {                     
                            case -1:
                                toastr.error("Delete Failed, the subject not found");
                                break;
                            case -2:
                                toastr.error("system exception error, please cntact administrator");
                                break;                   
                            case -3:
                                toastr.error("You can't delete the data , currently in use in transaction");
                                break;
                            default:
                                toastr.success("Delete Success");
                                self.GetPaggingEmployee();
                                break;
                        }                   
                    }
                })
            }          
        }

        self.InActive =(e)=> {
            $.ajax({
                url:"/api/employee/"+e.employeeId(),
                type:"PUT",
                success: function(data){
                    switch (data) {                     
                        case -1:
                            toastr.error("Delete Failed, the subject not found");
                            break;
                        case -2:
                            toastr.error("system exception error, please cntact administrator");
                            break; 
                        default:
                            toastr.success("Delete Success");
                            self.GetPaggingEmployee();
                            break;
                    }                   
                }
            })
        }

        self.SaveDraft = (e) => {
            e.isDraft(true);
            e.isNew(false);
            e.isEdit(false);
        }             

        self.remove =(e) => {           
            self.employees.pop(e);
        }

        self.Cancel = () => {
            var self;
            self = this;
            self.cancelData = ko.observableArray([]);
            
            $.each(self.employees(), function(index,item){
                if (item.isEdit() || item.isNew() || item.isDraft()) {
                    self.cancelData.push(item);
                }
            })

            if (self.cancelData().length > 0) {
                self.employees.removeAll(self.cancelData())
            }
            self.editable(false);
        }

        self.GetDepartement = () => {
            $.ajax({
                url: "/api/Departement",
                type: 'GET',
                success: function (data) {                  
                    var result = ko.utils.arrayMap(data, function (item) {
                        return new Departement(
                            item.id,
                            item.deptCode,
                            item.deptName,
                            item.description,
                            item.year                        
                        )
                    });
                    self.departements(result);                   
                }
            });  

        }        

        /*
            handling departement popup selection 
        */
       
       self.selectDepartement = (e) => {
          $.each(self.employees() , function(index, item){                      
            if (item.isNew() || item.isEdit()) {
                item.departement(e);
            }            
          })
          $("#deptSelection").modal("hide");
       }

       // calling function as initial page load       
        self.GetPaggingEmployee();
        self.GetDepartement();
    }

    employeeModelView = new EmployeeModelView();
    ko.applyBindings(employeeModelView, document.getElementById('employee'));

});