(function() {
    angular.module("funerariaApp")
    
    .factory("domicilios", function domiciliosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function(idPropietario, tipoPropietario) {
                return $http.get(apiUrl + "/domicilios", {
                    params: { 
                        "IdPropietario": idPropietario,
                        "TipoPropietario": tipoPropietario
                    }
                });
            }
        };
    })
})();