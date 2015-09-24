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
            templateUrl: '/Account/Register'
        })
        // Login
        .state('login', {
            url: '/login',
            templateUrl: '/Account/Login'
        })
        // Users
        .state('user', {
            url: '/user',
            templateUrl: '/Account/Ver'
        })
        // Atividades
        .state('atividades', {
            url: '/atividades',
            templateUrl: '/Atividade/Ver'
        });        

});