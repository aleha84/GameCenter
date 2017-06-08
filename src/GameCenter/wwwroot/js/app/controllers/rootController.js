function rootController($scope, $http, $routeParams, $location) {
    var utils = window.utils;

    $scope.apiBase = "/root";
    $scope.message = '';

    $scope.init = function() {
        $http.get($scope.apiBase).then(
            function (response) {
                var data = response.data;
                //console.log(response.data);
                $scope.message = response.data.message;
                $scope.user = response.data.user;
                $scope.applications = data.applications;

                utils.signalr.init($scope.invokeApp);
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
            console.log('no appId in route params, return');
            return;
        }
            
        console.log('appId: ' + $routeParams.appId + ", invoke app");
        alert("appId: " + $routeParams.appId);
    }

    $scope.init();
}