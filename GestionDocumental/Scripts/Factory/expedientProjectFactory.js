    angular
        .module('ExpedientProjectApp')
        .factory('expedientProjectFactory', expedientProjectFactory);

    expedientProjectFactory.$inject = ['$http'];

    function expedientProjectFactory($http) {

            return {
                getListExpedient: getListExpedient
            };

            function getListExpedient(id) {
                return $http.get('/Expedients/getListExpedient/' + id)
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