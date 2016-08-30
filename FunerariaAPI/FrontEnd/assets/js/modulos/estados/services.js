(function() {
    angular.module("funerariaApp")
    
    .factory("estados", function estadosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function() {
                return $http.get(apiUrl + "/estados");
            }
        };
    })
    
    .factory("municipios", function municipiosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function() {
                return $http.get(apiUrl + "/municipios");
            },
            
            getByEstado: function(idEstado) {
                return $http.get(apiUrl + "/municipios", {
                    params: { "IdEstado": idEstado }
                });
            }
        };
    })
})();