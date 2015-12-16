timesApp.controller('listarUsuarioController', ['$scope', 'Usuario', function ($scope, Usuario) {
    $scope.busca = {};
    $scope.usuarios = Usuario.query();
    $scope.ordem = "Nome";

    $scope.EditarUsuario = function (usuario) {
        $scope.EditarUsuarioModel = usuario;
    };
    $scope.DeletarUsuario = function (usuario) {
        $scope.DeletarUsuarioModel = usuario;
    };
    $scope.DetalhesUsuario = function (usuario) {
        $scope.DetalhesUsuarioModel = usuario;
    };
}]);

timesApp.controller('editarUsuarioController', ['$scope', 'Usuario', function ($scope, Usuario) {
    $scope.SalvarUsuario = function () {
        $scope.EditarUsuarioModel.$update()
            .then(function () {
                alert("Usuario Salvo Com Sucesso!");
                $('#editarUsuario').modal('hide');
            }, function () {
                alert("Problemas ao editar usuario :'(");
            });
    }
}]);

timesApp.controller('deletarUsuarioController', ['$scope', 'Usuario', function ($scope, Usuario) {
    $scope.RemoverUsuario = function () {
        $scope.DeletarUsuarioModel.$delete()
            .then(function () {
                alert("Usuario Deletado Com Sucesso!");
                $scope.usuarios.splice($scope.usuarios.indexOf($scope.DeletarUsuarioModel), 1);
                $('#deletarUsuario').modal('hide');
            }, function () {
                alert("Problemas ao deletar usuario :(");
            });
    }
}]);

timesApp.controller('novoUsuarioController', ['$scope', 'Usuario', function ($scope, Usuario) {
    $scope.NovoUsuarioModel = new Usuario;

    $scope.NovoUsuario = function () {
        $scope.NovoUsuarioModel.Ativo = true;
        $scope.NovoUsuarioModel.$save()
            .then(function (usuario) {
                alert("Usuario Criado Com Sucesso!");
                $('#novoUsuario').modal('hide');
                $scope.usuarios.push(usuario);
            }, function () {
                alert("Problemas ao criar usuario\nProvavelnte o Usuario ja existe!");
            });
    }
}]);

timesApp.controller('detalhesUsuarioController', ['$scope', '$rootScope', 'Usuario', 'Tarefa', function ($scope, $rootScope, Usuario, Tarefa) {
    $scope.busca = {};
    $scope.DetalhesUsuarioModel = Usuario.get({ Id: $rootScope.UsuarioAtual.Id || "" });
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