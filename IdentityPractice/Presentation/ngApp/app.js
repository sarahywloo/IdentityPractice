var IdentityPractice;
(function (IdentityPractice) {
    //define module
    angular.module("IdentityPractice", ['ngRoute', 'ui.bootstrap']);
    //Add the authInterceptor
    angular.module("IdentityPractice").factory('authInterceptor', function ($q, $window, $location) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                var token = $window.localStorage.getItem('token');
                if (token) {
                    config.headers.Authorization = "Bearer " + token;
                }
                return config;
            },
            responseError: function (response) {
                //401 is unauthorized
                if (response.status === 401) {
                    $location.path('/login');
                }
                //return a response or a promise
                return response || $q.when(response);
            }
        };
    });
    //configure module
    angular.module("IdentityPractice")
        .config(function ($routeProvider, $httpProvider) {
        $routeProvider
            .when('/', {
            templateUrl: '/Presentation/ngApp/views/newsFeed.html',
            controller: IdentityPractice.Controllers.NewsFeedController,
            controllerAs: 'controller'
        });
        $routeProvider
            .when('/profile/:username', {
            templateUrl: '/Presentation/ngApp/views/newsFeed.html',
            controller: IdentityPractice.Controllers.ProfileFeedController,
            controllerAs: 'controller'
        });
        $routeProvider
            .when('/register', {
            templateUrl: '/Presentation/ngApp/views/registration.html',
            controller: IdentityPractice.Controllers.AuthController,
            controllerAs: 'controller'
        });
        $routeProvider
            .when('/friends', {
            templateUrl: '/Presentation/ngApp/views/friendsList.html',
            controller: IdentityPractice.Controllers.FriendsController,
            controllerAs: 'controller'
        });
        $httpProvider.interceptors.push('authInterceptor');
        $routeProvider
            .when('/login', {
            templateUrl: '/Presentation/ngApp/views/login.html',
            controller: IdentityPractice.Controllers.AuthController,
            controllerAs: 'controller'
        });
    });
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=app.js.map