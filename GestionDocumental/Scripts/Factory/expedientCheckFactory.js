angular
    .module('ExpedientCheckApp')
    .factory('expedientCheckFactory', expedientCheckFactory);

expedientCheckFactory.$inject = ['$http'];

function expedientCheckFactory($http) {

    return {
        getListExpedientCheck: getListExpedientCheck
    };

    function getListExpedientCheck(id, idExpedient) {
        return $http.get('/CheckTypes/ListCheckProcess/' + id)
            .then(getAvengersComplete)
            .catch(getAvengersFailed);

        function getAvengersComplete(response) {
            return response.data;
        }

        function getAvengersFailed(error) {
            console.log('XHR Failed for getAvengers.' + error.data);
        }
    }
}