timesApp.controller('listarTarefaController', ['$scope', function ($scope) {
    $scope.busca = {};
    $scope.ordem = "Nome";
}]);

timesApp.controller('editarTarefaController', ['$scope', '$http', 'Usuario', 'ngServicoApi', function ($scope, $http, Usuario, ngServicoApi) {
    $scope.usuarios = Usuario.query();
    $http({
        method: 'GET',
        url: ngServicoApi.servicoApiBaseUrl + '/Atividade/0/Tarefa/GetStatus'
    }).then(function successCallback(response) {
        $scope.Status = response.data;
    }, function errorCallback(response) {
        console.log(response);
    });
    $scope.SalvarTarefa = function () {
        $scope.EditarTarefaModel.$update()
            .then(function () {
                alert("Tarefa Salvo Com Sucesso!");
                $('#editarTarefa').modal('hide');
            }, function () {
                alert("Problemas ao editar tarefa :'(");
            });
    }
}]);

timesApp.controller('deletarTarefaController', ['$scope', 'Tarefa', function ($scope, Tarefa) {
    $scope.RemoverTarefa = function () {
        $scope.DeletarTarefaModel.$delete()
            .then(function () {
                alert("Tipo de Tarefa Deletado Com Sucesso!");
                $scope.tarefas.splice($scope.tarefas.indexOf($scope.DeletarTarefaModel), 1);
                $('#deletarTarefa').modal('hide');
            }, function () {
                alert("Problemas ao deletar tarefa :(");
            });
    }
}]);

timesApp.controller('novaTarefaController', ['$scope', '$http', 'Tarefa', 'Usuario', 'ngServicoApi', function ($scope, $http, Tarefa, Usuario, ngServicoApi) {
    $scope.NovaTarefaModel = new Tarefa;
    $scope.usuarios = Usuario.query();
    $http({
        method: 'GET',
        url: ngServicoApi.servicoApiBaseUrl+ '/Atividade/0/Tarefa/GetStatus'
    }).then(function successCallback(response) {
        $scope.Status = response.data;
    }, function errorCallback(response) {
        console.log(response);
    });

    $scope.NovaTarefa = function () {
        $scope.NovaTarefaModel.$save()
            .then(function (tarefa) {
                alert("Tipo de Tarefa Criado Com Sucesso!");
                $('#novaTarefa').modal('hide');
                $scope.tarefas.push([tarefa]);
            }, function () {
                alert("Problemas ao criar tarefa\nProvavelnte o Tarefa ja existe!");
            });
    }
}]);

timesApp.controller('detalhesTarefaController', ['$scope',  function ($scope) {
    //$scope.DetalhesTarefaModel = Tarefa.get({ Id: $stateParams.Id || 0 }, function (tarefa) {
    //    console.log(tarefa);
    //});
}]);