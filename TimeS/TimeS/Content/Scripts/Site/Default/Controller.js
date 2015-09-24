timesApp.controller('navbarController', function ($scope) {
});

timesApp.controller('listUserController',['$scope', 'User', function($scope, User) {
    $scope.users = User.query();
}]);