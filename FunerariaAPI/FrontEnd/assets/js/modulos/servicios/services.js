(function() {
    angular.module("funerariaApp")
    
    .factory("servicios", function servicioFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        var nuevaSolicitudServicio = null;
        
        return {
            init: function() {
                nuevaSolicitudServicio = {
                    Cliente: null,
                    IdDomicilioCobro: 0
                }
            },

            existeCliente: function() {
                return (!nuevaSolicitudServicio);
            },
            
            setCliente: function(cliente) {
                nuevaSolicitudServicio.Cliente = cliente;
            },

            setDomicilioCobro: function(idDomicilio) {
                nuevaSolicitudServicio.IdDomicilioCobro = idDomicilio;
            }
        };
    })
})();