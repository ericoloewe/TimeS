var timesServices = angular.module('timesServices', ['ngResource']);

timesServices.factory('User', ['$resource',
  function($resource){
      return $resource('api/accountapi/', {}, {
          query: {method:'GET', params:{}, isArray:true}
      });
  }]);