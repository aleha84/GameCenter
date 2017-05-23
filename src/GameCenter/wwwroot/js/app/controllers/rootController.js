function rootController($scope, $http) {
    $scope.apiBase = "/root";
    $scope.message = '';

    $scope.init = function() {
        $http.get($scope.apiBase).then(
            function (response) {
                console.log(response.data);
                $scope.message = response.data.message;
            });
    }

    $scope.init();
}