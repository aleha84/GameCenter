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