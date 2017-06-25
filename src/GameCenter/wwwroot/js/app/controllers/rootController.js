function rootController($scope, $http, $routeParams, $location) {
    var utils = window.utils;

    $scope.apiBase = "api/root";
    $scope.appsApiBase = "api/application";
    $scope.message = '';
    $scope.appsListVisible = false;
    $scope.appDetailsVisible = false;
    $scope.selectedApplication = undefined;

    $scope.init = function () {
        $http.get($scope.apiBase).then(
            function (response) {
                var data = response.data;
                //console.log(response.data);
                $scope.message = response.data.message;
                $scope.user = response.data.user;
                $scope.applications = data.applications;

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
            $scope.selectedApplication = ad;
            $scope.appDetailsVisible = true;
        }, function (rejectResponce) {
            console.log('reject', rejectResponce);
        })
    }

    $scope.init();
}