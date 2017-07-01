function Routes() {
    return {
        root: '/',
        login: '/login/',
        apps: '/app/:appId'
    };
}
function loginController($scope, $http, $location) {
    $scope.apiBase = "/login";
    $scope.message = '';

    $scope.login = function() {
        //console.log($scope.userName, $scope.password);
        $http.post($scope.apiBase, 
            JSON.stringify({ login: $scope.userName, password: $scope.password }),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(
            function (response) {
                console.log(response);
                var data = response.data
                if (data) {
                    if (!data.result)
                        $scope.message = data.message;
                    else
                        $location.path($scope.constants.ROUTES.root);
                }
            });
    }
}
function rootController($scope, $http, $routeParams, $location) {
    var utils = window.utils;

    $scope.apiBase = "api/root";
    $scope.appsApiBase = "api/application";
    $scope.message = '';
    //$scope.appsListVisible = false;
    //$scope.appDetailsVisible = false;
    $scope.selectedApplication = undefined;

    $scope.init = function () {
        $http.get($scope.apiBase).then(
            function (response) {
                var data = response.data;
                //console.log(response.data);
                $scope.message = response.data.message;
                $scope.user = response.data.user;
                $scope.applications = data.applications;

                $scope.selectedApplication = undefined;

                $scope.appsListVisible = !$routeParams || $routeParams.appId === undefined;
                utils.signalr.init($scope.invokeApp());
            },
            function (rejectResponce) {
                console.log('reject', rejectResponce);
            });
    }

    $scope.getApp = function(appId) {
        $location.path($scope.constants.ROUTES.apps.replace(':appId',appId));
    }

    $scope.invokeApp = function() {
        if (!$routeParams || $routeParams.appId === undefined) {
            return;
        }

        console.log('appId: ' + $routeParams.appId + ", invoke app");

        $http.get($scope.appsApiBase + '/' + $routeParams.appId).then(function (ad) {
            if (ad.data) {
                $scope.selectedApplication = ad.data;
            }
            
        }, function (rejectResponce) {
            console.log('reject', rejectResponce);
        })
    }

    $scope.startApp = function () {
        if (!$scope.selectedApplication)
            return;


    }

    $scope.init();
}
function responseObserver($location, $q, ROUTES) {
    return {
        'responseError': function (errorResponse) {
            switch (errorResponse.status) {
            case 403:
                $location.path(ROUTES.login);
                break;
            case 500:
                alert('Backend Exception');
                break;
            }
            return $q.reject(errorResponse);
        }
    };
}
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