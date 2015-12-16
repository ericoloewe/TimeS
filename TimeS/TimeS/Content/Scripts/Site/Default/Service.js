var timesServices = angular.module('timesServices', ['ngResource']);

timesServices.factory('Usuario', ['$resource', 'ngServicoApi',
  function ($resource, ngServicoApi) {
      return $resource(ngServicoApi.servicoApiBaseUrl + 'Usuario/Gerenciador/:Id', { id: "@Id" }, {
          'update': {
              method: 'PUT'
          }
      });
  }]);

timesServices.factory('Atividade', ['$resource', 'ngServicoApi',
  function ($resource, ngServicoApi) {
      return $resource(ngServicoApi.servicoApiBaseUrl + 'Atividade/Gerenciador/:Id', { id: "@Id" }, {
          'update': {
              method: 'PUT'
          }
      });
  }]);

timesServices.factory('TipoAtividade', ['$resource', 'ngServicoApi',
  function ($resource, ngServicoApi) {
      return $resource(ngServicoApi.servicoApiBaseUrl + 'TipoAtividade/Gerenciador/:Id', { id: "@Id" }, {
          'update': {
              method: 'PUT'
          }
      });
  }]);

timesServices.factory('Tarefa', ['$resource', 'ngServicoApi', '$stateParams',
  function ($resource, ngServicoApi, $stateParams) {
      return $resource(ngServicoApi.servicoApiBaseUrl + 'Atividade/:atividadeId/Tarefa/Gerenciador/:Id', { atividadeId: $stateParams.Id, id: "@Id" }, {
          'update': {
              method: 'PUT'
          }
      });
  }]);