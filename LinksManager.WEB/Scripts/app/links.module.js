var LnkApp = angular.module('LnkApp', ['ngRoute', 'LnkControllers']);
LnkApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: 'Links/list.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: 'Links/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'Links/edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: 'Links/delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });

}]);

LnkApp.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
});