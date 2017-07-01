var app = angular.module('app', ['ngRoute']);

app.constant('ROUTES', Routes());

app.run(function($rootScope, ROUTES) {
    $rootScope.constants = {
        ROUTES: ROUTES
    };
});

app.config(function ($routeProvider, $locationProvider, ROUTES) {
    $locationProvider.hashPrefix('!');

    $routeProvider
        .when(ROUTES.root, {
            templateUrl: 'templates/root.html?_=' + new Date().getTime().toString(),
            controller: 'rootController'
        })
        .when(ROUTES.login,
        {
            templateUrl: 'templates/login.html?_=' + new Date().getTime().toString(),
            controller: 'loginController'
        })
        .when(ROUTES.apps,
        {
            templateUrl: 'templates/root.html?_=' + new Date().getTime().toString(),
            controller: 'rootController'
        })
        .otherwise({
            templateUrl: 'templates/notFound.html'
        });
});

app.config(function($httpProvider) {
    $httpProvider.interceptors.push('responseObserver');
});

app.factory('responseObserver', responseObserver);

app.controller('rootController', rootController);
app.controller('loginController', loginController);