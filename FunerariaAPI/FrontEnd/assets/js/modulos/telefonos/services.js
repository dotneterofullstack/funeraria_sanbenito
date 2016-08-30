(function() {
    angular.module("funerariaApp")
    
    .factory("telefonos", function telefonosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function(idPropietario, tipoPropietario) {
                return $http.get(apiUrl + "/telefonos", {
                    params: { 
                        "IdPropietario": idPropietario,
                        "TipoPropietario": tipoPropietario
                    }
                });
            }
        };
    })
})();