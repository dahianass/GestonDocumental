angular
    .module('DocumentCheckApp')
    .factory('documentCheckFactory', documentCheckFactory);

documentCheckFactory.$inject = ['$http'];

function documentCheckFactory($http) {

    return {
        getListDocument: getListDocument

    };

    function getListDocument(id, idExpedient) {
        return $http.get('/DocumentChecks/ListDocumentProcess/', { params: { id: id, IdExpedient: idExpedient } })
            .then(getAvengersComplete)
            .catch(getAvengersFailed);

        function getAvengersComplete(response) {
            return response.data;
        }

        function getAvengersFailed(error) {
            console.log('XHR Failed for getAvengers.' + error.data);
        }

        //$http.post("/DocumentChecks/ListDocumentProcess/", {
        //    params: { id: id, IdExpedient: idExpedient }
        //}).then(getAvengersComplete)
        //    .catch(getAvengersFailed);

        //function getAvengersComplete(response) {
        //    console.log( response.data);
        //    return response.data;
        //}

        //function getAvengersFailed(error) {
        //    console.log('XHR Failed for getAvengers.' + error.data);
        //    return 0;
        //}
    }
}
