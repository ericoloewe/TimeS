timesApp.controller('listarAtividadeController', ['$scope', 'Atividade', function ($scope, Atividade) {
    $scope.busca = {};
    $scope.atividades = Atividade.query();
    $scope.ordem = "Nome";

    $scope.EditarAtividade = function (atividade) {
        $scope.EditarAtividadeModel = atividade;
    };
    $scope.DeletarAtividade = function (atividade) {
        $scope.DeletarAtividadeModel = atividade;
    };
    $scope.DetalhesAtividade = function (atividade) {
        $scope.DetalhesAtividadeModel = atividade;
    };
}]);

timesApp.controller('listarAtividadeDoUsuarioController', ['$scope', function ($scope) {
    $scope.busca = {};
    $scope.ordem = "Nome";
}]);

timesApp.controller('editarAtividadeController', ['$scope', 'Atividade', 'TipoAtividade', 'Usuario', function ($scope, Atividade, TipoAtividade, Usuario) {
    $scope.tiposatividades = TipoAtividade.query();
    $scope.usuarios = Usuario.query();

    $scope.SalvarAtividade = function () {
        $scope.EditarAtividadeModel.$update()
            .then(function () {
                alert("Atividade Salvo Com Sucesso!");
                $('#editarAtividade').modal('hide');
            }, function () {
                alert("Problemas ao editar atividade :'(");
            });
    }
}]);

timesApp.controller('deletarAtividadeController', ['$scope', 'Atividade', function ($scope, Atividade) {
    $scope.AtividadeModel = Atividade.get({ Id: $scope.DeletarAtividadeModel.Id || 0 });
    
    $scope.RemoverAtividade = function () {
        $scope.AtividadeModel.$delete()
            .then(function () {
                alert("Atividade Deletado Com Sucesso!");
                $scope.atividades.splice($scope.atividades.indexOf($scope.DeletarAtividadeModel), 1);
                $('#deletarAtividade').modal('hide');
            }, function () {
                alert("Problemas ao deletar atividade :(");
            });
    }
}]);

timesApp.controller('novaAtividadeController', ['$scope', '$rootScope', 'Atividade', 'TipoAtividade', 'Usuario', function ($scope, $rootScope, Atividade, TipoAtividade, Usuario) {
    $scope.NovaAtividadeModel = new Atividade;
    $scope.tiposatividades = TipoAtividade.query();
    $scope.usuarios = Usuario.query();

    $scope.NovaAtividade = function () {
        if ($scope.NovaAtividadeModel.Responsavel_Id === "")
            $scope.NovaAtividadeModel.Responsavel_Id = $rootScope.UsuarioAtual.Id;
        
        $scope.NovaAtividadeModel.Criador_Id = $rootScope.UsuarioAtual.Id;

        $scope.NovaAtividadeModel.$save()
            .then(function (atividade) {
                alert("Atividade Criado Com Sucesso!");
                $('#novaAtividade').modal('hide');
                $scope.atividades.push(atividade);
            }, function () {
                alert("Problemas ao criar atividade\nProvavelnte o Atividade ja existe!");
            });
    }
}]);

timesApp.controller('detalhesAtividadeController', ['$scope', 'ngServicoApi', '$http', '$stateParams', 'Atividade', 'Tarefa', function ($scope, ngServicoApi, $http, $stateParams, Atividade, Tarefa) {
    $scope.TempoTarefa = "";
    $scope.busca = {};
    $scope.DetalhesAtividadeModel = Atividade.get({ Id: $stateParams.Id || 0 });
    $scope.ordem = "Nome";
    $scope.tarefas = Tarefa.query();

    $scope.EditarTarefa = function (tarefa) {
        $scope.EditarTarefaModel = tarefa;
    };
    $scope.DeletarTarefa = function (tarefa) {
        $scope.DeletarTarefaModel = tarefa;
    };
    $scope.DetalhesTarefa = function (tarefa) {
        $scope.DetalhesTarefaModel = tarefa;
    };
    $scope.AddHorasTarefa = function (tarefaId, tempo) {
        $http({
            method: 'POST',
            url: ngServicoApi.servicoApiBaseUrl + 'Atividade/' + $stateParams.Id + '/Tarefa/Gerenciador/' + tarefaId + '/Tempo',
            data: {
                Horas: tempo
            }
        }).then(function successCallback(response) {
            alert("Hora Adicionada Com Sucesso!");
            $scope.DetalhesTarefaModel.Tempo.push(response);
        }, function errorCallback(response) {
            console.log(response);
            alert("Ocorreu um erro ao adicionar hora na Tarefa!");
        });
    };
}]);