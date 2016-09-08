(function () {
    angular.module("funerariaApp")

    .factory("frecuenciaAbonos", function estadosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;

        return {
            get: function () {
                return $http.get(apiUrl + "/frecuenciaAbonos");
            }
        };
    })
})();