angular
    .module('ExpedientProjectApp')
    .controller('ExpedientProjectController', ExpedientProjectController);

ExpedientProjectController.$inject = ['expedientProjectFactory'];

function ExpedientProjectController(expedientProjectFactory) {

    var vm = this;
    vm.title = "Lista de expedientes";
    var id = $('#idExpedent').text();
    vm.getListExpedient = function (id) {
        expedientProjectFactory.getListExpedient(id)
           .then(function (data) {
               var listExpedient = data;
               SeeGridExpedient(listExpedient);
               console.log(data);
           });
    }
    vm.change = function (id) {
        window.location.href = "../../CheckTypes/List/" + id;
    }
    var listExpedient = vm.getListExpedient(id);

    var SeeGridExpedient = function (ListExpedient) {
        vm.mainGridOptions = {
            dataSource: {
                data: ListExpedient
                //type: "data",
                //transport: {
                //    read: 
                //}
            },
            sortable: true,
            selectable: "multiple row",
            filterable: {
                mode: "row"
            },
            dataBound: function (e) { //event handler for "dataBound" event
                console.log("-> Data is bound to the Grid");
            },
            change: function (e, test) { //event handler for "change" event
                var selectedDataItem = e.sender.dataItem(e.sender.select());
                console.log("-> Selected employee: " + selectedDataItem.FirstName + " " + selectedDataItem.LastName);
            },
            columns: [
              { field: "FileExpendient" },
              { field: "IdTypeProcess" },
              { field: "Advance", "title": "%", width: 70, template: "<div style='width: 100%' kendo-Progress-Bar k-value='dataItem.Advance' > </div>" },
              { template: '<button class=\'k-button\' ng-click=\'vm.change(dataItem.IdExpendient)\'><i class="icon-edit"></i>Ir</button>' }
            ],
        };
    }

    

    console.log(vm.IdExpedient);
}

