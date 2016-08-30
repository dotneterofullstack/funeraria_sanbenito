(function() {
    angular.module("funerariaApp")
    
    .factory("asesores", function asesoresFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            set: function(asesor) {
                return $http.post(apiUrl + "/asesores", asesor);
            },
            
            get: function() {
                return $http.get(apiUrl + "/asesores");
            },
            
            find: function(idAsesor) {
                return $http.get(apiUrl + "/asesores",{
                    params: { "ID": idAsesor }
                });
            }
        };
    })
    
    .factory("relacionDocumentos", function relacionDocumentosFactory($rootScope, $http) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        return {
            get: function(idAsesor) {
                return $http.get(apiUrl + "/RelacionAsesoresDocumentos",{
                    params: { "IdAsesor": idAsesor }
                });
            }
        };
    })
})();