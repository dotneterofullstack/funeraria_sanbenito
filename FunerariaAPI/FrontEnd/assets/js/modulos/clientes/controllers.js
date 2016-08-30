(function(){
    angular.module("funerariaApp")
    
    .controller("infoClienteController", function($scope, $stateParams, clientes, telefonos, 
            tiposTelefonos, domicilios, municipios) {
        clientes.find($stateParams.idCliente).then(function(response){
            $scope.cliente = response.data[0];
            
            tiposTelefonos.get().then(function(response) {
                $scope.tipostelefonos = response.data;
            }, function(errorResponse) {
                
            });
            
            municipios.get().then(function(response) {
                $scope.todosMunicipios = response.data;
            }, function(errorResponse) {
                
            });
            
            domicilios.get($stateParams.idCliente, 1).then(function(response){
                $scope.cliente.Domicilios = response.data;
            }, function(errorResponse){
                
            });
            
            telefonos.get($stateParams.idCliente, 1).then(function(response){
                $scope.cliente.Telefonos = response.data;
            }, function(errorResponse){
                
            });
            
        }, function(errorResponse){
            
        });
    })
    
    .controller("listadoClientesController", function($scope, clientes) {
        var init = function() {
            clientes.get().then(function(response) {
                $scope.clientes = response.data;
            }, function(errorResponse) {
                
            });
        }
        
        init();
    })
    
    .controller("nuevoClienteController", function($scope, $filter, estados, municipios, tiposTelefonos, clientes) {
        function inicializarCliente() {
            $scope.cliente = {
                ID: 0,
                IdClienteInvita: 0
            };
            $scope.cliente.Domicilios = [];
            $scope.cliente.Telefonos = [];
        }
        
        init = function() {
            inicializarCliente();
            
            clientes.get().then(function(response) {
                $scope.clientes = response.data;
            }, function(errorResponse) {
                
            });
            
            estados.get().then(function(response) {
                $scope.estados = response.data;
            }, function(errorResponse) {
                
            });
            
            municipios.get().then(function(response) {
                $scope.todosMunicipios = response.data;
            }, function(errorResponse) {
                
            });
            
            tiposTelefonos.get().then(function(response) {
                $scope.tipostelefonos = response.data;
            }, function(errorResponse) {
                
            });
        }
        
        $scope.obtenerMunicipios = function(idEstado) {
            $scope.municipios = $filter('filter')($scope.todosMunicipios, {IdEstado: idEstado})
        }
        
        $scope.establecerDomicilioCobranza = function(index) {
            $scope.IdDomicilioCobranza = index;
        }
        
        $scope.agregarDomicilio = function(domicilio) {
            domicilio.ID = 0;
            $scope.cliente.Domicilios.push(domicilio);
            $scope.domicilio = {};
        }
        
        $scope.agregarTelefono = function(telefono) {
            telefono.ID = 0;
            telefono.IdPropietario = 0;
            $scope.cliente.Telefonos.push(telefono);
            $scope.telefono = {};
        }
        
        $scope.eliminaDomicilio = function(index) {
            $scope.cliente.Domicilios.splice(index, 1);
        }
        
        $scope.eliminaTelefono = function(index) {
            $scope.cliente.Telefonos.splice(index, 1);
        }
        
        $scope.guardarCliente = function(cliente) {
            var nuevoCliente = angular.copy(cliente);
            
            clientes.set(nuevoCliente).then(
                function(response) {
                    $scope.fracasoGuardado = false;
                    $scope.exitoGuardado = true;
                    $scope.nuevoId = response.data.ID;
                    inicializarCliente();
                    $scope.frmCliente.$setPristine();
                }, function(errorResponse) {
                    $scope.exitoGuardado = false;
                    $scope.fracasoGuardado = true;
                    $scope.errorResponse = errorResponse.data;
                    console.log(errorResponse.data.ModelState);
                }
            );
        }
        
        init();
    })
})();