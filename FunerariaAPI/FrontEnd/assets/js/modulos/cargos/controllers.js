(function() {
    angular.module("funerariaApp")
    
    .controller("listadoCargosCtl", function($scope, cargos) {
        function init() {
            cargos.get().then(
                function(response) {
                    $scope.cargos = response.data;
                }, function(errorResponse){
                    console.log(errorResponse);
                }
            );
        }
        
        init();
    })
    
    .controller("NuevoCargoCtl", function($scope, cargos) {      
        function inicializarCargo() {
            $scope.cargo = {
                ID: 0,
                Nombre: ""
            };
        }
        
        $scope.guardarCargo = function(cargo) {
            var nuevoCargo = angular.copy(cargo);
            
            cargos.set(nuevoCargo).then(
                function(response) {
                    $scope.exitoGuardado = true;
                    $scope.nuevoId = response.data.ID;
                    inicializarCargo();
                    $scope.frmCargo.$setPristine();
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
            inicializarCargo();
        }
        
        init();
    })
})();