(function() {
    angular.module("funerariaApp")
    
    .factory("cargos", function cargosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function() {
                return $http.get(apiUrl + "/cargos");
            },
            
            set: function(cargo) {
                return $http.post(apiUrl + "/cargos", cargo);
            }
        };
    })
})();