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
    });
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=app.js.map