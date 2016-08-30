(function(){
    angular.module("funerariaApp")
    
    .controller("infoAsesorController", function($scope, $stateParams, asesores, telefonos, 
            tiposTelefonos, domicilios, municipios, documentos, relacionDocumentos, cargos) {
        asesores.find($stateParams.idAsesor).then(function(response){
            $scope.asesor = response.data[0];
            
            documentos.get().then(function(response) {
                $scope.documentos = response.data;
            }, function(errorResponse) {
                
            });

            asesores.get().then(function(response) {
                $scope.asesores = response.data;
            }, function(errorResponse) {
                
            });
            
            cargos.get().then(
                function(response) {
                    $scope.cargos = response.data;
                }, function(errorResponse){
                    console.log(errorResponse);
                }
            );
            
            tiposTelefonos.get().then(function(response) {
                $scope.tipostelefonos = response.data;
            }, function(errorResponse) {
                
            });
            
            municipios.get().then(function(response) {
                $scope.todosMunicipios = response.data;
            }, function(errorResponse) {
                
            });
            
            domicilios.get($stateParams.idAsesor, 1).then(function(response){
                $scope.asesor.Domicilios = response.data;
            }, function(errorResponse){
                
            });
            
            telefonos.get($stateParams.idAsesor, 1).then(function(response){
                $scope.asesor.Telefonos = response.data;
            }, function(errorResponse){
                
            });
            
            relacionDocumentos.get($stateParams.idAsesor).then(function(response) {
                $scope.asesor.RelacionAsesoresDocumentos = response.data;
            }, function(errorResponse) {
                
            });
            
        }, function(errorResponse){
            
        });
    })
    
    .controller("listadoAsesoresController", function($scope, asesores) {
        var init = function() {
            asesores.get().then(function(response) {
                $scope.asesores = response.data;
            }, function(errorResponse) {
                
            });
        }
        
        init();
    })
    
    .controller("nuevoAsesorController", function($scope, $filter, estados, municipios, tiposTelefonos, asesores, documentos, cargos) {
        function inicializarAsesor() {
            $scope.documentosSeleccionados = [ ];
            $scope.asesor = {
                ID: 0,
                IdAsesorInvita: 0
            };
            $scope.asesor.Domicilios = [];
            $scope.asesor.Telefonos = [];
            $scope.asesor.RelacionAsesoresDocumentos = [];
        }
        
        construirRelacionesDocumentos = function(asesor) {
            angular.forEach($scope.documentosSeleccionados, function(rel, idx) {
                var relacion = {
                    ID: 0,
                    IdAsesorInvita: 0,
                    IdDocumento: rel
                };
                
                asesor.RelacionAsesoresDocumentos.push(relacion);
            });
        }
        
        init = function() {
            $scope.documentosSeleccionados = [ ];
            inicializarAsesor();
            
            asesores.get().then(function(response) {
                $scope.asesores = response.data;
            }, function(errorResponse) {
                
            });
            
            cargos.get().then(
                function(response) {
                    $scope.cargos = response.data;
                }, function(errorResponse){
                    console.log(errorResponse);
                }
            );
            
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
            $scope.asesor.Domicilios.push(domicilio);
            $scope.domicilio = {};
        }
        
        $scope.agregarTelefono = function(telefono) {
            telefono.ID = 0;
            telefono.IdPropietario = 0;
            $scope.asesor.Telefonos.push(telefono);
            $scope.telefono = {};
        }
        
        $scope.eliminaDomicilio = function(index) {
            $scope.asesor.Domicilios.splice(index, 1);
        }
        
        $scope.eliminaTelefono = function(index) {
            $scope.asesor.Telefonos.splice(index, 1);
        }
        
        $scope.guardarAsesor = function(asesor) {
            construirRelacionesDocumentos(asesor);
            
            var nuevoAsesor = angular.copy(asesor);
            
            asesores.set(nuevoAsesor).then(
                function(response) {
                    $scope.fracasoGuardado = false;
                    $scope.exitoGuardado = true;
                    $scope.nuevoId = response.data.ID;
                    inicializarAsesor();
                    $scope.frmAsesor.$setPristine();
                }, function(errorResponse) {
                    $scope.asesor.RelacionAsesoresDocumentos = [];
                    $scope.exitoGuardado = false;
                    $scope.fracasoGuardado = true;
                    $scope.errorResponse = errorResponse.data;
                    console.log(errorResponse.data.ModelState);
                }
            );
        }
        
        $scope.cambiarSeleccionDocumento = function(idDocumento) {
            var idx = $scope.documentosSeleccionados.indexOf(idDocumento);
            
            if (idx > -1) {
                $scope.documentosSeleccionados.splice(idx, 1);
            } else {
                $scope.documentosSeleccionados.push(idDocumento);
            }
        }
        
        init();
    })
})();