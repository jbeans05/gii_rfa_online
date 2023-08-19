/// <reference path="../lib/jquery/dist/jquery.js" />
/// <reference path="../lib/knockout/knockout-latest.js" />


$(function () {
    'use strict'
    var itemViewModel;
    function Item(itemCode, itemName, brand, desc, supplier, unitPrice, currency, status, createdBy, createdTime) {
        var self;
        self = this;

        self.itemCode = ko.observable(itemCode || null);
        self.itemName = ko.observable(itemName || null);
        self.brand = ko.observable(brand || null);
        self.desc = ko.observable(desc || null);
        self.supplier = ko.observable(supplier || null);
        self.unitPrice = ko.observable(unitPrice || null);
        self.currency = ko.observable(currency || null);
        self.status = ko.observable(status || null);
        self.createdBy = ko.observable(createdBy || null);
        self.createdTime = ko.observable(createdTime || null);

        self.isNew = ko.observable(false);
        self.isDraft = ko.observable(false);
    }
    function ItemViewModel() {
        var self;
        self = this;

        self.keyword = ko.observable("item Code");
        self.items = ko.observableArray([]);
        self.isAdd = ko.observable(false);
        self.fileLocation = ko.observable();

        self.Search = () => { 
            // search actually getting data form databsae 
            
        }
        self.GetItems = () => {
            
            self.items.push(new Item('GII04958904', 'Hard disk', 'Seagate', 'Seagate SSD 512GB', 'PT Mitra Informatika', 900000, 'IDR', 'Active', '12000212', '20-Aug-2021'));
            self.items.push(new Item('GII04958912', 'Memory', 'Sand Disk', 'Sandisk DDR5 PC3200 16GB (8GBx2)', 'PT Mitra Informatika', 960000, 'IDR', 'Active', '12000212', '20-Aug-2021'));
            self.items.push(new Item('GII04958923', 'Monitor', 'Dell', 'Dell 32inch OLED display', 'PT Mitra Informatika', 1900000, 'IDR', 'Active', '12000212', '20-Aug-2021'));
            self.items.push(new Item('GII04958933', 'Laptop', 'Dell', 'Dell XPS 14inch', 'PT Mitra Informatika', 16000000, 'IDR', 'Active', '12000212', '20-Aug-2021'));
            self.items.push(new Item('GII04958957', 'Mouse', 'Logitech', 'Logitech G20', 'PT Mitra Informatika', 250000, 'IDR', 'Active', '12000212', '20-Aug-2021'));
            self.items.push(new Item('GII04958934', 'printer', 'HP', 'HP Laserjet', 'PT Mitra Informatika', 6000000, 'IDR', 'Active', '12000212', '20-Aug-2021'));
        }
        self.Download = () => { }
        self.Add = () => {
            var newItem, isPending;
            isPending = false;
           
            $.each(self.items(), function(index, item){
                if(item.isNew()){
                   isPending = true;                
                }
            })         
          
            // adding new row but previous input not yet finished is forbid 
            // you must adding row one  by one
            if(!!!isPending)
            {
                newItem = new Item();
                newItem.isNew(true);
                self.items.push(newItem);
                self.isAdd(true); 
            }             
        }

        self.PickFile = () => {
             $("#excelItem").trigger();       

        }

        self.Upload = () => { 
            var regexAll = /[^\\]*\.(\w+)$/;
            var pathFile = $("#excelItem").val();
            var ext = pathFile.match(regexAll);

            if(ext[1] !== 'xls' && ext[1] !== 'xlsx' )
            {
                alert('only excel file can be accepted');
            }
        }
        self.Save = () => { }
        self.SaveDraft = (e) => {           
            e.isDraft(true);
            e.isNew(false);        
        }
        self.remove = (e) => {
       
            self.items.pop(e);
        }
        self.Cancel = () => {           
            var cancelData;
            cancelData = this;

            // collecting data tobe delete 
            cancelData.DeleteData = ko.observableArray([]);
            $.each(self.items(), function(index,itm){               
                if(itm.isNew() || itm.isDraft() ){
                   cancelData.DeleteData.push(itm);
                }
            })
            
            self.items.removeAll(cancelData.DeleteData());
            self.isAdd(false);            
        }

        self.GetItems();
    }

    itemViewModel = new ItemViewModel();
    ko.applyBindings(itemViewModel, document.getElementById('items'));
});