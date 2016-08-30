(function() {
    angular.module("funerariaApp")
    
    .factory("clientes", function clientesFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            set: function(cliente) {
                return $http.post(apiUrl + "/clientes", cliente);
            },
            
            get: function() {
                return $http.get(apiUrl + "/clientes");
            },
            
            find: function(idCliente) {
                return $http.get(apiUrl + "/clientes",{
                    params: { "ID": idCliente }
                });
            }
        };
    })
})();