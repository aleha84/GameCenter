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