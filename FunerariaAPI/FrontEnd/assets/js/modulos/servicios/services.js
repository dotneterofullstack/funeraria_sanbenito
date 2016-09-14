(function() {
    angular.module("funerariaApp")
    
    .factory("servicios", function servicioFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function () {
                return $http.get(apiUrl + "/ServiciosFunerarios");
            },

            set: function (servicio) {
                return $http.post(apiUrl + "/ServiciosFunerarios", servicio);
            },

            find: function (idServicio) {
                return $http.get(apiUrl + "/ServiciosFunerarios", {
                    params: { "IdPaquete": idServicio }
                });
            },

            delete: function (index) {

            }
        };
    })
})();