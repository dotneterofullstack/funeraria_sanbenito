(function() {
    angular.module("funerariaApp")

    .controller("servicioController", function($scope, servicios) {
        function init() {
            servicios.init();
        }

        init();
    })

    .controller("nuevoServicioController", function ($scope, servicios, asesores, clientes, paquetes) {
        function init() {
            servicios.init();

            $scope.asesor = {
                ID: 0,
                IdPaquete: 0,
                IdAsesor: 0,
                IdCliente: 0,
                IdDomicilioCobranza: 0,
                NumeroContrato: '',
                NumeroSolicitud: '',
                Costo: 0,
                IdFrecuenciaAbonos: 0,
                ServicioYaProporcionado: false,
                EstatusCobranza: 0
            };

            asesores.get().then(function (response) {
                $scope.asesores = response.data;
            }, function (errorResponse) {

            });

            clientes.get().then(function (response) {
                $scope.clientes = response.data;
            }, function (errorResponse) {

            });

            paquetes.get().then(function (response) {
                $scope.paquetes = response.data;
            }, function (errorResponse) {

            });
        }

        init();
    })

    .controller("nuevoPaqueteController", function($scope, servicios) {
        function init() {
            
        }

        init();
    })
    
    .controller("nuevoClienteController", function($scope, $state, $filter, estados, municipios, tiposTelefonos, servicios, documentos) {
        function inicializarCliente() {
            $scope.cliente = {
                ID: 0
            };
            $scope.cliente.Domicilios = [];
            $scope.cliente.Telefonos = [];
        }
        
        init = function() {
            inicializarCliente();
            
            $scope.clienteGuardado = servicios.existeCliente();

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
            
            documentos.get().then(function(response) {
                $scope.documentos = response.data;
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
            
            servicios.setCliente(nuevoCliente);
            servicios.setDomicilioCobro($scope.IdDomicilioCobranza);
            $scope.clienteGuardado = true;
            $state.go("servicios.nuevo.paquete");

            // .then(
            //     function(response) {
            //         $scope.exitoGuardado = true;
            //         $scope.nuevoId = response.data.ID;
            //         inicializarCliente();
            //         $scope.frmCliente.$setPristine();
            //     }, function(errorResponse) {
            //         $scope.fracasoGuardado = true;
            //         $scope.errorResponse = errorResponse.data;
            //         console.log(errorResponse.data.ModelState);
            //     }
            // );
        }
        
        init();
    })
})();