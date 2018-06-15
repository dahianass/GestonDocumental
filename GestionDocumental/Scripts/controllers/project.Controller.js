angular
    .module('projectApp')
    .controller('ProjectCtrl', ProjectCtrl);

function ProjectCtrl() {
    var vm = this;
    vm.title = "Lista de expedientes"
    vm.reedirExpeden = function (id) {
        if (id != 0) {
            window.location.href = "../Expedients/List/" + id;
        } else {
            window.location.href = "Create";
        }
    }
}



