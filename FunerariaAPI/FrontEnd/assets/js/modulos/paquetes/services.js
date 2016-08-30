(function() {
    angular.module("funerariaApp")
    
    .factory("paquetes", function paquetesFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function() {
                return $http.get(apiUrl + "/paquetesservicios");
            },
            
            set: function(paquete) {
                return $http.post(apiUrl + "/paquetesservicios", paquete);
            },
            
            find: function(idPaquete) {
                return $http.get(apiUrl + "/paquetesservicios",{
                    params: { "IdPaquete": idPaquete }
                });
            },
            
            delete: function(index) {
                
            }
        };
    })
})();