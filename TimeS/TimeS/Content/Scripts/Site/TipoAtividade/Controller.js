timesApp.controller('listarTipoAtividadeController', ['$scope', 'TipoAtividade', function ($scope, TipoAtividade) {
    $scope.busca = {};
    $scope.tiposatividades = TipoAtividade.query();
    $scope.ordem = "Nome";

    $scope.EditarTipoAtividade = function (tipoatividade) {
        $scope.EditarTipoAtividadeModel = tipoatividade;
    };
    $scope.DeletarTipoAtividade = function (tipoatividade) {
        $scope.DeletarTipoAtividadeModel = tipoatividade;
    };
    $scope.DetalhesTipoAtividade = function (tipoatividade) {
        $scope.DetalhesTipoAtividadeModel = tipoatividade;
    };
}]);

timesApp.controller('editarTipoAtividadeController', ['$scope', 'TipoAtividade', function ($scope, TipoAtividade) {
    $scope.SalvarTipoAtividade = function () {
        $scope.EditarTipoAtividadeModel.$update()
            .then(function () {
                alert("TipoAtividade Salvo Com Sucesso!");
                $('#editarTipoAtividade').modal('hide');
            }, function () {
                alert("Problemas ao editar tipoatividade :'(");
            });
    }
}]);

timesApp.controller('deletarTipoAtividadeController', ['$scope', 'TipoAtividade', function ($scope, TipoAtividade) {
    $scope.RemoverTipoAtividade = function () {
        $scope.DeletarTipoAtividadeModel.$delete()
            .then(function () {
                alert("Tipo de Atividade Deletado Com Sucesso!");
                $scope.tiposatividades.splice($scope.tiposatividades.indexOf($scope.DeletarTipoAtividadeModel), 1);
                $('#deletarTipoAtividade').modal('hide');
            }, function () {
                alert("Problemas ao deletar tipoatividade :(");
            });
    }
}]);

timesApp.controller('novaTipoAtividadeController', ['$scope', 'TipoAtividade', function ($scope, TipoAtividade) {
    $scope.NovaTipoAtividadeModel = new TipoAtividade;

    $scope.NovaTipoAtividade = function () {
        $scope.NovaTipoAtividadeModel.$save()
            .then(function (tipoatividade) {
                alert("Tipo de Atividade Criado Com Sucesso!");
                $('#novaTipoAtividade').modal('hide');
                $scope.tiposatividades.push(tipoatividade);
            }, function () {
                alert("Problemas ao criar tipoatividade\nProvavelnte o TipoAtividade ja existe!");
            });
    }
}]);