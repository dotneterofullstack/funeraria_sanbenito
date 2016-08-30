(function() {
    angular.module("funerariaApp")
    
    .factory("tiposTelefonos", function tiposTelefonosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function() {
                return $http.get(apiUrl + "/tipostelefonos");
            }
        };
    })
})();