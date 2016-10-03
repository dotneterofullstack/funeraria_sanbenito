(function() {
    angular.module("funerariaApp")

    .controller("listadoSeerviciosCtl", function ($scope, servicios) {
        function init() {
            servicios.get().then(function (response) {
                $scope.servicios = response.data;
            }, function (errorResponse) {

            });
        }

        init();
    })

    .controller("servicioController", function ($scope, servicios) {
        function init() {

        }

        init();
    })

    .controller("nuevoServicioController", function ($scope, $stateParams, $filter, servicios, asesores, clientes, paquetes, frecuenciaAbonos, domicilios) {
        function init() {
            //servicios.init();
            $scope.servicio = {
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
                EstatusCobranza: 2
            };

            $scope.paqueteSeleccionado = {};
            $scope.clienteSeleccionado = {};

            asesores.get().then(function (response) {
                $scope.asesores = response.data;
            }, function (errorResponse) {

            });

            clientes.get().then(function (response) {
                $scope.clientes = response.data;
                if ($stateParams.idCliente)
                {
                    var clientes = $filter('filter')($scope.clientes, { ID: $stateParams.idCliente });
                    if (clientes.length == 1) {
                        $scope.clienteSeleccionado = clientes[0];
                        $scope.servicio.IdCliente = $scope.clienteSeleccionado.ID;
                        $scope.obtenerDomiciliosCliente($scope.clienteSeleccionado.ID);
                    }
                }
            }, function (errorResponse) {

            });

            paquetes.get().then(function (response) {
                $scope.paquetes = response.data;
            }, function (errorResponse) {

            });

            frecuenciaAbonos.get().then(function (response) {
                $scope.frecuencias = response.data;
            }, function (errorResponse) {

            });
        }

        $scope.establecerIdPaquete = function () {
            $scope.servicio.IdPaquete = $scope.paqueteSeleccionado.ID;
            $scope.servicio.Costo = $scope.paqueteSeleccionado.Precio;
        }

        $scope.establecerIdCliente = function () {
            $scope.servicio.IdCliente = $scope.clienteSeleccionado.ID;
            $scope.obtenerDomiciliosCliente($scope.clienteSeleccionado.ID);
        }

        $scope.guardarServicio = function (servicio) {
            var nuevoServicio = angular.copy(servicio);

            servicios.set(nuevoServicio).then(
                function (response) {
                    $scope.fracasoGuardado = false;
                    $scope.exitoGuardado = true;
                    $scope.nuevoId = response.data.ID;
                    init();
                    $scope.frmServicioFunerario.$setPristine();
                }, function (errorResponse) {
                    $scope.exitoGuardado = false;
                    $scope.fracasoGuardado = true;
                    $scope.errorResponse = errorResponse.data;
                    console.log(errorResponse.data.ModelState);
                }
            );
        }

        $scope.obtenerDomiciliosCliente = function (idCliente) {
            domicilios.get(idCliente, 2).then(function (response) {
                $scope.domicilios = response.data;
            }, function (errorResponse) {

            });
        }

        init();
    })

    
})();