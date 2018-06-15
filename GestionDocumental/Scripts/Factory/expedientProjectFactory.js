    angular
        .module('ExpedientProjectApp')
        .factory('expedientProjectFactory', expedientProjectFactory);

    expedientProjectFactory.$inject = ['$http'];

    function expedientProjectFactory($http) {

            return {
                getListExpedient: getListExpedient
            };

            function getListExpedient() {
                return $http.get('/Expedients/List/1')
                    .then(getAvengersComplete)
                    .catch(getAvengersFailed);

                function getAvengersComplete(response) {
                    return response.data.results;
                }

                function getAvengersFailed(error) {
                    console.log('XHR Failed for getAvengers.' + error.data);
                }
            }
    }