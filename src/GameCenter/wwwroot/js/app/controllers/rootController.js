function rootController($scope, $http, $routeParams, $location) {
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

                $scope.invokeApp();
            });
    }

    $scope.getApp = function(appId) {
        $location.path($scope.constants.ROUTES.apps.replace(':appId',appId));
    }

    $scope.invokeApp = function() {
        if (!$routeParams || $routeParams.appId === undefined)
            return;

        alert("appId: " + $routeParams.appId);
    }

    $scope.init();
}