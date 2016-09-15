(function() {
    angular.module("funerariaApp", ["ui.router", 'angular-date-picker-polyfill'])
    
    .config(function($stateProvider, $urlRouterProvider) {
        
        $urlRouterProvider.otherwise("/paquetes");
        
        $stateProvider
            // -- RUTAS PARA MODULO DE PAQUETES FUNERARIOS --
            .state('paquetes', {
                url: "/paquetes",
                abstract: true,
                templateUrl: "assets/partials/paquetes/index.html"
            })
            
            .state('paquetes.listado', {
                url: "",
                templateUrl: "assets/partials/paquetes/listado.html",
                controller: "listadoPaquetesCtl"
            })
            
            .state('paquetes.nuevo', {
                url: "/nuevo",
                templateUrl: "assets/partials/paquetes/agregar.html",
                controller: "NuevoPaqueteCtl"
            })
            
            .state('paquetes.info', {
                url: "/info/{id:int}",
                templateUrl: "assets/partials/paquetes/info.html",
                controller: "InfoPaqueteCtl"
            })
            
            .state('paquetes.editar', {
                url: "/editar/{id:int}",
                templateUrl: "assets/partials/paquetes/editar.html",
                controller: "EditarPaqueteCtl"
            })
            
            // -- RUTAS PARA SERVICIOS FUNERARIOS --

            
            .state('servicios', {
                url: "/servicios",
                abstract: true,
                templateUrl: "assets/partials/servicios/index.html",
                controller: "servicioController"
            })

            .state('servicios.listado', {
                url: "",
                templateUrl: "assets/partials/servicios/listado.html",
                //controller: "listadoPaquetesCtl"
            })
            
            .state('servicios.nuevo', {
                url: "/nuevo",
                templateUrl: "assets/partials/servicios/agregar.html",
                controller: "nuevoServicioController"
            })
            
            //.state('servicios.nuevo.cliente', {
            //    url: "",
            //    templateUrl: "assets/partials/servicios/agregar.cliente.html",
            //    controller: "nuevoClienteController"
            //})

            //.state('servicios.nuevo.paquete', {
            //    url: "",
            //    templateUrl: "assets/partials/servicios/agregar.paquete.html",
            //    controller: "nuevoPaqueteController"
            //})
            
            // -- RUTAS PARA CATALOGO DE ASESORES -- 
            .state('servicios.asesores', {
                url: "/asesores",
                abstract: true,
                templateUrl: "assets/partials/asesores/index.html"
            })
            
            .state('servicios.asesores.nuevo', {
                url: "/nuevo",
                templateUrl: "assets/partials/asesores/agregar.html",
                controller: "nuevoAsesorController"
            })
            
            .state('servicios.asesores.listado', {
                url: "/listado",
                templateUrl: "assets/partials/asesores/listado.html",
                controller: "listadoAsesoresController"
            })
            
            .state('servicios.asesores.info', {
                url: "/info/{idAsesor:int}",
                templateUrl: "assets/partials/asesores/info.html",
                controller: "infoAsesorController"
            })

            // -- RUTAS PARA CATALOGO DE CLIENTES -- 
            .state('servicios.clientes', {
                url: "/clientes",
                abstract: true,
                templateUrl: "assets/partials/clientes/index.html"
            })
            
            .state('servicios.clientes.nuevo', {
                url: "/nuevo",
                templateUrl: "assets/partials/clientes/agregar.html",
                controller: "nuevoClienteController"
            })
            
            .state('servicios.clientes.listado', {
                url: "/listado",
                templateUrl: "assets/partials/clientes/listado.html",
                controller: "listadoClientesController"
            })
            
            .state('servicios.clientes.info', {
                url: "/info/{idCliente:int}",
                templateUrl: "assets/partials/clientes/info.html",
                controller: "infoClienteController"
            })
            
            // -- RUTAS PARA CATALOGO DE CARGOS --
            .state('servicios.cargos', {
                url: "/cargos",
                abstract: true,
                templateUrl: "assets/partials/cargos/index.html"
            })
            
            .state('servicios.cargos.listado', {
                url: "/listado",
                templateUrl: "assets/partials/cargos/listado.html",
                controller: "listadoCargosCtl"
            })
            
            .state('servicios.cargos.nuevo', {
                url: "/nuevo",
                templateUrl: "assets/partials/cargos/agregar.html",
                controller: "NuevoCargoCtl"
            })
    })
    
    .run(function($rootScope) {
        // Crear configuración global
        $rootScope.Configuracion = {
             // RutaApi: "http://192.168.1.68:5000//api/"
            RutaApi: "http://localhost:50038/api/"
        };
    })
    
    .controller('mainController', function ($scope, $state) {
      $scope.$state = $state;
    });
})();