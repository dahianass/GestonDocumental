angular
    .module('ExpedientCheckApp')
    .controller('ExpedientCheckController', ExpedientCheckController);

ExpedientCheckController.$inject = ['expedientCheckFactory'];

function ExpedientCheckController(expedientProjectFactory) {

    var vm = this;
    vm.title = "Lista de expedientes";
    var id = $('#idExpedent').text();
    vm.getListExpedient = function (id) {
        expedientProjectFactory.getListExpedientCheck(id)
           .then(function (data) {
               var listExpedient = data;
               SeeGridExpedient(listExpedient);
               console.log(data);
           });
    }
    vm.reedirectDocument = function (id) {
        console.log(id);
        debugger;
    }
    var listExpedient = vm.getListExpedient(id);

    var SeeGridExpedient = function (ListExpedient) {
        vm.mainGridOptions = {
            dataSource: {
                data: ListExpedient
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
              { field: "Name" },
              { field: "Complet" },
              { template: '<button class=\'k-button\' ng-click=\'vm.reedirectDocument(dataItem.idExpedient , dataItem.idCheckType)\'><i class="icon-edit"></i>Ir</button>' }
            ],
        };
    }



    console.log(vm.IdExpedient);
}

