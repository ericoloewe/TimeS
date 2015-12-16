var timesApp = angular.module('timesApp', ['ui.router', 'timesServices']);

timesApp.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        .state('inicio', {
            url: '/',
            templateUrl: '/Home/Index'
        })

        // Sobre
        .state('sobre', {
            url: '/sobre',
            templateUrl: '/home/about'
        })
        // Contato
        .state('contato', {
            url: '/contato',
            templateUrl: '/home/contact'
        })
        // Register
        .state('registro', {
            url: '/registro',
            templateUrl: '/Usuario/Register'
        })
        // Login
        .state('login', {
            url: '/login',
            templateUrl: '/Usuario/Login'
        })
        // Users
        .state('usuario', {
            url: '/usuario',
            views: {
                '': {
                    templateUrl: '/Usuario/Ver',
                    controller: 'listarUsuarioController'
                },
                'detalhes@usuario': {
                    templateUrl: '/Usuario/Detalhes'
                },
                'editar@usuario': {
                    templateUrl: '/Usuario/Editar',
                    controller: 'editarUsuarioController'
                },
                'deletar@usuario': {
                    templateUrl: '/Usuario/Deletar',
                    controller: 'deletarUsuarioController'
                },
                'novo@usuario': {
                    templateUrl: '/Usuario/Novo',
                    controller: 'novoUsuarioController'
                }
            }
        })
        // Atividades
        .state('atividade', {
            url: '/atividade',
            views: {
                '': {
                    templateUrl: '/Atividade/Ver',
                    controller: 'listarAtividadeController'
                },
                'editar@atividade': {
                    templateUrl: '/Atividade/Editar',
                    controller: 'editarAtividadeController'
                },
                'deletar@atividade': {
                    templateUrl: '/Atividade/Deletar',
                    controller: 'deletarAtividadeController'
                },
                'nova@atividade': {
                    templateUrl: '/Atividade/Nova',
                    controller: 'novaAtividadeController'
                }
            }
        })
        .state('detalhesAtividade', {
            url: '/detalhes?Id',
            views: {
                '': {
                    templateUrl: '/Atividade/Detalhes',
                    controller: 'detalhesAtividadeController'
                },
                'verTarefas@detalhesAtividade': {
                    templateUrl: '/Tarefa/Ver',
                    controller: 'listarTarefaController'
                },
                'novaTarefa@detalhesAtividade': {
                    templateUrl: '/Tarefa/Nova',
                    controller: 'novaTarefaController'
                },
                'editarTarefa@detalhesAtividade': {
                    templateUrl: '/Tarefa/Editar',
                    controller: 'editarTarefaController'
                },
                'deletarTarefa@detalhesAtividade': {
                    templateUrl: '/Tarefa/deletar',
                    controller: 'deletarTarefaController'
                },
                'detalhesTarefa@detalhesAtividade': {
                    templateUrl: '/Tarefa/Detalhes',
                    controller: 'detalhesTarefaController'
                }
            }
        }).state('detalhesUsuario', {
            url: '/detalhesUsuario',
            views: {
                '': {
                    templateUrl: '/Usuario/DetalhesCompleto',
                    controller: 'detalhesUsuarioController'
                },
                'editarAtividades@detalhesUsuario': {
                    templateUrl: '/Atividade/Editar',
                    controller: 'editarAtividadeController'
                },
                'deletarAtividades@detalhesUsuario': {
                    templateUrl: '/Atividade/Deletar',
                    controller: 'deletarAtividadeController'
                },
                'novaAtividades@detalhesUsuario': {
                    templateUrl: '/Atividade/Nova',
                    controller: 'novaAtividadeController'
                }
            }
        })
        // TipoAtividades
        .state('tipoatividade', {
            url: '/tipoatividade',
            views: {
                '': {
                    templateUrl: '/TipoAtividade/Ver',
                    controller: 'listarTipoAtividadeController'
                },
                'detalhes@tipoatividade': {
                    templateUrl: '/TipoAtividade/Detalhes'
                },
                'editar@tipoatividade': {
                    templateUrl: '/TipoAtividade/Editar',
                    controller: 'editarTipoAtividadeController'
                },
                'deletar@tipoatividade': {
                    templateUrl: '/TipoAtividade/Deletar',
                    controller: 'deletarTipoAtividadeController'
                },
                'nova@tipoatividade': {
                    templateUrl: '/TipoAtividade/Nova',
                    controller: 'novaTipoAtividadeController'
                }
            }
        });

});

var servicoApi = 'http://localhost:1725/';
timesApp.constant('ngServicoApi', {
    servicoApiBaseUrl: servicoApi
});

timesApp.run(function ($rootScope) {
    $rootScope.UsuarioAtual = null;
});