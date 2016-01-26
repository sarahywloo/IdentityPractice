var IdentityPractice;
(function (IdentityPractice) {
    angular.module("IdentityPractice", ['ngRoute', 'ui.bootstrap'])
        .config(function ($routeProvider) {
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
    });
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=app.js.map