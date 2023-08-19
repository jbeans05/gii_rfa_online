/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />

$(function () {
    'use strict'
    var supplierViewModel;

    function Supplier(id, name, phone, address, email, status, action, createdBy, createdDate) {
        var self;
        self = this;

        self.id = ko.observable(id || null);
        self.name = ko.observable(name || null);
        self.phone = ko.observable(phone || null);
        self.address = ko.observable(address || null);
        self.email = ko.observable(email || null);
        self.status = ko.observable(status || null);
        self.action = ko.observable(action || null);
        self.createdBy = ko.observable(createdBy || null);
        self.createdDate = ko.observable(createdDate || null);
        self.isNew = ko.observable(false);
        self.isEdit = ko.observable(false);
        self.isDraft = ko.observable(false);
    }

    function SupplierViewModel() {
        var self;

        self = this;
        self.keyword = ko.observable();
        self.isAdd = ko.observable(false);
        self.suppliers = ko.observableArray([]);
        
       
        self.pageSize = ko.observable(10);
        self.pageIndex = ko.observable(1);
        self.totalPage = ko.observable(0);       

        self.keyword.subscribe((e) => {
            self.GetPagingSupplier();
        });

        /*paging handling
        ====================================================================================*/
      
        self.firstPage = () => {           
            self.pageIndex(1);
            self.GetPagingSupplier();
        };
        self.nextPge =()=> {                     
            if (parseInt(parseInt(self.pageIndex())+1) <= parseInt (self.totalPage())) {                
                self.pageIndex(parseInt(self.pageIndex())+1);
                self.GetPagingSupplier();
            }
        };
        self.previousePage =()=>{                  
            if (parseInt(self.pageIndex() -1 ) >= 1) {                
                self.pageIndex(self.pageIndex() -1 );
                self.GetPagingSupplier();
            }
        };
        self.lastPage=()=>{          
            self.pageIndex(self.totalPage());
            self.GetPagingSupplier();
        };
       

        self.GetTotalRecord = () => {
            var url;   
            if (!!!self.keyword()) {
                url  ="/api/Supplier/totalrecord";
            }else{
                url ="/api/Supplier/totalrecord/"+self.keyword();
            }           
            $.ajax({
                url: url,
                type: 'GET',
                success: function (data) {                    
                    if (data > 0) {      
                        self.totalPage( Math.ceil(parseInt(data)/parseInt(self.pageSize())));
                    } 
                    console.log(url+""+self.totalPage())  ;  
                }
            });
        }

        self.GetPagingSupplier = ()=>{
            var url;
            if (!!!self.keyword()) {
                url = "/api/Supplier/paging/"+self.pageIndex()+"/"+self.pageSize()
            }else
            {
                url = "/api/Supplier/paging/"+self.pageIndex()+"/"+self.pageSize()+"/"+self.keyword()
            }          
            self.suppliers.removeAll();
            $.ajax({
                url: url,
                type: 'GET',
                success: function (result) {
                    var result = ko.utils.arrayMap(result, function (item) {                       
                        return new Supplier(
                            item.id,
                            item.name,
                            item.phone,
                            item.address,
                            item.email,
                            item.isActive,
                            '',
                            item.createdBy,
                            moment(item.createdDate).format('LL')

                        )
                    });
                    self.suppliers(result);

                }
            });
            
            self.GetTotalRecord();
        }
         /*end paging handling */

     
       
        self.Add = () => {
            var newSupplier, isPending, dtNow, dtMoment;
            dtNow = new Date();
            dtMoment = moment(dtNow);
            isPending = false;

            $.each(self.suppliers(), function (index, item) {
                if (item.isNew()) {
                    isPending = true;
                }
            })
            if (!!!isPending) {
                newSupplier = new Supplier();
                newSupplier.id(0);
                newSupplier.action('insert');
                newSupplier.isNew(true);
                newSupplier.createdBy('202210110001');
                newSupplier.createdDate(dtMoment.format());

                self.suppliers.push(newSupplier);
                self.isAdd(true);
            }
        }

       

        self.Save = () => {
            var self;
            self = this;
            self.InsertUpdate = ko.observableArray([]);

            $.each(self.suppliers(), function (index, item) {
                if (item.isEdit() || item.isDraft() || item.isNew()) {
                    if (!!!item.name() || !!!item.phone() || !!!item.address() || !!!item.email()) {
                        toastr.info("please check your input");
                        return;
                    }

                    self.InsertUpdate.push(item);
                }
            });

            if (self.InsertUpdate().length > 0) {
                $.ajax({
                    url: "/api/Supplier",
                    type: "POST",
                    contentType: "application/json",
                    data: ko.toJSON(self.InsertUpdate()),
                    success: function (data) {
                        if (data === 0) {
                            self.isAdd(false);
                            self.GetPagingSupplier();
                            toastr.success("save successed");
                        } else {
                            toastr.error("save failed")
                        }
                    },
                    error: function (xhr) {
                        console.log(xhr);
                    }
                })
            }

        }

        self.SaveDraft = () => {
            $.each(self.suppliers(), (index, item) => {
                if (item.isNew() || item.isEdit()) {
                    item.isDraft(true);
                    item.isNew(false);
                    item.isEdit(false);
                }
            })
        }
        self.Cancel = (e) => {
            self.GetPagingSupplier();
            self.isAdd(false);
        }

        self.DeleteAdd = (e) => {            
            if (e.id() <= 0) {
                self.suppliers.remove(e);
                self.isAdd(false);
            }
        }


        self.rowEvenEdit = (e) => {
            if (e.id() <= 0) {
                e.isDraft(false);
                e.isNew(true);
                e.isEdit(false);
            } else {                
                e.isDraft(false);
                e.isNew(false);
                e.isEdit(true);
                e.action('edit');
                self.isAdd(true);
            }

        }
        self.rowEvenDelete = (e) => {
            var data;
            if (e.id() <= 0) {
                self.suppliers.pop(e);
            }                                 
        }



        self.GetPagingSupplier();       
    }

    supplierViewModel = new SupplierViewModel();
    ko.applyBindings(supplierViewModel, document.getElementById('supplier'))
});