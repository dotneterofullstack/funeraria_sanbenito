(function() {
    angular.module("funerariaApp")
    
    .controller("EditarPaqueteCtl", function($scope, $stateParams, paquetes) {
        paquetes.find($stateParams.id).then(function(response){
            $scope.paquete = response.data[0];
        }, function(errorResponse){
            
        });
        
        $scope.guardarPaquete = function(paquete) {
            var nuevoPaquete = angular.copy(paquete);
            
            paquetes.set(nuevoPaquete).then(
                function(response) {
                    $scope.exitoGuardado = true;
                    $scope.nuevoId = $scope.paquete.ID;
                    //inicializarPaquete();
                    $scope.frmPaquete.$setPristine();
                }, function(errorResponse) {
                    $scope.fracasoGuardado = true;
                    $scope.errorResponse = errorResponse.data;
                    console.log(errorResponse.data.ModelState);
                }
            );
        }
    })
    
    .controller("InfoPaqueteCtl", function($scope, $stateParams, paquetes) {
        paquetes.find($stateParams.id).then(function(response){
            $scope.paquete = response.data[0];
        }, function(errorResponse){
            
        });
    })
    
    .controller("listadoPaquetesCtl", function($scope, paquetes) {
        function init() {
            paquetes.get().then(
                function(response) {
                    $scope.paquetes = response.data;
                }, function(errorResponse){
                    console.log(errorResponse);
                }
            );
        }
        
        init();
    })
    
    .controller("NuevoPaqueteCtl", function($scope, paquetes) {      
        function inicializarPaquete() {
            $scope.paquete = {
                ID: 0,
                Descripcion: "",
                Precio: 0.0,
                Comision: 0.0,
                SoloCremacion: false
            };
        }
        
        $scope.guardarPaquete = function(paquete) {
            var nuevoPaquete = angular.copy(paquete);
            
            paquetes.set(nuevoPaquete).then(
                function(response) {
                    $scope.exitoGuardado = true;
                    $scope.nuevoId = response.data.ID;
                    inicializarPaquete();
                    $scope.frmPaquete.$setPristine();
                }, function(errorResponse) {
                    $scope.fracasoGuardado = true;
                    $scope.errorResponse = errorResponse.data;
                    console.log(errorResponse.data.ModelState);
                }
            );
        }
        
        function init() {
            $scope.exitoGuardado = false;
            $scope.fracasoGuardado = false;
            $scope.nuevoId = 0;
            inicializarPaquete();
        }
        
        init();
    })
})();