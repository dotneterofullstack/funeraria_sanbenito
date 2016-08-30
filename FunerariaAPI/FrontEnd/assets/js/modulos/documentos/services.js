(function() {
    angular.module("funerariaApp")
    
    .factory("documentos", function documentosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function() {
                return $http.get(apiUrl + "/documentos");
            }
        };
    })
})();