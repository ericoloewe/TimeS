timesApp.controller('navbarController', ['$scope', '$rootScope', '$http', function ($scope, $rootScope, $http) {
    $(window).ready(function() {
        if ($rootScope.UsuarioAtual == null) {
            $http({
                method: 'GET',
                url: '/Usuario/UsuarioAtual'
            }).then(function successCallback(response) {
                $rootScope.UsuarioAtual = response.data;
            }, function errorCallback(response) {
                console.log(response);
            });
        }
    });
}]);